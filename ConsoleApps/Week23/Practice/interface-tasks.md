# **Tasks for Mastering Interfaces in C#**

## Task 1: Understanding Interfaces
- **Objective:** Understand the concept of interfaces and their usage in C#.
- **Description:** Learn about interfaces, their purpose, and when to use them.
- **Resources:** 
  - Microsoft Docs: Interfaces in C#
  - C# Programming Guide: Interface Members
- **Key Concepts to Learn:**
  1. What are interfaces?
  2. Why use interfaces?
  3. Interface implementation
  4. Multiple interface inheritance
  5. Interface segregation principle

## Task 2: Logging System
- **Objective:** Implement a basic logging system using interfaces.
- **Instructions:**
  1. Create an interface `ILogger` with methods for:
     - Logging information messages
     - Logging warning messages
     - Logging error messages
     - Retrieving latest logs
  2. Implement three different logger classes:
     - ConsoleLogger: Writes to console with different colors
     - FileLogger: Saves to text file with timestamps
     - DatabaseLogger: Stores in memory collection
  3. Add these features to each implementation:
     - Message formatting with timestamps
     - Log level support
     - Log rotation or cleanup
  4. Create a test program demonstrating all loggers

## Task 3: Shape Calculator
- **Objective:** Create a shape calculation system using interfaces.
- **Instructions:**
  1. Create two interfaces:
     - IShape: For basic shape calculations
     - IResizable: For shapes that can be resized
  2. Implement concrete shape classes:
     - Circle: Area and circumference calculations
     - Rectangle: Area and perimeter calculations
     - Triangle: Area and perimeter calculations
  3. Add validation features:
     - Dimension validation
     - Triangle inequality check
     - Special case handling
  4. Create a shape processor class

## Task 4: Media Player
- **Objective:** Build a simple media player system using interfaces.
- **Instructions:**
  1. Create two main interfaces:
     - IMediaPlayer: Basic playback controls
     - IPlaylist: Playlist management
  2. Implement different player types:
     - AudioPlayer: For audio playback
     - VideoPlayer: For video playback
     - StreamingPlayer: For streaming content
  3. Include these features:
     - Playback status tracking
     - Playlist management
     - Basic error handling
  4. Create a console interface for testing

## Task 5: Shopping Cart System
- **Objective:** Implement a basic e-commerce shopping cart using interfaces.
- **Instructions:**
  1. Create two main interfaces:
     - IShoppingCart: Cart operations
     - IProduct: Product properties
  2. Implement different product types:
     - Basic Product: Standard items
     - Digital Product: Downloadable items
     - Physical Product: Items requiring shipping
  3. Add cart features:
     - Tax calculation
     - Discount application
     - Stock management
  4. Create a simple ordering system

## Requirements for All Tasks
1. Follow C# naming conventions
2. Add XML documentation comments
3. Implement proper error handling
4. Create console-based testing programs
5. Use meaningful names
6. Keep interfaces focused and small

## Learning Objectives
- Understanding interface basics
- Implementing multiple interfaces
- Working with interface inheritance
- Using interfaces for loose coupling
- Handling errors appropriately
- Writing clean, maintainable code

## Additional Challenges
- Add unit tests
- Implement logging
- Add configuration options
- Create file I/O operations
- Practice with collections

## Tips for Success
- Start with simple implementations
- Test each feature as you add it
- Use meaningful names
- Keep interfaces small and focused
- Document your code
- Handle edge cases
- Ask for help when stuck

Good luck with your interface practice tasks!


