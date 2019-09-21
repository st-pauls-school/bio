def primes(ubound):
    rv = [2]
    candidates = [x for x in range(3,ubound+1,2)]
    candidate = 2
    while candidate < ubound**0.5:
        candidate = candidates[0]        
        rv.append(candidate)
        candidates = list(filter(lambda x: x % candidate != 0, candidates)) 
    return rv + candidates

def paired_primes(value, primeList):
    counter = 0
    for possible in primeList:
        if possible > value // 2:
            break
        if (value-possible) in primeList:
            counter += 1 
    return counter

def pairs(value):
    return paired_primes(value, primes(10000))
            

print(pairs(22) == 3)
print(pairs(8) == 1)
print(pairs(62) == 3)
print(pairs(114) == 10)
print(pairs(346) == 9)
print(pairs(1000) == 28)
print(pairs(2326) == 35)
print(pairs(5000) == 76)
print(pairs(9240) == 329)
