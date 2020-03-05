namespace demoblaze_selenium_csharp.Pages
{
    public class ContactFormData
    {
        public ContactFormData(string email, string name, string message)
        {
            Email = email;
            Name = name;
            Message = message;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}