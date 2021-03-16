namespace WebsiteCommands.Commands
{
    public class WebsiteCommandData
    {
        public string Url { get; set; }

        public string Message { get; set; }

        public WebsiteCommandData()
        {
            Url = "";
            Message = "";
        }
    }
}
