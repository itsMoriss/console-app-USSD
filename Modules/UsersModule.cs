using System;
using System.Linq;

class UsersModule
{
    public static void RegisterUser()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        string role = "User"; // Default role
        decimal balance = 0; // Set initial balance to 0

        UserDataAccess dataAccess = new UserDataAccess(); // Create an instance
        dataAccess.RegisterUser(username, password, role, balance);
        Console.WriteLine("User registered successfully!");
    }

    public static User Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        UserDataAccess dataAccess = new UserDataAccess(); // Create an instance
        User user = dataAccess.GetUsers().FirstOrDefault(u => u.Username == username && u.Password == password); 
        return user;
    }
}
