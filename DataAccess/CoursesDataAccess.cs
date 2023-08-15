using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class CoursesDataAccess
{
    private static readonly string DataFolderPath = "Data/courses.txt";

    public static bool SaveCourse(Course course)
    {
        string courseData = $"{course.Name},{course.Price}";
        try
        {
            File.AppendAllText(DataFolderPath + "courses.txt", courseData + Environment.NewLine);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static List<Course> GetCourses()
    {
        List<Course> courses = new List<Course>();
        string[] courseLines = File.ReadAllLines(DataFolderPath + "courses.txt");

        foreach (string line in courseLines)
        {
            string[] courseData = line.Split(',');
            courses.Add(new Course(courseData[0], int.Parse(courseData[1])));
        }

        return courses;
    }

    // Implement methods for course deletion and update...
    public static bool DeleteCourse(string courseName)
    {
        string coursesFilePath = DataFolderPath + "courses.txt";

        try
        {
            string[] courseLines = File.ReadAllLines(coursesFilePath);
            List<string> updatedCourses = new List<string>();

            foreach (string line in courseLines)
            {
                string[] courseData = line.Split(',');
                if (courseData[0] != courseName)
                {
                    updatedCourses.Add(line);
                }
            }

            File.WriteAllLines(coursesFilePath, updatedCourses);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool UpdateCourse(string courseName, int newCoursePrice)
    {
        string coursesFilePath = DataFolderPath + "courses.txt";

        try
        {
            string[] courseLines = File.ReadAllLines(coursesFilePath);
            List<string> updatedCourses = new List<string>();

            foreach (string line in courseLines)
            {
                string[] courseData = line.Split(',');
                if (courseData[0] == courseName)
                {
                    courseData[1] = newCoursePrice.ToString();
                    updatedCourses.Add(string.Join(",", courseData));
                }
                else
                {
                    updatedCourses.Add(line);
                }
            }

            File.WriteAllLines(coursesFilePath, updatedCourses);
            return true;
        }
        catch
        {
            return false;
        }
    }
    

}
