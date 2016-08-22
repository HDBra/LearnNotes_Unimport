# 数据库操作辅助类

import sqlite3


def sqlExecute(sqlStr):
    '''

    :param sqlStr:
    :return:
    '''

    conn = sqlite3.connect("enterprise.db") # 打开数据库
    cursors = conn.cursor()
    # 样例
    # cursors.execute('insert into zoo(critter,count,damages) values(?,?,?)',('weasel',1,2000))
    cursors.execute(sqlStr)
    # 查询语句
    rows = cursors.fetchall()

    # 关闭连接
    cursors.close()
    conn.close()
