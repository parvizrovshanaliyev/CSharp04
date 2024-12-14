---

# Beginner OOP Practice Tasks - `Car` Class

---

## **Task Objective**

By completing this task, you will:
1. Learn how to create and use classes.
2. Understand how to define and use properties.
3. Implement constructors to initialize objects with default and custom values.
4. Write methods to manipulate and display object data.

---

## **Step 1: Create the `Car` Class**

### **Requirements**
1. Define a `Car` class with the following properties:
   - **`Make`**: The manufacturer of the car (e.g., "Toyota").
     - Type: `string`
     - Default: `"Unknown"`
     - Validation: Must not be empty or null.
   - **`Model`**: The model of the car (e.g., "Corolla").
     - Type: `string`
     - Default: `"Unknown"`
     - Validation: Must not be empty or null.
   - **`Year`**: The year the car was made.
     - Type: `int`
     - Default: `2000`
     - Validation: Must be greater than `0`.
   - **`Price`**: The price of the car.
     - Type: `decimal`
     - Default: `10000.0m`
     - Validation: Must be greater than or equal to `0.0`.

2. Add the following **constructors**:
   - **Default Constructor**:
     - Initializes the `Make` to `"Unknown"`, `Model` to `"Unknown"`, `Year` to `2000`, and `Price` to `10000.0m`.
   - **Parameterized Constructor 1**:
     - Accepts `Make`, `Model`, and `Year` as parameters and sets a default value for `Price`.
   - **Parameterized Constructor 2**:
     - Accepts `Make`, `Model`, `Year`, and `Price` as parameters.

3. Implement the following **methods**:
   - **`DisplayDetails()`**:
     - Prints the car's details (`Make`, `Model`, `Year`, `Price`).
   - **`ApplyDiscount(decimal discountPercentage)`**:
     - Applies a discount to the car's price based on the given percentage (between `0` and `100`).
   - **`UpdatePrice(decimal newPrice)`**:
     - Changes the car's price to the specified value, ensuring it is non-negative.
   - **`AgeOfCar()`**:
     - Returns the age of the car based on the current year.

---

## **Step 2: Write the `Main` Method**

### **Instructions**
1. **Create a Default Car**:
   - Instantiate a `Car` object using the default constructor.
   - Display its details using `DisplayDetails()`.

2. **Create a Custom Car**:
   - Instantiate a `Car` object using the second constructor with a make, model, and year.
   - Display its details.

3. **Create a Fully Custom Car**:
   - Instantiate a `Car` object using the fully parameterized constructor with a make, model, year, and price.
   - Display its details.

4. **Test the Methods**:
   - Apply a discount to the price of a car.
   - Change the car’s price.
   - Display the age of the car.
   - Display the updated details after each change.

---

## **Expected Output**

```
=== Car Class Demonstration ===
Make: Unknown, Model: Unknown, Year: 2000, Price: $10,000.00
Make: Toyota, Model: Corolla, Year: 2015, Price: $10,000.00
Make: Tesla, Model: Model 3, Year: 2020, Price: $40,000.00
The price after applying 10% discount is: $36,000.00
The car's price has been updated to: $35,000.00
The car's age is: 4 years.
Make: Tesla, Model: Model 3, Year: 2020, Price: $35,000.00
```

---

### **What You Have Learned**
By completing this task, you have learned how to:
1. Create a class with properties and methods.
2. Implement constructors to initialize class objects.
3. Implement basic validation for properties.
4. Test the behavior of an object by invoking methods.

---
