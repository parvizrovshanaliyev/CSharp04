# 📘 Teaching Guide: Building a File Manager in C# with WinForms

## 🎯 Introduction
This comprehensive guide will walk you through creating a Windows Forms (WinForms) application in C#. We'll build a File Manager that helps students transition from console-based applications to graphical user interfaces (GUI). This project is specifically designed to bridge the gap between console and desktop development while teaching essential concepts of both file handling and GUI programming.

### Why WinForms for This Project?
Windows Forms (WinForms) is an excellent starting point for desktop application development because:
1. It has a visual designer that makes UI creation intuitive
2. It follows event-driven programming patterns common in modern applications
3. It provides immediate visual feedback during development
4. It has a shallow learning curve compared to other UI frameworks like WPF or UWP

### What We'll Build
Our File Manager will be a practical application that allows users to:
- Create, open, edit, and save text files
- View file properties and metadata
- Navigate through directories
- Manage files with a user-friendly interface
- Implement modern features like auto-save and themes

## 📋 Prerequisites
Before starting this project, ensure you have:

### Required Knowledge
- **C# Basics**:
  - Variables and data types
  - Methods and parameters
  - Classes and objects
  - Exception handling
  - Basic file I/O operations
- **Object-Oriented Programming Concepts**:
  - Inheritance
  - Encapsulation
  - Method overriding
  - Event handling

### Development Environment
- **Visual Studio 2022**:
  - Community Edition is sufficient (free version)
  - Make sure the ".NET Desktop Development" workload is installed
  - Install any recommended updates
- **.NET 6.0 SDK or Later**:
  - Download from Microsoft's official website
  - Verify installation using `dotnet --version` in command prompt

### Recommended Additional Tools
- **Git** for version control (optional but recommended)
- **Visual Studio Code** as a lightweight alternative editor
- **Notepad++** or similar text editor for viewing log files

## 🗺️ Learning Path Overview

### 1. Project Setup & WinForms Basics (2-3 hours)
- Creating a new WinForms project
- Understanding the project structure
- Learning about forms and controls
- Basic event handling

### 2. UI Design & Component Layout (3-4 hours)
- Designing the user interface
- Working with various controls
- Implementing layout managers
- Creating responsive designs

### 3. File Operations Implementation (4-5 hours)
- Implementing file handling logic
- Creating helper classes
- Error handling and logging
- Testing file operations

### 4. Advanced Features & Polish (3-4 hours)
- Adding recent files functionality
- Implementing auto-save
- Creating theme support
- Adding keyboard shortcuts

### 5. Testing & Documentation (2-3 hours)
- Writing user documentation
- Testing all features
- Handling edge cases
- Creating installation guide

## 📌 Part 1: Project Setup & WinForms Basics

### 1.1 Creating the Project
Let's go through the project creation process step by step:

1. **Launch Visual Studio 2022**
   - Start Visual Studio 2022
   - If you see the start window, click "Create a new project"
   - If you're in the IDE, go to File → New → Project

2. **Select Project Template**
   - In the search box, type "Windows Forms"
   - From the filtered list, select "Windows Forms App"
   - Make sure it's the C# version (look for the C# icon)
   - Verify it's using .NET Core (not .NET Framework)

3. **Configure Project Settings**
   ```
   Project name: FileManagerApp
   Location: C:\YourPreferredPath\Projects
   Solution name: FileManagerApp
   Framework: .NET 6.0 (Long Term Support)
   ```

   Important Settings Explained:
   - **Project name**: Choose a descriptive name without spaces
   - **Location**: Select a path without special characters
   - **Solution name**: Usually matches project name for single-project solutions
   - **Framework**: .NET 6.0 offers the best balance of features and stability

4. **Additional Options**
   - Check "Place solution and project in the same directory"
   - Uncheck "Do not use top-level statements" (we want a traditional Program.cs)

### 1.2 Understanding the Generated Files
When Visual Studio creates a new WinForms project, it generates several important files:

```
FileManagerApp/
├── Form1.cs               // Main form code file
│   - Contains the form's logic and event handlers
│   - Where you'll write most of your custom code
│
├── Form1.Designer.cs      // Auto-generated UI code
│   - Created by the Windows Forms Designer
│   - DON'T modify this file manually
│   - Contains initialization code for all controls
│
├── Form1.resx            // Resource file
│   - Stores form resources (images, icons, etc.)
│   - Managed by Visual Studio
│   - Can be viewed with Resource Editor
│
└── Program.cs            // Application entry point
    - Contains the Main() method
    - Initializes the application
    - Sets up the main form
```

#### Important File Details:

1. **Form1.cs**
   ```csharp
   public partial class Form1 : Form
   {
       public Form1()
       {
           InitializeComponent();
       }
   }
   ```
   - The `partial` keyword allows the class to be split between files
   - `InitializeComponent()` sets up all designer-created controls
   - Add your custom code here

2. **Program.cs**
   ```csharp
   static class Program
   {
       [STAThread]
       static void Main()
       {
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());
       }
   }
   ```
   - `[STAThread]` ensures proper COM threading model
   - `EnableVisualStyles()` enables modern control styling
   - `Application.Run()` starts the message pump

### 1.3 Initial Setup Steps
Let's configure our main form with proper settings:

1. **Rename Form1 to MainForm**
   - Right-click on Form1.cs in Solution Explorer
   - Select "Rename"
   - Type "MainForm.cs"
   - Click "Yes" when asked to rename all references
   
   Why Rename?
   - More descriptive name for the main window
   - Better code organization
   - Follows C# naming conventions

2. **Configure Form Properties**
   ```csharp
   this.Text = "File Manager";              // Window title
   this.StartPosition = FormStartPosition.CenterScreen;  // Center on screen
   this.MinimumSize = new Size(800, 600);   // Prevent too-small window
   ```

   Additional Properties to Consider:
   ```csharp
   this.Icon = Properties.Resources.AppIcon;  // Custom icon
   this.FormBorderStyle = FormBorderStyle.Sizable;  // Resizable window
   this.WindowState = FormWindowState.Normal;  // Initial state
   ```

3. **Basic Form Structure**
   ```csharp
   public partial class MainForm : Form
   {
       // Fields for tracking state
       private string currentFilePath;
       private bool isFileModified;

       public MainForm()
       {
           InitializeComponent();
           SetupForm();
       }

       private void SetupForm()
       {
           // Initialize form state
           currentFilePath = string.Empty;
           isFileModified = false;

           // Set form properties
           this.Text = "File Manager";
           this.StartPosition = FormStartPosition.CenterScreen;
           this.MinimumSize = new Size(800, 600);

           // Subscribe to form events
           this.FormClosing += MainForm_FormClosing;
       }

       private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
       {
           // Check for unsaved changes
           if (isFileModified)
           {
               DialogResult result = MessageBox.Show(
                   "Do you want to save changes before closing?",
                   "Unsaved Changes",
                   MessageBoxButtons.YesNoCancel,
                   MessageBoxIcon.Warning);

               switch (result)
               {
                   case DialogResult.Yes:
                       // Save changes
                       SaveFile();
                       break;
                   case DialogResult.Cancel:
                       e.Cancel = true;
                       break;
               }
           }
       }
   }
   ```

### 1.4 Basic WinForms Concepts
Let's explore the fundamental concepts of Windows Forms:

#### Forms
Forms are the windows of your application. They can be:
- **Main Form**: The primary window (our FileManagerApp)
- **Dialog Forms**: Pop-up windows for user interaction
- **MDI Forms**: Parent windows that contain child windows

Key Form Properties:
```csharp
public partial class MainForm : Form
{
    // Form properties explained
    this.Text = "File Manager";          // Window title bar text
    this.ClientSize = new Size(800, 600);// Content area size
    this.FormBorderStyle = FormBorderStyle.Sizable;  // Window frame style
    this.MaximizeBox = true;             // Allow maximize
    this.MinimizeBox = true;             // Allow minimize
    this.ShowIcon = true;                // Show form icon
    this.ShowInTaskbar = true;           // Show in Windows taskbar
}
```

#### Controls
Controls are UI elements that users interact with. Common controls include:

1. **Buttons**
   ```csharp
   private Button CreateStyledButton(string text, string name)
   {
       Button btn = new Button
       {
           Text = text,
           Name = name,
           Size = new Size(80, 30),
           Font = new Font("Segoe UI", 9F),
           UseVisualStyleBackColor = true,
           Margin = new Padding(3)
       };
       return btn;
   }
   ```

2. **TextBoxes**
   ```csharp
   private TextBox CreateFilePathTextBox()
   {
       return new TextBox
       {
           Name = "txtFilePath",
           Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
           Width = 400,
           ReadOnly = true,
           BackColor = SystemColors.Window
       };
   }
   ```

3. **Labels**
   ```csharp
   private Label CreateInfoLabel(string text)
   {
       return new Label
       {
           Text = text,
           AutoSize = true,
           Font = new Font("Segoe UI", 9F),
           Padding = new Padding(3)
       };
   }
   ```

#### Events
Events are actions that controls respond to. Common events:

