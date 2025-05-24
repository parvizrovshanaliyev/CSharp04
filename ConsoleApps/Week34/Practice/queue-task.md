# 📝 Project Task: Print Job Management System Using `Queue`

---

### 🎯 Project Goal

Your mission is to create a **console-based print job management system** in C# that simulates how a printer handles multiple documents in a queue.

This system should allow users to:

* 📄 Add new print jobs to the queue
* 🖨️ Process (print) jobs in order
* 👀 View all pending print jobs
* ⏱️ Show estimated wait time
* 💾 Save print queue to a file
* 📂 Load saved print queue when the app starts

> 💡 Think of this as a simplified version of how your computer's printer queue works!

---

### 📚 What You Will Learn

By building this app, you'll practice:

* ✅ Using a `Queue<string>` to manage print jobs (FIFO logic)
* ✅ Reading and writing `.txt` files using file I/O
* ✅ Working with timestamps and wait time calculations
* ✅ Structuring a command-based console menu
* ✅ Managing print queue state between sessions

---

### 🧩 How the Application Will Work

**When the app starts:**

* It checks if a file named `printqueue.txt` exists
* If found, the app loads the previous print jobs into a queue

**While the app is running:**

* Users can add new print jobs, process jobs, view the queue, or clear it
* Each print job has a name and estimated print time
* Jobs are processed in the order they were added (FIFO)
* When the user chooses to exit, the queue content is saved to `printqueue.txt`

---

### 🖥️ Menu Structure (User Interface)

```
=== 🖨️ Print Job Management System ===
1. Add new print job
2. Process next print job
3. View all pending jobs
4. Show estimated wait time
5. Clear print queue
6. Save and exit
Enter your choice:
```

Each option triggers a different queue or file operation.

---

### ✅ Key Programming Concepts Covered

| Concept            | What You'll Practice                            |
| ------------------ | ----------------------------------------------- |
| `Queue<T>`         | Using a queue for print job management (FIFO)   |
| File Handling      | Read from and write to a `.txt` file            |
| Exception Handling | Safely dealing with empty queues and files      |
| User Interaction   | Menu input, validation, and dynamic responses    |
| Time Management    | Calculating wait times and processing durations  |

---

### 🧭 Step-by-Step Coding Plan (No Code Yet)

Follow this outline to build your project in manageable steps:

1. **Create a Console App Project**
   Open Visual Studio or VS Code and create a new C# console application.

2. **Import Required Namespaces**
   You'll need namespaces for collections (`Queue`) and file operations.

3. **Define Your Queue and File Path**
   Create a `Queue<string>` to hold print jobs, and define a constant for the file name.

4. **Load Existing Queue Content (if any)**
   Check if `printqueue.txt` exists. If it does, read each line and enqueue it.

5. **Create the Main Menu Loop**
   Use a `while` loop to repeatedly show the menu and wait for user input.

6. **Handle Menu Options**
   Use a `switch` or `if` statements:

   * Option 1: Read job details and enqueue
   * Option 2: Process (dequeue) the next job
   * Option 3: Display all pending jobs
   * Option 4: Calculate and show wait time
   * Option 5: Clear the queue
   * Option 6: Save the queue to file and exit

7. **Add Input Validations**
   Ensure users don't enter empty job names or invalid print times.

8. **Save Data on Exit**
   Convert the queue to an array and write it to the file before quitting.

9. **Test Your Application**
   Try each feature:

   * Add multiple print jobs
   * Process jobs in order
   * Exit and reopen to confirm persistence

---

### 💡 Optional Bonus Challenges (If You're Ready)

* 🎨 Add different print job priorities
* ⏰ Show estimated completion time for each job
* 🔄 Add ability to cancel specific jobs
* 📊 Display queue statistics (average wait time, total jobs processed)

---

### 💬 Final Tips for Students

* Take one step at a time — don't try to write everything at once.
* Use comments to label each section of your code.
* Test often: after every small change, run the app and check what works.
* Think about what happens if the user tries to process jobs when the queue is empty.

> By finishing this project, you'll understand how **real-world systems** manage queues of tasks, like print spoolers or job schedulers.

---

## 🧪 Sample Output (What the App Looks Like When Running)

```plaintext
=== 🖨️ Print Job Management System ===
1. Add new print job
2. Process next print job
3. View all pending jobs
4. Show estimated wait time
5. Clear print queue
6. Save and exit
Enter your choice: 1

Enter job name: Document1.pdf
Enter estimated print time (minutes): 2
✅ Print job added to queue.

Press any key to continue...

=== 🖨️ Print Job Management System ===
1. Add new print job
2. Process next print job
3. View all pending jobs
4. Show estimated wait time
5. Clear print queue
6. Save and exit
Enter your choice: 1

Enter job name: Report.docx
Enter estimated print time (minutes): 5
✅ Print job added to queue.

Press any key to continue...

=== 🖨️ Print Job Management System ===
1. Add new print job
2. Process next print job
3. View all pending jobs
4. Show estimated wait time
5. Clear print queue
6. Save and exit
Enter your choice: 3

📋 Pending Print Jobs:
1. Document1.pdf (2 minutes)
2. Report.docx (5 minutes)

Press any key to continue...

=== 🖨️ Print Job Management System ===
1. Add new print job
2. Process next print job
3. View all pending jobs
4. Show estimated wait time
5. Clear print queue
6. Save and exit
Enter your choice: 2

🖨️ Processing: Document1.pdf
✅ Print job completed!

Press any key to continue...

=== 🖨️ Print Job Management System ===
1. Add new print job
2. Process next print job
3. View all pending jobs
4. Show estimated wait time
5. Clear print queue
6. Save and exit
Enter your choice: 4

⏱️ Estimated wait time: 5 minutes

Press any key to continue...

=== 🖨️ Print Job Management System ===
1. Add new print job
2. Process next print job
3. View all pending jobs
4. Show estimated wait time
5. Clear print queue
6. Save and exit
Enter your choice: 6

💾 Changes saved. Exiting...
```

---

### 📝 Notes:

* Jobs are processed in **FIFO order**: first job added is processed first.
* Wait time is calculated based on the sum of all pending jobs' print times.
* File saving happens automatically when option `6` is selected.
* When you run the program again, previous print jobs are **restored from `printqueue.txt`**.
