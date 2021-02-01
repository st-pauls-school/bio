
def dressingRaw(target, length=0):
    if target == "A":
        return "A"
    if target == "B":
        return "AA"
    q = [("AB","AA")]
    results = []
    while True:
        d,seq = q.pop(0)
        if d == target:
            results.append(seq)
            if len(seq) > length:
                break
        if len(d) < len(target):
            a = d + chr(ord('A')+len(d))
            q.append((a,seq+"A"))
        if seq[-1] != 'S':
            s = d[1] + d[0] + d[2:] 
            q.append((s,seq+"S"))
            
        if seq[-len(d):] != "R"*(len(d)-1):
            r = d[1:] + d[0]
            q.append((r,seq+"R"))
    if length == 0:
        return results
    return [r for r in results if len(r) == length]

def dressing(target):
    return len(dressingRaw(target)[0])

def partA1():
    print(dressing("ACBD") == 6)
    print(dressing("A") == 1)
    print(dressing("AB") == 2)
    print(dressing("BA") == 3)
    print(dressing("ACB") == 5)
    print(dressing("DCBA") == 8)
    print(dressing("ABCDEFGH") == 8)
    print(dressing("BACDE") == 6)
    print(dressing("AEDBC") == 12)
    print(dressing("BACDEFGH") == 9)
def partA2():
    print(dressing("CFBGAHDE") == 15)
    print(dressing("GADEFBC") == 16)
    print(dressing("GCFBEDA") == 21)
    print(dressing("CHDGABFE") == 23)
    print(dressing("AHGEFDCB") == 27)


def partB():
    l = 5
    c = 0
    combos = [""]  
    while len(combos[0]) < l:  
        head = combos.pop(0)
        for j in range(l):
            c = chr(ord('A')+j)
            if c not in head:
                combos.append(head + c)
    return [a for a in combos if dressing(a) == 6]

#partA1()
#print(partB())

print(4, dressingRaw("DCBA", 8))


#print(6, dressingRaw("FEDCBA", 15))

#print(dressingRaw("GFEDCBA"))
#print(dressingRaw("HGFEDCBA"))

def decrypt(chain):
    result = ""
    current = 0
    while chain != "":
        if chain[0] == 'A':
            result = result + chr(ord('A')+current)
            current += 1
        if chain[0] == 'R':
            result = result[1:] + result[0]
        if chain[0] == 'S':
            result = result[1] + result[0] + result[2:]
        chain = chain[1:]
    return result

# DCBA
print(decrypt('AA AAS RRS'))
print(decrypt('AARAARRS'))

# FEDCBA 15 = 3, 3, 9
print('I', decrypt('AARAARR SAA RRRRS')) 
print('II', decrypt('AAAARR AAS RRSRRS')) 
print('III', decrypt('AA ASA RR AAS RRRRS'))


print('II',  decrypt('AARAARR SAA RRRR SAA RRRRRRS')) #9
print('III', decrypt('AA AAS RR SAA RRRR SAA RRRRRRS')) #27
3. 9. 9. 27, 27 
