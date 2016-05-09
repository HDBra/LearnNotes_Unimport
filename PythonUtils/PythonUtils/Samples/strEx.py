#�����ַ���
s1 = '''when the door open
i see  mary
'''

s2 = """when the door open
i see  mary"""

s2 += str(12)
#�ظ��ַ���
s2 = "hello"*4
#��Ƭ  s[start:end:step] startĬ��Ϊ1 endĬ��Ϊ�ַ������� stepĬ��Ϊ1 ���stepΪ������������
s2[:]
s2[1:]
s2[:-1]#���������һ��
s2[1:-1]#���������һ��
s2[1:-1:2]#2ָ����step
s2[::-1]#����

len(s2)#��ȡ����
s2.split()
','.join(['hello','world'])

#tuple是不可修改的
empty_tuple = ()
#字典
empty_dict={}
#set
empty_set = set()
setEx = {1,3,5,7}