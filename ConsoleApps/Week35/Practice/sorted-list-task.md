# Project Task: Phone Book Management System Using `SortedList`

---

### Project Goal

Your mission is to create a **console-based phone book management system** in C# that uses `SortedList` to maintain contact records sorted by their names.

This system should allow users to:

* Add new contacts
* Update contact information
* Search for contacts by name
* View all contacts sorted alphabetically
* Delete contacts
* Save contacts to a file
* Load saved contacts when the app starts

> Think of this as a simplified version of your phone's contact list!

---

### What You Will Learn

By building this app, you'll practice:

* Using `SortedList` to maintain alphabetically sorted contacts
* Working with binary search for efficient lookups
* Reading and writing `.txt` files using file I/O
* Structuring a command-based console menu
* Managing contact data between sessions

---

### How the Application Will Work

**When the app starts:**

* It checks if a file named `phonebook.txt` exists
* If found, the app loads the previous contacts into a SortedList

**While the app is running:**

* Users can add new contacts, update information, search for contacts, or view all contacts
* Each contact record has a name, phone number, and email
* Records are automatically sorted by name
* When the user chooses to exit, the records are saved to `phonebook.txt`

---

### Menu Structure (User Interface)

```
=== Phone Book Management System ===
1. Add new contact
2. Update contact
3. Search contact by name
4. View all contacts
5. Delete contact
6. Save and exit
Enter your choice:
```

Each option triggers different SortedList operations.

---

### Key Programming Concepts Covered

| Concept            | What You'll Practice                            |
| ------------------ | ----------------------------------------------- |
| `SortedList`       | Using sorted collections for efficient lookups  |
| Binary Search      | Understanding how SortedList uses binary search |
| File Handling      | Read from and write to a `.txt` file            |
| Exception Handling | Safely dealing with invalid inputs and files    |
| User Interaction   | Menu input, validation, and dynamic responses    |

---

### Step-by-Step Coding Plan

Follow this outline to build your project in manageable steps:

1. **Create a Console App Project**
   Open Visual Studio or VS Code and create a new C# console application.

2. **Import Required Namespaces**
   You'll need namespaces for collections (`SortedList`) and file operations.

3. **Define Your SortedList and File Path**
   Create a `SortedList<string, Contact>` to hold contact records.

4. **Create Contact Class**
   ```csharp
   public class Contact
   {
       public string Name { get; set; }
       public string PhoneNumber { get; set; }
       public string Email { get; set; }
       public string Address { get; set; }
       public DateTime LastModified { get; set; }
   }
   ```

5. **Load Existing Records (if any)**
   Check if `phonebook.txt` exists. If it does, read each line and add to SortedList.

6. **Create the Main Menu Loop**
   Use a `while` loop to repeatedly show the menu and wait for user input.

7. **Handle Menu Options**
   Use a `switch` or `if` statements:

   * Option 1: Read contact details and add to SortedList
   * Option 2: Update existing contact's information
   * Option 3: Search for contact by name
   * Option 4: Display all contacts
   * Option 5: Delete a contact
   * Option 6: Save records to file and exit

8. **Add Input Validations**
   Ensure users don't enter invalid phone numbers or email addresses.

9. **Save Data on Exit**
   Convert the SortedList to a format suitable for file storage.

10. **Test Your Application**
    Try each feature:

    * Add multiple contacts
    * Update contact information
    * Search for contacts
    * Delete contacts
    * Exit and reopen to confirm persistence

---

### Optional Bonus Challenges

* Add contact categories (Family, Friends, Work, etc.)
* Implement contact favorites
* Add contact search by phone number
* Add contact groups
* Implement contact import/export functionality

---

### Final Tips for Students

* Take one step at a time — don't try to write everything at once.
* Use comments to label each section of your code.
* Test often: after every small change, run the app and check what works.
* Think about what happens if the user tries to add duplicate names.

> By finishing this project, you'll understand how **real-world systems** use sorted collections for efficient contact management.

---

## Sample Output (What the App Looks Like When Running)

```plaintext
=== Phone Book Management System ===
1. Add new contact
2. Update contact
3. Search contact by name
4. View all contacts
5. Delete contact
6. Save and exit
Enter your choice: 1

Enter contact name: John Smith
Enter phone number: +1-555-0123
Enter email: john.smith@email.com
Enter address: 123 Main St
Contact added successfully.

Press any key to continue...

=== Phone Book Management System ===
1. Add new contact
2. Update contact
3. Search contact by name
4. View all contacts
5. Delete contact
6. Save and exit
Enter your choice: 1

Enter contact name: Alice Johnson
Enter phone number: +1-555-0124
Enter email: alice.j@email.com
Enter address: 456 Oak Ave
Contact added successfully.

Press any key to continue...

=== Phone Book Management System ===
1. Add new contact
2. Update contact
3. Search contact by name
4. View all contacts
5. Delete contact
6. Save and exit
Enter your choice: 4

Phone Book Contacts (Sorted by Name):
Name: Alice Johnson
Phone: +1-555-0124
Email: alice.j@email.com
Address: 456 Oak Ave
Last Modified: 2024-03-15 14:30:00

Name: John Smith
Phone: +1-555-0123
Email: john.smith@email.com
Address: 123 Main St
Last Modified: 2024-03-15 14:25:00

Press any key to continue...

=== Phone Book Management System ===
1. Add new contact
2. Update contact
3. Search contact by name
4. View all contacts
5. Delete contact
6. Save and exit
Enter your choice: 3

Enter name to search: John Smith
Found contact:
Name: John Smith
Phone: +1-555-0123
Email: john.smith@email.com
Address: 123 Main St
Last Modified: 2024-03-15 14:25:00

Press any key to continue...

=== Phone Book Management System ===
1. Add new contact
2. Update contact
3. Search contact by name
4. View all contacts
5. Delete contact
6. Save and exit
Enter your choice: 6

Changes saved. Exiting...
```

---

### Notes:

* Records are automatically sorted by name using SortedList
* Binary search is used internally for efficient lookups
* File saving happens automatically when option `6` is selected
* When you run the program again, previous records are **restored from `phonebook.txt`**
* The system demonstrates the efficiency of SortedList for maintaining sorted data
