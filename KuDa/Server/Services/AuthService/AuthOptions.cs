using Microsoft.IdentityModel.Tokens;
using Server;
using System.Text;

namespace KuDa.Server.Services.AuthService
{
    public class AuthOptions
    {
        public const string ISSUER = "Kuda";
        public const string AUDIENCE = "KudaUsers";
        private static readonly string KEY;
        public static SymmetricSecurityKey GetKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

        static AuthOptions()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            KEY = config["AuthKey:DynamicAuthKey"]!;
        }
    }
}
