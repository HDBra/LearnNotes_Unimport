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


