class AnalyticsModule
{
    public static void ViewCoursePurchases()
    {
        AnalyticsDataAccess analyticsDataAccess = new AnalyticsDataAccess(); // Create an instance
        List<Purchase> purchases = analyticsDataAccess.GetPurchases();

        Console.WriteLine("Course Purchases:");
        foreach (Purchase purchase in purchases)
        {
            Console.WriteLine($"Username: {purchase.Username}, Course Purchased: {purchase.CoursePurchased}");
        }
    }

    public static void SavePurchaseData(User user, string courseName)
    {
        string purchaseData = $"{user.Username},{courseName}";
        File.AppendAllText("Data/analytics.txt", purchaseData + Environment.NewLine);
    }
}
