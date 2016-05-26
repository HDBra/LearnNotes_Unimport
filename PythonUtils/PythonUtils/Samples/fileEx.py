#with相当于c#的using,自动释放资源
with open('1.txt','wt') as fileout:
          fileout.write('hello world')

import csv

villains = [['doctor','no'],['rosa','lkess']]
with open('1.csv','wt') as fout:
    csvout = csv.writer(fout)
    csvout.writerows(villains)
    