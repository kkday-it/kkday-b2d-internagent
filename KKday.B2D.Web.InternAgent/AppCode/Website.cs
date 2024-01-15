
namespace KKday.B2D.Web.InternAgent.AppCode
{
    public sealed class Website
    {
        public static readonly Website Instance = new Website();
         
        // Database Connection
        public string SqlConnectionString { get; private set; }

        public string KKdayApiUrl { get; private set; }
        public string KKdayApiAuthorizeToken { get; private set; }

        public string Currency  { get; private set; }
        public string Marketing  { get; private set; }
     
        private Website()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Init(IConfiguration config)
        {
            this.KKdayApiUrl = config["KKdayApi:Url"];
            this.KKdayApiAuthorizeToken = config["KKdayApi:AuthorToken"];
            this.Currency = config["Currency"];
            this.Marketing = config["Marketing"];
        }
         
    }
}
