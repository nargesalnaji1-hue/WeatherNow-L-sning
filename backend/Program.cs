using System;
using System.Threading.Tasks;
using WeatherNow.Backend.Services;

namespace WeatherNow.Backend
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== WeatherNow Email Processor ===");
            
            var emailService = new EmailService();

            // Test-mejl 1: Support-ärende
            string email1 = "Hej, er app kraschar varje gång jag försöker se prognosen för Stockholm. Vad är fel?";
            var result1 = await emailService.ProcessIncomingEmail(email1);
            PrintResult(email1, result1);

            // Test-mejl 2: Klagomål
            string email2 = "Jag är mycket missnöjd med att ni har börjat ta betalt för tjänster som var gratis förut!";
            var result2 = await emailService.ProcessIncomingEmail(email2);
            PrintResult(email2, result2);

            Console.WriteLine("Processering klar.");
        }

        static void PrintResult(string original, EmailProcessResult result)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Inkommande: {original}");
            Console.WriteLine($"Identifierad Kategori: {result.Category}");
            Console.WriteLine($"Genererat Svarsförslag: {result.DraftResponse}");
            Console.WriteLine($"Tidstämpel: {result.ProcessedAt}");
            Console.WriteLine("--------------------------------------------------\n");
        }
    }
}
