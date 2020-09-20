
def promenade(prom):
    # a dictionary of previous positions 
    previous = {'':(1,1)}
    for i in range(len(prom)):
        # what's the character we're looking at now 
        current = prom[i]
        # so we know the other one 
        other = 'L' if current == 'R' else 'R'
                
        # what's the pattern before the current character (it will be in the dictionary) 
        beforecurrent = prom[:i]
        
        n1,d1 = previous[beforecurrent] # get the numerator and denominator for the previous pattern

        # if the other character has not been seen before 
        if other not in beforecurrent:
            n2,d2 = (1,0) if other == 'L' else (0,1) # get the L/R specific unseen numerator and denominator 
        else:
            # otherwise use rindex to find the last index of the last instance of the other character in the beforecurrent string 
            n2,d2 = previous[beforecurrent[:beforecurrent.rindex(other)]]
        
        # add the whole pattern to the dictionary 
        previous[beforecurrent+current] = (n1+n2),(d1+d2)
        
    return previous[prom]

# the given examples 
print(promenade('L') == (1,2))
print(promenade('LR') == (2,3))
print(promenade('LRL') == (3,5))
print(promenade('LRLL') == (4,7))
print(promenade('RL') == (3,2)) 

# the mark scheme values 
print(promenade('R') == (2,1))
print(promenade('LL') == (1,3))
print(promenade('LLLRRR') == (4,13))
print(promenade('LLRRLL') == (7,17))
print(promenade('RRRLRRR') == (19,5))
print(promenade('LLLLRLLLL') == (6,29))
print(promenade('LLLLLLLLLL') == (1,11))
print(promenade('LRLRLRLRLR') == (89,144))

