class Solution:
    # Best (Modulo)
    def reachingPoints(self, sx: int, sy: int, tx: int, ty: int) -> bool:
        while tx >= sx and ty >= sy:
            if tx == ty:
                break
            elif tx > ty:
                if ty > sy:
                    tx %= ty
                else:
                    return (tx - sx) % ty == 0
            else:
                if tx > sx:
                    ty %= tx
                else:
                    return (ty - sy) % tx == 0
                
        return tx == sx and ty == sy




    # Naive
    def reachingPoints2(self, sx: int, sy: int, tx: int, ty: int) -> bool:
        seen = set()

        def recurse(sx: int, sy: int, tx: int, ty: int) -> bool:
            if (sx, sy) in seen:
                return False
            if sx == tx and sy == ty:
                return True
            if sx > tx or sy > ty:
                return False
            seen.add((sx, sy))
            if recurse(sx + sy, sy, tx, ty):
                return True
            if recurse(sx, sx + sy, tx, ty):
                return True
            return False
        return recurse(sx, sy, tx, ty)