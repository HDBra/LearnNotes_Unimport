import unittest

# 通过继承TestCase类，覆盖runTest函数也可以使所有的测试样例以test开头的函数来实现测试

class StringTest(unittest.TestCase):
    '''
    测试样例
    '''

    def testStr(self):
        '''
        每个测试样例，必须以test开头
        :param result:
        :return:
        '''
        source = "hello world"
        expect = "HELLO WORLD"
        result = source.upper()
        self.assertEqual(result, expect)

    def testStr2(self):
        '''
        每个测试样例，必须以test开头
        :param result:
        :return:
        '''
        source = "hello world"
        expect = "HELLO WORLD"
        result = source.upper()
        self.assertEqual(result, expect)


    def setUp(self):
        '''
        执行所有的test之前执行的动作
        :return:
        '''
        pass

    def tearDown(self):
        '''
        执行所有的test之后执行的动作
        :return:
        '''
        pass

