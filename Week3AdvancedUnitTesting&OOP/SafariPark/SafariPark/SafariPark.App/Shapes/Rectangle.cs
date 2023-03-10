namespace SafariPark.App;

internal sealed class Rectangle : Shape //When applied to a class, the sealed modifier prevents other classes from inheriting from it.
{
    private int _width;
    private int _height;

    public Rectangle(int width, int height)
    {
        _width = width;
        _height = height;
    }
    public override int CalculateArea()
    {
        return _width * _height;
    }

    public override string ToString()
    {
        return $"{CalculateArea()}";
    }
}