```csharp
// Button click event
private void btnOpen_Click(object sender, EventArgs e)
{
    // Code to open file
}

// Text changed event
private void txtContent_TextChanged(object sender, EventArgs e)
{
    isFileModified = true;
    UpdateFormTitle();
}

// Form load event
private void MainForm_Load(object sender, EventArgs e)
{
    InitializeControls();
}

// Key press event
private void txtContent_KeyDown(object sender, KeyEventArgs e)
{
    // Check for Ctrl+S
    if (e.Control && e.KeyCode == Keys.S)
    {
        SaveFile();
        e.Handled = true;
    }
}
```

#### Properties Window
The Properties window (F4) is crucial for design-time configuration:

Important Property Categories:
1. **Appearance**
   - BackColor
   - ForeColor
   - Font
   - Cursor

2. **Behavior**
   - Enabled
   - Visible
   - TabIndex
   - TabStop

3. **Layout**
   - Location
   - Size
   - Dock
   - Anchor

4. **Data**
   - DataSource
   - DataBindings
   - Tag

## 📌 Part 2: Detailed UI Design & Layout

### Understanding UI Design Principles
Before we start building our interface, let's understand some key UI design principles:

1. **Visual Hierarchy**
   - Important elements should be more prominent
   - Group related items together
   - Use consistent spacing and alignment

2. **User Flow**
   - Arrange controls in a logical order
   - Most common actions should be easily accessible
   - Provide visual feedback for actions

3. **Responsive Design**
   - Interface should adapt to window resizing
   - Use docking and anchoring for flexible layouts
   - Maintain usability at different window sizes

### Understanding UI Controls
Before diving into the layout, let's understand each UI control we'll be using:

#### MenuStrip
The MenuStrip control provides the main menu interface for the application.
```csharp
MenuStrip menuStrip = new MenuStrip
{
    Dock = DockStyle.Top,
    RenderMode = ToolStripRenderMode.System,
    BackColor = SystemColors.Control,
    Font = new Font("Segoe UI", 9F)
};
```
Key Properties:
- `Dock`: Determines how the menu attaches to the form
- `RenderMode`: Controls the visual style
- `Items`: Collection of menu items
- `BackColor`: Background color
- `Font`: Text font and size

Common Events:
- `ItemClicked`: Fires when any menu item is clicked
- `MenuActivate`: Fires when menu is opened
- `MenuDeactivate`: Fires when menu is closed

#### TextBox
TextBox controls provide text input and display capabilities.
```csharp
TextBox textBox = new TextBox
{
    Multiline = false,
    ScrollBars = ScrollBars.None,
    AcceptsReturn = false,
    AcceptsTab = false,
    WordWrap = false,
    Font = new Font("Segoe UI", 9F),
    BorderStyle = BorderStyle.Fixed3D
};
```
Key Properties:
- `Multiline`: Allows multiple lines of text
- `ScrollBars`: Adds scroll bars when needed
- `AcceptsReturn`: Handles Enter key press
- `AcceptsTab`: Handles Tab key press
- `WordWrap`: Wraps text to next line
- `MaxLength`: Maximum text length
- `PasswordChar`: Character for password fields

Common Events:
- `TextChanged`: Fires when text is modified
- `KeyPress`: Fires when a key is pressed
- `KeyDown`: Fires before key press
- `KeyUp`: Fires after key release

#### RichTextBox
RichTextBox provides advanced text editing capabilities.
```csharp
RichTextBox richTextBox = new RichTextBox
{
    Dock = DockStyle.Fill,
    Font = new Font("Consolas", 10F),
    AcceptsTab = true,
    WordWrap = false,
    ScrollBars = RichTextBoxScrollBars.Both,
    DetectUrls = true,
    AutoWordSelection = true
};
```
Key Properties:
- `SelectionFont`: Font for selected text
- `SelectionColor`: Color for selected text
- `SelectionBackColor`: Background color for selection
- `BulletIndent`: Indentation for bullet points
- `DetectUrls`: Automatically detects URLs
- `AutoWordSelection`: Selects whole words

Common Events:
- `SelectionChanged`: Fires when selection changes
- `LinkClicked`: Fires when a link is clicked
- `Protected`: Fires when protected content is modified
- `ZoomFactorChanged`: Fires when zoom level changes

#### Button
Buttons provide clickable actions in the interface.
```csharp
Button button = new Button
{
    Text = "Click Me",
    Size = new Size(80, 30),
    Font = new Font("Segoe UI", 9F),
    UseVisualStyleBackColor = true,
    FlatStyle = FlatStyle.System,
    ImageAlign = ContentAlignment.MiddleLeft,
    TextImageRelation = TextImageRelation.ImageBeforeText
};
```
Key Properties:
- `FlatStyle`: Visual style of the button
- `Image`: Icon or image to display
- `ImageAlign`: Image position
- `TextImageRelation`: Text and image layout
- `DialogResult`: Result when used in dialogs
- `TabIndex`: Tab navigation order

Common Events:
- `Click`: Fires when clicked
- `MouseEnter`: Fires when mouse hovers
- `MouseLeave`: Fires when mouse leaves
- `Paint`: Fires when button is drawn

#### ListView
ListView displays items in various formats.
```csharp
ListView listView = new ListView
{
    View = View.Details,
    FullRowSelect = true,
    GridLines = true,
    MultiSelect = false,
    HeaderStyle = ColumnHeaderStyle.Nonclickable,
    Font = new Font("Segoe UI", 9F)
};
```
Key Properties:
- `View`: Display mode (Details, List, Tiles, etc.)
- `Columns`: Column definitions
- `Items`: Collection of list items
- `CheckBoxes`: Enables item checkboxes
- `Groups`: Item grouping
- `Sorting`: Sort direction

Common Events:
- `ItemSelectionChanged`: Fires when selection changes
- `ColumnClick`: Fires when column header is clicked
- `ItemCheck`: Fires when item is checked/unchecked
- `ItemActivate`: Fires when item is activated

#### SplitContainer
SplitContainer divides space between two panels.
```csharp
SplitContainer splitContainer = new SplitContainer
{
    Dock = DockStyle.Fill,
    Orientation = Orientation.Vertical,
    SplitterDistance = this.Width - 250
};
```
Key Properties:
- `Orientation`: Vertical or horizontal split
- `SplitterDistance`: Position of splitter
- `Panel1`: First panel
- `Panel2`: Second panel
- `SplitterWidth`: Width of splitter bar
- `Panel1MinSize`: Minimum size of Panel1
- `Panel2MinSize`: Minimum size of Panel2

Common Events:
- `SplitterMoving`: Fires while splitter is dragged
- `SplitterMoved`: Fires after splitter position changes
- `Panel1Collapsed`: Fires when Panel1 is collapsed
- `Panel2Collapsed`: Fires when Panel2 is collapsed

#### StatusStrip
StatusStrip provides status information at form bottom.
```csharp
StatusStrip statusStrip = new StatusStrip
{
    Dock = DockStyle.Bottom,
    SizingGrip = true,
    ShowItemToolTips = true
};
```
Key Properties:
- `Items`: Collection of status items
- `SizingGrip`: Shows resize grip
- `LayoutStyle`: Item layout style
- `GripStyle`: Style of sizing grip
- `GripMargin`: Margin around grip

Common Events:
- `ItemClicked`: Fires when item is clicked
- `ItemAdded`: Fires when item is added
- `ItemRemoved`: Fires when item is removed

#### ToolTip
ToolTip provides hover information for controls.
```csharp
ToolTip toolTip = new ToolTip
{
    AutomaticDelay = 500,
    InitialDelay = 500,
    ReshowDelay = 100,
    ShowAlways = true,
    IsBalloon = false
};
```
Key Properties:
- `AutomaticDelay`: Delay before showing
- `InitialDelay`: First show delay
- `ReshowDelay`: Delay between shows
- `IsBalloon`: Uses balloon style
- `ToolTipTitle`: Title text
- `ToolTipIcon`: Icon to display

Common Events:
- `Draw`: Fires when tooltip is drawn
- `Popup`: Fires before tooltip shows
- `Closed`: Fires when tooltip closes

### 2.1 Main Form Layout Structure
Our application will use a professional, well-organized layout:

```
+----------------------------------------+
|  Menu Strip                            |  ← Global actions
+----------------------------------------+
|  File Path Controls                    |  ← Current file info
|  +------------------------------------+
|  | Path TextBox | Browse Button       |
+----------------------------------------+
|    File Operations Buttons             |  ← Common actions
+----------------------------------------+
|  Content Area          |  File List    |  ← Main workspace
|                       |                |
|  [RichTextBox]        |  [ListBox]     |  ← Split view
|                       |                |
|                       |                |
+----------------------------------------+
|  Status Bar                            |  ← Status info
+----------------------------------------+
```

Layout Explanation:
1. **Top Section**: Contains global navigation and file path
2. **Middle Section**: Main content area with file editor
3. **Right Section**: File browser and properties
4. **Bottom Section**: Status information and metadata

### 2.2 Adding Controls (Detailed Steps)

#### 1. MenuStrip Setup
The MenuStrip provides hierarchical access to all functions:

