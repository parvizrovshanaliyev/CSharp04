namespace OOP.ClassAndObject;

/// <summary>
/// Represents a Car with fields, properties, constructors, and methods.
/// Demonstrates constructor overloading and various property types.
/// </summary>
public class Car
{

    // Private field for the read-only property
    private readonly string _model;

    // Read-Only Property
    public string Model => _model;

    public string Model1 { get; }

    public string Model2
    {
        get
        {
            return _model;
        }
    }

    // Auto-implemented property
    private string _color;
    public string Color
    {
        get
        {
            return _color;
        }
        set
        {
            _color = value;
        }
    }

    public string Color1 { get; set; }

    

    // Property with validation
    private int speed;
    public int Speed
    {
        get { return speed; }
        set
        {
            if (value >= 0) speed = value;
            else Console.WriteLine("Speed cannot be negative.");
        }
    }

    

    // Computed Property
    public string Description => $"{Model} - {Color}";

    // Write-Only Property
    private string _secret;
    public string Secret
    {
        set { _secret = value; } // Can only be set, not read
    }
   

    // Default constructor
    public Car()
    {
        _model = "Unknown";
        Color = "White";
        Speed = 0;
        Console.WriteLine("Default constructor called: Car initialized with default values.");
    }

    // Constructor with model and color
    public Car(string model, string color)
    {
       _model = model;
        this.Color = color;
        Speed = 0; // Default speed
        Console.WriteLine($"Constructor called: Car initialized with Model: {model}, Color: {color}, Speed: {Speed}");
    }

    // Fully parameterized constructor
    public Car(string model, string color, int speed):this(model, color)
    {
        this._model = model;
        this.Color = color;
        this.Speed = speed;
        Console.WriteLine($"Constructor called: Car initialized with Model: {model}, Color: {color}, Speed: {speed}");
    }

    // Method to display details
    public void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}, Color: {Color}, Speed: {Speed} km/h, Description: {Description}");
    }

    // Method to accelerate
    public void Accelerate(int increment)
    {
        Speed += increment;
        Console.WriteLine($"{Model} accelerated by {increment} km/h. New Speed: {Speed} km/h");
    }

    // Method to brake
    public void Brake(int decrement)
    {
        Speed -= decrement;
        if (Speed < 0) Speed = 0; // Prevent negative speed
        Console.WriteLine($"{Model} slowed down by {decrement} km/h. New Speed: {Speed} km/h");
    }
}