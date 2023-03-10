# PairProgramming - BubbleSort & Collections Lab

## Bubble Sort

For the bubble sort we looked at the test we had to complete and implemented the BubbleSort Method in the Program class.

In that method we look at how long the array wee are sorting is, loop through as many ints there are but the last one, as Bubble sorting is the way of sorting an array by looking at an element and the one after, if the first element is bigger than the one after swap elements.

The sort should end with the array being sorted with lowest first.

### Array Merge

In this method we made a new result array, added the first array to the result array, concatonated the second array to the result array and then sorted it.

## Collections

### Queue - First in First out

For queue its a list that can only be accessed at the front of the list with Enqueue and Dequeue (Dequeue also returns that first element)

### Stack - Last in first out

Push - Push on top of the 'stack'
Pop - Pop off the top of the stock
Peek - Look at the first element

Stacks are a good way to reverse order an array since its last in first out.

            foreach (int i in original) { stack.Push(i); }

            for (int i = 0; i < original.Length; i++)
            {
                result[i] = stack.Pop();
            }

### Dictionary

Dictionarys are arrays that are stored with 'keys' which act as identifiers for the array instead of indexes 

            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in input)
                if (char.GetNumericValue(c) != -1)
                {
                    if (dic.ContainsKey(c))
                        dic[c]++;
                    else dic.Add(c, 1);
                }
            foreach (var item in dic)
                result += item;

In the above example each dictionary entry is marked with the the numberic value the char represents, if the dictionary already contained a key it would add 1 to that entry if not it added the key to the array.



