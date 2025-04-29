# Given the radius and the position of the center of a circle, implement the function randPoint which generates a uniform random point inside the circle.

# Implement the Solution class:

# Solution(double radius, double x_center, double y_center) initializes the object with the radius of the circle radius and the position of the center (x_center, y_center).
# randPoint() returns a random point inside the circle. A point on the circumference of the circle is considered to be in the circle. The answer is returned as an array [x, y].

class Solution:

    def __init__(self, radius: float, x_center: float, y_center: float):
        self.radius = radius
        self.x_center = x_center
        self.y_center = y_center

    def randPoint(self) -> List[float]:
        # To make the point uniformly random, I am going to 
        # pick a random angle and random length from the radius
        rndRadians = random.random() * 2 * math.pi
        # The purpose of sqrt is to make the points uniform - add weight to the points on the outer edge.
        # Refer to https://leetcode.com/problems/generate-random-point-in-a-circle/solutions/1113792/generate-random-point-in-a-circle-short-easy-w-explanation-and-diagrams/
        rndRadius = math.sqrt(random.random()) * self.radius
        xOffset = math.cos(rndRadians) * rndRadius
        yOffset = math.sin(rndRadians) * rndRadius
        return [self.x_center + xOffset, self.y_center + yOffset]