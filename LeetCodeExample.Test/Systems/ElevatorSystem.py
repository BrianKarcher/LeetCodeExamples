import threading
import time
import heapq

class Request:
    def __init__(self, floor, direction=None):
        self.floor = floor
        self.direction = direction  # Only for external requests

class Elevator:
    def __init__(self, elevator_id, max_floors):
        self.id = elevator_id
        self.current_floor = 0
        self.direction = "IDLE"  # UP, DOWN, IDLE
        self.status = "IDLE"  # MOVING, IDLE, MAINTENANCE
        self.queue = []  # Min heap for priority handling
        self.lock = threading.Lock()

    def move(self):
        while True:
            time.sleep(1)  # Simulate movement
            with self.lock:
                if self.queue:
                    target_floor = heapq.heappop(self.queue)
                    print(f"Elevator {self.id} moving from {self.current_floor} to {target_floor}")
                    self.current_floor = target_floor
                    if not self.queue:
                        self.status, self.direction = "IDLE", "IDLE"
                else:
                    self.status, self.direction = "IDLE", "IDLE"

    def request_floor(self, floor):
        with self.lock:
            heapq.heappush(self.queue, floor)
            self.status = "MOVING"
            self.direction = "UP" if floor > self.current_floor else "DOWN"

class ElevatorSystem:
    def __init__(self, num_elevators, max_floors):
        self.elevators = [Elevator(i, max_floors) for i in range(num_elevators)]
        self.num_floors = max_floors

        # Start elevator movement threads
        for elevator in self.elevators:
            threading.Thread(target=elevator.move, daemon=True).start()

    def request_elevator(self, floor, direction):
        best_elevator = self.find_best_elevator(floor, direction)
        if best_elevator:
            print(f"Assigning Elevator {best_elevator.id} to floor {floor}")
            best_elevator.request_floor(floor)

    def find_best_elevator(self, floor, direction):
        # Simple strategy: Pick the closest idle elevator or one moving in the right direction
        best_elevator, min_distance = None, float("inf")
        for elevator in self.elevators:
            if elevator.status == "IDLE":
                distance = abs(elevator.current_floor - floor)
                if distance < min_distance:
                    best_elevator, min_distance = elevator, distance
            elif elevator.direction == direction and \
                 ((direction == "UP" and elevator.current_floor < floor) or
                  (direction == "DOWN" and elevator.current_floor > floor)):
                best_elevator = elevator
        return best_elevator

# Simulating the system
elevator_system = ElevatorSystem(num_elevators=3, max_floors=10)

# Simulating requests
elevator_system.request_elevator(3, "UP")
time.sleep(2)
elevator_system.request_elevator(7, "DOWN")
time.sleep(2)
elevator_system.request_elevator(2, "UP")
