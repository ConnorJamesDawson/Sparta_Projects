using AdventOfCode.app;

namespace AdventOfCodeDay1.Test;

public class Tests
{
    [TestCase(1000, "1 Elf")]
    [TestCase(10000, "5 Elf")]
    public void CalorieCounting_WhenGivenAIntNeeded_ReturnAnElfName(int calorieWanted, string expected)
    {
        Assert.That(Program.FindElfHolding(calorieWanted), Is.EqualTo(expected));
    }
    [Test]
    public void CalorieCounting_WhenCalledFindElfHoldingMostCalories_ReturnsFourthElf()
    {
        Assert.That(Program.FindElfHoldingMostCalories(), Is.EqualTo("4 Elf"));
    }
}