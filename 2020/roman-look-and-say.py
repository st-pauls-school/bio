# task 1a 

def split(s):
	current = s[0]
	counter = 1
	rv = []
	for c in s[1:]:
		if c == current:
			counter += 1
		else:
			rv.append((current,counter))
			current = c
			counter = 1
	rv.append((current,counter))
	return rv

def generate(x):
	def convert(digit, l):
		if digit == 0:
			return ""
		elif digit <= 3:
			d = l[0]*digit
		elif digit == 4:
			d = l[0]+l[1]
		elif digit == 5:
			d = l[1]
		elif digit == 9:
			d = l[0]+l[2]
		else: # 6-8
			d = l[1] + l[0]*(digit-5)
		return d

	units = x % 10
	u = convert(units, ["I","V","X"])
	tens = (x % 100) // 10
	t = convert(tens, ["X","L","C"])
	hundreds = (x % 1000) // 100 
	h = convert(hundreds, ["C","D","M"])
	th = "M" * (x // 1000)

	return th + h + t + u


romans = [generate(i) for i in range(1,4000)]

def look_and_say(s):
	rv = ""
	for pair in split(s):
		rv += romans[pair[1]-1] + pair[0]
	return rv

print("Look-and-say tests:")
print(look_and_say("MMXX") == "IIMIIX")
print(look_and_say("IIMIIX") == "IIIIMIIIIX")

def report(s,l):
	for i in range(l):
		s = look_and_say(s)
	return s.count("I"), s.count("V")

print("Task 1a given examples:")
print(report("MMXX",1) == (4,0))
print(report("MMXX",3) == (6,2))


# task 1b 

ls = [look_and_say(s) for s in romans]
print("Task 1b:", [x for x in ls if x in romans])

print("Task 1c:", len(set(ls)))


# Mark scheme
print("Task 1a mark scheme:")

print(report("MMXX",3) == (6, 2))
print(report("C",1) == (1, 0))
print(report("V",1) == (1, 1))
print(report("III",2) == (2, 1))
print(report("I",7) == (6, 2))
print(report("MMXX",8) == (30, 12))
print(report("II",20) == (101, 37))
print(report("IV",20) == (121, 46))
print(report("MDCLX",30) == (1795, 695))
print(report("M",50) == (2858, 1103))
print(report("V",50) == (2858, 1104))
print(report("MMDCCCLXXXVIII",50) == (19013, 7333))


