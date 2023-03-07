# Pair-Programming-AdventOfCode Day 1 & 2

## Advent Of Code: Day 1 - Calorie Counting

In this project the brief was:

- Given a set of 'elves'
- Each holding a different amount of 'Calories'
- Which Elf has the most amount of Calories

### Development Process

So each 'Elf' is just an array holding the different values so they need to be Jagged Arrays.

In Test Driven Development thinking, we made a test that loops through a single Array looking for a specific value and return which elf had that value which lead to the development to the FindElfHolding method to test the looping method for the arrays.

Then the next point of development was to loop through the jagged array and add up the emount of 'Calories' that each elf holds, if that elf holds more than the stored sum value, that elf number is stored and then loop through the other elfs and check again.

At the end of the loop the elf with the most 'Calories' has it's number returned.

## Advent Of Code: Day 2 - Rock, Paper, Scissors

In this project, the brief was:

- Given a predetermined set of rock paper scissors for both the opponent and the user.
- Each hand thrown (Rock, Paper, scissors) gives a base amount of points (1, 2, 3 respectivley).
- Winning a hand would give +6 points, a draw would give +3 points and losing a hand would give +0 points. (so a winning rock hand would give 7 points)
- Return the amount of points given at the end of the three hands.

### Development Process

In TTD thinking, we created a test to return the amount of points given when a particular hand is used.

Then we made the Rock, Paper, Scissors method to return the amount of points given for using a certain hand.

Then we made the next step of the test to get the result of a particular hand against another one and give the correct points as outlined in the brief.

Then we refactored the Rock, Paper, Scissors method to add the points for winning a particular hand along with the points added from using a particular hand and then returned that value.

After that step was to test a complete hand (3 hands) in the testing environment and return the expected amount of points for the various had combinations that can happen.

Then we refactored the Rock, Paper, Scissors method to loop through both a opponents hands and a users hands and get all of the points given if the user won or lost.
