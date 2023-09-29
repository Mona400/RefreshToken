namespace JWTAuthentication.Helpers
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issure { get; set; }
        public string Audience { get; set; }
        public string DurationInDays { get; set; }
    }
}
