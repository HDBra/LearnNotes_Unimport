#file

import os
import shutil
import glob

def openEx(fileName,mode):
    '''文件操作'''
    return open(fileName,mode)


def fileOrDirectoryExists(fileOrDirName):
    '''
    判断文件或者目录是否存在
    :param fileOrDirName: 文件或者目录名
    :return:
    '''

    return os.path.exists(fileOrDirName)

def isFile(fileName):
    """
    判断是否路径指示的是文件
    :param fileName:
    :return:
    """
    return os.path.isfile(fileName)

def isDir(path):
    '''
    判断路径是否是目录
    :param path:
    :return:
    '''
    return os.path.isdir(path)


def isAbs(path):
    '''
    判断是否是绝对路径
    :param path:
    :return:
    '''
    return os.path.isabs(path)

def rename(src,dst):
    '''
    重命名文件或者目录
    :param src:
    :param dst:
    :return:
    '''
    os.rename(src,dst)

def abs(path):
    '''
    获取完全路径
    :param path:
    :return:
    '''
    os.path.abspath(path)

def remove(path):
    '''
    删除一个文件
    :param path:
    :return:
    '''
    os.remove(path)

def mkdir(path):
    '''
    创建一个目录
    :param path:
    :return:
    '''
    os.mkdir(path)

def rmdir(path):
    '''
    删除1个路径
    :param path:
    :return:
    '''
    os.rmdir(path)

def copy(srcFile,destFile):
    '''
    将srcFile复制到destFile  实际上也可以操作目录
    :param srcFile:
    :param destFile:
    :return:
    '''
    shutil.copy(srcFile,destFile)

def move(srcFile,destFile):
    '''
    将srcFile移动到destFile 实际上也可以操作目录
    :param srcFile:
    :param destFile:
    :return:
    '''
    shutil.move(srcFile,destFile)

def listDir(path):
    '''
    返回path下的文件或目录
    :param path:
    :return:
    '''
    return os.listdir(path)


def setCurrentDir(path):
    '''
    更改当前目录
    :param path:
    :return:
    '''
    os.chdir(path)

def getCurrentDir():
    '''
    获取当前目录
    :return:
    '''
    return os.getcwd()

def glob(patten="*.txt"):
    '''
    按照模式过滤文件或目录
    :param patten:
    :return:
    '''
    return glob.glob(patten)




if __name__ == '__main__':
    print(os.getcwd())

