## 📝 Task: Product Inventory System using `Hashtable`

### 🎯 Objective:

Build a **console-based C# application** that manages a store's product inventory using a `Hashtable`.

Each product will be stored with:

* `ProductCode` as the **key** (e.g., `"P001"`)
* `ProductName` as the **value** (e.g., `"Wireless Mouse"`)

---

### 📚 Requirements:

1. **Create a `Hashtable`** to store product code → product name.
2. Implement the following operations:

   * ➕ Add new product (with code and name)
   * 📋 View all products
   * 🔍 Search product by code
   * ✏️ Update product name by code
   * ❌ Remove product by code
   * 🔢 Show total number of products

---

### 💡 Bonus Features:

* 🧪 Check if a product name exists using `ContainsValue`
* 🔁 Wrap all operations in a loop with a numbered menu
* ✨ Sort product codes alphabetically before display
* ✅ Validate inputs: prevent empty or duplicate codes

---

### 🧪 Sample Console Menu:

```
=== 🛒 Product Inventory System ===
1. Add new product
2. View all products
3. Search product by code
4. Update product name
5. Remove product
6. Check if product exists by name
7. Show product count
8. Exit
Enter your choice: _
```

---

### ✅ Example Behavior

```
Enter Product Code: P001
Enter Product Name: Wireless Mouse
✅ Product added!

Enter Product Code to search: P002
❌ Product not found.

Enter Product Code to update: P001
Enter New Name: Bluetooth Mouse
✅ Product updated!
```

---

### 🔨 Concepts Practiced

| Concept            | Learning Purpose                           |
| ------------------ | ------------------------------------------ |
| `Hashtable`        | Use key-value data structure for inventory |
| `ContainsKey`      | Prevent duplicate codes, verify existence  |
| `Remove`, `Clear`  | Modify collection content                  |
| `foreach` + `Keys` | Display entries (with optional sorting)    |
| Input validation   | Ensure program reliability and UX          |

