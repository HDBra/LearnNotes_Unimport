#if实例
week = True
if week:
    print('week')
else:
    print('not week')


#False None 0 0.0 '' [] () {} set()被认为是False
if week:
    print('week')
elif week==True:
    print('week')
else:
    print('not week')


#while
count = 0
while count<5:
    print(count)
    count+=1

rabbits = ['flopsy','Mopsy']

for r in rabbits:
    print(r)


