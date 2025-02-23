using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.ShapeCalculator;

/// <summary>
/// Interface for shape calculations.
/// This interface defines methods for calculating area and perimeter.
/// It is implemented by various shape classes to enforce consistency in calculation logic.
/// </summary>
public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}

/// <summary>
/// Interface for resizable shapes.
/// This allows shapes to be resized dynamically by a specified factor.
/// </summary>
public interface IResizable
{
    void Resize(double factor);
}

/// <summary>
/// Represents a Circle with area and circumference calculations.
/// Implements <see cref="IShape"/> for standard shape calculations and <see cref="IResizable"/> for resizing capabilities.
/// </summary>
public class Circle : IShape, IResizable
{
    public double Radius { get; private set; }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be greater than zero.");
        Radius = radius;
    }

    /// <summary>
    /// Calculates the area of the circle using the formula πr².
    /// </summary>
    public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);

    /// <summary>
    /// Calculates the circumference of the circle using the formula 2πr.
    /// </summary>
    public double CalculatePerimeter() => 2 * Math.PI * Radius;

    /// <summary>
    /// Resizes the circle by multiplying the radius by the given factor.
    /// </summary>
    /// <param name="factor">The factor by which the circle is resized.</param>
    public void Resize(double factor)
    {
        if (factor <= 0)
            throw new ArgumentException("Resize factor must be greater than zero.");
        Radius *= factor;
    }
}

/// <summary>
/// Represents a Rectangle with area and perimeter calculations.
/// Implements <see cref="IShape"/> for calculations and <see cref="IResizable"/> for resizing capabilities.
/// </summary>
public class Rectangle : IShape, IResizable
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Width and Height must be greater than zero.");
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Calculates the area of the rectangle using the formula width × height.
    /// </summary>
    public double CalculateArea() => Width * Height;

    /// <summary>
    /// Calculates the perimeter of the rectangle using the formula 2(width + height).
    /// </summary>
    public double CalculatePerimeter() => 2 * (Width + Height);

    /// <summary>
    /// Resizes the rectangle by multiplying width and height by the given factor.
    /// </summary>
    /// <param name="factor">The factor by which the rectangle is resized.</param>
    public void Resize(double factor)
    {
        if (factor <= 0)
            throw new ArgumentException("Resize factor must be greater than zero.");
        Width *= factor;
        Height *= factor;
    }
}

/// <summary>
/// Represents a Triangle with area and perimeter calculations.
/// Implements <see cref="IShape"/> for standard shape calculations.
/// </summary>
public class Triangle : IShape
{
    public double SideA { get; private set; }
    public double SideB { get; private set; }
    public double SideC { get; private set; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("All sides must be greater than zero.");
        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            throw new ArgumentException("Invalid triangle sides.");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    /// <summary>
    /// Calculates the area of the triangle using Heron's formula.
    /// </summary>
    public double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    /// <summary>
    /// Calculates the perimeter of the triangle by summing all its sides.
    /// </summary>
    public double CalculatePerimeter() => SideA + SideB + SideC;
}
