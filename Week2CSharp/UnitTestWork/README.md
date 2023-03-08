# Nunit Cheat sheet
    [TestCase(14, 1)]
    [TestCase(16, 1)]
    [TestCase(28, 2)]
    [TestCase(42, 3)]
    public void Test_GetStones_WithMultipleValues(int pounds, int expected)
    {
        int result = Program.GetStones(pounds);
        Assert.That(result, Is.EqualTo(expected));
    }
## Regular Tests 
    [TestCase("5", 1, 2, 3, 4, 5)]
    [TestCase("15", 1, 2, 3, 4, 15)]
    public void Test_GetHighestInt_WithDoWhileLoop(string expected, params int[] intList)
    {
        string result = LoopTypes.HighestDoWhileLoop(intList.ToList());
        Assert.That(result, Is.EqualTo(expected));
    }
## For handling Lists

Assert.That(() => Program.ReturnGradeTurnery(mark), Throws.TypeOf<ArgumentOutOfRangeException>());
For non customised error handling

throw new ArgumentOutOfRangeException("Mark must be must be between 0-100");


Assert.That(() => Program.ReturnGradeTurnery(mark), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Mark must be must be between 0-100"));
For customised error handling
