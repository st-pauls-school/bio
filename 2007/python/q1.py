
import sys

def test(did_pass):
    """  Print the result of a test.  """
    linenum = sys._getframe(1).f_lineno   # Get the caller's line number.
    if did_pass:
        msg = "Test at line {0} ok.".format(linenum)
    else:
        msg = ("Test at line {0} FAILED.".format(linenum))
    print(msg)


def pairs(hand):
	hand.sort()
	rv = 0 
	identical = 0
	previous = hand[0]
	for i in range(1, len(hand)):
		if hand[i] == previous:
			if identical == 0: 	
				identical = 1
			elif identical == 1:
				identical = 3
			elif identical == 3:
				identical = 6
		else:
			rv += identical 
			identical = 0 
		previous = hand[i]
	return rv + identical

def fifteens(hand):
	return sum([1 if x == 15 else 0 for x in generate(0,hand)])

def generate(incoming, hand):
	if(len(hand) == 1):
		return [incoming, incoming+hand[0]]
	else: 
		return generate(incoming, hand[1:]) + generate(incoming+hand[0], hand[1:])


def cards(hand):
	return 0 if len(hand) != 5 else pairs(hand) + fifteens(hand)

test(fifteens([7,8]) == 1)
test(fifteens([7,7]) == 0)
test(fifteens([5,10]) == 1)
test(fifteens([5,5,10]) == 2)

test(pairs([1,1]) == 1)
test(pairs([1,2]) == 0)
test(pairs([1,2,2]) == 1)
test(pairs([2,2,2]) == 3)
test(pairs([1,2,2,2]) == 3)
test(pairs([1,1,2,2,2]) == 4)
test(pairs([1,2,2,2,1]) == 4)

test(cards([3,3,3,2,10]) == 6)
test(cards([3,3,3,2,2]) == 4)
test(cards([1,2,3,4,5]) == 1)


test(cards([3, 3, 3, 2, 10]) ==6)
test(cards([3, 4, 7, 9, 10]) == 0)
test(cards([7, 9, 2, 2, 10]) == 1)
test(cards([2, 7, 9, 10, 2]) == 1)
test(cards([2, 2, 3, 3, 4]) == 2)
test(cards([7, 6, 6, 6, 10]) == 3)
test(cards([1, 6, 2, 4, 9]) == 2)
test(cards([1, 8, 2, 3, 9]) == 1)
test(cards([2, 2, 7, 8, 2]) == 4)
test(cards([5, 5, 10, 5, 5]) == 14)