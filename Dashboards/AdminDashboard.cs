class AdminDashboard
{
    public static void Show()
    {
        while (true)
        {
            Console.WriteLine("Welcome, Admin!");
            Console.WriteLine("1. Add a New Course");
            Console.WriteLine("2. View All Courses");
            Console.WriteLine("3. Delete a Course");
            Console.WriteLine("4. Update a Course");
            Console.WriteLine("5. View Analytics");
            Console.WriteLine("6. Logout");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddNewCourse();
                    break;
                case 2:
                    ViewAllCourses();
                    break;
                case 3:
                    DeleteCourse();
                    break;
                case 4:
                    UpdateCourse();
                    break;
                case 5:
                    ViewAnalytics();
                    break;
                case 6:
                    Console.WriteLine("Logging out...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void AddNewCourse()
    {
        Console.Write("Enter course name: ");
        string courseName = Console.ReadLine();
        Console.Write("Enter course price: ");
        int coursePrice = int.Parse(Console.ReadLine());

        // Implement logic to save the new course to courses.txt
        // Example:
        string courseData = $"{courseName},{coursePrice}";
        File.AppendAllText("Data/courses.txt", courseData + Environment.NewLine);

        Console.WriteLine("Course added successfully!");
    }

    private static void ViewAllCourses()
    {
        Console.WriteLine("All Courses:");

        string[] coursesLines = File.ReadAllLines("Data/courses.txt");
        foreach (string line in coursesLines)
        {
            string[] courseData = line.Split(',');
            string courseName = courseData[0];
            int coursePrice = int.Parse(courseData[1]);
            Console.WriteLine($"- {courseName} @ {coursePrice}");
        }
    }

    private static void DeleteCourse()
    {
        Console.Write("Enter the name of the course to delete: ");
        string courseName = Console.ReadLine();

        // Implement logic to delete the course from courses.txt
        // Example:
        string[] coursesLines = File.ReadAllLines("Data/courses.txt");
        List<string> updatedCourses = new List<string>();

        foreach (string line in coursesLines)
        {
            string[] courseData = line.Split(',');
            if (courseData[0] != courseName)
            {
                updatedCourses.Add(line);
            }
        }

        File.WriteAllLines("Data/courses.txt", updatedCourses);
        Console.WriteLine("Course deleted successfully!");
    }

    private static void UpdateCourse()
    {
        Console.Write("Enter the name of the course to update: ");
        string courseName = Console.ReadLine();

        // Implement logic to update the course in courses.txt
        // Example:
        string[] coursesLines = File.ReadAllLines("Data/courses.txt");
        List<string> updatedCourses = new List<string>();

        foreach (string line in coursesLines)
        {
            string[] courseData = line.Split(',');
            if (courseData[0] == courseName)
            {
                Console.Write("Enter new course price: ");
                int newCoursePrice = int.Parse(Console.ReadLine());
                courseData[1] = newCoursePrice.ToString();
                updatedCourses.Add(string.Join(",", courseData));
                Console.WriteLine("Course updated successfully!");
            }
            else
            {
                updatedCourses.Add(line);
            }
        }

        File.WriteAllLines("Data/courses.txt", updatedCourses);
    }

    private static void ViewAnalytics()
    {
        AnalyticsModule.ViewCoursePurchases();
    }
}
