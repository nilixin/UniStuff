namespace PKS2
{
    public class EmailMessage
    {
        public string RecipientAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailMessage(string recipientAddress, string subject, string body)
        {
            RecipientAddress = recipientAddress;
            Subject = subject;
            Body = body;
        }
    }
}
