namespace WebsiteCommands.Configuration
{
    public class WebsiteCommandConfig
    {
        public string CommandName { get; set; }

        public string? Description { get; set; }

        public string Url { get; set; }

        public string Message { get; set; }

        public WebsiteCommandConfig()
        {
            CommandName = "";
            Description = null;
            Url = "";
            Message = "";
        }
    }
}
