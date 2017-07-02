using System;

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double coordinatesTopLeftX;
    private double coordinatesTopLeftY;

    public Rectangle(string id, double width, double height, double coordinatesTopLeftY, double coordinatesTopLeftX)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.coordinatesTopLeftX = coordinatesTopLeftX;
        this.coordinatesTopLeftY = coordinatesTopLeftY;
    }

    public string Id => this.id;

    public bool IntersectsRectangle(Rectangle r)
    {
        return this.ContainsRectangleCorner(r) || r.ContainsRectangleCorner(this);
    }

    private bool ContainsRectangleCorner(Rectangle r)
    {
        return this.ContainsPoint(r.coordinatesTopLeftX, r.coordinatesTopLeftY) ||
               this.ContainsPoint(r.coordinatesTopLeftX, r.coordinatesTopLeftY + height) ||
               this.ContainsPoint(r.coordinatesTopLeftX + width, r.coordinatesTopLeftY) ||
               this.ContainsPoint(r.coordinatesTopLeftX + width, r.coordinatesTopLeftY + height);
    }

    private bool ContainsPoint(double x, double y)
    {
        return x >= this.coordinatesTopLeftX && x <= this.coordinatesTopLeftX + width &&
               y >= this.coordinatesTopLeftY && y <= this.coordinatesTopLeftY + height;
    }
}