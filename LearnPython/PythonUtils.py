import sys

# python中字符串是不可变的， python所有一切都是对象， python所有的变量名可以看成void *,  python中 string tuple number是不可更改的，每次操作实际上创建一个新的对象
# python传值或者传参可以认为是void*传值

# python中能够改变变量作用域的代码段 def class lamda
# if/elif/else with try/except/finally while/for 并不能改变变量作用域，即代码块中的变量实际上是函数作用域，可以在外部访问
# 变量的搜索路径： 本地变量>全局变量

#默认参数定义在最后，命名参数调用时也放到最后
# 可选默认参数不要使用Mutable类型变量，None除外，然后在函数中判断是None，进行初始化，The problem is that each default value is evaluated
# when the function is defined—i.e., usually when the module is loaded—and the
# default values become attributes of the function object. So if a default value is a mutable
# object, and you change it, the change will affect every future call of the function.
# *arg 捕获所有的位置参数，它是tuple类型，它之前可以有其它的位置参数， **kwargs捕获所有的命名参数，它定义在*arg之后，它是dict类型
# del 删除了一个引用，当所有的引用都消失了，才会被GC

# Weak reference 弱引用 ， 弱引用不增加计数，如果对象被回收，返回None,否则返回对象。

#以下被认为是False, 除此之外是True
#boolean False
#null None
#zero integer 0
#zero float 0.0
#empty string ''
#empty list []
#empty tuple ()
#empty dict {}
#empty set set()


if __name__ == "__main__":
    # 第一个参数是文件路径本身，接下来是具体参数
    print(sys.argv[0])


