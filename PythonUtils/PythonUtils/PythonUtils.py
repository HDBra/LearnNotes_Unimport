import sys
from Removables import report

s = report.get_description()
print(s)
for place in sys.path:
    print(place)