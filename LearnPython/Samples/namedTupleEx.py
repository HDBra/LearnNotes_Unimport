from collections import namedtuple

City = namedtuple('City','name country population')
city = City('北京','中国',10000)

print(city,city.name)