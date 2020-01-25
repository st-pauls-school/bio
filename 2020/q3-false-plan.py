def enumerate(p,q,r):
    if q >= r: 
        return p**r
    return sum([enumerate(p,q,r-(i+1)) for i in range(q)]) * (p-1)

def falseplan(p,q,r,n):
    blocksizes = [enumerate(p,q,x) for x in range(1,r+1)]
    print(blocksizes)
    plan = ""
    location = -1
    alphabet = [chr(ord('A')+i) for i in range(p)]
    n-=1
    while r > 0:
        availableletters =  alphabet[:]
        # special case, if the plan has a string of
        # length q already, there is one fewer choice 
        if len(plan)>=q and plan[-q:] == plan[-1]*q:
            availableletters.remove(plan[-1]) 
        lettersize = (blocksizes[location]//len(availableletters))
        letteroffset = n // lettersize
        plan = plan + availableletters[letteroffset]
        print(plan, n, lettersize, letteroffset, availableletters)
        r -= 1 
        n -= letteroffset * lettersize
        location -= 1
    print(plan)
    return plan


#print(falseplan(1,1,1,1) == "A")
#print(falseplan(1,12,12,1) == "AAAAAAAAAAAA")
#print(falseplan(2,1,8,2) == "BABABABA")
print(falseplan(6,2,8,567890) == "CCADDCFA")
print(falseplan(2,2,12,400) == "BBAABBAABABA")
print(falseplan(8,8,8,16000111) == "HFACCBFG")
print(falseplan(6,2,12,1666111000) == "FFBBFFCCBCFA")
