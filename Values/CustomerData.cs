namespace demoblaze_selenium_csharp.Values
{
    public class CustomerData
    {
        public CustomerData(
            string email,
            string name,
            string message,
            string password,
            string cardNumber,
            string expirationMonth,
            string expirationYear,
            string country,
            string city)
        {
            Email = email;
            Name = name;
            Message = message;
            Password = password;
            CreditCardNumber = cardNumber;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            Country = country;
            City = city;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}