class StringUtils(object):
    """description of class"""
    
    @staticmethod
    def encode(str):
        return str.encode('utf-8');

    @staticmethod
    def decode(b):
        return b.decode('utf-8')