using System;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to Jitu's Course Platform!");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UsersModule.RegisterUser();
                    break;
                case 2:
                    User user = UsersModule.Login();
                    if (user != null && user.Role == "Admin")
                    {
                        Admin admin = AdminModule.Login();
                        if (admin != null)
                        {
                            AdminDashboard.Show();
                        }
                        else
                        {
                            Console.WriteLine("Admin login failed. Invalid username or password.");
                        }
                    }
                    else if (user != null)
                    {
                        UserDashboard.Show(user);
                    }
                    else
                    {
                        Console.WriteLine("Login failed. Invalid username or password.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
