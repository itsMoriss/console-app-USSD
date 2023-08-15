using System;
using System.Collections.Generic;
using System.IO;

class AnalyticsModule
{
    private static string purchasesFilePath = "Data/analytics.txt";

    public static void SavePurchaseData(User user, string coursePurchased)
    {
        string purchaseData = $"{user.Username},{coursePurchased}";
        File.AppendAllText(purchasesFilePath, purchaseData + Environment.NewLine);
    }

    public static List<Purchase> GetPurchases()
    {
        List<Purchase> purchases = new List<Purchase>();
        string[] purchaseLines = File.ReadAllLines(purchasesFilePath);

        foreach (string line in purchaseLines)
        {
            string[] purchaseData = line.Split(',');
            string username = purchaseData[0];
            string coursePurchased = purchaseData[1];
            purchases.Add(new Purchase(username, coursePurchased));
        }

        return purchases;
    }

    public static void ViewCoursePurchases()
    {
        List<Purchase> purchases = GetPurchases();

        Console.WriteLine("Course Purchases:");
        foreach (Purchase purchase in purchases)
        {
            Console.WriteLine($"- {purchase.Username} purchased {purchase.CoursePurchased}");
        }
    }
}
