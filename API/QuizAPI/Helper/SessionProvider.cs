using System.IdentityModel.Tokens.Jwt;
using Service.Helper;

namespace QuizAPI.Helper
{
    public static class SessionProvider
    {
        public static CurrentUser GetCurrentSession(this HttpRequest request)
        {
            var user = new CurrentUser()
            {
                UserId = string.Empty,
                Name = string.Empty,
                IsAdmin = false
            };

            try
            {
                string header = request.Headers["Authorization"];
                string accessToken = header.Split(' ')[1];
                var token = new JwtSecurityToken(accessToken);
                user.UserId = ValueFromClaim<string>(token, AppClaim.UserId);
                user.Name = ValueFromClaim<string>(token, AppClaim.Name);
                user.IsAdmin = ValueFromClaim<bool>(token, AppClaim.IsAdmin);
            }
            catch { }

            return user;
        }

        private static T ValueFromClaim<T>(JwtSecurityToken token, string claimName)
        {
            var claimValue = token.Claims.FirstOrDefault(x => x.Type.Equals(claimName, StringComparison.OrdinalIgnoreCase));
            try
            {
                return (T)Convert.ChangeType(claimValue.Value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }
    }
}
