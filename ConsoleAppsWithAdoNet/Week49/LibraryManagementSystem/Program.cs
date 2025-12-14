using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.Services;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Repositories;
using static LibraryManagementSystem.Presentation.ConsoleHelper;

namespace LibraryManagementSystem;

class Program
{
    private static IBookService _bookService = null!;
    private static IMemberService _memberService = null!;
    private static IBookBorrowService _borrowService = null!;

    static void Main(string[] args)
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║         LIBRARY MANAGEMENT SYSTEM - Week49 Practice           ║");
        Console.WriteLine("║           ADO.NET + Generic Collections Demo                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        var connectionString = DatabaseConfig.ConnectionString;
        _bookService = new BookService(new BookRepository(connectionString));
        _memberService = new MemberService(new MemberRepository(connectionString));
        _borrowService = new BookBorrowService(new BookBorrowRepository(connectionString));
        PrintInfo("Services initialized successfully.\n");

        while (true)
        {
            Console.WriteLine("\n══════════════════ MAIN MENU ══════════════════");
            Console.WriteLine("1. Book Management");
            Console.WriteLine("2. Member Management");
            Console.WriteLine("3. Borrow Management");
            Console.WriteLine("0. Exit");
            Console.WriteLine("═══════════════════════════════════════════════");

            switch (ReadString("Select option: "))
            {
                case "1": BookMenu(); break;
                case "2": MemberMenu(); break;
                case "3": BorrowMenu(); break;
                case "0": Console.WriteLine("\nGoodbye!"); return;
                default: PrintError("Invalid option."); break;
            }
        }
    }

    static void BookMenu()
    {
        while (true)
        {
            Console.WriteLine("\n────────────── BOOK MANAGEMENT ──────────────");
            Console.WriteLine("1. View All   2. View by ID   3. Add");
            Console.WriteLine("4. Update     5. Delete       0. Back");
            Console.WriteLine("──────────────────────────────────────────────");

            try
            {
                switch (ReadString("Select: "))
                {
                    case "1":
                        PrintList(_bookService.GetAllBooks(), "Books", "📚");
                        break;

                    case "2":
                        PrintItem(_bookService.GetBookById(ReadInt("Book ID: ")), "Book not found.");
                        break;

                    case "3":
                        PrintAddResult(_bookService.AddBook(new Book
                        {
                            Title = ReadString("Title: "),
                            Author = ReadString("Author: "),
                            ISBN = ReadString("ISBN: "),
                            PublishedYear = ReadInt("Published Year: "),
                            Genre = ReadString("Genre: "),
                            TotalCopies = ReadInt("Total Copies: ", 1)
                        }), "Book");
                        break;

                    case "4":
                        var book = _bookService.GetBookById(ReadInt("Book ID: "));
                        if (book == null) { PrintInfo("Book not found."); break; }
                        Console.WriteLine($"Current: {book}");
                        book.Title = ReadStringOrKeep("Title", book.Title);
                        book.Author = ReadStringOrKeep("Author", book.Author);
                        PrintResult(_bookService.UpdateBook(book), "Book updated.", "Update failed.");
                        break;

                    case "5":
                        PrintResult(_bookService.DeleteBook(ReadInt("Book ID: ")), "Book deleted.", "Delete failed.");
                        break;

                    case "0": return;
                    default: PrintError("Invalid option."); break;
                }
            }
            catch (Exception ex) { PrintError(ex.Message); }
        }
    }

    static void MemberMenu()
    {
        while (true)
        {
            Console.WriteLine("\n────────────── MEMBER MANAGEMENT ──────────────");
            Console.WriteLine("1. View All   2. View by ID   3. Add");
            Console.WriteLine("4. Update     5. Delete       0. Back");
            Console.WriteLine("────────────────────────────────────────────────");

            try
            {
                switch (ReadString("Select: "))
                {
                    case "1":
                        PrintList(_memberService.GetAllMembers(), "Members", "👥");
                        break;

                    case "2":
                        PrintItem(_memberService.GetMemberById(ReadInt("Member ID: ")), "Member not found.");
                        break;

                    case "3":
                        PrintAddResult(_memberService.AddMember(new Member
                        {
                            FirstName = ReadString("First Name: "),
                            LastName = ReadString("Last Name: "),
                            Email = ReadString("Email: "),
                            Phone = ReadString("Phone: "),
                            Address = ReadString("Address: ")
                        }), "Member");
                        break;

                    case "4":
                        var member = _memberService.GetMemberById(ReadInt("Member ID: "));
                        if (member == null) { PrintInfo("Member not found."); break; }
                        Console.WriteLine($"Current: {member}");
                        member.FirstName = ReadStringOrKeep("First Name", member.FirstName);
                        member.LastName = ReadStringOrKeep("Last Name", member.LastName);
                        member.Email = ReadStringOrKeep("Email", member.Email);
                        PrintResult(_memberService.UpdateMember(member), "Member updated.", "Update failed.");
                        break;

                    case "5":
                        PrintResult(_memberService.DeleteMember(ReadInt("Member ID: ")), "Member deleted.", "Delete failed.");
                        break;

                    case "0": return;
                    default: PrintError("Invalid option."); break;
                }
            }
            catch (Exception ex) { PrintError(ex.Message); }
        }
    }

    static void BorrowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n────────────── BORROW MANAGEMENT ──────────────");
            Console.WriteLine("1. View All   2. View by ID   3. Add");
            Console.WriteLine("4. Update     5. Delete       0. Back");
            Console.WriteLine("────────────────────────────────────────────────");

            try
            {
                switch (ReadString("Select: "))
                {
                    case "1":
                        PrintList(_borrowService.GetAllBorrows(), "Borrow Records", "📋");
                        break;

                    case "2":
                        PrintItem(_borrowService.GetBorrowById(ReadInt("Borrow ID: ")), "Record not found.");
                        break;

                    case "3":
                        var days = ReadInt("Borrow Days (default 14): ", 14);
                        PrintAddResult(_borrowService.AddBorrow(new BookBorrowRecord
                        {
                            BookId = ReadInt("Book ID: "),
                            MemberId = ReadInt("Member ID: "),
                            BorrowDate = DateTime.Now,
                            DueDate = DateTime.Now.AddDays(days)
                        }), "Borrow record");
                        break;

                    case "4":
                        var record = _borrowService.GetBorrowById(ReadInt("Borrow ID: "));
                        if (record == null) { PrintInfo("Record not found."); break; }
                        Console.WriteLine($"Current: {record}");
                        Console.WriteLine("1. Mark as Returned  2. Extend Due Date");
                        switch (ReadString("Select: "))
                        {
                            case "1": record.IsReturned = true; record.ReturnDate = DateTime.Now; break;
                            case "2": record.DueDate = record.DueDate.AddDays(ReadInt("Additional days: ", 7)); break;
                        }
                        PrintResult(_borrowService.UpdateBorrow(record), "Record updated.", "Update failed.");
                        break;

                    case "5":
                        PrintResult(_borrowService.DeleteBorrow(ReadInt("Borrow ID: ")), "Record deleted.", "Delete failed.");
                        break;

                    case "0": return;
                    default: PrintError("Invalid option."); break;
                }
            }
            catch (Exception ex) { PrintError(ex.Message); }
        }
    }
}
