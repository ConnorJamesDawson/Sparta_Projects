namespace Vehicle.Tests;
using Vehicle.App;


public class Tests
{

    [TestCase(20, 2)]
    [TestCase(40, 4)]
    [TestCase(10, 0)]
    [TestCase(0, 0)]
    public void WhenADefaultVehicleMovesANumberOfTimesItsPositionIsExpected(int vehiclePosition, int howManyMoves)
    {
        Vehicle v = new Vehicle();
        var result = v.Move(howManyMoves);
        Assert.That(vehiclePosition, Is.EqualTo(v.Position));
        Assert.That($"Moving along {howManyMoves} times", Is.EqualTo(result));
    }

    [TestCase(40, 5)]
    public void WhenAVehicleWithANumberSpeedIsMovedOnceItsPositionIsExpected( int vehicleSpeed, int vehicleCapacity)
    {
        Vehicle v = new Vehicle(vehicleCapacity, vehicleSpeed);
        var result = v.Move();
        Assert.That(vehicleSpeed, Is.EqualTo(v.Position));
        Assert.That("Moving along", Is.EqualTo(result));
    }
}
