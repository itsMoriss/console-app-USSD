using System;
using System.Collections.Generic;
using System.IO;

class CoursesModule
{
    private static List<Course> courses = new List<Course>();
    private static string coursesFilePath = "Data/courses.txt";

    public static void AddNewCourse(string name, decimal price)
    {
        string courseData = $"{name},{price}";
        File.AppendAllText(coursesFilePath, courseData + Environment.NewLine);
    }

    public static List<Course> GetCourses()
    {
        // Implement logic to retrieve available courses, e.g., from a file or database
        List<Course> courses = new List<Course>();

        string[] courseLines = File.ReadAllLines("Data/courses.txt");
        foreach (string line in courseLines)
        {
            string[] courseData = line.Split(',');
            string courseName = courseData[0];
            decimal coursePrice = decimal.Parse(courseData[1]);

            Course course = new Course(courseName, coursePrice);
            courses.Add(course);
        }

        return courses;
    }


    public static void ViewAllCourses()
    {
        List<Course> courses = GetCourses();

        Console.WriteLine("Available Courses:");
        foreach (Course course in courses)
        {
            Console.WriteLine($"{course.Name} - ${course.Price}");
        }
    }

    public static void DeleteCourse(string courseName)
    {
        List<Course> courses = GetCourses();
        Course courseToDelete = courses.Find(c => c.Name == courseName);

        if (courseToDelete != null)
        {
            courses.Remove(courseToDelete);
            SaveCourses(courses);
            Console.WriteLine($"Course '{courseName}' deleted.");
        }
        else
        {
            Console.WriteLine($"Course '{courseName}' not found.");
        }
    }

    public static void UpdateCourse(string courseName, string newName, decimal newPrice)
    {
        List<Course> courses = GetCourses();
        Course courseToUpdate = courses.Find(c => c.Name == courseName);

        if (courseToUpdate != null)
        {
            courseToUpdate.Name = newName;
            courseToUpdate.Price = newPrice;
            SaveCourses(courses);
            Console.WriteLine($"Course '{courseName}' updated.");
        }
        else
        {
            Console.WriteLine($"Course '{courseName}' not found.");
        }
    }

    public static void PurchaseCourse(User user)
    {
        List<Course> courses = GetCourses();

        Console.WriteLine("Available Courses:");
        for (int i = 0; i < courses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {courses[i].Name} (${courses[i].Price})");
        }

        Console.Write("Select a course to purchase (enter the number): ");
        int selectedCourseIndex = int.Parse(Console.ReadLine()) - 1;

        if (selectedCourseIndex >= 0 && selectedCourseIndex < courses.Count)
        {
            Course selectedCourse = courses[selectedCourseIndex];

            Console.WriteLine($"You've selected '{selectedCourse.Name}' for ${selectedCourse.Price}.");

            bool successfulPurchase = false;
            while (!successfulPurchase)
            {
                Console.Write("Simulating STK push... Enter top-up amount: ");
                decimal topUpAmount = decimal.Parse(Console.ReadLine());

                if (topUpAmount >= selectedCourse.Price)
                {
                    AnalyticsDataAccess analyticsDataAccess = new AnalyticsDataAccess();
                    analyticsDataAccess.SavePurchaseData(user.Username, selectedCourse.Name);

                    Console.WriteLine($"Congratulations! You've successfully purchased '{selectedCourse.Name}'.");
                    successfulPurchase = true;
                }
                else
                {
                    Console.WriteLine("Insufficient funds. Please top up your account or press Enter to cancel.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid course selection.");
        }
    }

    private static void SaveCourses(List<Course> courses)
    {
        File.WriteAllText(coursesFilePath, string.Empty);
        foreach (Course course in courses)
        {
            string courseData = $"{course.Name},{course.Price}";
            File.AppendAllText(coursesFilePath, courseData + Environment.NewLine);
        }
    }

     public static void ViewAnalytics()
    {
        AnalyticsModule.ViewCoursePurchases();
    }
}
