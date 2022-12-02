namespace Booking.System.WebApi.Settings
{
    public class JWTSettings
    {
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Secret { get; set; }
        public string ExpiresIn { get; set; }
    }
}