```csharp
private void SetupMenuStrip()
{
    // Create main menu items
    ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
    ToolStripMenuItem editMenu = new ToolStripMenuItem("&Edit");
    ToolStripMenuItem viewMenu = new ToolStripMenuItem("&View");
    ToolStripMenuItem helpMenu = new ToolStripMenuItem("&Help");

    // File menu items
    fileMenu.DropDownItems.AddRange(new ToolStripItem[]
    {
        new ToolStripMenuItem("&New", null, NewFile_Click, Keys.Control | Keys.N),
        new ToolStripMenuItem("&Open...", null, OpenFile_Click, Keys.Control | Keys.O),
        new ToolStripMenuItem("&Save", null, SaveFile_Click, Keys.Control | Keys.S),
        new ToolStripMenuItem("Save &As...", null, SaveFileAs_Click),
        new ToolStripSeparator(),
        new ToolStripMenuItem("E&xit", null, Exit_Click, Keys.Alt | Keys.F4)
    });

    // Edit menu items
    editMenu.DropDownItems.AddRange(new ToolStripItem[]
    {
        new ToolStripMenuItem("Cu&t", null, Cut_Click, Keys.Control | Keys.X),
        new ToolStripMenuItem("&Copy", null, Copy_Click, Keys.Control | Keys.C),
        new ToolStripMenuItem("&Paste", null, Paste_Click, Keys.Control | Keys.V),
        new ToolStripSeparator(),
        new ToolStripMenuItem("&Settings...", null, Settings_Click)
    });

    // View menu items
    viewMenu.DropDownItems.AddRange(new ToolStripItem[]
    {
        new ToolStripMenuItem("&Word Wrap", null, WordWrap_Click) { CheckOnClick = true },
        new ToolStripMenuItem("File &Details", null, FileDetails_Click) { CheckOnClick = true }
    });

    // Help menu items
    helpMenu.DropDownItems.AddRange(new ToolStripItem[]
    {
        new ToolStripMenuItem("&View Help", null, ViewHelp_Click, Keys.F1),
        new ToolStripMenuItem("&About", null, About_Click)
    });

    // Add all menus to the MenuStrip
    menuStrip1.Items.AddRange(new ToolStripItem[]
    {
        fileMenu,
        editMenu,
        viewMenu,
        helpMenu
    });
}
```

Menu Design Principles:
- Use ampersand (&) for keyboard shortcuts
- Group related items together
- Add separators between groups
- Include keyboard accelerators
- Keep menus shallow (max 2 levels)

#### 2. File Path Controls
Create a professional file path display area:

```csharp
private void SetupFilePathControls()
{
    // Create container panel
    Panel pathPanel = new Panel
    {
        Dock = DockStyle.Top,
        Height = 30,
        Padding = new Padding(5)
    };

    // Create path label
    Label lblPath = new Label
    {
        Text = "File Path:",
        AutoSize = true,
        Anchor = AnchorStyles.Left | AnchorStyles.Top,
        TextAlign = ContentAlignment.MiddleLeft
    };

    // Create path textbox
    TextBox txtFilePath = new TextBox
    {
        Name = "txtFilePath",
        Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
        ReadOnly = true,
        BackColor = SystemColors.Window,
        Width = pathPanel.Width - 100
    };

    // Create browse button
    Button btnBrowse = new Button
    {
        Text = "Browse...",
        Width = 80,
        Anchor = AnchorStyles.Top | AnchorStyles.Right
    };

    // Layout controls
    pathPanel.Controls.AddRange(new Control[]
    {
        lblPath,
        txtFilePath,
        btnBrowse
    });

    // Position controls
    lblPath.Location = new Point(5, 8);
    txtFilePath.Location = new Point(70, 5);
    btnBrowse.Location = new Point(pathPanel.Width - 85, 3);

    // Add to form
    this.Controls.Add(pathPanel);
}
```

#### 3. Operation Buttons
Create a consistent button layout:

```csharp
private void SetupOperationButtons()
{
    // Create button container
    FlowLayoutPanel buttonPanel = new FlowLayoutPanel
    {
        Dock = DockStyle.Top,
        Height = 40,
        Padding = new Padding(5),
        FlowDirection = FlowDirection.LeftToRight
    };

    // Create operation buttons
    Button[] buttons = new[]
    {
        CreateOperationButton("New", "btnNew"),
        CreateOperationButton("Open", "btnOpen"),
        CreateOperationButton("Save", "btnSave"),
        CreateOperationButton("Delete", "btnDelete")
    };

    // Add buttons to panel
    buttonPanel.Controls.AddRange(buttons);

    // Add panel to form
    this.Controls.Add(buttonPanel);
}

private Button CreateOperationButton(string text, string name)
{
    Button btn = new Button
    {
        Text = text,
        Name = name,
        Size = new Size(80, 30),
        Margin = new Padding(5, 0, 0, 0),
        UseVisualStyleBackColor = true
    };

    // Add tooltip
    toolTip1.SetToolTip(btn, $"{text} file");

    return btn;
}
```

#### 4. Main Content Area
Create a professional text editor:

```csharp
private void SetupContentArea()
{
    // Create split container
    SplitContainer splitContainer = new SplitContainer
    {
        Dock = DockStyle.Fill,
        Orientation = Orientation.Vertical,
        SplitterDistance = this.Width - 250
    };

    // Create rich text box
    RichTextBox txtContent = new RichTextBox
    {
        Name = "txtContent",
        Dock = DockStyle.Fill,
        Font = new Font("Consolas", 10F),
        WordWrap = false,
        AcceptsTab = true,
        ScrollBars = RichTextBoxScrollBars.Both
    };

    // Create file list view
    ListView lstFiles = new ListView
    {
        Name = "lstFiles",
        Dock = DockStyle.Fill,
        View = View.Details,
        FullRowSelect = true,
        GridLines = true
    };

    // Add columns to list view
    lstFiles.Columns.AddRange(new[]
    {
        new ColumnHeader { Text = "Name", Width = 150 },
        new ColumnHeader { Text = "Size", Width = 70 },
        new ColumnHeader { Text = "Modified", Width = 120 }
    });

    // Add controls to split container
    splitContainer.Panel1.Controls.Add(txtContent);
    splitContainer.Panel2.Controls.Add(lstFiles);

    // Add split container to form
    this.Controls.Add(splitContainer);
}
```

[Continue with the rest of the UI implementation...]

## 📌 Part 3: File Operations Implementation

### Understanding File Operations
Before implementing file operations, let's understand the key concepts:

1. **File System Operations**
   - Reading and writing files
   - File existence checks
   - Error handling
   - File metadata access

2. **Security Considerations**
   - File permissions
   - Exception handling
   - Path validation
   - Secure file operations

3. **Performance Considerations**
   - Buffered vs. unbuffered I/O
   - Async operations for large files
   - Resource cleanup
   - Memory management

### 3.1 File Helper Class
The `FileHelper` class encapsulates all file operations and provides a clean API:

```csharp
public static class FileHelper
{
    // Constants for file operations
    private const int DEFAULT_BUFFER_SIZE = 4096;
    private const int MAX_FILE_SIZE = 100 * 1024 * 1024; // 100MB

    /// <summary>
    /// Reads the entire contents of a file with proper error handling
    /// </summary>
    public static string ReadFile(string filePath)
    {
        ValidateFilePath(filePath);

        try
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // Check file size
                if (stream.Length > MAX_FILE_SIZE)
                {
                    throw new InvalidOperationException($"File is too large (max {MAX_FILE_SIZE / 1024 / 1024}MB)");
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error reading file {filePath}: {ex.Message}");
            throw new FileOperationException($"Could not read file: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Saves content to a file with backup creation
    /// </summary>
    public static void SaveFile(string filePath, string content)
    {
        ValidateFilePath(filePath);

        string backupPath = CreateBackup(filePath);

        try
        {
            // Write to temporary file first
            string tempPath = Path.GetTempFileName();
            File.WriteAllText(tempPath, content);

            // Move temporary file to target location
            File.Copy(tempPath, filePath, true);
            File.Delete(tempPath);

            // Delete backup if save was successful
            if (File.Exists(backupPath))
            {
                File.Delete(backupPath);
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error saving file {filePath}: {ex.Message}");
            
            // Restore from backup if available
            if (File.Exists(backupPath))
            {
                File.Copy(backupPath, filePath, true);
            }

            throw new FileOperationException($"Could not save file: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Safely deletes a file with recycle bin support
    /// </summary>
    public static void DeleteFile(string filePath)
    {
        ValidateFilePath(filePath);

        try
        {
            // Move to recycle bin instead of permanent deletion
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                filePath,
                Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
        }
        catch (Exception ex)
        {
            Logger.Log($"Error deleting file {filePath}: {ex.Message}");
            throw new FileOperationException($"Could not delete file: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Gets detailed file information
    /// </summary>
    public static FileInfo GetFileInfo(string filePath)
    {
        ValidateFilePath(filePath);

        try
        {
            FileInfo info = new FileInfo(filePath);
            if (!info.Exists)
            {
                throw new FileNotFoundException("File not found", filePath);
            }
            return info;
        }
        catch (Exception ex)
        {
            Logger.Log($"Error getting file info for {filePath}: {ex.Message}");
            throw new FileOperationException($"Could not get file info: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Creates a backup copy of the file
    /// </summary>
    private static string CreateBackup(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }

        string backupPath = filePath + ".bak";
        try
        {
            File.Copy(filePath, backupPath, true);
            return backupPath;
        }
        catch (Exception ex)
        {
            Logger.Log($"Failed to create backup of {filePath}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Validates file path for common issues
    /// </summary>
    private static void ValidateFilePath(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path cannot be empty");
        }

        if (filePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
        {
            throw new ArgumentException("File path contains invalid characters");
        }

        if (!Path.IsPathRooted(filePath))
        {
            throw new ArgumentException("File path must be absolute");
        }

        // Check path length
        if (filePath.Length > 260 && !filePath.StartsWith(@"\\?\"))
        {
            filePath = @"\\?\" + filePath;
        }
    }
}

/// <summary>
/// Custom exception for file operations
/// </summary>
public class FileOperationException : Exception
{
    public FileOperationException(string message) : base(message) { }
    public FileOperationException(string message, Exception inner) : base(message, inner) { }
}
```

