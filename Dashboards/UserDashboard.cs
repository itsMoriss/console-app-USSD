using System;
using System.Collections.Generic;

class UserDashboard
{
    public static void Show(User user)
    {
        while (true)
        {
            Console.WriteLine($"Welcome, {user.Username}!");
            Console.WriteLine("1. View All Courses");
            Console.WriteLine("2. Purchased Courses");
            Console.WriteLine("3. Purchase a Course");
            Console.WriteLine("4. Logout");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewAllCourses();
                    break;
                case 2:
                    ViewPurchasedCourses(user);
                    break;
                case 3:
                    PurchaseCourse(user);
                    break;
                case 4:
                    Console.WriteLine("Logging out...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void ViewAllCourses()
    {
        List<Course> availableCourses = CoursesModule.GetCourses();

        Console.WriteLine("Available Courses:");
        for (int i = 0; i < availableCourses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableCourses[i].Name} @ {availableCourses[i].Price}");
        }
    }

    // private static void ViewAllCoursesAndPurchase(User user)
    // {
    //     ViewAllCourses();

    //     Console.WriteLine("Do you want to purchase a course? (Y/N)");
    //     string choice = Console.ReadLine();

    //     if (choice.ToUpper() == "Y")
    //     {
    //         PurchaseCourse(user);
    //     }
    // }


    private static void ViewPurchasedCourses(User user)
    {
        Console.WriteLine($"Courses purchased by {user.Username}:");

        List<Purchase> purchases = AnalyticsModule.GetPurchases();
        foreach (Purchase purchase in purchases)
        {
            if (purchase.Username == user.Username)
            {
                Console.WriteLine($"- {purchase.CoursePurchased}");
            }
        }
    }


    private static void PurchaseCourse(User user)
    {
        List<Course> availableCourses = CoursesModule.GetCourses();

        Console.WriteLine("Available Courses:");
        for (int i = 0; i < availableCourses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableCourses[i].Name} @ {availableCourses[i].Price}");
        }

        Console.Write("Select a course to purchase (enter course number): ");
        int courseNumber = int.Parse(Console.ReadLine());

        if (courseNumber >= 1 && courseNumber <= availableCourses.Count)
        {
            Course selectedCourse = availableCourses[courseNumber - 1];
            if (user.Balance >= selectedCourse.Price)
            {
                user.Balance -= selectedCourse.Price;
                UserDataAccess dataAccess = new UserDataAccess();
                dataAccess.UpdateUserBalance(user, user.Balance);
                Console.WriteLine($"Congratulations! You have purchased {selectedCourse.Name}.");
                AnalyticsModule.SavePurchaseData(user, selectedCourse.Name);
            }
            else
            {
                Console.WriteLine("Insufficient balance to purchase this course.");
            }
        }
        else
        {
            Console.WriteLine("Invalid course number.");
        }
    }
}
