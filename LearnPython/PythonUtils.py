import math

class Point:
    'Point'

    def reset(self):
        'reset'
        self.x = 0
        self.y = 0

    def move(self,x,y):
        """dddshs
        sd
        dsssd"""
        self.x = x;
        self.y = y;

    def calculate_distance(self,otherPoint):
        return math.sqrt((self.x - otherPoint.x)**2 + (self.y - otherPoint.y)**2)



point1 = Point()
point2 = Point()
point1.reset()
point2.move(5,0)
print(point2.calculate_distance(point1))
assert (point2.calculate_distance(point1) == point1.calculate_distance(point2))
point1.move(3,4)
print(point1.calculate_distance(point2))
print(point1.calculate_distance(point1))
