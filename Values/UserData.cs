namespace demoblaze_selenium_csharp.Values
{
    public class UserData
    {
        public UserData(
            string email,
            string name,
            string message,
            string password,
            string card)
        {
            Email = email;
            Name = name;
            Message = message;
            Password = password;
            CreditCardNumber = card;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
        public string CreditCardNumber { get; set; }
    }
}