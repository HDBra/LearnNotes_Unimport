# Thread辅助类

import threading
import queue
import _thread

# 由于GIL的存在，即python解释器进程同时只能有一个线程执行，多线程不能提高cpu限制的性能，可以提高IO限制的性能



def threadAction(action,args):
    '''
    创建一个线程，并启动
    :param action:
    :param args:
    :return:
    '''
    t = threading.Thread(target=action,args=args)
    t.start()


def threadCall(action,args):
    '''
    创建一个线程并启动
    :param action:
    :param args:
    :return:
    '''
    thequeue = queue.Queue() #多线程安全的队列
    thread = threading.Thread(target=action,args=(thequeue,))
    thread.start()

def allocLock():
    '''
    分配锁
    :return:
    '''
    lock = _thread.allocate_lock()