namespace PKS2
{
    internal class Contact
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public Contact(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }
    }
}
