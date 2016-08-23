#时间相关
import calendar
import datetime
import time


def isLeap(year):
    '''
    判断是否是闰年
    :param year:
    :return:
    '''
    return calendar.isleap(year=year)


def date(year,month,day):
    '''
    返回年月日构成的日期
    :param year:
    :param month:
    :param day:
    :return:
    '''
    return datetime.date(year,month,day)

def today():
    '''
    返回今天
    :return:
    '''
    return datetime.date.today()


def time(hour,minute,seconds):
    '''返回时分秒'''
    return time(hour,minute,seconds)

def now():
    '''返回当前时间
    '''
    return datetime.datetime.now()


if __name__ == '__main__':
    print(now())