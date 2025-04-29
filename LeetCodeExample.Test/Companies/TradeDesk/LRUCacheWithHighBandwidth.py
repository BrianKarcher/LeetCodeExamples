# This needs to accomonodate a VERY busy endpoint that has billions of transactions. We need to be careful around process-wide locks as that
# makes data go through sequentially even if the inner operation is fast.

# This approach uses sharded locks where we split the keys by hash into buckets, then lock the individual bucket.
# For example, we can key.hash % 16 for 16 buckets, or more buckets if we please.
# The bucket count should correlate with the potential thread count.

# We use OrderedDict because it supports LRU Cache and we don't need to implement a doubly linked list ourselves.

# TTL Version with sharding
from collections import OrderedDict
from threading import Lock
import time

class ShardedLRUCacheWithTTL:
    def __init__(self, capacity, num_buckets=16, default_ttl=None):
        self.capacity = capacity
        self.num_buckets = num_buckets
        self.bucket_capacity = capacity // num_buckets + 1
        self.buckets = [OrderedDict() for _ in range(num_buckets)]
        self.locks = [Lock() for _ in range(num_buckets)]
        self.default_ttl = default_ttl  # in seconds

    def _bucket_index(self, key):
        return hash(key) % self.num_buckets

    def _is_expired(self, expires_at):
        return expires_at is not None and time.time() > expires_at

    def get(self, key):
        idx = self._bucket_index(key)
        with self.locks[idx]:
            bucket = self.buckets[idx]
            if key not in bucket:
                return None

            value, expires_at = bucket[key]
            if self._is_expired(expires_at):
                del bucket[key]
                return None

            bucket.move_to_end(key)
            return value

    def put(self, key, value, ttl=None):
        idx = self._bucket_index(key)
        with self.locks[idx]:
            bucket = self.buckets[idx]
            expires_at = time.time() + ttl if ttl is not None else (
                time.time() + self.default_ttl if self.default_ttl else None
            )

            if key in bucket:
                bucket.move_to_end(key)
            bucket[key] = (value, expires_at)

            if len(bucket) > self.bucket_capacity:
                self._evict_expired_or_oldest(bucket)

    def _evict_expired_or_oldest(self, bucket):
        # Evict expired keys first
        expired_keys = [k for k, (_, exp) in bucket.items() if self._is_expired(exp)]
        for k in expired_keys:
            bucket.pop(k)

        # If still over capacity, evict oldest
        while len(bucket) > self.bucket_capacity:
            bucket.popitem(last=False)

    def __repr__(self):
        output = []
        now = time.time()
        for i, bucket in enumerate(self.buckets):
            with self.locks[i]:
                filtered = {
                    k: v[0]
                    for k, v in bucket.items()
                    if not self._is_expired(v[1])
                }
                if filtered:
                    output.append(f"Bucket {i}: {filtered}")
        return "\n".join(output)


# Non-TTL version

from collections import OrderedDict
from threading import Lock
import threading
import hashlib

class ShardedLRUCache:
    def __init__(self, capacity, num_buckets=16):
        self.capacity = capacity
        self.num_buckets = num_buckets
        self.bucket_capacity = capacity // num_buckets + 1
        self.buckets = [OrderedDict() for _ in range(num_buckets)]
        self.locks = [Lock() for _ in range(num_buckets)]

    def _bucket_index(self, key):
        return hash(key) % self.num_buckets

    def get(self, key):
        idx = self._bucket_index(key)
        with self.locks[idx]:
            bucket = self.buckets[idx]
            if key not in bucket:
                return None
            bucket.move_to_end(key)
            return bucket[key]

    def put(self, key, value):
        idx = self._bucket_index(key)
        with self.locks[idx]:
            bucket = self.buckets[idx]
            if key in bucket:
                bucket.move_to_end(key)
            bucket[key] = value
            if len(bucket) > self.bucket_capacity:
                bucket.popitem(last=False)

    def __repr__(self):
        return "\n".join(
            f"Bucket {i}: {dict(bucket)}"
            for i, bucket in enumerate(self.buckets) if bucket
        )