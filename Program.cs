using System;
using System.Security.Cryptography;

public class VerificationService
{
    public string GenerateOtpCode()
    {
        return RandomNumberGenerator.GetInt32(100000, 1000000).ToString();
    }

    public bool VerifyCode(string inputCode, string expectedCode)
    {
        if (string.IsNullOrWhiteSpace(inputCode) || string.IsNullOrWhiteSpace(expectedCode))
        {
            return false;
        }
        return inputCode == expectedCode;
    }
}

class Program
{
    static void Main()
    {
        var authService = new VerificationService();
        string expectedCode = authService.GenerateOtpCode();
        
        Console.WriteLine($"[Системное сообщение] Код отправлен: {expectedCode}");
        Console.WriteLine(new string('-', 30));
        Console.Write("Введите 6-значный код подтверждения: ");
        
        string userInput = expectedCode; 
        Console.WriteLine(userInput);

        if (authService.VerifyCode(userInput, expectedCode))
        {
            Console.WriteLine("✅ Успех: Верификация пройдена!");
        }
        else
        {
            Console.WriteLine("❌ Ошибка: Неверный код.");
        }
    }
}