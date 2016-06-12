#list comprehension
#[expression for item in iterable if condition]
#[]里的list comprehension的变量有自己的作用域
[number for number in range(1,6) if number%2 == 0]


#dictionary comprehension
#{key_expression:value_expression for item in iterable}

#set comprehension
#{expression for item in iterable}

colors = ['black','white']
sizes = ['S','M','L']

shirts = [(color,size) for color in colors for size in sizes if color == 'white']

print(shirts)

#generator expression 是使用listcomps一样的语法，但是用()而不是[]，它是迭代器模式，每次生成一个值
