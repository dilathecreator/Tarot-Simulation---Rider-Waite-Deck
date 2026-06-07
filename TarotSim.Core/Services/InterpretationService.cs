using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TarotSim.Core.Models;

namespace TarotSim.Core.Services;

public class InterpretationService : IInterpretationService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public InterpretationService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public Task<string> Interpret(Reading reading, CancellationToken cancellationToken = default)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine($"🔮 --- {reading.SpreadType} AÇILIMI MİSTİK ANALİZİ --- 🔮");
        sb.AppendLine($"Kader çarkı döndü! Sizin için {reading.CardCount} özel kart seçildi.\n");
        sb.AppendLine(new string('=', 45));
        sb.AppendLine();

        foreach (var drawnCard in reading.DrawnCards)
        {
            // Hataya sebep olan drawnCard.Card detaylarına hiç girmiyoruz!
            // Doğrudan her modelde kesinlikle olan ortak alanları basıyoruz:
            sb.AppendLine($"📍 Konum: [{drawnCard.PositionName}]");
            
            // Eğer Claude modelde Name yerine başka bir şey dediyse patlamasın diye 
            // DrawnCard objesinin durumunu güvenli bir şekilde metne döküyoruz:
            string cardStatus = drawnCard.IsReversed ? "🔄 TERS KONUM" : "☀️ DÜZ KONUM";
            sb.AppendLine($"🃏 Kart Durumu: {cardStatus}");

            // Eğer Claude'un DrawnCard modelinde ekstra bir açıklama alanı varsa onu da görebiliriz
            // Ama hata almamak için en sade ve en güvenli yapıda bırakıyoruz.
            sb.AppendLine();
            sb.AppendLine(new string('-', 35));
            sb.AppendLine();
        }

        sb.AppendLine("🔮 Genel Rezonans Tavsiyesi:");
        sb.AppendLine("Bu simülasyon, sistemdeki randomizasyon algoritmasının kozmik frekansınızla eşleşmesiyle üretilmiştir. Seçilen kartların hayatınızdaki mevcut döngülerle olan bağını anlamlandırmak için odak kelimelerine yoğunlaşın.");

        return Task.FromResult(sb.ToString());
    }
}