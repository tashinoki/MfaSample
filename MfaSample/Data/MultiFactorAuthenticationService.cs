using System.Net;
using OtpNet;

namespace MfaSample.Data;

public class MultiFactorAuthenticationService
{
    private const string Secret = "K4NXNUMFWKC6Y2AMKZQUROI2MWXPLV47";
    private const string UserId = "kenya.kinoshita@test.com";
    private const string AppName = "Sansan Data Hub";

    public string GetUri()
    {
        var secret = GetOrGenerateTwoFactorSecretsAsync();
        var qr = GenerateQrCodeUri(AppName, UserId, Secret);
        return qr;
    }

    public bool VerifyAsync(string verifyCode)
    {
        var totp = new Totp(Base32Encoding.ToBytes(Secret), totpSize: 6);
        if (!totp.VerifyTotp(verifyCode, out _, VerificationWindow.RfcSpecifiedNetworkDelay))
        {
            return false;
        }

        return true;
    }

    private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
    private string GenerateQrCodeUri(string appName, string userName, string unformattedSecrets)
    {
        return string.Format(
            AuthenticatorUriFormat,
            WebUtility.UrlEncode(appName),
            WebUtility.UrlEncode(userName),
            unformattedSecrets); ;
    }

    private string GetOrGenerateTwoFactorSecretsAsync()
    {
        //if (!string.IsNullOrEmpty(user.TwoFactorSecrets))
        //    return user.TwoFactorSecrets;

        var key = KeyGeneration.GenerateRandomKey();
        var secrets = Base32Encoding.ToString(key);

        // save secret to user

        return secrets;
    }
}