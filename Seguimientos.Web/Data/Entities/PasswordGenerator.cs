using System;
using System.Text;

public class PasswordGenerator
{
    public int Id { get; set; }
    public int Length { get; set; } = 8;
    public bool IncludeLowercase { get; set; } = true;
    public bool IncludeUppercase { get; set; } = true;
    public bool IncludeNumbers { get; set; } = true;
    public bool IncludeSymbols { get; set; } = true;
    public string GeneratedPassword { get; set; }

    public void GeneratePassword()
    {
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string symbols = "!@#$%^&*()_-+={[}];:'\",<.>/?";

        StringBuilder characterSet = new StringBuilder();

        if (IncludeLowercase) characterSet.Append(lowercase);
        if (IncludeUppercase) characterSet.Append(uppercase);
        if (IncludeNumbers) characterSet.Append(numbers);
        if (IncludeSymbols) characterSet.Append(symbols);

        if (characterSet.Length == 0)
        {
            throw new InvalidOperationException("Ningun caracter ha sido seleccionado");
        }

        Random random = new Random();
        StringBuilder password = new StringBuilder();

        for (int i = 0; i < Length; i++)
        {
            int index = random.Next(characterSet.Length);
            password.Append(characterSet[index]);
        }

        GeneratedPassword = password.ToString();
    }
}
