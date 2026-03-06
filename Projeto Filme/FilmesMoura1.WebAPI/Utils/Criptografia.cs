namespace FilmesMoura1.WebAPI.Utils;

 static class Criptografia
{
    public static string GerarHash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);

    }

    public static bool ComparaHash(string senhaForm, string senhaBanco)
    {
        return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
    }
}
