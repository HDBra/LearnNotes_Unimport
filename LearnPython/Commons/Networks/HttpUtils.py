# Http相关

import urllib.request


def requestGet(urlStr):
    '''
    使用get请求url
    :param urlStr:
    :return:
    '''

    conn = urllib.request.urlopen(urlStr)
    return conn.read().decode('utf-8')



if (__name__ == '__main__'):
    print(requestGet('http://www.baidu.com'))
