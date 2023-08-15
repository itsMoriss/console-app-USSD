class Purchase
{
    public string Username { get; }
    public string CoursePurchased { get; }

    public Purchase(string username, string coursePurchased)
    {
        Username = username;
        CoursePurchased = coursePurchased;
    }
}
