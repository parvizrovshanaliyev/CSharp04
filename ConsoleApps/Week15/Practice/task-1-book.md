---

# Beginner OOP Practice Tasks - `Book` Class 

---

## **Task Objective**

By completing this task, you will:
1. Learn how to create and use classes.
2. Understand how to define and use properties.
3. Implement constructors to initialize objects with default and custom values.
4. Write methods to manipulate and display object data.

---

## **Step 1: Create the `Book` Class**

### **Requirements**
1. Define a `Book` class with the following properties:
   - **`Title`**: The title of the book.
     - Type: `string`
     - Default: `"Untitled"`
     - Validation: Must not be empty or null.
   - **`Author`**: The author of the book.
     - Type: `string`
     - Default: `"Unknown"`
     - Validation: Must not be empty or null.
   - **`YearPublished`**: The year the book was published.
     - Type: `int`
     - Default: `2000`
     - Validation: Must be a positive year (greater than 0).
   - **`Price`**: The price of the book.
     - Type: `decimal`
     - Default: `0.0`
     - Validation: Must be greater than or equal to `0.0`.

2. Add the following **constructors**:
   - **Default Constructor**:
     - Initializes the `Title` to `"Untitled"`, `Author` to `"Unknown"`, `YearPublished` to `2000`, and `Price` to `0.0`.
   - **Parameterized Constructor 1**:
     - Accepts `Title`, `Author`, and `YearPublished` as parameters and sets default value for `Price`.
   - **Parameterized Constructor 2**:
     - Accepts `Title`, `Author`, `YearPublished`, and `Price` as parameters.

3. Implement the following **methods**:
   - **`DisplayDetails()`**:
     - Prints the book's details (`Title`, `Author`, `YearPublished`, `Price`).
   - **`DiscountPrice(decimal discountPercentage)`**:
     - Applies a discount to the book's price based on the given percentage. The discount should be between `0` and `100` percent.
   - **`ChangePrice(decimal newPrice)`**:
     - Changes the book's price to the specified value, ensuring it is non-negative.
   - **`UpdateYearPublished(int newYear)`**:
     - Updates the year the book was published, ensuring it is greater than 0.

---

## **Step 2: Write the `Main` Method**

### **Instructions**
1. **Create a Default Book**:
   - Instantiate a `Book` object using the default constructor.
   - Display its details using `DisplayDetails()`.

2. **Create a Custom Book**:
   - Instantiate a `Book` object using the second constructor with a title, author, and year published.
   - Display its details.

3. **Create a Fully Custom Book**:
   - Instantiate a `Book` object using the fully parameterized constructor with a title, author, year published, and price.
   - Display its details.

4. **Test the Methods**:
   - Apply a discount to the price of a book.
   - Change a book’s price.
   - Update a book’s year of publication.
   - Display the updated details after each change.

---

## **Expected Output**

```
=== Book Class Demonstration ===
Title: Untitled, Author: Unknown, Year Published: 2000, Price: $0.00
Title: C# Programming, Author: John Doe, Year Published: 2020, Price: $0.00
Title: Advanced C# Programming, Author: Jane Smith, Year Published: 2023, Price: $49.99
The price after 10% discount is: $44.99
The price has been updated to: $39.99
The year of publication has been updated to: 2024
Title: Advanced C# Programming, Author: Jane Smith, Year Published: 2024, Price: $39.99
```

---

### **What You Have Learned**
By completing this task, you have learned how to:
1. Create a class with properties and methods.
2. Implement constructors to initialize class objects.
3. Define basic validation in methods.
4. Test object behavior by invoking methods and displaying results.

---