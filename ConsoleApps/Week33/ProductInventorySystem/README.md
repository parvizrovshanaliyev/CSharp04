# 🛒 Product Inventory System

## 📋 Project Overview
The Product Inventory System is a C# console application that manages product inventory using a Hashtable data structure. The system allows users to perform various operations on product data while following Object-Oriented Programming (OOP) principles and SOLID design patterns.

## 🎯 Features
- Add new products with unique codes
- View all products in inventory
- Search products by code
- Update product names
- Remove products
- Check product existence by name
- Display total product count

## 🏗️ Architecture

### Project Structure
```
ProductInventorySystem/
├── Constants/
│   └── MenuOptions.cs         # Menu options and constant messages
├── Models/
│   └── Product.cs            # Product entity model
├── Repositories/
│   ├── IProductRepository.cs # Repository interface
│   └── ProductRepository.cs  # Hashtable-based implementation
├── Services/
│   ├── IProductService.cs    # Service interface
│   └── ProductService.cs     # Business logic implementation
├── Utils/
│   └── ConsoleHelper.cs      # Console utility methods
└── Program.cs                # Main application entry point
```

### Design Patterns
1. **Repository Pattern**
   - Abstracts data access
   - Uses Hashtable for storage
   - Provides CRUD operations

2. **Service Layer Pattern**
   - Implements business logic
   - Handles validation
   - Manages transactions

3. **SOLID Principles**
   - **Single Responsibility**: Each class has one purpose
   - **Open/Closed**: Extensible through interfaces
   - **Liskov Substitution**: Proper inheritance hierarchy
   - **Interface Segregation**: Focused interfaces
   - **Dependency Inversion**: Dependencies through abstractions

## 💻 Technical Implementation

### Data Structure
- Uses `Hashtable` for O(1) lookup performance
- Product code as key
- Product object as value

### Key Components

#### Product Model
```csharp
public class Product
{
    public string Code { get; }
    public string Name { get; }
    // Constructor and validation
}
```

#### Repository Interface
```csharp
public interface IProductRepository
{
    bool Add(Product product);
    ICollection GetAll();
    Product GetByCode(string code);
    // Other CRUD operations
}
```

#### Service Layer
```csharp
public interface IProductService
{
    bool AddProduct(string code, string name);
    ICollection GetAllProducts();
    // Business operations
}
```

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or VS Code

### Installation
1. Clone the repository
2. Open the solution in Visual Studio
3. Build the project
4. Run the application

### Usage
1. Launch the application
2. Use the menu to select operations:
   - 1: Add new product
   - 2: View all products
   - 3: Search product
   - 4: Update product
   - 5: Remove product
   - 6: Check product existence
   - 7: Show product count
   - 8: Exit

## 🧪 Testing
The system includes built-in validation:
- Input validation for all user entries
- Duplicate code checking
- Empty input handling
- Error message display

## 🔄 Error Handling
- Graceful error handling for all operations
- User-friendly error messages
- Input validation at all levels
- Exception handling in service layer

## 📝 Code Quality Features
- XML documentation for all classes and methods
- Consistent naming conventions
- Clean code practices
- Proper separation of concerns
- Comprehensive error handling
- Input validation
- User-friendly interface

## 🔮 Future Improvements
1. **Data Persistence**
   - Add file-based storage
   - Implement database integration

2. **Enhanced Features**
   - Product categories
   - Price management
   - Stock tracking
   - Search by multiple criteria

3. **UI Improvements**
   - Color-coded output
   - Better formatting
   - Progress indicators

4. **Performance**
   - Caching mechanism
   - Batch operations
   - Optimized searches

## 📚 Learning Points
1. **C# Concepts**
   - Hashtable usage
   - Interface implementation
   - Exception handling
   - Console I/O

2. **Design Patterns**
   - Repository pattern
   - Service layer pattern
   - SOLID principles

3. **Best Practices**
   - Code organization
   - Error handling
   - Input validation
   - Documentation

## 🔗 References
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Hashtable Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable)
- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)

## 🤝 Contributing
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

## 👥 Authors
- Your Name - Initial work

## 🙏 Acknowledgments
- Thanks to all contributors
- Inspired by real-world inventory systems 