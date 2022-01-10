def block_palindrome(v):
    total = 0 
    for i in range(len(v)//2):
        i = i+1
        if v[:i] == v[-i:]:
            total += 1 + block_palindrome(v[i:-i])

    return total 

def test():
    # given examples 
    print(block_palindrome("BONBON") == 1)
    print(block_palindrome("ONION") == 1)
    print(block_palindrome("BBACBB") == 3)

    # mark scheme 
    print(block_palindrome("XX") == 1)
    print(block_palindrome("YZ") == 0)
    print(block_palindrome("OLYMPIAD") == 0)
    print(block_palindrome("RACECAR") == 3)
    print(block_palindrome("KKKKKKK") == 7)
    print(block_palindrome("BBIIOIIBB") == 9)
    print(block_palindrome("PPPQQQQPPP") == 19)
    print(block_palindrome("AAAAAAAAAA") == 31)

print(block_palindrome(input("word (2-10) characters ")))