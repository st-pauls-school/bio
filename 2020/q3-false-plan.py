

def generate(p,q,r):
    q += 1
    letters = [ chr(ord('A')+i) for i in range(p)]
    values = letters[:]
    for outer in range(1,r):
        newvalues = []
        for v in values:
            for l in letters:
                candidate = v+l
                if len(candidate) >= q:
                    if candidate [-q:] == candidate [-1]*q:
                        continue
                newvalues.append(candidate)
        values = newvalues
    return (values)
            
def enumerate(p,q,r):
    if q >= r: 
        return p**r
    return sum([enumerate(p,q,r-(i+1)) for i in range(q)]) * (p-1)

for i in range(1,13):
    e = enumerate(11,12,i) 
    print(e, e % 11 == 0)

print(generate(11,5,12))