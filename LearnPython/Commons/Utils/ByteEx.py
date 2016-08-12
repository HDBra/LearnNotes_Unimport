#bytes是不可变的   bytearray是可变的

class ByteEx:
    '''
    Byte辅助类
    '''

    @staticmethod
    def getBytes(str,encoding='utf-8'):
        return bytes(str,encoding)
