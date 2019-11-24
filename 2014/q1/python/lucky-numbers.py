
import sys

def test(did_pass):
    linenum = sys._getframe(1).f_lineno
    if did_pass:
        msg = "Test at line {0} successful.".format(linenum)
    else:
        msg = "Test at line {0} failed.".format(linenum)
    print(msg)

def lucky_numbers(i):
	lucky_index = 0 
	#generate all the odd numbers
	numbers = [x for x in range(1, 2*(i+1), 2)]
	# continue until we reach our target number 
	while numbers[lucky_index] < i:
		# point to the next
		lucky_index += 1
		# what is the interval for destruction  
		doomed_interval = numbers[lucky_index]
		# start at the index (0-indexed of course)
		current_index = doomed_interval-1
		# loop through the lucky numbers ... 
		while current_index+doomed_interval < len(numbers): 
			# removing the item at the doomed location 
			numbers.pop(current_index)
			current_index += doomed_interval - 1 # one fewer to compensate for the one we've just removed 

	return max([x for x in numbers if x < i]), min([x for x in numbers if x > i])


test(lucky_numbers(5) == (3,7))	
test(lucky_numbers(33) == (31,37))	
test(lucky_numbers(34) == (33,37))	
test(lucky_numbers(399) == (393,409))	
test(lucky_numbers(456) == (451,463))	
test(lucky_numbers(3301) == (3297,3307))	
test(lucky_numbers(3304) == (3301,3307))	
test(lucky_numbers(9703) == (9691,9727))	
test(lucky_numbers(10000) == (9999,10003))	

