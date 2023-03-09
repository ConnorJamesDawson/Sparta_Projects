using Vehicle.App;

namespace Vehicle.Tests;

internal class AirplaneTests
{

    [TestCase(100, $"Moving along at an altitude of 100 meters")]
    [TestCase(5000, $"Moving along at an altitude of 5000 meters")]
    [TestCase(10000, $"Moving along at an altitude of 10000 meters")]
    public void Move_WhenGivenAnAltitudeToAsendTo_GiveExpectedReturnOfSameAltitude(int altitude, string expected)
    {
        Airplane sutAirplane = new(200);

        sutAirplane.Ascend(altitude);

        string result = sutAirplane.Move();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(100, 1, $"Moving along 1 times at an altitude of 100 meters")]
    [TestCase(5000, 19, $"Moving along 19 times at an altitude of 5000 meters")]
    [TestCase(10000, 999, $"Moving along 999 times at an altitude of 10000 meters")]
    public void Move_WhenGivenAnAltitudeToAsendToAndMoveTimes_GiveExpectedReturnOfSameAltitudeAndAmountOfMoves(int altitude, int timesMoved, string expected)
    {
        Airplane sutAirplane = new(200);

        sutAirplane.Ascend(altitude);

        string result = sutAirplane.Move(timesMoved);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(100, 50, $"Moving along at an altitude of 50 meters")]
    [TestCase(5000, 2500, $"Moving along at an altitude of 2500 meters")]
    [TestCase(10000, 3750, $"Moving along at an altitude of 6250 meters")]
    public void Move_WhenGivenAnAltitudeToDesendTo_GiveExpectedReturnOfSameAltitude(int altitudeAscend, int altitudeDescend, string expected)
    {
        Airplane sutAirplane = new(200);

        sutAirplane.Ascend(altitudeAscend);

        sutAirplane.Descend(altitudeDescend);

        string result = sutAirplane.Move();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Jet2", 100, "Thank you for flying Jet2: Vehicle.App.Airplane altitude: 100")]
    [TestCase("2Jet", 1000, "Thank you for flying 2Jet: Vehicle.App.Airplane altitude: 1000")]
    [TestCase("AirLingus", 50, "Thank you for flying AirLingus: Vehicle.App.Airplane altitude: 50")]
    public void ToString_WhenGivenAirlineNameAndAltitude_RetrunExpectedString(string airlineName, int altitude, string expected)
    {
        Airplane sutAirplane = new(210, 200, 50, airlineName);

        sutAirplane.Ascend(altitude);

        string result = sutAirplane.ToString();

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(50)]
    public void Descend_WhenGivenAnAltitudeToDesendToButWouldTakeItOutOfRange_ThrowOutOfRangeException(int altitudeDescend)
    {
        Airplane sutAirplane = new(200);

        Assert.That(() => sutAirplane.Descend(altitudeDescend), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("You cannot go below 0 altitude without crashing, that's not allowed!"));
    }

    [TestCase(50, 75)]
    [TestCase(200, 250)]
    public void NumPassengers_WhenGivenMorePassengersThanCapacityOnAirplane_ThrowOutOfRangeException(int capacity, int numPassengers)
    {
        Assert.That(() => new Airplane(capacity, numPassengers, 0, "test"), Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}