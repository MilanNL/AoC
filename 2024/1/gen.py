# Converts the input (1.txt) into an array of strings readable by Dabulang
s = str(list(map(lambda x: x[:-1] if '\n' in x else x, open('1.txt').readlines()))).replace("'", '"')

with open('1.dabu', 'r') as f:
    l = f.readlines()

l.insert(0, f'Const l As List[String] = {s};\n')

with open('1.dabu', 'w') as f:
    f.writelines(l)