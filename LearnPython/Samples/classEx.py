class classEx(object):
    """description of class"""
    pass

class Person():
    '''Person description'''

    def __init__(self):
        pass


class Person2():
    """Person2 description"""
    def __init__(self, name):
        self.name1 = name


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


