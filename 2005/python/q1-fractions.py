
def d2f(decimal, decimalplaces=4):
    # by default this will be 10000, but this leaves us flexibility to have more decimal places 
    tens = 10**decimalplaces 
    # curiously int(0.7525 * 10000) returned as 7424 so this is something of a hack 
    numerator = int(round(decimal * tens, 0))
    denominator = tens

    # generate all the primes up to the sqrt of the 
    primes = generate_primes(int(tens**0.5))
    return simplify(numerator, denominator, primes)

# a recursive function that will find the largest prime that is a factor of both the denominator and numerator
def simplify(n, d, primes):
    # if the numerator is 1, there's no more work to do 
    if n == 1: 
        return fraction_format(n,d)
    # assume no prime is a factor 
    largest = 1
    for prime in primes: 
        # check if any of the primes divides into both numerator and denominator 
        if n%prime == 0 and d%prime == 0:
            largest = prime 
            break               # a minor performance benefit 
    # recursively call if they both divide through 
    if largest > 1:
        return simplify(n//largest, d//largest, primes)
    # if we get here, then the numerator and denominator are coprime 
    return fraction_format(n,d)

def fraction_format(n, d):
    return '{0} / {1}'.format(n, d)

# my variant of the Sieve of Eratosthenes - https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes 
# primes are so common in BIO questions that being able to reproduce this is a valuable skill 
def generate_primes(n):
    ps = list(range(2,n))       # generate all the numbers from 2 to n 
    index = 0                   # this is the index of the largest known prime, so we start at the value 2 
    while index < len(ps):      # while we still have candidates left to check
                                # append the values up to and including indices, 
                                # filtering out any from the remainder that are factors of the largest prime 
        ps = ps[:index+1] + [p for p in ps[index+1:] if p%ps[index] != 0]         
        index += 1              # increase the index to reflect that the next 
    return ps 

# these are the test cases from the mark scheme 
decimals = [0.125,0.9,0.0008,0.49,0.2005,0.1418,0.7525,0.9952,0.016]
results = ['1 / 8','9 / 10','1 / 1250','49 / 100','401 / 2000','709 / 5000','301 / 400','622 / 625','2 / 125']

# loop through the test cases
for d,f in zip(decimals,results):
    result = d2f(d)
    # the assert statement will throw an error if the condition is false 
    assert f == result
    # print out our result 
    print("{0} is {1}".format(d, result))
