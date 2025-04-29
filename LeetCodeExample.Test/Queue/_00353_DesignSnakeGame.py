from typing import List
class SnakeGame:

    def __init__(self, width: int, height: int, food: List[List[int]]):
        self.snake = [(0, 0)]
        self.snake_set = {(0,0) : 1}
        self.food = food
        self.foodIndex = 0
        self.width = width
        self.height = height
        self.score = 0
        self.movement = {'U': [-1, 0], 'L': [0, -1], 'R': [0, 1], 'D': [1, 0]}

    def move(self, direction: str) -> int:
        # move head
        newHead = (self.snake[-1][0] + self.movement[direction][0],
                   self.snake[-1][1] + self.movement[direction][1])

        print(f"new loc {newHead}")

        # collision detection
        if newHead[1] < 0 or newHead[1] >= self.width or newHead[0] < 0 or newHead[0] >= self.height:
            return -1

        # Checking if the snake bites itself. We skip the tail since the tail 
        # has moved, we just haven't deleted the old tail yet from the queue.        
        if newHead in self.snake_set and newHead != self.snake[0]:
            return -1

        if self.foodIndex < len(self.food) and self.food[self.foodIndex][0] == newHead[0] and self.food[self.foodIndex][1] == newHead[1]:
            # if on food, increment food index
            self.foodIndex += 1
            self.score += 1
            print("landed on food")
        else:
            # if not on food, remove tail from the board and the queue
            tail = self.snake.pop(0)
            del self.snake_set[tail]
            print(f"popped")

        # append new head to queue
        self.snake.append(newHead)
        # place new head location on board
        self.snake_set[newHead] = 1
        print(f"snake_set {self.snake_set}")
        print(f"snake {self.snake}")
        return self.score

# snakeGame = SnakeGame(3, 2, [[1,2], [0,1]])
# print(snakeGame.move("R")) # return 0
# print(snakeGame.move("D")) # return 0
# print(snakeGame.move("R")) # return 1, snake eats the first piece of food. The second piece of food appears at (0, 1).
# print(snakeGame.move("U")) # return 1
# print(snakeGame.move("L")) # return 2, snake eats the second food. No more food appears.
# print(snakeGame.move("U")) # return -1, game over because snake collides with border

# snakeGame = SnakeGame(3, 3, [[2,0],[0,0],[0,2],[2,2]])

# print(snakeGame.move("D"))
# print(snakeGame.move("D"))
# print(snakeGame.move("R"))
# print(snakeGame.move("U"))
# print(snakeGame.move("U"))
# print(snakeGame.move("L"))
# print(snakeGame.move("D"))
# print(snakeGame.move("R"))
# print(snakeGame.move("R"))
# print(snakeGame.move("U"))
# print(snakeGame.move("L"))
# print(snakeGame.move("D"))

# snakeGame = SnakeGame(2, 1, [[0,1]])

# print(snakeGame.move("R"))
# print(snakeGame.move("R"))

snakeGame = SnakeGame(3, 3, [[0,1],[0,2],[1,2],[2,2],[2,1],[2,0],[1,0]])

print(snakeGame.move("R"))
print(snakeGame.move("R"))
print(snakeGame.move("D"))
print(snakeGame.move("D"))
print(snakeGame.move("L"))
print(snakeGame.move("L"))
print(snakeGame.move("U"))
print(snakeGame.move("U"))
print(snakeGame.move("R"))
print(snakeGame.move("R"))
print(snakeGame.move("D"))
print(snakeGame.move("D"))
print(snakeGame.move("L"))
print(snakeGame.move("L"))
print(snakeGame.move("U"))
print(snakeGame.move("R"))
print(snakeGame.move("U"))
print(snakeGame.move("L"))
print(snakeGame.move("D"))
