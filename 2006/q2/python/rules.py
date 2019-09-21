import pytest
def validate(pattern, inputs, max_length=12):

    patterns = generate_patterns(pattern, max_length)
    rv = []
    for singleinput in inputs:
        yes = False
        for candidate in patterns:
            if validateagainst(singleinput, candidate):
                yes = True
                break
        rv.append("Yes" if yes else "No")
    return rv

def validateagainst(number, pattern):
    if len(number) != len(pattern):
        return False
    current = int(number[0])
    for i in range(1, len(pattern)):
        nextone = int(number[i])
        if pattern[i] == 'u' and nextone <= current: 
                return False
        if pattern[i] == 'd' and nextone >= current: 
                return False
        current = nextone
    return True

def generate_patterns(pattern, length):
    qm = pattern.find("?")
    star = pattern.find("*")

    if qm < 0 and star < 0: 
        if len(pattern) > length: 
            return []
        return [pattern]
    
    patterns = []
    later = qm if qm > star else star
    minipatternwithout, minipatternwith = isolate(pattern, later)
    
    # what is the pattern, without the isolated subpattern? 
    withoutminipattern = pattern[:later-len(minipatternwith)+1]+pattern[later+1:]
    if len(withoutminipattern) <= length: 
        patterns = patterns + [withoutminipattern] + generate_patterns(withoutminipattern, length) 


    if later == qm: 
        withminipattern = pattern[:later-len(minipatternwith)+1]+minipatternwithout+pattern[later+1:]
        if len(withminipattern)-len(minipatternwith) <= length: 
            patterns = patterns + [withminipattern] + generate_patterns(withminipattern, length) 
    else: 
        insertacopy = pattern[:later-len(minipatternwith)+1]+minipatternwithout+pattern[later-len(minipatternwith)+1:]
        if len(insertacopy)-len(minipatternwith) <= length: 
            patterns = patterns + generate_patterns(insertacopy, length) 

    patterns = list(set(patterns))
    patterns.sort()
    return patterns

def isolate(pattern, index):
    if pattern[index-1] == ')':
        for i in range(index-1, -1, -1):
            if pattern[i] == '(':
                return pattern[i+1:index-1], pattern[i:index+1]
    else:
        rv = pattern[index-1], pattern[index-1:index+1]
        return rv

def test_generate():
    assert generate_patterns('xu?',5) == ['x','xu']
    assert generate_patterns('xu?x',5) == ['xux','xx']
    assert generate_patterns('xu*',5) == ['x','xu','xuu','xuuu','xuuuu']
    assert generate_patterns('x(ud)*',5) == ['x','xud','xudud']
    assert generate_patterns('x(ud)*x',5) == ['xudx','xx']

def test_isolate():
    assert isolate("xu*",2) == ('u','u*')
    assert isolate("x(uu)*",5) == ('uu','(uu)*') 
    assert isolate("x(uu)?x",5) == ('uu','(uu)?')

def test_validateagainst():
    assert validateagainst("2468","xxxx") == True
    assert validateagainst("2468","xuuu") == True
    assert validateagainst("2468","xudd") == False
    assert validateagainst("244","xuu") == False

def test_validate():
    assert validate("xu*", ["02468","4688"]) == ["Yes","No"]

def test_mark_scheme():
    assert validate("x", ["7","12"]) == ["Yes","No"]
    assert validate("xux", ["667","65"]) == ["No","No"]
    assert validate("xddu", ["8654","2102"]) == ["No","Yes"]
    assert validate("xuxd", ["9801","4543"]) == ["No","Yes"]
    assert validate("xx*", ["0","2006"]) == ["Yes","Yes"]
    assert validate("xd*u", ["56","54322"]) == ["Yes","No"]
    assert validate("x?x", ["123","4567"]) == ["No","No"]
    assert validate("x*xu", ["7654","2"]) == ["No","No"]
    assert validate("x(xud)?", ["789","7890"]) == ["No","Yes"]
    assert validate("x(ud)*u?", ["0836","19181716151"]) == ["Yes","Yes"]

test_isolate()
test_generate()
test_validateagainst()
test_validate()
test_mark_scheme()