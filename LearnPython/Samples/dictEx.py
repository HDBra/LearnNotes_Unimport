import collections.abc

a = dict(one=1,two=2,three=3)
b={'one':1,'two':2,'three':3}
c = dict(zip(['one','two','three'],[1,2,3]))
print(a==b==c)

dialCodes = [
    (86,'china'),
    (91,'india'),
    (62,'Brazil')
]

country_code = {country:code for code,country in dialCodes}

print(country_code)

country_code = {country:code for country,code in country_code.items() if code <80}
print(country_code)