class classEx(object):
    """description of class"""
    pass

class Person():
    '''Person description'''

    def __init__(self):
        pass

#看这个实例
class Person2():
    """Person2 description"""
    #静态变量
    staticVar = 1

    def __init__(self, name):
        self.name1 = name #实例变量

    @classmethod
    def clsMethodEx(cls):
        print(Person2.staticVar)

    @staticmethod
    def staticMethodEx():
        print(Person2.staticVar)

#继承
class Car():
    pass


class Yugo(Car):
    pass


class Duck():
    def __init__(self, input_name):
        self.hidden_name = input_name

    def get_name(self):
        print('inside the getter')
        return self.hidden_name

    def set_name(self,input_name):
        print('insidet the setter')
        self.hidden_name = input_name

    name = property(get_name,set_name)

    @classmethod
    def kids(cls):
        print("it has",cls.count,'object')

class Duc():
    def __init__(self, input_name):
        self.hidden_name = input_name

    @property    
    def name(self):
        print('inside the getter')
        return self.hidden_name


    def name(self,input_name):
        print('insidet the setter')

    @classmethod
    def kids(cls):
        print(" class method ")

    @staticmethod
    def test():
        print('test')

from math import hypot

class Vector:
    def __init__(self,x,y):
        self.x = x;
        self.y = y

    def __add__(self, other):
        return Vector(self.x + other.x,self.y+other.y);

    def __repr__(self):
        return "Vector({0},{1})".format(self.x, self.y)

    def  __abs__(self):
        return hypot(self.x,self.y)

    def __bool__(self):
        return bool(abs(self))

    def __add__(self, other):
        x = self.x + other.x
        y = self.y + other.y
        return Vector(x,y)

    def __mul__(self, scalar):
        return Vector(self.x*scalar,self.y*scalar)



