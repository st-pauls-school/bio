def isPat(s):
    if len(s) == 0:
        return False
    if len(s) == 1:
        return True
    for i in range(1, len(s)):
        first = s[:i]
        second = s[i:]
        if isPat(first[::-1]) and isPat(second[::-1]):
            if min(list(first)) > max(list(second)):
                return True
    return False
def isPatW(s):
    return 'YES' if isPat(s) else 'NO'

def handler(i):
    items = i.split(' ')
    print(isPatW(items[0]))
    print(isPatW(items[1]))
    print(isPatW(items[0]+items[1]))

def partA():
    for i in ["DE C", "A A", "A B", "B A", "AB CD", "BEFCD A", "GEA DBCF", "EFCD GAB", "ECBDFA LKJIHG", "BDIGEF HCA", "JKHGIL ADFEBC"]:
        print(i)
        handler(i)

def partB():
    l = 4
    c = 0
    combos = [""]  
    while len(combos[0]) < l:  
        head = combos.pop(0)
        for j in range(4):
            c = chr(ord('A')+j)
            if c not in head:
                combos.append(head + c)
    return [a for a in combos if isPat(a)]

partA()
print(partB())

