using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.Model;
using System.Runtime.CompilerServices;

namespace SimpleCrud
{
    internal class SimpleCrudApp
    {
        SimpleCrudDataContext dataContext;

        public SimpleCrudApp()
        {
            dataContext = new SimpleCrudDataContext();
        }

        internal void Run()
        {
            string userInput = "";

            while(userInput.ToLower() != "x")
            {
                userInput = ShowMenu();
                handleUserInput(userInput);
            }
        }

        private void handleUserInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    // Show all
                    ShowAll();
                    break;
                case "2":
                    // Add new
                    AddNew();
                    break;
                case "3":
                    // Update
                    Update();
                    break;
                case "4":
                    // Delete
                    Delete();
                    break;
                default:
                    Console.WriteLine("Incorrect choice...");
                    // Invalid input
                    break;
            }
            Helpers.Pause();
        }

        private void Delete()
        {
            // TODO: Find the object the user wants to delete using
            Book selectedBook = SelectBook();

            // TODO: Delete the selected object from dataContext and save changes
            dataContext.Remove(selectedBook);
            dataContext.SaveChanges();  
            Console.WriteLine($"Something was deleted.");
        }

        private void Update()
        {
            // TODO: Find the object the user wants to update using
            // Object selectedObject = SelectObject();
            Book selectedBook = SelectBook();
            // TODO: Ask user for new details of the object
            Console.WriteLine("Book name:");
            string newName = Console.ReadLine();
            selectedBook.Name = newName;
            // TODO: Update object based on provided details and save changes
            dataContext.Update(selectedBook);
            dataContext.SaveChanges();
            Console.WriteLine($"Something was updated.");
        }

        private void AddNew()
        {
            // TODO: Ask user for details of new object
            Console.WriteLine("Book name:");
            string bookName = Console.ReadLine();
            // TODO: Create new object based on provided details
            Book newBook = new Book(bookName);
            // TODO: Add object to dataContext and save changes
            dataContext.Add(newBook);
            dataContext.SaveChanges();
            Console.WriteLine("Something was added.");
        }

        private Book SelectBook()
        {
            ShowAll();
            int selectedBookId;
            Book? selectedBook = null;

            do
            {
                selectedBookId = Helpers.AskForInt("Enter ID of book");
                // TODO: Find theselected object:
                selectedBook = dataContext.Books.Find(selectedBookId);
                // selectedObject = dataContext.Objects.Find(selectedObjectId);

            } 
            while (selectedBook == null);

            return selectedBook;
        }

        private void ShowAll()
        {
                               
            Console.WriteLine("================ All Objects ================");

            // TODO: Get all object using
            // List<Object> objects = dataContext.Objects.ToList();
            List<Book>books = dataContext.Books.ToList();
            // TODO: Rewrite Object, o and objects to the correct type and name
            foreach (Book book in books)
            {
                Console.WriteLine(book.Name);
            }
            Console.WriteLine("=============================================");
        }

        private string ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Show all books");
            Console.WriteLine("2. Add new book");
            Console.WriteLine("3. Update book");
            Console.WriteLine("4. Delete book");
            Console.WriteLine("X. Exit");

            string userInput = Helpers.Ask("Make your choice and press <ENTER>.");
            return userInput;
        }
    }
}