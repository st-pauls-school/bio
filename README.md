# BIO 


The BIO - the British Infomatics Olympiad - is an annual competition. Old papers and more information can be found (here)[https://olympiad.org.uk/].

The BIO round one will be sat either in the last week before Christmas or the first week of term in the New Year. The paper last 3 hours. It is optional, but 8th form Computing students and those who are looking to do Computer Science at university are strongly encouraged to participate. 

## BIO Structure 

The round one papers have a familiar structure: 

- Three questions which need to be answered with a program 
- each with subsidiary parts which can be calculated on paper, possibly with aspects of the program just written 
- Each question takes input the from the user 
- Each question should print out the result 

You are free to use any computer language you like to solve the problems. 

### Question 1 

Q1 is generally quite straightforward, often solvable with brute force and iteration (occasionally recursive solutions might be elegant answers, but are rarely required). 

Occasionally we see a quirk to Q1 which can be problematic (e.g. (Debt Repayment, 2018, Q1)[https://olympiad.org.uk/papers/2018/bio/bio18-exam.pdf]) - in that case it was a rounding to 2 decimal places after every calculation, not a simple compounding - but generally Q1 is reasonably approachable, even by new programmers. 

### Question 2

Q2 is generally quite long, it is normally just the repeated application of a particular algorithm, but based around state changes, i.e. being able to store information about a particular state, then to calculate the next state and so on. Generally quite intricate, but normally acheivable. 

### Question 3

Q3 normally involves something fairly simply specified but which cannot be resolved in a reasonable time using brute force. It will often need some sort of insight and resulting shortcut to enable a quick solution. This might sometimes mean combinatorics, factorials, queues and breadth first searching between connected states. 

## Common Techniques 

- converting input which might be several values separated by spaces into several variables, possibly integers or floats. 
- representing grids of data 
- spotting 'quick' non brute methods 
- combinatorics (e.g. nCr, nPr) and factorial based choosing and rearrangements 
- recursive use of queues and basic graph theory tracking state changes and finding the shortest or optimal solutions 
- recursive use of stacks to find whether a solution exists - proving something impossible 




