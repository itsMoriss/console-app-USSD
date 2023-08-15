using System;
using System.Collections.Generic;
using System.IO;

class AnalyticsDataAccess
{
    private string purchasesFilePath = "Data/analytics.txt";

    public void SavePurchaseData(string username, string coursePurchased)
    {
        string purchaseData = $"{username},{coursePurchased}";
        File.AppendAllText(purchasesFilePath, purchaseData + Environment.NewLine);
    }

    public List<Purchase> GetPurchases()
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
}
