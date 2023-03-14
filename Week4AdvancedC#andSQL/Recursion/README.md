# Recursion

Recursion works theough calling the method within it's own code body, store it on the stack until it hits the base call, then go through all of the methods on the call stack one by one, this is VERY intensive on the stack so be careful on how much you use it.

So recursion is very heavy on stack bandwidth.

So for the recursive, the case case would be 1 due to it dividing until it gets to one element to compare

## Recurive Binary Merge Sort Array

Merge array is safe on compution time because it splits arrays as evenly as it can until there is only one cell either side to compare, then places the smalleest value of the two into the leftmost element in the result array. It does this loop until both arrays have been merged.

e.g. Array (8,4,2,19)

For the 1st recursion you'd have the left hand array being (8,4) and the right hand array being (2,19)

For the 2nd recursion you have (8) and (4) for the left and for the right you'd have (2) and (19)

For the third you'd merge the left side into (4,8) since the lhs is smaller than the rhs, For the right it'd be (2,19)

For the Fourth recursion it'd compare (4,8) and (2,19), which would lead to (2,4,8,19)

# Github Questions - Recursion

- What is a recursive function?

A recusrive function is a function that calls itself as many times as the counter will allow, put them calls on the stack, until it hits the 'base case' where it then resolves the rest of the function in a recursive manner as it deals with the last loop made first and works backwards 

- What is Big-O notation?

The Big-O notation measures the worst-case complexity of an algorithm. The algorithm works on data input of any size. For a given n, it answers the question: “What happens as n approaches infinity?” This helps to analyze the effectiveness of an algorithm which can be measured in time and efficiency.

- Give an example of an O(n) process. O(1)? O(n squared)?

O(1) - one operation - Assign a variable, one for loop
O(n) - multiple operations - Recursive functions
O(n2) - Quadratic - two nested loops
O(n3) - Cubic - three nested loops

- Why are some algorithms considered unreasonable?

They can get out of hand quite quickly, for example for the wedding plan example, having only 7 possible places had 10000+ examples.

Algorithms that have O(n!) are inpractable/ unreasonable

Unreasonable orders

O(n3)
O(n!)
O(2pown)
O(npown)
