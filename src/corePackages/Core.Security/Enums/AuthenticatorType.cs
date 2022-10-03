namespace Core.Security.Enums;

public enum AuthenticatorType
{
    None = 0,
    Email = 1,  //two faktoring giriş yapısı
    Otp = 2    //çeşitli yazılımlarla sağlanan giriş yöntemi
}