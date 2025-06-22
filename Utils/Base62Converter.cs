namespace UrlShortener.Utils;

public static class Base62Converter
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Encode(long value)
    {
        if (value == 0) return Alphabet[0].ToString();
        var s = "";
        while (value > 0)
        {
            s = Alphabet[(int)(value % 62)] + s;
            value /= 62;
        }
        return s;
    }
}
