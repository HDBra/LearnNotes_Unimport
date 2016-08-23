# Thread辅助类

import threading
import queue



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
    thequeue = queue.Queue()
    thread = threading.Thread(target=action,args=(thequeue,))
    thread.start()
