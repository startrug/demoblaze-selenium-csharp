namespace demoblaze_selenium_csharp.Pages
{
    public class UserData
    {
        public UserData(string email, string name, string message, string password)
        {
            Email = email;
            Name = name;
            Message = message;
            Password = password;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
    }
}