### 3.2 Logger Class
A robust logging system is crucial for debugging and maintenance:

```csharp
public static class Logger
{
    private static readonly string LogFile = "filemanager.log";
    private static readonly object LogLock = new object();
    private static readonly int MaxLogSize = 5 * 1024 * 1024; // 5MB

    public static void Log(string message, LogLevel level = LogLevel.Info)
    {
        string logMessage = FormatLogMessage(message, level);

        lock (LogLock)
        {
            try
            {
                // Check log file size
                if (File.Exists(LogFile))
                {
                    FileInfo logFileInfo = new FileInfo(LogFile);
                    if (logFileInfo.Length > MaxLogSize)
                    {
                        RotateLogFile();
                    }
                }

                // Write log entry
                File.AppendAllText(LogFile, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // If logging fails, write to debug output
                System.Diagnostics.Debug.WriteLine(
                    $"Failed to write to log file: {ex.Message}");
                System.Diagnostics.Debug.WriteLine(logMessage);
            }
        }
    }

    private static string FormatLogMessage(string message, LogLevel level)
    {
        return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";
    }

    private static void RotateLogFile()
    {
        try
        {
            string backupLog = LogFile + DateTime.Now.ToString(".yyyy-MM-dd-HH-mm-ss");
            File.Move(LogFile, backupLog);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(
                $"Failed to rotate log file: {ex.Message}");
        }
    }
}

public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error
}
```

### 3.3 Event Handlers
Implement the UI event handlers with proper error handling and user feedback:

```csharp
public partial class MainForm : Form
{
    private bool isFileModified = false;
    private string currentFilePath = string.Empty;

    /// <summary>
    /// Creates a new empty file
    /// </summary>
    private void btnNew_Click(object sender, EventArgs e)
    {
        if (isFileModified)
        {
            DialogResult result = MessageBox.Show(
                "Do you want to save changes to the current file?",
                "Save Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    if (!SaveFile())
                    {
                        return; // Don't create new file if save failed
                    }
                    break;
                case DialogResult.Cancel:
                    return;
            }
        }

        // Clear content
        txtContent.Clear();
        txtFilePath.Clear();
        currentFilePath = string.Empty;
        isFileModified = false;
        UpdateFormTitle();
    }

    /// <summary>
    /// Opens an existing file
    /// </summary>
    private void btnOpen_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog ofd = new OpenFileDialog())
        {
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Read file content
                    string content = FileHelper.ReadFile(ofd.FileName);
                    
                    // Update UI
                    txtContent.Text = content;
                    txtFilePath.Text = ofd.FileName;
                    currentFilePath = ofd.FileName;
                    isFileModified = false;
                    
                    // Update form
                    UpdateFormTitle();
                    UpdateFileInfo(ofd.FileName);
                    
                    // Add to recent files
                    AddToRecentFiles(ofd.FileName);
                }
                catch (FileOperationException ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error Opening File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }

    /// <summary>
    /// Saves the current file
    /// </summary>
    private bool SaveFile()
    {
        if (string.IsNullOrEmpty(currentFilePath))
        {
            return SaveFileAs();
        }

        try
        {
            FileHelper.SaveFile(currentFilePath, txtContent.Text);
            isFileModified = false;
            UpdateFormTitle();
            UpdateFileInfo(currentFilePath);
            return true;
        }
        catch (FileOperationException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Error Saving File",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }
    }

    /// <summary>
    /// Shows the Save As dialog
    /// </summary>
    private bool SaveFileAs()
    {
        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileHelper.SaveFile(sfd.FileName, txtContent.Text);
                    
                    // Update state
                    currentFilePath = sfd.FileName;
                    txtFilePath.Text = sfd.FileName;
                    isFileModified = false;
                    
                    // Update UI
                    UpdateFormTitle();
                    UpdateFileInfo(sfd.FileName);
                    AddToRecentFiles(sfd.FileName);
                    
                    return true;
                }
                catch (FileOperationException ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error Saving File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Updates the form title to show the current file
    /// </summary>
    private void UpdateFormTitle()
    {
        string fileName = string.IsNullOrEmpty(currentFilePath) 
            ? "Untitled" 
            : Path.GetFileName(currentFilePath);
            
        this.Text = $"{fileName}{(isFileModified ? "*" : "")} - File Manager";
    }

    /// <summary>
    /// Updates the file information display
    /// </summary>
    private void UpdateFileInfo(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            lblFileInfo.Text = "No file selected";
            return;
        }

        try
        {
            FileInfo info = FileHelper.GetFileInfo(filePath);
            lblFileInfo.Text = $"Size: {FormatFileSize(info.Length)}\n" +
                             $"Modified: {info.LastWriteTime:g}\n" +
                             $"Created: {info.CreationTime:g}";
        }
        catch (FileOperationException ex)
        {
            lblFileInfo.Text = $"Error: {ex.Message}";
        }
    }

    /// <summary>
    /// Formats file size in human-readable format
    /// </summary>
    private string FormatFileSize(long bytes)
    {
        string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
        int suffixIndex = 0;
        double size = bytes;

        while (size >= 1024 && suffixIndex < suffixes.Length - 1)
        {
            size /= 1024;
            suffixIndex++;
        }

        return $"{size:N2} {suffixes[suffixIndex]}";
    }
}
```

## 📌 Part 4: Advanced Features

### Understanding Advanced Features
Before implementing advanced features, let's understand their importance:

1. **Recent Files**
   - Improves user experience
   - Provides quick access to frequently used files
   - Requires persistent storage

2. **Auto-Save**
   - Prevents data loss
   - Reduces user anxiety
   - Requires careful implementation to avoid performance issues

3. **Theme Support**
   - Enhances visual comfort
   - Provides accessibility options
   - Demonstrates UI customization

### 4.1 Recent Files Feature
Implement a professional recent files system:

```csharp
public class RecentFilesManager
{
    private const string RegistryPath = @"Software\FileManagerApp\RecentFiles";
    private const int MaxRecentFiles = 10;
    private List<string> recentFiles;

    public RecentFilesManager()
    {
        recentFiles = LoadRecentFiles();
    }

    /// <summary>
    /// Adds a file to the recent files list
    /// </summary>
    public void AddFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return;

        // Remove if already exists
        recentFiles.RemoveAll(f => f.Equals(filePath, StringComparison.OrdinalIgnoreCase));

        // Add to start of list
        recentFiles.Insert(0, filePath);

        // Trim list if too long
        while (recentFiles.Count > MaxRecentFiles)
        {
            recentFiles.RemoveAt(recentFiles.Count - 1);
        }

        // Save changes
        SaveRecentFiles();
    }

    /// <summary>
    /// Gets the list of recent files
    /// </summary>
    public IReadOnlyList<string> GetRecentFiles()
    {
        // Remove any files that no longer exist
        recentFiles.RemoveAll(f => !File.Exists(f));
        SaveRecentFiles();
        return recentFiles.AsReadOnly();
    }

    /// <summary>
    /// Clears the recent files list
    /// </summary>
    public void ClearRecentFiles()
    {
        recentFiles.Clear();
        SaveRecentFiles();
    }

    /// <summary>
    /// Loads recent files from registry
    /// </summary>
    private List<string> LoadRecentFiles()
    {
        try
        {
            using (var key = Registry.CurrentUser.OpenSubKey(RegistryPath))
            {
                if (key != null)
                {
                    var files = new List<string>();
                    for (int i = 0; i < MaxRecentFiles; i++)
                    {
                        var path = key.GetValue($"File{i}") as string;
                        if (!string.IsNullOrEmpty(path) && File.Exists(path))
                        {
                            files.Add(path);
                        }
                    }
                    return files;
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error loading recent files: {ex.Message}", LogLevel.Error);
        }
        return new List<string>();
    }

    /// <summary>
    /// Saves recent files to registry
    /// </summary>
    private void SaveRecentFiles()
    {
        try
        {
            using (var key = Registry.CurrentUser.CreateSubKey(RegistryPath))
            {
                // Clear existing values
                foreach (var valueName in key.GetValueNames())
                {
                    key.DeleteValue(valueName);
                }

                // Save new values
                for (int i = 0; i < recentFiles.Count; i++)
                {
                    key.SetValue($"File{i}", recentFiles[i]);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error saving recent files: {ex.Message}", LogLevel.Error);
        }
    }
}
```

