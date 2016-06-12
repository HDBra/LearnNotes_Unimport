if __name__ == "__main__":
    pass


colors = ['black','white']
sizes = ['S','M','L']

shirts = [(color,size) for color in colors for size in sizes if color == 'white']

print(shirts)