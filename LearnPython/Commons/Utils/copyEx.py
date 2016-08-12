import copy


def shallowCopy(obj):
    '''
    浅复制任意对象
    :param obj:
    :return:
    '''
    return copy.copy(obj)


def deepCopy(obj):
    '''
    深复制任意对象

    :param obj:
    :return:
    '''
    return copy.deepcopy(obj)