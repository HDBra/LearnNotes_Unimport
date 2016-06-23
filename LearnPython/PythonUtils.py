if __name__ == "__main__":
    pass


coordinates = (33.84,-1)
x,y = coordinates

ids = [('usa','112'),('bra','121'),('esp','121')]

for item in sorted(ids):
    print('%s %s'%item)

for country,_ in ids:
    print(country)