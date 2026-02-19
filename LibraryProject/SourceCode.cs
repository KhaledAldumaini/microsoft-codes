using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; }
    public bool IsBorrowed { get; set; }

    public Book(string title)
    {
        Title = title;
        IsBorrowed = false;
    }
}

class LibraryManager
{
    static void Main()
    {
        const int Capacity = 5;
        const int BorrowLimit = 3;
        var books = new List<Book>(Capacity);
        int userBorrowedCount = 0;

        while (true)
        {
            Console.WriteLine("Choose an action: add/remove/search/borrow/checkin/exit");
            string action = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();

            switch (action)
            {
                case "add":
                    AddBook(books, Capacity);
                    break;
                case "remove":
                    RemoveBook(books);
                    break;
                case "search":
                    SearchBook(books);
                    break;
                case "borrow":
                    BorrowBook(books, ref userBorrowedCount, BorrowLimit);
                    break;
                case "checkin":
                    CheckInBook(books, ref userBorrowedCount);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid action. Please choose add, remove, search, borrow, checkin, or exit.");
                    break;
            }

            DisplayBooks(books);
        }
    }

    static void AddBook(List<Book> books, int capacity)
    {
        if (books.Count >= capacity)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }

        Console.WriteLine("Enter the title of the book to add:");
        string newBook = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrEmpty(newBook))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        bool exists = books.Exists(b => string.Equals(b.Title, newBook, StringComparison.OrdinalIgnoreCase));
        if (exists)
        {
            Console.WriteLine("This book already exists in the library.");
            return;
        }

        books.Add(new Book(newBook));
        Console.WriteLine($"Added '{newBook}'.");
    }

    static void RemoveBook(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }

        Console.WriteLine("Enter the title of the book to remove:");
        string removeBook = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrEmpty(removeBook))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        int index = books.FindIndex(b => string.Equals(b.Title, removeBook, StringComparison.OrdinalIgnoreCase));
        if (index >= 0)
        {
            if (books[index].IsBorrowed)
            {
                Console.WriteLine("Cannot remove a book that is currently checked out.");
                return;
            }

            Console.WriteLine($"Removed '{books[index].Title}'.");
            books.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void SearchBook(List<Book> books)
    {
        Console.WriteLine("Enter the title of the book to search for:");
        string query = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrEmpty(query))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        int index = books.FindIndex(b => string.Equals(b.Title, query, StringComparison.OrdinalIgnoreCase));
        if (index >= 0)
        {
            var b = books[index];
            Console.WriteLine(b.IsBorrowed ? $"'{b.Title}' is currently checked out." : $"'{b.Title}' is available.");
        }
        else
        {
            Console.WriteLine("Book not found in the collection.");
        }
    }

    static void BorrowBook(List<Book> books, ref int userBorrowedCount, int borrowLimit)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to borrow.");
            return;
        }

        if (userBorrowedCount >= borrowLimit)
        {
            Console.WriteLine($"You have reached the borrow limit of {borrowLimit} books.");
            return;
        }

        Console.WriteLine("Enter the title of the book to borrow:");
        string title = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        int index = books.FindIndex(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
        if (index < 0)
        {
            Console.WriteLine("Book not found in the collection.");
            return;
        }

        var book = books[index];
        if (book.IsBorrowed)
        {
            Console.WriteLine("That book is already checked out.");
            return;
        }

        book.IsBorrowed = true;
        userBorrowedCount++;
        Console.WriteLine($"You have borrowed '{book.Title}'. ({userBorrowedCount}/{borrowLimit})");
    }

    static void CheckInBook(List<Book> books, ref int userBorrowedCount)
    {
        Console.WriteLine("Enter the title of the book to check in:");
        string title = (Console.ReadLine() ?? string.Empty).Trim();
        if (string.IsNullOrEmpty(title))
        {
            Console.WriteLine("Title cannot be empty.");
            return;
        }

        int index = books.FindIndex(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
        if (index < 0)
        {
            Console.WriteLine("Book not found in the collection.");
            return;
        }

        var book = books[index];
        if (!book.IsBorrowed)
        {
            Console.WriteLine("That book is not currently checked out.");
            return;
        }

        book.IsBorrowed = false;
        userBorrowedCount = Math.Max(0, userBorrowedCount - 1);
        Console.WriteLine($"You have checked in '{book.Title}'. ({userBorrowedCount} borrowed)");
    }

    static void DisplayBooks(List<Book> books)
    {
        Console.WriteLine("Available books:");
        if (books.Count == 0)
        {
            Console.WriteLine("(none)");
            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(book.IsBorrowed ? $"{book.Title} (checked out)" : book.Title);
        }
    }
}