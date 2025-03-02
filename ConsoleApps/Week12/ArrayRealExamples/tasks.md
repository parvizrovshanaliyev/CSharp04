# **📌 Real-World Array-Based Tasks Using Classes in Arrays**

This guide provides **real-world tasks** where **arrays store objects (instances of classes)**. Each task includes a **scenario, requirements, and implementation approach** to help students understand **object-oriented programming with arrays**.

---

## **1️⃣ Student Grade Management System 🎓**
### **📌 Scenario**
A university needs to track **multiple students** and their **grades**.

### **✅ Requirements**
- Create a **`Student` class** with:
  - `Name` (string)
  - `Grade` (int)
- Store **N students** in an **array of `Student` objects**.
- Implement functions to:
  - **Calculate** highest, lowest, and average grades.
  - **Sort students** by grade.
  - **Search** for a student by name.

### **🛠️ Implementation Approach**
- Create a **`Student` class** with `Name` and `Grade` properties.
- Use an **array of `Student` objects** in a `StudentManager` class.
- Implement methods for **sorting, searching, and calculating grades**.

---

## **2️⃣ Store Inventory Management 🛒**
### **📌 Scenario**
A **store** needs to track **products and prices**.

### **✅ Requirements**
- Create a **`Product` class** with:
  - `Name` (string)
  - `Price` (decimal)
- Store **N products** in an **array of `Product` objects**.
- Implement functions to:
  - **Find the most expensive and cheapest product**.
  - **Sort products by price**.
  - **Search for a product by name**.

### **🛠️ Implementation Approach**
- Define a `Product` class with `Name` and `Price` properties.
- Use an **array of `Product` objects** in a `StoreInventory` class.
- Implement **sorting, searching, and price analysis functions**.

---

## **3️⃣ Hospital Patient Monitoring System 🏥**
### **📌 Scenario**
A **hospital** wants to track **patient records** including temperature.

### **✅ Requirements**
- Create a **`Patient` class** with:
  - `Name` (string)
  - `Age` (int)
  - `Temperature` (double)
- Store **N patients** in an **array of `Patient` objects**.
- Implement functions to:
  - **Identify fever cases** (Temperature > 37.5°C).
  - **Sort patients by temperature**.
  - **Find a patient by name**.

### **🛠️ Implementation Approach**
- Define a `Patient` class with `Name`, `Age`, and `Temperature` properties.
- Store patient data in an **array of `Patient` objects** inside `HospitalRecords`.
- Implement **filtering, sorting, and searching functions**.

---

## **4️⃣ Movie Ticket Booking System 🎥**
### **📌 Scenario**
A **cinema** wants to manage **seat reservations**.

### **✅ Requirements**
- Create a **`Seat` class** with:
  - `Row` (int)
  - `Col` (int)
  - `IsBooked` (bool)
- Store **N×M seats** in a **2D array of `Seat` objects**.
- Implement functions to:
  - **Book a seat** by row & column.
  - **Display available seats**.

### **🛠️ Implementation Approach**
- Define a `Seat` class with `Row`, `Col`, and `IsBooked` properties.
- Use a **2D array of `Seat` objects** in `Cinema`.
- Implement **seat reservation and display functions**.

---

## **5️⃣ Weather Forecast System 🌦️**
### **📌 Scenario**
A **weather station** records **daily temperature readings**.

### **✅ Requirements**
- Create a **`WeatherData` class** with:
  - `Day` (int)
  - `Temperature` (double)
- Store **7 days of temperature readings** in an **array of `WeatherData` objects**.
- Implement functions to:
  - **Find hottest and coldest days**.
  - **Calculate average temperature**.
  - **Sort days by temperature**.

### **🛠️ Implementation Approach**
- Define a `WeatherData` class with `Day` and `Temperature` properties.
- Store weather data in an **array of `WeatherData` objects** inside `WeatherStation`.
- Implement **sorting, searching, and calculation methods**.

---

## **6️⃣ Shopping Cart System 🛍️**
### **📌 Scenario**
An **e-commerce platform** tracks items in a **shopping cart**.

### **✅ Requirements**
- Create a **`CartItem` class** with:
  - `ProductName` (string)
  - `Price` (decimal)
  - `Quantity` (int)
- Store **N items** in an **array of `CartItem` objects**.
- Implement functions to:
  - **Add items to cart**.
  - **Remove items from cart**.
  - **Calculate total price**.

### **🛠️ Implementation Approach**
- Define a `CartItem` class with `ProductName`, `Price`, and `Quantity`.
- Use an **array of `CartItem` objects** in `ShoppingCart`.
- Implement **functions for cart management**.

---

## **7️⃣ Stock Market Price Tracker 📈**
### **📌 Scenario**
A **financial platform** tracks **daily stock prices**.

### **✅ Requirements**
- Create a **`Stock` class** with:
  - `Date` (DateTime)
  - `Price` (decimal)
- Store **N stock price records** in an **array of `Stock` objects**.
- Implement functions to:
  - **Find highest and lowest prices**.
  - **Calculate average price**.
  - **Sort prices chronologically**.

### **🛠️ Implementation Approach**
- Define a `Stock` class with `Date` and `Price` properties.
- Store stock data in an **array of `Stock` objects** inside `StockMarketTracker`.
- Implement **sorting, searching, and price analysis functions**.

---

## **8️⃣ AI-Based Chatbot System 🤖**
### **📌 Scenario**
A chatbot answers **FAQs** using **predefined responses**.

### **✅ Requirements**
- Create a **`ChatbotResponse` class** with:
  - `Question` (string)
  - `Answer` (string)
- Store **N questions & responses** in an **array of `ChatbotResponse` objects**.
- Implement functions to:
  - **Match a question to its response**.
  - **Handle unknown questions**.

### **🛠️ Implementation Approach**
- Define a `ChatbotResponse` class with `Question` and `Answer` properties.
- Store chatbot data in an **array of `ChatbotResponse` objects** inside `Chatbot`.
- Implement **search logic to match user input**.

---

## **9️⃣ Library Book Management System 📚**
### **📌 Scenario**
A **library** tracks **books and availability**.

### **✅ Requirements**
- Create a **`Book` class** with:
  - `Title` (string)
  - `Author` (string)
  - `IsAvailable` (bool)
- Store **N books** in an **array of `Book` objects**.
- Implement functions to:
  - **View available books**.
  - **Borrow a book** (set `IsAvailable = false`).
  - **Return a book** (set `IsAvailable = true`).

### **🛠️ Implementation Approach**
- Define a `Book` class with `Title`, `Author`, and `IsAvailable` properties.
- Store book data in an **array of `Book` objects** inside `LibrarySystem`.
- Implement **functions for borrowing, returning, and displaying books**.

---

## **🚀 Summary**
✅ These **tasks use arrays to store objects** instead of primitive values.  
✅ They teach **object-oriented programming** while reinforcing **array operations**.  
✅ Covers **diverse real-world applications**, including **education, healthcare, finance, and AI**.  

---

## **🔥 Challenge Yourself!**
Try implementing:
✅ **A Bank Transaction History System**  
✅ **A Real-Time Sports Leaderboard Tracker**  
✅ **A Social Media "Trending Posts" Feature**  