
def promenade(prom):
	previous = {}
	if prom[0] == 'L':
		previous[prom[0]] = (1,2)
	if prom[0] == 'R':
		previous[prom[0]] = (2,1)

	# we've dealt with the first character, so we can ignore that 
	for i in range(1,len(prom)):
		pattern = prom[:i]
#		print(i, pattern, previous)

		lc = -1 if 'L' not in pattern else pattern.rindex('L')+1
		rc = -1 if 'R' not in pattern else pattern.rindex('R')+1

#		print(lc,rc)

		if lc == -1:
			l, m = 1, 0
		else:
			l, m = previous[pattern[:lc]]

#		print(l,m)

		if rc == -1:
			r, s = 0, 1
		else:
			r, s = previous[pattern[:rc]]

		previous[pattern] = ((l+r), (m+s))
	print(prom, previous)
	return previous[prom]

#print(promenade('L'))
#print(promenade('R'))
print(promenade('LL'))
print(promenade('LRLL'))
