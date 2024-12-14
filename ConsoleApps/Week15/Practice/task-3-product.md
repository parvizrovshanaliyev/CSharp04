---

# Beginner OOP Practice Tasks - `Product` Class

---

## **Task Objective**

By completing this task, you will:
1. Learn how to create and use classes.
2. Understand how to define and use properties.
3. Implement constructors to initialize objects with default and custom values.
4. Write methods to manipulate and display object data.

---

## **Step 1: Create the `Product` Class**

### **Requirements**

1. Define a `Product` class with the following properties:
   - **`Name`**: The name of the product.
     - Type: `string`
     - Default: `"Unnamed Product"`
     - Validation: Must not be empty or null.
   - **`Category`**: The category of the product.
     - Type: `string`
     - Default: `"General"`
     - Validation: Must not be empty or null.
   - **`Price`**: The price of the product.
     - Type: `decimal`
     - Default: `0.0`
     - Validation: Must be greater than or equal to `0.0`.
   - **`Stock`**: The stock quantity of the product.
     - Type: `int`
     - Default: `0`
     - Validation: Must not be negative.

2. Add the following **constructors**:
   - **Default Constructor**:
     - Initializes the `Name` to `"Unnamed Product"`, `Category` to `"General"`, `Price` to `0.0`, and `Stock` to `0`.
   - **Parameterized Constructor 1**:
     - Accepts `Name` and `Category` as parameters and sets default values for `Price` and `Stock`.
   - **Parameterized Constructor 2**:
     - Accepts `Name`, `Category`, `Price`, and `Stock` as parameters.

3. Implement the following **methods**:
   - **`DisplayDetails()`**:
     - Prints the product's details (`Name`, `Category`, `Price`, `Stock`).
   - **`ApplyDiscount(decimal discountPercentage)`**:
     - Applies a discount to the product's price based on the given percentage. The discount should be between `0` and `100` percent.
   - **`ChangePrice(decimal newPrice)`**:
     - Changes the product's price to the specified value, ensuring it is non-negative.
   - **`UpdateStock(int quantity)`**:
     - Updates the stock quantity by adding the given number of items, ensuring the stock does not become negative.

---

## **Step 2: Write the `Main` Method**

### **Instructions**

1. **Create a Default Product**:
   - Instantiate a `Product` object using the default constructor.
   - Display its details using `DisplayDetails()`.

2. **Create a Custom Product**:
   - Instantiate a `Product` object using the second constructor with a name and category.
   - Display its details.

3. **Create a Fully Custom Product**:
   - Instantiate a `Product` object using the fully parameterized constructor with a name, category, price, and stock quantity.
   - Display its details.

4. **Test the Methods**:
   - Apply a discount to the price of a product.
   - Change a product’s price.
   - Add stock to the product.
   - Display the updated details after each change.

---

## **Expected Output**

```
=== Product Class Demonstration ===
Name: Unnamed Product, Category: General, Price: $0.00, Stock: 0
Name: Smartphone, Category: Electronics, Price: $0.00, Stock: 0
Name: Laptop, Category: Electronics, Price: $999.99, Stock: 10
The price after a 10% discount is: $899.99
The price has been updated to: $799.99
10 units have been added to stock. Current stock: 20
Name: Laptop, Category: Electronics, Price: $799.99, Stock: 20
```

---

### **What You Have Learned**
By completing this task, you have learned how to:
1. Create a class with properties and methods.
2. Implement constructors to initialize class objects.
3. Define basic validation in methods.
4. Test object behavior by invoking methods and displaying results.

---