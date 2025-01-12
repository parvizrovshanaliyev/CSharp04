# **Tasks for Mastering Inheritance in C#**

---

## **1. Exploring Access Modifiers**

### Task:
- Create a `LibraryItem` class with:
  - `private string ItemCode`
  - `protected string Title`
  - `public string Author`
- Create a `Book` class that inherits `LibraryItem` and:
  - Prints accessible members of the base class.
  - Sets and retrieves the values of accessible members.
- Create a `Magazine` class outside the `LibraryItem` hierarchy and attempt to access the members.
- Document which members are accessible and why.

---

## **2. Basic Inheritance Implementation**

### Task:
- Create a `Device` class with the following members:
  - `string Manufacturer`
  - `void DisplayManufacturer()` that prints the manufacturer.
- Create a `Mobile` class that inherits from `Device` and adds:
  - `string Model`
  - `void DisplayDetails()` that prints the manufacturer and model.
- Create a `Tablet` class that also inherits from `Device` and adds:
  - `bool HasStylus`
  - `void DisplayTabletDetails()` to print all the details.

---

## **3. Method Overriding**

### Task:
- Create a `Notification` class with a `virtual` method `Send()` that prints `"Sending generic notification..."`.
- Create an `EmailNotification` class that overrides `Send()` to print `"Sending email notification..."`.
- Create an `SMSNotification` class that overrides `Send()` to print `"Sending SMS notification..."`.
- Use a list of `Notification` objects to demonstrate polymorphism by calling `Send()`.

---

## **4. Constructor Chaining with `base`**

### Task:
- Create a `Building` class with:
  - A constructor that takes and prints the building type (e.g., "Residential" or "Commercial").
- Create an `Apartment` class that inherits `Building` and has:
  - A constructor that accepts and prints the number of floors.
  - Use `base` to call the constructor of the `Building` class.
- Test by creating objects of `Apartment` with different parameters.

---

## **5. Multi-Level Inheritance**

### Task:
- Create an `Animal` class with:
  - A method `Move()` that prints `"The animal is moving."`
- Create a `Bird` class that inherits `Animal` and adds:
  - A method `Fly()` that prints `"The bird is flying."`
- Create a `Parrot` class that inherits `Bird` and adds:
  - A method `Talk()` that prints `"The parrot is talking."`
- Test the methods by creating an object of `Parrot` and calling all available methods.

---

## **6. Real-World Inheritance Example**

### Task:
- Create a `Person` base class with:
  - `string Name`
  - `int Age`
  - A method `GetInfo()` that prints the name and age.
- Create a `Doctor` class that inherits `Person` and adds:
  - `string Specialty`
  - A method `GetDoctorDetails()` that prints all the details.
- Create an `Engineer` class that inherits `Person` and adds:
  - `string Field`
  - A method `GetEngineerDetails()` that prints all the details.

---

## **7. Composition vs Inheritance**

### Task:
- Create a `Screen` class with a method `ShowResolution()` that prints `"Resolution: 1920x1080"`.
- Create a `Laptop` class that uses composition to include a `Screen` object and calls its method.
- Create another class `Desktop` that inherits `Screen` and uses the method directly.
- Compare the benefits of using composition and inheritance by writing a short reflection.

---

## **Deliverables**

1. **Code**: Submit your C# implementations for each task.
2. **Reflection**: Write a short paragraph summarizing your learning from each task.
3. **Diagrams**: Provide UML diagrams or visual representations for multi-level inheritance and composition vs inheritance.

---

### **Additional Notes**
- Ensure your code is well-documented and uses meaningful variable names.
- Test your implementations thoroughly to understand edge cases and behaviors in inheritance.
- Focus on the key differences between inheritance and composition and when to use each.

---