import os
import subprocess
import multiprocessing
import time
import sys

def getpid():
    '''
    获取当前进程的pid
    :return:
    '''
    return os.getpid()


def getProcessOutput(processStr):
    '''
    执行进程
    :param processStr: 字符串表示的进程
    :return:
    '''
    return subprocess.getoutput(processStr)

def call(processStr):
    '''
    执行进程
    :param processStr:
    :return: 返回进程结束的返回码
    '''
    return subprocess.call(processStr)


def process(action,args):
    '''
    将一个方法转换为进程执行
    :param action:
    :param args:
    :return:
    '''
    p = multiprocessing.Process(action,args)
    p.start()


def system(str):
    '''
    执行字符串命令，实际上是调用系统内置的命令行来执行的
    :param str:
    :return:
    '''
    return os.system(str)

def exit(exitCode):
    '''
    退出进程
    :param exitCode:
    :return:
    '''
    sys.exit(exitCode)


def sleep(seconds):
    '''
    休眠指定时间
    :param seconds:
    :return:
    '''
    time.sleep(seconds)

def environment():
    '''
    获取环境变量
    '''
    return os.environ




if __name__ == '__main__':
    print(os.getcwd())