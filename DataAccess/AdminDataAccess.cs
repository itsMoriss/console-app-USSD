using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class AdminDataAccess
{
    private string adminFilePath = "Data/admin.txt";

    public List<Admin> GetAdmins()
    {
        List<Admin> admins = new List<Admin>();
        string[] adminLines = File.ReadAllLines(adminFilePath);

        foreach (string line in adminLines)
        {
            string[] userData = line.Split(',');
            string username = userData[0];
            string password = userData[1];
            string role = userData[2];

            if (role == "Admin")
            {
                admins.Add(new Admin(username, password, role));
            }
        }

        return admins;
    }

    public void RegisterAdmin(string username, string password)
    {
        string adminData = $"{username},{password},Admin";
        File.AppendAllText(adminFilePath, adminData + Environment.NewLine);
    }
}
