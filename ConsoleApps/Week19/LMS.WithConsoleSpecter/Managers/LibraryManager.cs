using Spectre.Console;
using LMS.WithConsoleSpecter.Models;
using LMS.WithConsoleSpecter.Enums;

namespace LMS.WithConsoleSpecter.Managers
{
    public class LibraryManager
    {
        private readonly LibraryItem?[] _libraryItems;
        private int _itemCount;
        private const int MaxItems = 100;

        public LibraryManager()
        {
            _libraryItems = new LibraryItem[MaxItems];
            _itemCount = 0;
        }

        public void RunMainMenu()
        {
            bool running = true;

            while (running)
            {
                DisplayMenuOptions();
                int choice = GetUserChoice();
                running = ProcessMenuChoice(choice);
            }
        }

        private int GetUserChoice()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>("Enter your choice:")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]That's not a valid choice[/]")
                    .Validate(choice => choice switch
                    {
                        >= 1 and <= 6 => ValidationResult.Success(),
                        _ => ValidationResult.Error("[red]Please enter a number between 1 and 6[/]")
                    }));
        }

        private void DisplayMenuOptions()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold yellow]Library Management System Menu[/]"))
                    .Expand()
                    .Border(BoxBorder.Rounded)
                    .BorderStyle(Style.Parse("blue"))
                    .Header("[bold blue]Options[/]"));

            AnsiConsole.WriteLine("1. Add new item");
            AnsiConsole.WriteLine("2. List all items");
            AnsiConsole.WriteLine("3. Search items");
            AnsiConsole.WriteLine("4. Delete an item");
            AnsiConsole.WriteLine("5. Update an item");
            AnsiConsole.WriteLine("6. Logout and Exit");
        }

        private bool ProcessMenuChoice(int choice)
        {
            try
            {
                switch (choice)
                {
                    case 1:
                        AddNewItem();
                        break;
                    case 2:
                        DisplayAllItemInfo();
                        break;
                    case 3:
                        SearchItems();
                        break;
                    case 4:
                        DeleteItem();
                        break;
                    case 5:
                        UpdateItem();
                        break;
                    case 6:
                        AnsiConsole.MarkupLine("[bold green]Thank you for using LMS![/]");
                        return false;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Invalid choice. Please enter a number between 1 and 6.[/]");
                        break;
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred: {ex.Message}[/]");
            }
            return true;
        }

        private void AddNewItem()
        {
            try
            {
                var type = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select item type:")
                        .AddChoices("Book", "Magazine", "Article"));

                string title = AnsiConsole.Ask<string>("Enter title:");
                string author = AnsiConsole.Ask<string>("Enter author:");
                int publishYear = AnsiConsole.Ask<int>("Enter publish year:");

                string additionalInformation = type switch
                {
                    "Book" => AnsiConsole.Ask<string>("Enter genre:"),
                    "Magazine" => AnsiConsole.Ask<string>("Enter issue number:"),
                    "Article" => AnsiConsole.Ask<string>("Enter journal name:"),
                    _ => ""
                };

                var item = CreateNewItem(type, title, author, publishYear, additionalInformation);

                if (item != null)
                {
                    AddItem(item);
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Error: Item creation failed.[/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred while adding a new item: {ex.Message}[/]");
            }
        }

        private void DisplayAllItemInfo()
        {
            try
            {
                if (_itemCount == 0)
                {
                    AnsiConsole.MarkupLine("[bold red]Error: No items in library[/]");
                    return;
                }

                var table = new Table();
                table.AddColumn("Index");
                table.AddColumn("Title");
                table.AddColumn("Author");
                table.AddColumn("Type");

                for (int i = 0; i < _itemCount; i++)
                {
                    var item = _libraryItems[i];
                    if (item != null)
                    {
                        table.AddRow((i + 1).ToString(), item.Title, item.Author, item.GetType().Name);
                    }
                }

                AnsiConsole.Write(table);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred while displaying items: {ex.Message}[/]");
            }
        }

        private void SearchItems()
        {
            try
            {
                string searchTerm = AnsiConsole.Ask<string>("Enter search term (title or author):");
                var searchResult = SearchItems(searchTerm);

                if (searchResult.Length == 0)
                {
                    AnsiConsole.MarkupLine("[bold red]No items found matching your search.[/]");
                    return;
                }

                var table = new Table();
                table.AddColumn("Index");
                table.AddColumn("Title");
                table.AddColumn("Author");
                table.AddColumn("Type");

                for (int i = 0; i < searchResult.Length; i++)
                {
                    var item = searchResult[i];
                    table.AddRow((i + 1).ToString(), item.Title, item.Author, item.GetType().Name);
                }

                AnsiConsole.Write(table);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred while searching items: {ex.Message}[/]");
            }
        }

        private void DeleteItem()
        {
            try
            {
                DisplayAllItemInfo();
                int choice = AnsiConsole.Ask<int>("Enter the number of the item to delete (or 0 to cancel):");

                if (choice == 0)
                {
                    AnsiConsole.MarkupLine("[bold yellow]Deletion cancelled.[/]");
                    return;
                }

                DeleteItem(choice - 1);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred while deleting an item: {ex.Message}[/]");
            }
        }

        private void UpdateItem()
        {
            try
            {
                DisplayAllItemInfo();
                int index = AnsiConsole.Ask<int>("Enter the number of the item to update (or 0 to cancel):") - 1;
                if (index < 0)
                {
                    AnsiConsole.MarkupLine("[bold yellow]Update cancelled.[/]");
                    return;
                }

                string newTitle = AnsiConsole.Ask<string>("Enter new title:");
                string newAuthor = AnsiConsole.Ask<string>("Enter new author:");
                int newPublishYear = AnsiConsole.Ask<int>("Enter new publish year:");
                string newAdditionalInfo = AnsiConsole.Ask<string>("Enter new additional information:");

                UpdateItem(index, newTitle, newAuthor, newPublishYear, newAdditionalInfo);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[bold red]An error occurred while updating an item: {ex.Message}[/]");
            }
        }

        private bool AddItem(LibraryItem item)
        {
            if (!ValidateItem(item)) return false;

            _libraryItems[_itemCount++] = item;
            AnsiConsole.MarkupLine("[bold green]Item added successfully[/]");
            return true;
        }

        private LibraryItem[] SearchItems(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                AnsiConsole.MarkupLine("[bold red]Search term cannot be empty.[/]");
                return Array.Empty<LibraryItem>();
            }

            searchTerm = searchTerm.Trim().ToLower();
            LibraryItem[] matchingItems = new LibraryItem[_itemCount];
            int matchCount = 0;

            for (int i = 0; i < _itemCount; i++)
            {
                LibraryItem? item = _libraryItems[i];
                if (item == null) continue;
                if (item != null &&
                    (item.Title.ToLower().Contains(searchTerm) ||
                     item.Author.ToLower().Contains(searchTerm)))
                {
                    matchingItems[matchCount++] = item;
                }
            }

            Array.Resize(ref matchingItems, matchCount);
            return matchingItems;
        }

        private bool DeleteItem(int index)
        {
            if (!ValidateIndex(index)) return false;

            for (int i = index; i < _itemCount - 1; i++)
            {
                _libraryItems[i] = _libraryItems[i + 1];
            }

            _libraryItems[--_itemCount] = null;
            AnsiConsole.MarkupLine("[bold green]Item deleted successfully[/]");
            return true;
        }

        private bool UpdateItem(int index, string newTitle, string newAuthor, int newPublishYear, string newAdditionalInfo)
        {
            if (!ValidateIndex(index) || !ValidateItemDetails(newTitle, newAuthor, newPublishYear)) return false;

            LibraryItem? item = _libraryItems[index];
            if (item == null)
            {
                AnsiConsole.MarkupLine("[bold red]Error: Item not found.[/]");
                return false;
            }
            item.UpdateDetails(newTitle, newAuthor, newPublishYear);

            switch (item)
            {
                case Book book:
                    if (!ValidateAdditionalInfo(newAdditionalInfo, "Genre cannot be empty for books.")) return false;
                    book.UpdateGenre(newAdditionalInfo);
                    break;

                case Magazine magazine:
                    if (!ValidateAdditionalInfo(newAdditionalInfo, "Invalid issue number for magazines.", out int issueNumber) || issueNumber <= 0) return false;
                    magazine.UpdateIssueNumber(issueNumber);
                    break;

                case Article article:
                    if (!ValidateAdditionalInfo(newAdditionalInfo, "Journal name cannot be empty for articles.")) return false;
                    article.UpdateJournalName(newAdditionalInfo);
                    break;

                default:
                    AnsiConsole.MarkupLine("[bold red]Error: Unknown item type.[/]");
                    return false;
            }

            AnsiConsole.MarkupLine("[bold green]Item updated successfully.[/]");
            return true;
        }

        private LibraryItem? CreateNewItem(string type, string title, string author, int publishYear, string additionalInfo)
        {
            if (!ValidateItemDetails(title, author, publishYear)) return null;

            LibraryItem? item = type switch
            {
                "Book" => CreateBook(title, author, publishYear, additionalInfo),
                "Magazine" => CreateMagazine(title, author, publishYear, additionalInfo),
                "Article" => CreateArticle(title, author, publishYear, additionalInfo),
                _ => null
            };

            if (item == null)
            {
                AnsiConsole.MarkupLine("[bold red]Error: Item creation failed.[/]");
            }

            return item;
        }

        private Book? CreateBook(string title, string author, int publishYear, string genre)
        {
            return ValidateAdditionalInfo(genre, "Genre cannot be empty.") ? new Book(title, author, publishYear, genre) : null;
        }

        private Magazine? CreateMagazine(string title, string author, int publishYear, string issueNumberStr)
        {
            return ValidateAdditionalInfo(issueNumberStr, "Invalid issue number.", out int issueNumber) && issueNumber > 0 ? new Magazine(title, author, publishYear, issueNumber) : null;
        }

        private Article? CreateArticle(string title, string author, int publishYear, string journalName)
        {
            return ValidateAdditionalInfo(journalName, "Journal name cannot be empty.") ? new Article(title, author, publishYear, journalName) : null;
        }

        private bool ValidateItem(LibraryItem item)
        {
            if (item == null)
            {
                AnsiConsole.MarkupLine("[bold red]Error: Cannot add null item[/]");
                return false;
            }

            if (_itemCount >= MaxItems)
            {
                AnsiConsole.MarkupLine("[bold red]Error: Library is full[/]");
                return false;
            }

            return true;
        }

        private bool ValidateIndex(int index)
        {
            if (index < 0 || index >= _itemCount)
            {
                AnsiConsole.MarkupLine("[bold red]Invalid item index[/]");
                return false;
            }

            return true;
        }

        private bool ValidateItemDetails(string title, string author, int publishYear)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                AnsiConsole.MarkupLine("[bold red]Title and author cannot be empty.[/]");
                return false;
            }

            if (publishYear < 1000 || publishYear > DateTime.Now.Year)
            {
                AnsiConsole.MarkupLine($"[bold red]Publish year must be between 1000 and {DateTime.Now.Year}.[/]");
                return false;
            }

            return true;
        }

        private bool ValidateAdditionalInfo(string additionalInfo, string errorMessage, out int parsedValue)
        {
            if (!int.TryParse(additionalInfo, out parsedValue))
            {
                AnsiConsole.MarkupLine($"[bold red]{errorMessage}[/]");
                return false;
            }

            return true;
        }

        private bool ValidateAdditionalInfo(string additionalInfo, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(additionalInfo))
            {
                AnsiConsole.MarkupLine($"[bold red]{errorMessage}[/]");
                return false;
            }

            return true;
        }
    }
}
