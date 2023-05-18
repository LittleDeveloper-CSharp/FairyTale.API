using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FairyTale.API
{
    public static class JWTOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "1EC575BFECB64C9B5BA4525BE4448";   // ключ для шифрации
        public const int LIFETIME = 5; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
