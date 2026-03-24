namespace EventPlus.webAPI.Utils;

public static class Criptografia
{
    public static String GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword
            (senha);
    }

    public static bool CompararHash(String
        senhaInformada, string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify
            (senhaInformada, senhaBanco);
    }
}
