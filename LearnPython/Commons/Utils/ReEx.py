#正则表达式
import re

def match(pattern,str):
    '''字符串匹配'''
    return re.findall(pattern,str)