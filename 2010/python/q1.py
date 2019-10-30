
def anagramNumbers(a):

	liA = list(str(a))
	liA.sort()
	res = []
	for i in range(2,10):
		b = i*a
		liB = list(str(b))
		if len(liA) == len(liB):
			liB.sort()
			if liA == liB:
				res.append(str(i))
	if len(res) == 0:
		return "NO"
	return ' '.join(res)


print(anagramNumbers(123456789))
print(anagramNumbers(100))
print(anagramNumbers(1))
print(anagramNumbers(148258))
print(anagramNumbers(555))
print(anagramNumbers(1035))
print(anagramNumbers(123876))
print(anagramNumbers(142857))
print(anagramNumbers(49271085))
print(anagramNumbers(123450186))
