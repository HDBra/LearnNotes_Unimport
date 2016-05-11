#�쳣����
short_list = [1,2,3]
position = 5
try:
    short_list[position]
except:
    print('exception')



try:
    short_list[position]
except IndexError as err:
    print('bad index')
except Exception as other:
    print('error happen')