﻿using System.Runtime.CompilerServices;
using System.Text.Json;
using ConsoleApp7;

Admin admin = new Admin();
UsersList usersList = new UsersList();
LoginMenu loginMenu = new LoginMenu();
Library library = new Library();
string jsonLibraryFromFile = File.ReadAllText(@"D:\c#zadania\ConsoleApp7\path123.json");
library.library = JsonSerializer.Deserialize<List<Book>>(jsonLibraryFromFile);
Login();
void Login()
{
    while (true)
    {
        loginMenu.ShowMenu();
        switch (loginMenu.NavigateMenu())
        {
            case 1:
                RegularUser user = usersList.GetRegularUser(usersList.EnterUsername(), usersList.EnterPassword());
                if (user!=null)
                {
                    RegularUser(user);
                    break;
                }
                else
                {
                    Console.WriteLine("Błędne dane do logowania");
                    break;
                }
            case 2:
                usersList.AddUser();
                break;
            case 3:
                if (admin.AdminLogin())
                {
                    AdminUser();
                    break;
                }
                else
                {
                    Console.WriteLine("Błędne dane do logowania");
                    break;
                }
            case 4:
                Console.WriteLine("Do widzenia!");
                Environment.Exit(0);
                break;
        }
    }
}
void AdminUser()
    {
        while (true)
        {
            Console.Clear();
            admin.ShowMenu();
            switch (admin.NavigateMenu())
            {
                case 1:
                    library.AddBook(library.CreateBook());
                    string jsonLibrary = JsonSerializer.Serialize(library.library);
                File.WriteAllText(@"D:\c#zadania\ConsoleApp7\path123.json", jsonLibrary);
                break;
                case 2:
                    library.ShowFoundBooks(library.ChooseTypeToFind());
                    break;
                case 3:
                    library.DeleteBook();
                    break;
                case 4:
                    library.EditBookFromLibrary();
                    break;
                case 7:
                    Console.Clear();
                    Login();
                    break;

            }

        } 
    }
void RegularUser(RegularUser regularUser)
    {
        Console.Clear();
        while (true)
        {
            regularUser.ShowMenu();
            switch (regularUser.NavigateMenu())
            {
                case 1:
                    library.ShowFoundBooks(library.ChooseTypeToFind());
                    break;
                case 2:
                    regularUser.AddBookToFavourites(library.MoveFromLibraryToFavourites());
                    break;
                case 3:
                    regularUser.ShowFavouritesBooks();
                    break;
                case 4:
                    Console.Clear();
                    Login();
                    break;
            }
        }
    }