Add to MainForm.cs:
```csharp
private RecentFilesManager recentFilesManager;
private ToolStripMenuItem recentFilesMenu;

private void InitializeRecentFiles()
{
    recentFilesManager = new RecentFilesManager();
    
    // Create recent files menu
    recentFilesMenu = new ToolStripMenuItem("Recent Files");
    fileMenu.DropDownItems.Insert(fileMenu.DropDownItems.Count - 2, recentFilesMenu);
    fileMenu.DropDownItems.Insert(fileMenu.DropDownItems.Count - 2, new ToolStripSeparator());
    
    UpdateRecentFilesMenu();
}

private void UpdateRecentFilesMenu()
{
    recentFilesMenu.DropDownItems.Clear();
    
    var files = recentFilesManager.GetRecentFiles();
    if (files.Count == 0)
    {
        var noFilesItem = new ToolStripMenuItem("(No Recent Files)") { Enabled = false };
        recentFilesMenu.DropDownItems.Add(noFilesItem);
        return;
    }

    foreach (string file in files)
    {
        var item = new ToolStripMenuItem(Path.GetFileName(file))
        {
            ToolTipText = file,
            Tag = file
        };
        item.Click += RecentFile_Click;
        recentFilesMenu.DropDownItems.Add(item);
    }

    recentFilesMenu.DropDownItems.Add(new ToolStripSeparator());
    var clearItem = new ToolStripMenuItem("Clear Recent Files");
    clearItem.Click += (s, e) =>
    {
        recentFilesManager.ClearRecentFiles();
        UpdateRecentFilesMenu();
    };
    recentFilesMenu.DropDownItems.Add(clearItem);
}

private void RecentFile_Click(object sender, EventArgs e)
{
    var menuItem = (ToolStripMenuItem)sender;
    var filePath = (string)menuItem.Tag;
    
    if (!File.Exists(filePath))
    {
        MessageBox.Show(
            "File no longer exists.",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        recentFilesManager.GetRecentFiles(); // This will remove non-existent files
        UpdateRecentFilesMenu();
        return;
    }

    OpenFile(filePath);
}
```

### 4.2 Auto-Save Feature
Implement a reliable auto-save system:

```csharp
public class AutoSaveManager : IDisposable
{
    private readonly System.Windows.Forms.Timer timer;
    private readonly Action saveAction;
    private readonly string filePath;
    private bool isEnabled;

    public int Interval
    {
        get => timer.Interval;
        set => timer.Interval = value;
    }

    public bool IsEnabled
    {
        get => isEnabled;
        set
        {
            isEnabled = value;
            timer.Enabled = value;
        }
    }

    public AutoSaveManager(Action saveAction, string filePath, int intervalSeconds = 300)
    {
        this.saveAction = saveAction;
        this.filePath = filePath;
        
        timer = new System.Windows.Forms.Timer
        {
            Interval = intervalSeconds * 1000 // Convert to milliseconds
        };
        timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                saveAction();
                Logger.Log($"Auto-saved file: {filePath}", LogLevel.Info);
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Auto-save failed: {ex.Message}", LogLevel.Error);
        }
    }

    public void ResetTimer()
    {
        if (timer.Enabled)
        {
            timer.Stop();
            timer.Start();
        }
    }

    public void Dispose()
    {
        timer.Dispose();
    }
}
```

Add to MainForm.cs:
```csharp
private AutoSaveManager autoSaveManager;
private const int AutoSaveIntervalSeconds = 300; // 5 minutes

private void InitializeAutoSave()
{
    autoSaveManager = new AutoSaveManager(
        () => SaveFile(),
        currentFilePath,
        AutoSaveIntervalSeconds);

    // Add auto-save option to settings menu
    var autoSaveItem = new ToolStripMenuItem("Auto-Save")
    {
        CheckOnClick = true,
        Checked = true
    };
    autoSaveItem.Click += (s, e) =>
    {
        autoSaveManager.IsEnabled = autoSaveItem.Checked;
        if (autoSaveItem.Checked)
        {
            ShowAutoSaveNotification();
        }
    };
    settingsMenu.DropDownItems.Add(autoSaveItem);

    // Enable auto-save
    autoSaveManager.IsEnabled = true;
}

private void ShowAutoSaveNotification()
{
    notifyIcon1.ShowBalloonTip(
        3000,
        "Auto-Save Enabled",
        $"Files will be automatically saved every {AutoSaveIntervalSeconds / 60} minutes",
        ToolTipIcon.Info);
}
```

### 4.3 Theme Support
Implement a flexible theming system:

```csharp
public class ThemeManager
{
    public enum Theme
    {
        Light,
        Dark,
        System
    }

    private readonly Form mainForm;
    private Theme currentTheme;

    // Theme colors
    private static class ThemeColors
    {
        public static class Light
        {
            public static readonly Color Background = SystemColors.Window;
            public static readonly Color Text = SystemColors.WindowText;
            public static readonly Color Control = SystemColors.Control;
            public static readonly Color ControlText = SystemColors.ControlText;
            public static readonly Color Border = SystemColors.ControlDark;
        }

        public static class Dark
        {
            public static readonly Color Background = Color.FromArgb(30, 30, 30);
            public static readonly Color Text = Color.FromArgb(240, 240, 240);
            public static readonly Color Control = Color.FromArgb(45, 45, 45);
            public static readonly Color ControlText = Color.FromArgb(240, 240, 240);
            public static readonly Color Border = Color.FromArgb(60, 60, 60);
        }
    }

    public ThemeManager(Form mainForm)
    {
        this.mainForm = mainForm;
        currentTheme = Theme.Light;
    }

    public void ApplyTheme(Theme theme)
    {
        currentTheme = theme;
        
        // Determine colors based on theme
        var (bgColor, textColor, controlColor, controlTextColor, borderColor) = theme switch
        {
            Theme.Dark => (
                ThemeColors.Dark.Background,
                ThemeColors.Dark.Text,
                ThemeColors.Dark.Control,
                ThemeColors.Dark.ControlText,
                ThemeColors.Dark.Border
            ),
            _ => (
                ThemeColors.Light.Background,
                ThemeColors.Light.Text,
                ThemeColors.Light.Control,
                ThemeColors.Light.ControlText,
                ThemeColors.Light.Border
            )
        };

        // Apply colors to form
        mainForm.BackColor = controlColor;
        mainForm.ForeColor = controlTextColor;

        // Apply to all controls recursively
        ApplyThemeToControls(mainForm.Controls, bgColor, textColor, controlColor, controlTextColor, borderColor);

        // Save theme preference
        SaveThemePreference();
    }

    private void ApplyThemeToControls(
        Control.ControlCollection controls,
        Color bgColor,
        Color textColor,
        Color controlColor,
        Color controlTextColor,
        Color borderColor)
    {
        foreach (Control control in controls)
        {
            switch (control)
            {
                case TextBox txt:
                    txt.BackColor = bgColor;
                    txt.ForeColor = textColor;
                    break;

                case RichTextBox rtb:
                    rtb.BackColor = bgColor;
                    rtb.ForeColor = textColor;
                    break;

                case Button btn:
                    btn.BackColor = controlColor;
                    btn.ForeColor = controlTextColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = borderColor;
                    break;

                case Panel pnl:
                    pnl.BackColor = controlColor;
                    pnl.ForeColor = controlTextColor;
                    break;

                case MenuStrip ms:
                    ms.BackColor = controlColor;
                    ms.ForeColor = controlTextColor;
                    foreach (ToolStripMenuItem item in ms.Items)
                    {
                        ApplyThemeToMenuItem(item, controlColor, controlTextColor);
                    }
                    break;
            }

            // Recursively apply to child controls
            if (control.HasChildren)
            {
                ApplyThemeToControls(
                    control.Controls,
                    bgColor,
                    textColor,
                    controlColor,
                    controlTextColor,
                    borderColor);
            }
        }
    }

    private void ApplyThemeToMenuItem(
        ToolStripMenuItem item,
        Color backColor,
        Color foreColor)
    {
        item.BackColor = backColor;
        item.ForeColor = foreColor;

        foreach (ToolStripItem dropItem in item.DropDownItems)
        {
            if (dropItem is ToolStripMenuItem menuItem)
            {
                ApplyThemeToMenuItem(menuItem, backColor, foreColor);
            }
        }
    }

    private void SaveThemePreference()
    {
        try
        {
            using (var key = Registry.CurrentUser.CreateSubKey(@"Software\FileManagerApp\Settings"))
            {
                key.SetValue("Theme", currentTheme.ToString());
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error saving theme preference: {ex.Message}", LogLevel.Error);
        }
    }

    public Theme LoadThemePreference()
    {
        try
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\FileManagerApp\Settings"))
            {
                if (key != null)
                {
                    var themeName = key.GetValue("Theme") as string;
                    if (Enum.TryParse<Theme>(themeName, out var theme))
                    {
                        return theme;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error loading theme preference: {ex.Message}", LogLevel.Error);
        }
        return Theme.Light;
    }
}
```

