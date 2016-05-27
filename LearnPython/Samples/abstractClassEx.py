import abc


class MediaLoader(metaclass=abc.ABCMeta):
    @abc.abstractmethod
    def play(self):
        pass

    @abc.abstractproperty
    def ext(self):
        pass

    @classmethod
    def __subclasshook__(cls, subclass):
        if cls is MediaLoader:
            attrs = set(dir(subclass))
            if set(cls.__abstractmethods__) <= attrs:
                return True

        return NotImplemented


class Wav(MediaLoader):
    ext = '.oog'

    def play(self):
        print('wav')
