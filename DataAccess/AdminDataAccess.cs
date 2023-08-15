using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class AdminDataAccess
{
    private string usersFilePath = "Data/users.txt";

    public List<Admin> GetAdmins()
    {
        List<Admin> admins = new List<Admin>();
        string[] userLines = File.ReadAllLines(usersFilePath);

        foreach (string line in userLines)
        {
            string[] userData = line.Split(',');
            string username = userData[0];
            string password = userData[1];
            string role = userData[2];

            if (role == "Admin")
            {
                admins.Add(new Admin(username, password,role));
            }
        }

        return admins;
    }
}
