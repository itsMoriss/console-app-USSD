using System;
using System.Collections.Generic;
using System.Linq;

class AdminModule
{
    public static Admin Login()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        AdminDataAccess adminDataAccess = new AdminDataAccess();
        List<Admin> admins = adminDataAccess.GetAdmins();
        Admin admin = admins.FirstOrDefault(a => a.Username == username && a.Password == password);

        if (admin != null)
        {
            if (admin.Role != "Admin")
            {
                Console.WriteLine("Login failed. You are not an admin.");
                return null;
            }

            Console.WriteLine("Login successful!");
            return admin;
        }
        else
        {
            Console.WriteLine("Login failed. Invalid credentials.");
            return null;
        }
    }

    public static void ShowAdminDashboard(Admin admin)
    {
        Console.WriteLine($"Welcome, {admin.Username} (Admin)!");
        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Add a new course");
        Console.WriteLine("2. View all courses");
        Console.WriteLine("3. Delete a course");
        Console.WriteLine("4. Update a course");
        Console.WriteLine("5. View analytics");
        Console.WriteLine("6. Logout");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter course name: ");
                string courseName = Console.ReadLine();
                Console.Write("Enter course price: ");
                decimal coursePrice = decimal.Parse(Console.ReadLine());
                CoursesModule.AddNewCourse(courseName, coursePrice);
                Console.WriteLine("Course added successfully!");
                ShowAdminDashboard(admin);
                break;

            case 2:
                CoursesModule.ViewAllCourses();
                ShowAdminDashboard(admin);
                break;

            case 3:
                Console.Write("Enter the name of the course to delete: ");
                string courseToDelete = Console.ReadLine();
                CoursesModule.DeleteCourse(courseToDelete);
                ShowAdminDashboard(admin);
                break;

            case 4:
                Console.Write("Enter the name of the course to update: ");
                string courseToUpdate = Console.ReadLine();
                Console.Write("Enter the new name for the course: ");
                string newCourseName = Console.ReadLine();
                Console.Write("Enter the new price for the course: ");
                decimal newCoursePrice = decimal.Parse(Console.ReadLine());
                CoursesModule.UpdateCourse(courseToUpdate, newCourseName, newCoursePrice);
                ShowAdminDashboard(admin);
                break;

            case 5:
                CoursesModule.ViewAnalytics();
                ShowAdminDashboard(admin);
                break;

            case 6:
                Program.Main(new string[0]);
                break;

            default:
                Console.WriteLine("Invalid choice.");
                ShowAdminDashboard(admin);
                break;
        }
    }
}
