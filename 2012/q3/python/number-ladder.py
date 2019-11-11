import time

def convert(i):
	conversion = ['ZERO', 'ONE', 'TWO','THREE','FOUR','FIVE','SIX','SEVEN','EIGHT','NINE']
	s = ''
	if i == 0:
		s = conversion[0]
	while i > 0:
		s += conversion[i%10]
		i //= 10
	return  ''.join(sorted(list(s)))

# generate all the unique letter combinations
def cache(x):
	return [convert(i) for i in range(x)]

# in effect the number of changes is the n(x) + n(y) - n(x ^ y) (i.e. n (x union y) - n (x intersect y))
# iterate over x, removing characters from y, counting the number removed 
# then return the total in x, the new y and the number that should be removed from x 
def remaining(x, y, cache):
	x = cache[x] 
	y = cache[y]
	removed_from_x = 0
	# given the lists are sorted, this could be done more efficiently 
	for i in range(len(x)):
		f = y.find(x[i])
		if f == 0:
			y = y[1:] 
			removed_from_x += 1
		elif f == len(y)-1:
			y = y[:-1]
			removed_from_x += 1
		elif f > 0:
			y = y[:f]+y[f+1:] 
			removed_from_x += 1
	return len(x) - removed_from_x + len(y)


def number_ladder(src, target, limit=1000):
	maps = cache(limit) 
	visited=[None]*limit
	queue = [(src,0)]
	while len(queue) > 0: 
		src, level = queue.pop(0)
		if visited[src] == None:
			visited[src] = level
		for i in range(limit):
			if visited[i] == None:
				if i != src:
					if remaining(src, i, maps) <= 5:
						if i == target:
							return level+1
						visited[i]=level+1 
						queue.append((i, level+1))
	return -1 

# summarise the test, with a time estimate for each result 
def number_ladder_checker(src, target, expected):
	t0 = time.time()
	actual = number_ladder(src,target) 
	t1 = time.time()
	total = t1-t0
	return "{0} -> {1} {2} == {3} => {4} [{5:.02f}s]".format(src, target, expected, actual, expected==actual, total)

print(number_ladder_checker(26, 61, 1))
print(number_ladder_checker(1, 90, 1))
print(number_ladder_checker(1, 610, 2))

print(number_ladder_checker(1, 2, 1))
print(number_ladder_checker(1, 3, 2))
print(number_ladder_checker(1, 4, 1))

print(number_ladder_checker(14, 543, 2))
print(number_ladder_checker(5, 75, 1))
print(number_ladder_checker(71, 713, 1))

print(number_ladder_checker(21, 911, 2))
print(number_ladder_checker(329, 927, 2))
print(number_ladder_checker(66, 71, 3))

print(number_ladder_checker(250, 361, 3))
print(number_ladder_checker(34, 756, 4))
print(number_ladder_checker(18, 735, 3))

print(number_ladder_checker(77, 383, 5))
print(number_ladder_checker(48, 677, 4))
print(number_ladder_checker(232, 471, 4))

print(number_ladder_checker(220, 691, 5))
print(number_ladder_checker(198, 222, 5))
print(number_ladder_checker(410, 666, 6))

print(number_ladder_checker(402, 788, 6))
print(number_ladder_checker(203, 959, 6))
print(number_ladder_checker(404, 777, 6))