Add to MainForm.cs:
```csharp
private ThemeManager themeManager;

private void InitializeTheme()
{
    themeManager = new ThemeManager(this);

    // Add theme menu items
    var themeMenu = new ToolStripMenuItem("Theme");
    viewMenu.DropDownItems.Add(themeMenu);

    var lightTheme = new ToolStripMenuItem("Light")
    {
        Tag = ThemeManager.Theme.Light,
        Checked = true
    };
    var darkTheme = new ToolStripMenuItem("Dark")
    {
        Tag = ThemeManager.Theme.Dark
    };
    var systemTheme = new ToolStripMenuItem("Use System Setting")
    {
        Tag = ThemeManager.Theme.System
    };

    EventHandler themeClick = (s, e) =>
    {
        var item = (ToolStripMenuItem)s;
        var theme = (ThemeManager.Theme)item.Tag;
        
        // Update checkmarks
        lightTheme.Checked = (theme == ThemeManager.Theme.Light);
        darkTheme.Checked = (theme == ThemeManager.Theme.Dark);
        systemTheme.Checked = (theme == ThemeManager.Theme.System);
        
        // Apply theme
        themeManager.ApplyTheme(theme);
    };

    lightTheme.Click += themeClick;
    darkTheme.Click += themeClick;
    systemTheme.Click += themeClick;

    themeMenu.DropDownItems.AddRange(new ToolStripItem[]
    {
        lightTheme,
        darkTheme,
        systemTheme
    });

    // Load and apply saved theme
    var savedTheme = themeManager.LoadThemePreference();
    themeManager.ApplyTheme(savedTheme);
}
```

## 📌 Part 5: Testing & Documentation

### Understanding Testing Importance
Before we dive into testing, let's understand why thorough testing is crucial:

1. **Quality Assurance**
   - Ensures functionality works as expected
   - Identifies bugs early in development
   - Validates user experience
   - Verifies error handling

2. **User Experience**
   - Confirms intuitive interface
   - Validates workflow efficiency
   - Ensures accessibility
   - Tests responsiveness

3. **Maintenance**
   - Facilitates future updates
   - Documents expected behavior
   - Helps track regressions
   - Supports troubleshooting

### 5.1 Testing Checklist

#### Basic Functionality Tests
```csharp
public class FileManagerTests
{
    private const string TestDirectory = @"C:\Tests\FileManager";
    private const string TestFile = "test.txt";
    private const string TestContent = "Hello, World!";

    [TestInitialize]
    public void Setup()
    {
        // Create test directory
        Directory.CreateDirectory(TestDirectory);
    }

    [TestCleanup]
    public void Cleanup()
    {
        // Clean up test files
        if (Directory.Exists(TestDirectory))
        {
            Directory.Delete(TestDirectory, true);
        }
    }

    [TestMethod]
    public void TestFileOperations()
    {
        string filePath = Path.Combine(TestDirectory, TestFile);

        // Test file creation
        FileHelper.SaveFile(filePath, TestContent);
        Assert.IsTrue(File.Exists(filePath), "File should exist after creation");

        // Test file reading
        string content = FileHelper.ReadFile(filePath);
        Assert.AreEqual(TestContent, content, "File content should match");

        // Test file deletion
        FileHelper.DeleteFile(filePath);
        Assert.IsFalse(File.Exists(filePath), "File should not exist after deletion");
    }

    [TestMethod]
    public void TestLargeFileHandling()
    {
        string filePath = Path.Combine(TestDirectory, "large.txt");
        StringBuilder largeContent = new StringBuilder();
        for (int i = 0; i < 100000; i++)
        {
            largeContent.AppendLine($"Line {i}");
        }

        // Test large file operations
        FileHelper.SaveFile(filePath, largeContent.ToString());
        string content = FileHelper.ReadFile(filePath);
        Assert.AreEqual(largeContent.ToString(), content);
    }

    [TestMethod]
    public void TestErrorHandling()
    {
        string invalidPath = Path.Combine(TestDirectory, "invalid", "test.txt");

        // Test invalid path
        Assert.ThrowsException<FileOperationException>(() =>
        {
            FileHelper.SaveFile(invalidPath, TestContent);
        });

        // Test reading non-existent file
        Assert.ThrowsException<FileOperationException>(() =>
        {
            FileHelper.ReadFile(invalidPath);
        });
    }
}
```

#### UI Testing Checklist
1. **File Operations**
   - [ ] Create new file
     ```csharp
     [TestMethod]
     public void TestNewFile()
     {
         using (var form = new MainForm())
         {
             // Simulate New File action
             form.InvokeMethod("btnNew_Click", null, null);
             
             // Verify form state
             Assert.AreEqual(string.Empty, form.GetTextBoxContent("txtContent"));
             Assert.AreEqual(string.Empty, form.GetTextBoxContent("txtFilePath"));
             Assert.IsFalse(form.GetFieldValue<bool>("isFileModified"));
         }
     }
     ```
   - [ ] Open existing file
   - [ ] Save file
   - [ ] Save As
   - [ ] Delete file

2. **UI Features**
   - [ ] Menu items work
     ```csharp
     [TestMethod]
     public void TestMenuItems()
     {
         using (var form = new MainForm())
         {
             // Get menu items
             var fileMenu = form.GetMenuItem("fileMenu");
             var editMenu = form.GetMenuItem("editMenu");
             
             // Verify menu structure
             Assert.IsNotNull(fileMenu);
             Assert.IsNotNull(editMenu);
             
             // Verify menu item count
             Assert.AreEqual(6, fileMenu.DropDownItems.Count);
             Assert.AreEqual(5, editMenu.DropDownItems.Count);
         }
     }
     ```
   - [ ] Keyboard shortcuts
   - [ ] Recent files list
   - [ ] Theme switching

3. **Error Handling**
   - [ ] Invalid file paths
   - [ ] File access denied
   - [ ] File in use by another process
   - [ ] Large file handling

4. **Advanced Features**
   - [ ] Auto-save functionality
   - [ ] Theme persistence
   - [ ] Recent files management

### 5.2 Known Issues & Solutions

#### 1. File Access Issues
```csharp
public class FileAccessTests
{
    [TestMethod]
    public void TestFileAccessDenied()
    {
        string restrictedPath = @"C:\Windows\System32\restricted.txt";
        
        try
        {
            // Attempt to write to restricted location
            FileHelper.SaveFile(restrictedPath, "test");
            Assert.Fail("Should not be able to write to restricted location");
        }
        catch (FileOperationException ex)
        {
            Assert.IsTrue(ex.Message.Contains("access denied"));
        }
    }

    [TestMethod]
    public void TestFileInUse()
    {
        string filePath = "test.txt";
        
        // Create and hold file lock
        using (var fs = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
        {
            try
            {
                FileHelper.SaveFile(filePath, "test");
                Assert.Fail("Should not be able to write to locked file");
            }
            catch (FileOperationException ex)
            {
                Assert.IsTrue(ex.Message.Contains("being used by another process"));
            }
        }
    }
}
```

#### 2. Large File Handling
```csharp
public class LargeFileHandler
{
    private const int BufferSize = 4096;
    
    public static void ProcessLargeFile(string filePath, Action<string> lineProcessor)
    {
        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (var reader = new StreamReader(stream, Encoding.UTF8, true, BufferSize))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineProcessor(line);
            }
        }
    }
}
```

#### 3. UI Responsiveness
```csharp
public class BackgroundOperations
{
    public static async Task ProcessFileAsync(string filePath, IProgress<int> progress)
    {
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            var totalBytes = stream.Length;
            var buffer = new byte[BufferSize];
            var bytesRead = 0;
            
            while (bytesRead < totalBytes)
            {
                var count = await stream.ReadAsync(buffer, 0, buffer.Length);
                bytesRead += count;
                
                var percentComplete = (int)((bytesRead * 100) / totalBytes);
                progress.Report(percentComplete);
            }
        }
    }
}
```

### 5.3 Documentation

#### README.md
Create a comprehensive README file:

```markdown
# File Manager Application

A professional-grade file management application built with C# and Windows Forms.

## 🌟 Features

### Core Functionality
- Create, open, edit, and save text files
- File metadata display
- Directory navigation
- Recent files list

### Advanced Features
- Auto-save functionality
- Dark/Light theme support
- File operation logging
- Error handling and recovery

## 🚀 Getting Started

### Prerequisites
- Windows 7 or later
- .NET 6.0 Runtime
- 4GB RAM minimum
- 100MB free disk space

### Installation
1. Download the latest release
2. Run the installer (FileManager_Setup.exe)
3. Follow the installation wizard
4. Launch from Start Menu

### Quick Start
1. Launch File Manager
2. Click "New" or "Open" to start
3. Edit content in the main text area
4. Save using Ctrl+S or File → Save

## 🛠️ Development Setup

### Requirements
- Visual Studio 2022
- .NET 6.0 SDK
- Windows Forms development workload

### Building from Source
```bash
# Clone the repository
git clone https://github.com/yourusername/filemanager.git

# Open solution
cd filemanager
start FileManager.sln

# Build solution
dotnet build

