namespace TMobile.Api.Models
{
    public class LoginResponse
    {
        public int ResultCode { get; set; }
        public string Sub { get; set; }
        public string AccessToken { get; set; }
        public long Nbf { get; set; }
        public long Iat { get; set; }
        public long Exp { get; set; }
        public Guid Jti { get; set; }
    }
}
