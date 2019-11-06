def primes(ubound):
    rv = [2]
    candidates = [x for x in range(3,ubound+1,2)]
    candidate = 2
    while candidate < ubound**0.5:
        candidate = candidates[0]        
        rv.append(candidate)
        # this resizing of the lists is somewhat sub-optimal, considering re-writing, e.g. https://stackoverflow.com/a/3941967 
        candidates = list(filter(lambda x: x % candidate != 0, candidates)) 
    return rv + candidates

def distinct_primes(value):
	rv = []
	list_of_primes = primes(value)
	while value > 1:
		if value % list_of_primes[0] == 0: 
			rv.append(list_of_primes[0])
			value //= list_of_primes[0]
		else: 
			list_of_primes.pop(0)
	product = 1
	for i in set(rv):
		product *= i
	return product 

print(distinct_primes(100) == 10)
print(distinct_primes(101) == 101)
print(distinct_primes(2) == 2)
print(distinct_primes(1001) == 1001)
print(distinct_primes(371293) == 13)
print(distinct_primes(789774) == 789774)
print(distinct_primes(999883) == 999883)
print(distinct_primes(561125) == 335)
print(distinct_primes(661229) == 4379)
