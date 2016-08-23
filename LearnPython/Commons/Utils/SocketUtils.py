# socket 帮助类

import socket

def udpServer(ip,port):
    '''
    构建一个udp服务器
    :param ip:
    :param port:
    :return:
    '''
    server = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
    server.bind((ip,port))
    max_size = 4096
    (data,client) = server.recvfrom(max_size)
    sendStr = ''
    server.sendto(sendStr.encode())
    server.close()


def tcpSend():
    '''
    tcp客户端
    :return:
    '''
    address = ('127.0.0.1',6789)
    client = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    client.connect(address)
    client.sendall("".encode())
    data = client.recv(4096)
    client.close()


def tcpServer():
    '''
    tcp 服务器
    :return:
    '''
    address = ('127.0.0.1',6789)
    max_size = 4096
    server = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    server.bind(address)
    server.listen(1982)
    client,addr = server.accept()
    data = client.recv(max_size)
    client.close()
    server.close()
