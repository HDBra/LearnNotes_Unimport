# 结构文本处理
# CSV XML Json 文件处理

import csv
import xml.etree.ElementTree
import json



def writeCsv(fileName,data = None):
    '''
    写Csv格式的文件，如果文件存在则覆盖
    :param fileName:
    :param data: 要写的数据，采用  [[],[],......] 格式
    :return:
    '''
    if data is None:
        # 样例说明 数据的格式
        data = [
            ['Doctor','No'],
            ['Rosa','Klebb'],
            ['Mister','Big'],
            ['Auric','Goldfinger']
        ]

    with open(fileName,'wt') as fout:
        csv_writer = csv.writer(fout)
        csv_writer.writerows(data)



def readCsv(fileName):
    '''
    读取csv格式的文件
    :param fileName:
    :return:
    '''
    with open(fileName,'rt') as fin:
        csv_reader = csv.reader(fin)
        data = [row for row in csv_reader]
    return data


def dumpJson(data):
    '''
    将data数据转换为json格式
    :param data:
    :return:
    '''
    return json.dumps(data)


def loadJson(jsonStr):
    '''将json字符串转换为data'''
    return json.loads(jsonStr)



if __name__ == '__main__':
    # 测试模块
    data = ['tom','json']
    print(type(loadJson(dumpJson(data))))
