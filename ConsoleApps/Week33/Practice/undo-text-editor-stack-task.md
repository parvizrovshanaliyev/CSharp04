Certainly! Here's the **improved version** of your task, with **clearer structure**, **more student-friendly explanations**, and a **step-by-step coding plan (without actual code)** to help students approach the project confidently from start to finish.

---

# 📝 Project Task: Undo Text Editor Using `Stack` and File Storage

---

### 🎯 Project Goal

Your mission is to create a **console-based text editor** in C# that behaves like a simple notepad with undo and file-saving capabilities.

This mini-editor should allow users to:

* ✏️ Type in lines of text
* 🔙 Undo the last line they typed
* 👀 View all current text
* 💾 Save text to a file when exiting
* 📂 Load saved text from the file when the app starts

> 💡 Imagine this as a mini version of Notepad that remembers your writing even after you close the program.

---

### 📚 What You Will Learn

By building this app, you’ll practice:

* ✅ Using a `Stack<string>` to manage undo behavior (LIFO logic)
* ✅ Reading and writing `.txt` files using file I/O
* ✅ Validating user input and handling edge cases
* ✅ Structuring a command-based console menu
* ✅ Managing app state between sessions (persistence)

---

### 🧩 How the Application Will Work

**When the app starts:**

* It checks if a file named `session.txt` exists
* If found, the app loads the previous text into a stack

**While the app is running:**

* The user can type new lines, undo the last entry, view all content, or clear everything
* All lines are managed using a `Stack` to allow undoing
* When the user chooses to exit, the stack content is saved back to `session.txt`

---

### 🖥️ Menu Structure (User Interface)

```
=== Simple Text Editor ===
1. Type new text
2. Undo last entry
3. View current text
4. Clear all
5. Save and exit
Enter your choice:
```

Each option triggers a different stack or file operation.

---

### ✅ Key Programming Concepts Covered

| Concept            | What You'll Practice                            |
| ------------------ | ----------------------------------------------- |
| `Stack<T>`         | Using a stack for undo operations (LIFO logic)  |
| File Handling      | Read from and write to a `.txt` file            |
| Exception Handling | Safely dealing with missing/empty files         |
| User Interaction   | Menu input, validation, and dynamic responses   |
| App State          | Saving and restoring user data between sessions |

---

### 🧭 Step-by-Step Coding Plan (No Code Yet)

Follow this outline to build your project in manageable steps:

1. **Create a Console App Project**
   Open Visual Studio or VS Code and create a new C# console application.

2. **Import Required Namespaces**
   You’ll need namespaces for collections (`Stack`) and file operations.

3. **Define Your Stack and File Path**
   Create a `Stack<string>` to hold the text, and define a constant for the file name.

4. **Load Existing File Content (if any)**
   Check if `session.txt` exists. If it does, read each line and push it onto the stack.

5. **Create the Main Menu Loop**
   Use a `while` loop to repeatedly show the menu and wait for user input.

6. **Handle Menu Options**
   Use a `switch` or `if` statements:

   * Option 1: Read user input and push it onto the stack
   * Option 2: Undo (pop) the top element
   * Option 3: Display all current text from the stack
   * Option 4: Clear the stack
   * Option 5: Save the stack to file and exit

7. **Add Input Validations**
   Ensure users don’t enter empty strings or duplicate consecutive lines.

8. **Save Data on Exit**
   Convert the stack to an array and write it to the file before quitting.

9. **Test Your Application**
   Try each feature:

   * Type multiple lines
   * Undo a few
   * Exit and reopen to confirm persistence

---

### 💡 Optional Bonus Challenges (If You’re Ready)

* 🕒 Add timestamps to each typed line
* 🗂️ Allow user to choose or name their save file
* 🚫 Prevent adding the same text twice in a row
* 🔁 Add redo functionality using a second stack

---

### 💬 Final Tips for Students

* Take one step at a time — don’t try to write everything at once.
* Use comments to label each section of your code.
* Test often: after every small change, run the app and check what works.
* Think about what happens if the user does something unexpected (e.g., undoes when nothing is typed).

> By finishing this project, you’ll simulate how **real applications** (like editors or IDEs) manage session memory, undo, and persistence.

---

## 🧪 Sample Output (What the App Looks Like When Running)

```plaintext
=== Simple Text Editor ===
1. Type new text
2. Undo last entry
3. View current text
4. Clear all
5. Save and exit
Enter your choice: 1

Enter new line: This is my first line.
✅ Text added.

Press any key to continue...

=== Simple Text Editor ===
1. Type new text
2. Undo last entry
3. View current text
4. Clear all
5. Save and exit
Enter your choice: 1

Enter new line: This is my second line.
✅ Text added.

Press any key to continue...

=== Simple Text Editor ===
1. Type new text
2. Undo last entry
3. View current text
4. Clear all
5. Save and exit
Enter your choice: 3

📋 Current text (most recent first):
This is my second line.
This is my first line.

Press any key to continue...

=== Simple Text Editor ===
1. Type new text
2. Undo last entry
3. View current text
4. Clear all
5. Save and exit
Enter your choice: 2

✅ Removed: This is my second line.

Press any key to continue...

=== Simple Text Editor ===
1. Type new text
2. Undo last entry
3. View current text
4. Clear all
5. Save and exit
Enter your choice: 3

📋 Current text (most recent first):
This is my first line.

Press any key to continue...

=== Simple Text Editor ===
1. Type new text
2. Undo last entry
3. View current text
4. Clear all
5. Save and exit
Enter your choice: 5

💾 Changes saved. Exiting...
```

---

### 📝 Notes:

* Text is displayed in **LIFO order**: the last typed line appears first.
* Undo removes the most recent line.
* File saving happens automatically when option `5` is selected.
* When you run the program again, previous content is **restored from `session.txt`**.

