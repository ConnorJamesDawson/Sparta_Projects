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
