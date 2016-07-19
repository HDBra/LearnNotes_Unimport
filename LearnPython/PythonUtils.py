import sys

# python中字符串是不可变的， python所有一切都是对象， python所有的变量名可以看成void *,  python中 string tuple number是不可更改的，每次操作实际上创建一个新的对象
# python传值或者传参可以认为是void*传值

if __name__ == "__main__":
    # 第一个参数是文件路径本身，接下来是具体参数
    print(sys.argv[0])


l = [1,2,3]
print(id(l))
l*=2
print(id(l))