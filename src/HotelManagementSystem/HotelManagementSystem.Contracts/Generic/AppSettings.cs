namespace HotelManagementSystem.Contracts.Generic
{
    public class AppSettings
    {
        public string AdminConnectionString { get; set; } = string.Empty;
        public string MxpConnectionString { get; set; } = string.Empty;
        public string AdminUrl { get; set; } = string.Empty;
        public string AdminClientId { get; set; } = string.Empty;
        public string AdminClientSecret { get; set; } = string.Empty;
        public string HotelManagementIdentityUrl { get; set; } = string.Empty;
    }
}
