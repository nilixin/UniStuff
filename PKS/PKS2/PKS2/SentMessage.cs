namespace PKS2
{
    public class SentMessage
    {
        public string DestinationAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public SentMessage(string destinationAddress, string subject, string body)
        {
            DestinationAddress = destinationAddress;
            Subject = subject;
            Body = body;
        }

        
    }
}
