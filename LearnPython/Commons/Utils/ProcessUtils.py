import os
import subprocess
import multiprocessing
import time


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


def sleep(seconds):
    '''
    休眠指定时间
    :param seconds:
    :return:
    '''
    time.sleep(seconds)




if __name__ == '__main__':
    print(os.getcwd())