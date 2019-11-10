def convert(i):
	conversion = ['ZERO', 'ONE', 'TWO','THREE','FOUR','FIVE','SIX','SEVEN','EIGHT','NINE']
	s = ''
	if i == 0:
		s = conversion[0]
	while i > 0:
		s += conversion[i%10]
		i //= 10
	return  ''.join(sorted(list(s)))

def cache(x):
	return [convert(i) for i in range(x)]

def remaining(x, y, cache):
	x = cache[x] 
	y = cache[y]
	removed_from_x = 0
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

def number_ladder(queue, target, cache, visited=[]):
	src, level = queue.pop(0)
	visited.append(src)
	for i in range(1000):
		if i != src and i not in visited:
			if remaining(src, i, cache) <= 5:
				if i == target:
					return level+1
				queue.append((i, level+1))
	return number_ladder(queue, target, cache, visited)


mapping_cache = cache(1000)
#print('A', number_ladder([(26,0)], 61, mapping_cache) == 1)
#print('B', number_ladder([(1,0)], 90, mapping_cache) == 1)
#print('C', number_ladder([(1,0)], 610, mapping_cache) == 2)

#print(remaining(1,2,mapping_cache))

#print(number_ladder([(1,0)], 2, mapping_cache) == 1)
#print(number_ladder([(1,0)], 3, mapping_cache) == 2)
#print(number_ladder([(1,0)], 4, mapping_cache) == 1)

#print(number_ladder([(14,0)], 543, mapping_cache) == 2)
#print(number_ladder([(5,0)], 75, mapping_cache) == 1)
#print(number_ladder([(71,0)], 713, mapping_cache) == 1)

#print(number_ladder([(21,0)], 911, mapping_cache) == 2)
#print(number_ladder([(329,0)], 927, mapping_cache) == 2)
#print(number_ladder([(66,0)], 71, mapping_cache) == 3)

print(number_ladder([(250,0)], 361, mapping_cache) == 3)
print(number_ladder([(34,0)], 756, mapping_cache) == 4)
print(number_ladder([(18,0)], 735, mapping_cache) == 3)

#print(number_ladder([(77,0)], 383, mapping_cache) == 5)
#print(number_ladder([(48,0)], 677, mapping_cache) == 4)
#print(number_ladder([(232,0)], 471, mapping_cache) == 4)

#print(number_ladder([(220,0)], 691, mapping_cache) == 5)
#print(number_ladder([(198,0)], 222, mapping_cache) == 5)
#print(number_ladder([(410,0)], 666, mapping_cache) == 6)

#print(number_ladder([(402,0)], 788, mapping_cache) == 6)
#print(number_ladder([(203,0)], 959, mapping_cache) == 6)
#print(number_ladder([(404,0)], 777, mapping_cache) == 6)