# Run tests
dotnet test
```

### Project Structure
```
FileManager/
├── src/
│   ├── FileManager.Core/       # Core functionality
│   ├── FileManager.UI/         # WinForms UI
│   └── FileManager.Tests/      # Unit tests
├── docs/                       # Documentation
├── tools/                      # Build scripts
└── README.md
```

## 📖 Usage Guide

### Basic Operations
1. **Creating Files**
   - Click "New" or press Ctrl+N
   - Enter content in the editor
   - Save with Ctrl+S

2. **Opening Files**
   - Click "Open" or press Ctrl+O
   - Select file in dialog
   - File content loads in editor

3. **Saving Files**
   - Click "Save" or press Ctrl+S
   - For new files, provide a name
   - For existing files, saves immediately

### Advanced Features
1. **Auto-Save**
   - Enable in Settings menu
   - Saves every 5 minutes
   - Indicated in status bar

2. **Themes**
   - Toggle in View menu
   - Choose Light/Dark
   - Settings persist between sessions

3. **Recent Files**
   - Access from File menu
   - Shows last 10 files
   - Click to open directly

## 🤝 Contributing
We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to your branch
5. Create a Pull Request

## 📝 License
This project is licensed under the MIT License - see [LICENSE.md](LICENSE.md)

## 🙏 Acknowledgments
- [Microsoft WinForms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [Icons by Icons8](https://icons8.com)
```

#### API Documentation
Create XML documentation for key classes:

```csharp
/// <summary>
/// Manages file operations with error handling and logging
/// </summary>
public static class FileHelper
{
    /// <summary>
    /// Reads the entire contents of a file
    /// </summary>
    /// <param name="filePath">The path to the file to read</param>
    /// <returns>The contents of the file as a string</returns>
    /// <exception cref="FileOperationException">Thrown when file cannot be read</exception>
    public static string ReadFile(string filePath) { ... }

    /// <summary>
    /// Saves content to a file with backup creation
    /// </summary>
    /// <param name="filePath">The path where to save the file</param>
    /// <param name="content">The content to write to the file</param>
    /// <exception cref="FileOperationException">Thrown when file cannot be saved</exception>
    public static void SaveFile(string filePath, string content) { ... }
}
```

#### User Guide
Create a user guide in the docs folder:

```markdown
# File Manager User Guide

## Getting Started
This guide will help you get started with File Manager...

## Features
Detailed explanation of each feature...

## Troubleshooting
Common issues and their solutions...

## FAQ
Frequently asked questions...
```

## 📋 Troubleshooting Guide

### Common Issues and Solutions

#### 1. Application Performance
```csharp
// Problem: Application becomes unresponsive when handling large files
// Solution: Implement async loading with progress reporting

public async Task LoadLargeFileAsync(string filePath, IProgress<int> progress)
{
    try
    {
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        using var reader = new StreamReader(stream);
        var content = new StringBuilder();
        var totalSize = stream.Length;
        var buffer = new char[4096];
        var bytesRead = 0;

        while (true)
        {
            var readCount = await reader.ReadBlockAsync(buffer, 0, buffer.Length);
            if (readCount == 0) break;
            
            content.Append(buffer, 0, readCount);
            bytesRead += readCount;
            progress.Report((int)((bytesRead * 100) / totalSize));
        }

        txtContent.Text = content.ToString();
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading file: {ex.Message}", "Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

#### 2. Memory Management
```csharp
// Problem: Memory usage grows with multiple file operations
// Solution: Implement proper disposal and memory cleanup

public class ResourceManager : IDisposable
{
    private bool disposed = false;
    private List<IDisposable> managedResources = new();

    public void AddResource(IDisposable resource)
    {
        managedResources.Add(resource);
    }

    public void RemoveResource(IDisposable resource)
    {
        resource.Dispose();
        managedResources.Remove(resource);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                foreach (var resource in managedResources)
                {
                    resource?.Dispose();
                }
                managedResources.Clear();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
```

#### 3. UI Thread Issues
```csharp
// Problem: UI freezes during long operations
// Solution: Use BackgroundWorker or async/await pattern

private async void btnOpen_Click(object sender, EventArgs e)
{
    using var dialog = new OpenFileDialog();
    if (dialog.ShowDialog() == DialogResult.OK)
    {
        btnOpen.Enabled = false;
        statusStrip.Items[0].Text = "Loading file...";
        
        try
        {
            var progress = new Progress<int>(value =>
            {
                toolStripProgressBar.Value = value;
            });

            await LoadLargeFileAsync(dialog.FileName, progress);
            statusStrip.Items[0].Text = "File loaded successfully";
        }
        finally
        {
            btnOpen.Enabled = true;
        }
    }
}
```

#### 4. Theme Application Issues
```csharp
// Problem: Theme changes don't apply to all controls
// Solution: Implement recursive theme application

private void ApplyThemeRecursively(Control control, Theme theme)
{
    // Apply theme to current control
    ApplyThemeToControl(control, theme);

    // Recursively apply to child controls
    foreach (Control child in control.Controls)
    {
        ApplyThemeRecursively(child, theme);
    }

    // Special handling for context menus
    if (control.ContextMenuStrip != null)
    {
        ApplyThemeToContextMenu(control.ContextMenuStrip, theme);
    }
}
```

### Common Error Messages

1. **File Access Denied**
   ```
   Error: Access to the path 'C:\file.txt' is denied.
   ```
   - **Cause**: Insufficient permissions or file is locked
   - **Solution**: 
     - Run application as administrator
     - Check file permissions
     - Ensure file isn't opened by another process

2. **Invalid Path Characters**
   ```
   Error: The path contains invalid characters.
   ```
   - **Cause**: Path contains forbidden characters
   - **Solution**: 
     - Remove special characters
     - Use Path.GetInvalidPathChars() to validate
     - Implement path sanitization

3. **File In Use**
   ```
   Error: The process cannot access the file because it is being used by another process.
   ```
   - **Cause**: File is locked by another process
   - **Solution**: 
     - Implement file sharing modes
     - Add retry mechanism
     - Show user which process is locking the file

### Best Practices for Error Prevention

1. **Input Validation**
```csharp
public static class InputValidator
{
    public static bool IsValidFileName(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName)) return false;
        
        var invalidChars = Path.GetInvalidFileNameChars();
        return !fileName.Any(c => invalidChars.Contains(c));
    }

    public static bool IsValidFilePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return false;
        
