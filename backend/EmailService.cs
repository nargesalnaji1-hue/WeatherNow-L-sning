using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherNow.Backend.Services
{
    /// <summary>
    /// Service för att hantera affärslogik kring inkommande kundmejl.
    /// Denna klass simulerar integrationen med en AI-modell för kategorisering.
    /// </summary>
    public class EmailService
    {
        // Simulerad databas för svarsmallar
        private readonly Dictionary<string, string> _responseTemplates = new Dictionary<string, string>
        {
            { "Support", "Hej! Tack för din fråga angående teknisk support. Vi tittar på ditt ärende..." },
            { "Klagomål", "Hej! Vi beklagar verkligen att du är missnöjd. Vi tar detta på största allvar..." },
            { "Beställning", "Hej! Tack för din beställning. Här är din orderbekräftelse..." },
            { "Allmänt", "Hej! Tack för att du hörde av dig till WeatherNow. Vi återkommer så snart vi kan." }
        };

        /// <summary>
        /// Processar ett inkommande mejl genom att kategorisera det och hämta en lämplig mall.
        /// </summary>
        /// <param name="emailBody">Innehållet i mejlet</param>
        /// <returns>Ett objekt med kategori och svarsförslag</returns>
        public async Task<EmailProcessResult> ProcessIncomingEmail(string emailBody)
        {
            // Här skulle ett API-anrop till en LLM (t.ex. GPT-4) ske i en riktig applikation.
            // För detta case simulerar vi logiken.
            
            string category = DetermineCategory(emailBody);
            string draft = GenerateDraft(category, emailBody);

            return new EmailProcessResult
            {
                Category = category,
                DraftResponse = draft,
                ProcessedAt = DateTime.Now
            };
        }

        private string DetermineCategory(string body)
        {
            body = body.ToLower();
            if (body.Contains("fungerar inte") || body.Contains("felmeddelande") || body.Contains("bugg"))
                return "Support";
            if (body.Contains("dåligt") || body.Contains("arg") || body.Contains("missnöjd"))
                return "Klagomål";
            if (body.Contains("köpa") || body.Contains("beställa") || body.Contains("prenumeration"))
                return "Beställning";
            
            return "Allmänt";
        }

        private string GenerateDraft(string category, string originalBody)
        {
            if (_responseTemplates.TryGetValue(category, out var template))
            {
                return template;
            }
            return _responseTemplates["Allmänt"];
        }
    }

    public class EmailProcessResult
    {
        public string Category { get; set; }
        public string DraftResponse { get; set; }
        public DateTime ProcessedAt { get; set; }
    }
}
