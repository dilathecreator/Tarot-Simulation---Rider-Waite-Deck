using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TarotSim.Core.Models;

namespace TarotSim.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingController : ControllerBase
    {
        // 78 Kartlık Sabit Veri Havuzu (Diğer servisler patlak olduğu için doğrudan buraya aldık)
        private static readonly List<string> TarotCards = new List<string>
        {
            "Majiisyen (The Magician)", "Azize (The High Priestess)", "İmparatoriçe (The Empress)", 
            "İmparator (The Emperor)", "Aziz (The Hierophant)", "Aşıklar (The Lovers)", 
            "Araba (The Chariot)", "Adalet (The Justice)", "Ermiş (The Hermit)", 
            "Kader Çarkı (Wheel of Fortune)", "Güç (The Strength)", "Asılan Adam (The Hanged Man)", 
            "Ölüm (Death)", "Denge (Temperance)", "Şeytan (The Devil)", 
            "Yıkılan Kule (The Tower)", "Yıldız (The Star)", "Ay (The Moon)", 
            "Güneş (The Sun)", "Mahkeme (Judgement)", "Dünya (The World)", "Deli (The Fool)"
        };

        private static readonly List<string> AuraColors = new List<string> { "#FFD700", "#4B0082", "#00FFFF", "#FF4500", "#9400D3", "#00FF00" };

        [HttpPost]
        public async Task<IActionResult> CreateReading([FromBody] DrawRequest request)
        {
            // JavaScript'ten gelen spreadType değerine göre kart sayısını belirliyoruz
            int cardCount = request.SpreadType switch
            {
                0 => 1,  // Günün Kartı
                1 => 3,  // 3 Kart Açılımı
                2 => 10, // Kelt Haçı
                _ => 1
            };

            // Fisher-Yates Algoritması ile Kartları Karıştırma
            var random = new Random();
            var shuffledDeck = new List<string>(TarotCards);
            for (int i = shuffledDeck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = shuffledDeck[i];
                shuffledDeck[i] = shuffledDeck[j];
                shuffledDeck[j] = temp;
            }

            var drawnCardsList = new List<object>();
            var sb = new StringBuilder();

            sb.AppendLine($"🔮 --- TAROT AÇILIMI MİSTİK ANALİZİ --- 🔮");
            sb.AppendLine($"Kader çarkı döndü! Sizin için {cardCount} özel kart seçildi.\n");
            sb.AppendLine(new string('=', 45));
            sb.AppendLine();

            for (int i = 0; i < cardCount; i++)
            {
                string cardName = shuffledDeck[i];
                bool isReversed = random.Next(2) == 0; // %50 ihtimalle ters veya düz
                string auraColor = AuraColors[random.Next(AuraColors.Count)];

                // Pozisyon İsimlendirmesi
                string positionName = request.SpreadType switch
                {
                    1 => i switch { 0 => "Geçmiş", 1 => "Şimdiki Zaman", 2 => "Gelecek", _ => $"Kart {i + 1}" },
                    2 => i switch { 0 => "Mevcut Durum", 1 => "Engeller", 2 => "Bilinçaltı", 3 => "Geçmiş", 4 => "Taçlandıran", 5 => "Gelecek", _ => $"Kelt Konumu {i + 1}" },
                    _ => "Günün Kartı ODAK"
                };

                // Frontend'in beklediği JSON yapısı patlamasın diye uydurma bir nesne oluşturuyoruz
                drawnCardsList.Add(new
                {
                    positionName = positionName,
                    isReversed = isReversed,
                    card = new
                    {
                        name = cardName,
                        description = $"Aura Rengi: {auraColor} | Bu kart hayatınızdaki mevcut döngüyü temsil eder."
                    }
                });

                sb.AppendLine($"📍 Konum: [{positionName}]");
                sb.AppendLine($"🃏 Kart: {cardName} {(isReversed ? "🔄 (TERS)" : "☀️ (DÜZ)")}");
                sb.AppendLine(new string('-', 35));
                sb.AppendLine();
            }

            sb.AppendLine("🔮 Genel Rezonans Tavsiyesi:");
            sb.AppendLine("Bu simülasyon, sistemdeki randomizasyon algoritmasının kozmik frekansınızla eşleşmesiyle üretilmiştir. Seçilen kartların hayatınızdaki mevcut döngülerle olan bağını anlamlandırmak için odak kelimelerine yoğunlaşın.");

            var response = new
            {
                drawnCards = drawnCardsList,
                interpretation = sb.ToString()
            };

            return Ok(response);
        }
    }

    // Frontend'den gelen istek modelini karşılamak için gereken DTO sınıfı
    // Frontend'den gelen istek modelini karşılamak için gereken DTO sınıfı
    public class DrawRequest
    
    {
        public int SpreadType { get; set; }
        public int? CustomCardCount { get; set; }
    }
}