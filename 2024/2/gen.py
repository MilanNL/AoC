# Converts the input (2.txt) into an array of strings readable by Dabulang
# and prepends this line to the 2.dabu
s = str(list(map(lambda x: x[:-1] if '\n' in x else x, open('2.txt').readlines()))).replace("'", '"')

with open('2.dabu', 'r') as f:
    l = f.readlines()

l.insert(0, f'Const l As List[String] = {s};\n')

with open('2.dabu', 'w') as f:
    f.writelines(l)