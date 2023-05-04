using System.Text;
using Tweetinvi.Security;

namespace ApiFinancialControl.Services;

public class EncryptService
{
    public static string EncryptPassword(string password)
    {
        var hash = new SHA1CryptoServiceProvider();
        var passwordBytes = Encoding.Default.GetBytes(password);
        var passwordHash = hash.ComputeHash(passwordBytes);
        var passwordHashBase64 = Convert.ToBase64String(passwordHash);

        return passwordHashBase64;

    }

}
