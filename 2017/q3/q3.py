# the key takeaway in this solution is not to brute force the individual ways parcels 
# could be formulated. The answer is the number of possibilities, which means considering
# where substitutions can be made and how many of them are feasible. 

# p is the number of parcels
# i is the options for the weights
# n is the number of items in total 
# w is the weight of each parcel

# take an input string of four integers separated by spaces - does absolutely no validation
def split_input(str):
	items = str.split(' ')
	rv = []
	for i in items:
		rv.append(int(i))
	return rv 

# takes the input parameters and generates all legal candidate parcels (i.e. the ones of the correct weights, 
# up to the total allowed number of items)
def generate_candidates(p, i, n, w):
	candidates = [([], 1, 0)]
	valids = []
	# candidates are triples containing a list of items, the current max and the current sum (to alleviate
	# multiple recalculations)
	while len(candidates) > 0: 
		stub = candidates.pop()
		# take the next candidate and attempt to create a set of parcels with that candidate and all possible
		# next items (bearing in mind you can't add a weight lighter than the current max)
		for weight in range(stub[1], i+1):
			li = list(stub[0])
			li.append(weight)
			s = stub[2]+weight
			candidate = (li, weight, s)
			# having built the new candidate parcel, check that it is viable 
			# - if it is already the correct weight, add it to the valid list, 
			# - if it too light but could still be viable, insert into the candidate list 
			if len(li) <= n-(p-1):
				if s == w: 
					valids.append(candidate)
				if s+weight <= w:
					candidates.insert(0, candidate) 
	# return just the lists of items, not the sums and counts 
	return [t[0] for t in valids]

# create an indexed array, indicating how many of the indices' weights are in the list of possible candidates 
def generate_value_counts(values, counts):
	rv = [0] * (max(values)+1)
	for x in counts:
		rv[x[0]] += 1
	return rv

# for the given number of items requirements in the given number of parcels, what combinations are possible 
def generate_combinations(values, p, n):
	candidates = [[x] for x in values]
	while p > 1:
		next_generation = []
		for c in candidates:
			for v in values: 
				ng = list(c)
				ng.append(v)
				next_generation.append(ng)
		candidates = list(next_generation)
		p -= 1 
	# TODO this seems like a bit of a waste, to generate them all and then decide which are valid - could certainly 
	# look to be cleverer here 
	candidates = [x for x in candidates if sum(x) == n]
	return candidates

# simply weight a single parcel combination based on value counts and the indices of the weights 
def weigh_combination(combination, value_counts):
	if combination == []: 
		return 1

	val = combination.pop()
	return value_counts[val] * weigh_combination(combination, value_counts)

# given the candidate parcels, how can they be combined? 
def count_parcels(candidates, p, n, w):
	# create a list of pairs of the candidates, with their item counts 
	counts = [(len(x), x) for x in candidates]
	if counts == []:
		return 0
	values = set([x[0] for x in counts])
	# determine how many of each item count there are 
	value_counts = generate_value_counts(values, counts)
	# how could the generated item counts be combined to create the correct distributions 
	combinations = generate_combinations(values, p, n)

	# given the possible distributions, and the number of each quantity, multiply through and add them together 
	return sum([weigh_combination(combo, value_counts) for combo in combinations])


# take in the input and the expected output and format the printing appropriately 
def test(str, expected):
	print(str)
	p, i, n, w = split_input(str)
	candidates = generate_candidates(p, i, n, w)
	cparcels = count_parcels(candidates, p, n, w)
	print(cparcels)
	if cparcels == expected:
		print('True')
	else: 
		print("expecting {0}, got {1} {2}".format(expected, cparcels, cparcels == expected))
	print("")

# the official mark scheme inputs and their expected values. 

test("2 3 4 3", 3)
test("1 1 20 20", 1)
test("1 1 10 15", 0)
test("1 2 10 15", 1)
test("1 3 10 20", 6)
test("1 10 5 25", 98)
test("2 2 10 6", 3)
test("2 2 21 14", 8)
test("3 3 10 6", 51)
test("2 9 17 24", 98852)
test("3 9 17 24", 10092972)
test("5 8 23 17", 2093750500)


