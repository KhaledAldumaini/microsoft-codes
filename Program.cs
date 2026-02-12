
internal class Program
{
    private static void Main(string[] args)
    {
        string book1 = string.Empty;
        string book2 = string.Empty;
        string book3 = string.Empty;
        string book4 = string.Empty;
        string book5 = string.Empty;

        Console.WriteLine("Simple Library Manager (max 5 books)");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Choose an action: add / remove / list / exit");
            Console.Write("Action: ");
            var action = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();

            if (action == "add")
            {
                if (!string.IsNullOrEmpty(book1) && !string.IsNullOrEmpty(book2) && !string.IsNullOrEmpty(book3) && !string.IsNullOrEmpty(book4) && !string.IsNullOrEmpty(book5))
                {
                    Console.WriteLine("All book slots are full. Cannot add more books.");
                    continue;
                }

                Console.Write("Enter book title to add: ");
                var title = (Console.ReadLine() ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Empty title — nothing was added.");
                    continue;
                }

                if (string.IsNullOrEmpty(book1)) { book1 = title; Console.WriteLine($"Added: {title}"); continue; }
                if (string.IsNullOrEmpty(book2)) { book2 = title; Console.WriteLine($"Added: {title}"); continue; }
                if (string.IsNullOrEmpty(book3)) { book3 = title; Console.WriteLine($"Added: {title}"); continue; }
                if (string.IsNullOrEmpty(book4)) { book4 = title; Console.WriteLine($"Added: {title}"); continue; }
                if (string.IsNullOrEmpty(book5)) { book5 = title; Console.WriteLine($"Added: {title}"); continue; }
            }
            else if (action == "remove")
            {
                if (string.IsNullOrEmpty(book1) && string.IsNullOrEmpty(book2) && string.IsNullOrEmpty(book3) && string.IsNullOrEmpty(book4) && string.IsNullOrEmpty(book5))
                {
                    Console.WriteLine("No books to remove — the library is empty.");
                    continue;
                }

                Console.Write("Enter the exact title to remove: ");
                var title = (Console.ReadLine() ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Empty title — nothing was removed.");
                    continue;
                }

                if (string.Equals(book1, title, System.StringComparison.OrdinalIgnoreCase)) { book1 = string.Empty; Console.WriteLine($"Removed: {title}"); continue; }
                if (string.Equals(book2, title, System.StringComparison.OrdinalIgnoreCase)) { book2 = string.Empty; Console.WriteLine($"Removed: {title}"); continue; }
                if (string.Equals(book3, title, System.StringComparison.OrdinalIgnoreCase)) { book3 = string.Empty; Console.WriteLine($"Removed: {title}"); continue; }
                if (string.Equals(book4, title, System.StringComparison.OrdinalIgnoreCase)) { book4 = string.Empty; Console.WriteLine($"Removed: {title}"); continue; }
                if (string.Equals(book5, title, System.StringComparison.OrdinalIgnoreCase)) { book5 = string.Empty; Console.WriteLine($"Removed: {title}"); continue; }

                Console.WriteLine($"Book titled '{title}' not found in the library.");
            }
            else if (action == "list")
            {
                Console.WriteLine();
                Console.WriteLine("Books currently in the library:");
                var hasAny = false;
                if (!string.IsNullOrEmpty(book1)) { Console.WriteLine("- " + book1); hasAny = true; }
                if (!string.IsNullOrEmpty(book2)) { Console.WriteLine("- " + book2); hasAny = true; }
                if (!string.IsNullOrEmpty(book3)) { Console.WriteLine("- " + book3); hasAny = true; }
                if (!string.IsNullOrEmpty(book4)) { Console.WriteLine("- " + book4); hasAny = true; }
                if (!string.IsNullOrEmpty(book5)) { Console.WriteLine("- " + book5); hasAny = true; }
                if (!hasAny) Console.WriteLine("(no books available)");
            }
            else if (action == "exit")
            {
                Console.WriteLine("Exiting library manager. Goodbye.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please enter 'add', 'remove', 'list' or 'exit'.");
            }
        }
    }
}