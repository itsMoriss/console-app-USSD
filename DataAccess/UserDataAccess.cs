using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class UserDataAccess
{
    private string usersFilePath = "Data/users.txt";

    public void RegisterUser(string username, string password, string role, decimal balance)
    {
        string userData = $"{username},{password},{role},{balance}"; // Initialize balance to 0.00
        File.AppendAllText(usersFilePath, userData + Environment.NewLine);
    }

    public List<User> GetUsers()
    {
        List<User> users = new List<User>();
        string[] userLines = File.ReadAllLines(usersFilePath);

        foreach (string line in userLines)
        {
            string[] userData = line.Split(',');
        
            if (userData.Length >= 4) // Check if there are at least 4 elements
            {
                string username = userData[0];
                string password = userData[1];
                string role = userData[2];
                decimal balance;
            
                if (decimal.TryParse(userData[3], out balance)) // Try to parse the balance
                {
                    users.Add(new User(username, password, role, balance));
                }
                else
                {
                    Console.WriteLine($"Error parsing balance for user: {username}");
                }
            }
            else
            {
                Console.WriteLine($"Invalid data format in line: {line}");
            }
        }

        return users;
    }


    public List<Admin> GetAdmins()
    {
        List<Admin> admins = new List<Admin>();
        string[] adminLines = File.ReadAllLines(usersFilePath);

        foreach (string line in adminLines)
        {
            string[] adminData = line.Split(',');
            string username = adminData[0];
            string password = adminData[1];
            string role = adminData[2];
            admins.Add(new Admin(username, password, role));
        }

        return admins;
    }

    // public void UpdateUserBalance(List<User> users, User user, decimal newBalance)
    // {
    //     User existingUser = users.FirstOrDefault(u => u.Username == user.Username);
    //     if (existingUser != null)
    //     {
    //         existingUser.Balance = newBalance;
    //         SaveUsersToFile(users);
    //     }
    // }

    public void UpdateUserBalance(User user, decimal newBalance)
    {
        List<User> users = GetUsers();

        User existingUser = users.FirstOrDefault(u => u.Username == user.Username);
        if (existingUser != null)
        {
            existingUser.Balance = newBalance;
            SaveUsersToFile(users);
        }
    }

    private void SaveUsersToFile(List<User> users)
    {
        List<string> userLines = new List<string>();
        foreach (User user in users)
        {
            string userData = $"{user.Username},{user.Password},{user.Role}";
            userLines.Add(userData);
        }
        File.WriteAllLines(usersFilePath, userLines);
    }
}
