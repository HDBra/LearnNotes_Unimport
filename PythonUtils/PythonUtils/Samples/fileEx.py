#with�൱��c#��using,�Զ��ͷ���Դ
with open('1.txt','wt') as fileout:
          fileout.write('hello world')

import csv

villains = [['doctor','no'],['rosa','lkess']]
with open('1.csv','wt') as fout:
    csvout = csv.writer(fout)
    csvout.writerows(villains)
    