        try
        {
            Path.GetFullPath(path);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
```

2. **Resource Cleanup**
```csharp
public static class ResourceGuard
{
    public static void SafeDispose<T>(ref T disposable) where T : IDisposable
    {
        if (disposable != null)
        {
            try
            {
                disposable.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Log($"Error disposing resource: {ex.Message}");
            }
            finally
            {
                disposable = default;
            }
        }
    }
}
```

3. **Exception Handling Best Practices**
```csharp
public static class ExceptionHandler
{
    public static void HandleException(Exception ex, string operation)
    {
        // Log the exception
        Logger.Log($"Error during {operation}: {ex.Message}", LogLevel.Error);
        
        // Determine user-friendly message
        string userMessage = GetUserFriendlyMessage(ex);
        
        // Show error to user
        MessageBox.Show(
            userMessage,
            $"Error - {operation}",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }

    private static string GetUserFriendlyMessage(Exception ex)
    {
        return ex switch
        {
            FileNotFoundException => "The specified file could not be found.",
            UnauthorizedAccessException => "You don't have permission to access this file.",
            IOException ioe when (ioe.Message.Contains("being used by another process"))
                => "The file is currently in use by another program.",
            _ => "An unexpected error occurred. Please try again."
        };
    }
}
```

### Performance Optimization Tips

1. **Large File Handling**
   - Use buffered reading
   - Implement virtual loading for large files
   - Show progress indicators

2. **UI Responsiveness**
   - Use async/await for I/O operations
   - Implement background workers
   - Add cancellation support

3. **Memory Management**
   - Dispose resources properly
   - Use memory-efficient data structures
   - Implement lazy loading

## 🎓 Learning Outcomes
After completing this project, students will understand:
1. WinForms application structure
2. UI design principles
3. File system operations
4. Event-driven programming
5. Error handling
6. Basic application architecture

## 📚 Additional Resources
- [Microsoft WinForms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [C# File System Documentation](https://docs.microsoft.com/en-us/dotnet/standard/io/)
- [Windows Forms Best Practices](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/best-practices/)

## 🚀 Next Steps
After completing this basic version, students can extend the application with:
1. Multiple document interface (MDI)
2. File compression support
3. Search functionality
4. File comparison tools
5. Syntax highlighting for code files
6. Plugin system

This project provides a solid foundation in desktop application development while reinforcing file handling concepts learned in previous console applications.

## 🔍 Debugging Techniques

### Visual Studio Debugging Tools

#### 1. Breakpoints and Conditional Breakpoints
```csharp
// Use conditional breakpoints for specific scenarios
private void btnSave_Click(object sender, EventArgs e)
{
    // Set breakpoint with condition: isFileModified == true
    if (isFileModified)
    {
        SaveFile();
    }
}
```

#### 2. Watch Windows
- Add variables to watch
- Evaluate expressions
- Monitor property changes

#### 3. Output Window
```csharp
public static class DebugHelper
{
    [Conditional("DEBUG")]
    public static void Log(string message)
    {
        Debug.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {message}");
    }
}
```

### Common Debugging Scenarios

#### 1. Event Handler Issues
```csharp
// Problem: Event handler not firing
private void AttachEventHandlers()
{
    // Log when handlers are attached
    DebugHelper.Log("Attaching event handlers");
    
    btnSave.Click += (s, e) =>
    {
        DebugHelper.Log("Save button clicked");
        SaveFile();
    };
}
```

#### 2. Control State Issues
```csharp
// Problem: Control state unexpected
private void ValidateControlState()
{
    DebugHelper.Log($"Button enabled: {btnSave.Enabled}");
    DebugHelper.Log($"TextBox text: {txtContent.Text.Length} chars");
    DebugHelper.Log($"Modified flag: {isFileModified}");
}
```

#### 3. Layout Problems
```csharp
// Problem: Controls not positioned correctly
private void LogControlLayout()
{
    foreach (Control control in this.Controls)
    {
        DebugHelper.Log($"Control: {control.Name}");
        DebugHelper.Log($"  Location: {control.Location}");
        DebugHelper.Log($"  Size: {control.Size}");
        DebugHelper.Log($"  Visible: {control.Visible}");
    }
}
```

### Using Debug Builds

#### 1. Debug Configuration
```csharp
public class FileHelper
{
    public static void SaveFile(string path, string content)
    {
#if DEBUG
        DebugHelper.Log($"Saving file: {path}");
        DebugHelper.Log($"Content length: {content.Length}");
#endif
        // Save file implementation
    }
}
```

#### 2. Debug-Only Features
```csharp
public partial class MainForm : Form
{
#if DEBUG
    private ToolStripMenuItem debugMenu;
    
    private void InitializeDebugMenu()
    {
        debugMenu = new ToolStripMenuItem("Debug");
        debugMenu.DropDownItems.AddRange(new ToolStripItem[]
        {
            new ToolStripMenuItem("Log Control State", null, (s, e) => ValidateControlState()),
            new ToolStripMenuItem("Log Layout", null, (s, e) => LogControlLayout()),
            new ToolStripMenuItem("Clear Log", null, (s, e) => Debug.WriteLine("\n--- Log Cleared ---\n"))
        });
        menuStrip.Items.Add(debugMenu);
    }
#endif
}
```

### Logging and Tracing

#### 1. Trace Listeners
```csharp
public static class LogConfiguration
{
    public static void Initialize()
    {
        Trace.Listeners.Add(new TextWriterTraceListener("debug.log"));
        Trace.AutoFlush = true;
    }
}
```

#### 2. Performance Tracing
```csharp
public static class PerformanceTracer
{
    public static void TraceOperation(string operation, Action action)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            action();
        }
        finally
        {
            stopwatch.Stop();
            DebugHelper.Log($"{operation} took {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
```

### Memory and Performance Analysis

#### 1. Memory Leaks
```csharp
public class MemoryMonitor
{
    private static readonly PerformanceCounter MemCounter = new("Process", "Working Set - Private", Process.GetCurrentProcess().ProcessName);

    public static void LogMemoryUsage(string checkpoint)
    {
        DebugHelper.Log($"Memory at {checkpoint}: {MemCounter.NextValue() / 1024 / 1024:N2} MB");
    }
}
```

#### 2. UI Performance
```csharp
public static class UIPerformanceHelper
{
    public static void MeasureUIOperation(Control control, Action action, string operationName)
    {
        var start = DateTime.Now;
        control.BeginUpdate();
        try
        {
            action();
        }
        finally
        {
            control.EndUpdate();
            var duration = (DateTime.Now - start).TotalMilliseconds;
            DebugHelper.Log($"UI Operation '{operationName}' took {duration:N2}ms");
        }
    }
}
```

## 💡 WinForms Development Best Practices

### 1. Form Design Principles

#### Layout Management
```csharp
public partial class MainForm : Form
{
    private void InitializeLayout()
    {
        // Use TableLayoutPanel for grid-based layouts
        var tableLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 2,
            Padding = new Padding(10),
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        };

        // Set row and column styles
        tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
    }
}
```

#### Control Naming Conventions
```csharp
// Use meaningful prefixes and descriptive names
private TextBox txtFileName;        // Prefix: txt
private Button btnSave;            // Prefix: btn
private Label lblStatus;           // Prefix: lbl
private MenuStrip menuMain;        // Prefix: menu
private ToolStrip toolbarMain;     // Prefix: toolbar
private StatusStrip statusBar;     // Prefix: status
```

### 2. Event Handling

#### Proper Event Subscription
```csharp
public class EventHandlerManager
{
    private readonly Dictionary<Control, List<Delegate>> eventHandlers = new();

    public void SubscribeEvent(Control control, string eventName, Delegate handler)
    {
        // Store handler reference
        if (!eventHandlers.ContainsKey(control))
            eventHandlers[control] = new List<Delegate>();
        eventHandlers[control].Add(handler);

        // Subscribe to event
        control.GetType().GetEvent(eventName).AddEventHandler(control, handler);
    }

    public void UnsubscribeAll()
    {
        foreach (var pair in eventHandlers)
        {
            var control = pair.Key;
            foreach (var handler in pair.Value)
            {
                // Unsubscribe each handler
                var eventName = handler.Method.Name.Replace("_", "");
                control.GetType().GetEvent(eventName).RemoveEventHandler(control, handler);
            }
        }
        eventHandlers.Clear();
    }
}
```

### 3. Resource Management

#### Image Resource Handling
```csharp
public static class ImageResourceManager
{
    private static readonly Dictionary<string, Image> imageCache = new();

    public static Image GetImage(string resourceName)
    {
        if (imageCache.TryGetValue(resourceName, out var image))
            return image;

        image = Properties.Resources.ResourceManager.GetObject(resourceName) as Image;
        if (image != null)
            imageCache[resourceName] = image;

        return image;
    }

    public static void ClearCache()
    {
        foreach (var image in imageCache.Values)
            image.Dispose();
        imageCache.Clear();
    }
}
```

#### Form Cleanup
```csharp
public partial class MainForm : Form
{
    private readonly List<IDisposable> disposables = new();

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);

        // Clean up resources
        foreach (var disposable in disposables)
        {
            try
            {
                disposable.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error disposing resource: {ex.Message}");
            }
        }
        disposables.Clear();
    }
}
```

### 4. Performance Optimization

#### Control Updates
```csharp
public static class ControlUpdateHelper
{
    public static void SuspendDrawing(Control control, Action action)
    {
        try
        {
            control.SuspendLayout();
            if (control is ListView listView)
                listView.BeginUpdate();
            
            action();
        }
        finally
        {
            if (control is ListView listView)
                listView.EndUpdate();
            control.ResumeLayout();
        }
    }
}
```

#### Efficient Data Binding
```csharp
public class BindingHelper
{
    public static void BindDataSource<T>(BindingSource binding, IList<T> data, 
        Control control, string propertyName)
    {
        binding.DataSource = null;
        binding.DataSource = new BindingList<T>(data);
        control.DataBindings.Add(propertyName, binding, "Current");
    }
}
```

### 5. User Experience

#### Error Handling
```csharp
public static class UserFeedback
{
    public static void ShowError(string message, string title = "Error")
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static bool Confirm(string message, string title = "Confirm")
    {
        return MessageBox.Show(message, title, 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    public static void ShowStatus(ToolStripStatusLabel label, string message, 
        int timeout = 3000)
    {
        label.Text = message;
        Task.Delay(timeout).ContinueWith(_ =>
        {
            if (label.IsHandleCreated)
                label.BeginInvoke(new Action(() => label.Text = string.Empty));
        });
    }
}
```

#### Keyboard Navigation
```csharp
public partial class MainForm : Form
{
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // Handle custom keyboard shortcuts
        switch (keyData)
        {
            case Keys.Control | Keys.F:
                ShowFindDialog();
                return true;
            case Keys.F5:
                RefreshContent();
                return true;
            case Keys.Escape:
                if (CloseActiveDialog())
                    return true;
                break;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
}
```

### 6. Testing and Maintainability

#### Form Design Testing
```csharp
public static class FormTester
{
    public static void ValidateFormLayout(Form form)
    {
        // Check for overlapping controls
        var controls = form.Controls.Cast<Control>();
        foreach (var control in controls)
        {
            var overlapping = controls.Where(c => c != control && 
                c.Bounds.IntersectsWith(control.Bounds));
            
            foreach (var overlap in overlapping)
            {
                Debug.WriteLine($"Warning: {control.Name} overlaps with {overlap.Name}");
            }
        }

        // Check for proper tab order
        var tabOrder = controls.OrderBy(c => c.TabIndex)
            .Select(c => c.Name);
        Debug.WriteLine("Tab Order: " + string.Join(" -> ", tabOrder));
    }
}
```

#### Control State Validation
```csharp
public static class ControlValidator
{
    public static void ValidateControlStates(Form form)
    {
        foreach (Control control in form.Controls)
        {
            // Check enabled state consistency
            if (control.Enabled && !control.Parent.Enabled)
                Debug.WriteLine($"Warning: {control.Name} is enabled but parent is disabled");

            // Check visibility consistency
            if (control.Visible && !control.Parent.Visible)
                Debug.WriteLine($"Warning: {control.Name} is visible but parent is hidden");

            // Check for proper disposal
            if (control is IDisposable)
                Debug.WriteLine($"Note: {control.Name} implements IDisposable");
        }
    }
}
```

