START = 10000
MINIMUM_REPAYMENT = 5000 


def interestRepayment(interestRate, repaymentRate):
	remainingDebt = START
	totalRepayment = 0
	previous = remainingDebt
	while (remainingDebt > 0): 
		previous = remainingDebt
		i1, i2 = Calculate(remainingDebt, interestRate, repaymentRate)
		totalRepayment += i2
		remainingDebt = i1
		if(previous <= remainingDebt):
			remainingDebt = 0

	return  totalRepayment / 100

# the key here is to use integer division when calculating the quantities 
def Calculate(remainingDebt, interestRate, repaymentRate):
	additionalDebt = remainingDebt * interestRate
	remainingDebt += (additionalDebt // 100) + (0 if additionalDebt % 100 == 0 else 1)
	payment = remainingDebt * repaymentRate
	payment = (payment // 100) + (0 if payment % 100 == 0 else 1)
	if (payment <= MINIMUM_REPAYMENT):
		payment = MINIMUM_REPAYMENT
	if (payment > remainingDebt):
		payment = remainingDebt
	remainingDebt -= payment
	return remainingDebt, payment


def test(result, expected):
	print(result)
	if result == expected:
		print(True)
	else:
		print('actual: {0}, but was expecting {1}'.format(result, expected))
	print('') 

test(interestRepayment(10, 50), 116.55)
test(interestRepayment(0, 0), 100)
test(interestRepayment(0, 70), 100)
test(interestRepayment(49, 0), 492.17)
test(interestRepayment(70, 100), 170)
test(interestRepayment(21, 21), 143.46)
test(interestRepayment(31, 31), 180.8)
test(interestRepayment(24, 30), 152.22)
test(interestRepayment(76, 79), 214.48)
test(interestRepayment(98, 69), 317.74)
test(interestRepayment(61, 52), 287.57)
test(interestRepayment(36, 37), 207.22)
test(interestRepayment(61, 38), 6755.51)
test(interestRepayment(85, 46), 34606.34)



