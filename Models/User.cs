class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public decimal Balance { get; set; }

    public User(string username, string password, string role, decimal balance)
    {
        Username = username;
        Password = password;
        Role = role;
        Balance = balance;
    }
}
