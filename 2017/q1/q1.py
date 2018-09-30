
def triangle(left, right):
	if left == right: 
		return left
	if left == 'R':
		return 'B' if right == 'G' else 'G'
	if left == 'G':
		return 'B' if right == 'R' else 'R'
	return 'G' if right == 'R' else 'R'

def q1(str):
	if len(str) <= 1:
		return str		
	if len(str) == 2:
		return triangle(str[0],str[1])
	newstring = ''
	for i in range(len(str)-1):
		newstring = newstring + triangle(str[i], str[i+1])
	return q1(newstring)


def test(inp, expected):
	print(inp)
	result = q1(inp)
	print(result)
	if result == expected:
		print(True)
	else:
		print('actual: {0}, but was expecting {1}'.format(result, expected))
	print('') 

test('RG', 'B')
test('GR', 'B')
test('R', 'R')
test('GG','G')
test('RRR','R')
test('RGB','G')
test('BGGRB','B')
test('BRGRBG','G')
test('GGGGGG','G')
test('GRBRBRBRBR','B')
test('RBGBGBGBGR','R')



