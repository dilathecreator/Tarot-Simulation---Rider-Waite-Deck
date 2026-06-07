# 🔮 Mistik Tarot Simülasyonu (TarotSim)

Geleneksel ezoterik sembolizm ile modern yazılım mühendisliği prensiplerini kesişim noktasında buluşturan, yüksek taşınabilirliğe (portability) sahip, full-stack mimari tabanlı bir dijital tarot rezonans ekosistemidir. 

Bu proje; veri çekme otomasyonlarından performans odaklı karıştırma algoritmalarına, katmanlı backend mimarisinden sıfır bağımlılıklı dinamik frontend optimizasyonuna kadar uzanan uçtan uca bir yazılım geliştirme serüveninin ürünüdür.

---

## 🚀 Mimari Yaklaşımı

Tarot Simülasyonu, kullanıcı deneyimini en üst seviyeye çıkarmak ve dağıtım (deployment) maliyetlerini sıfıra indirmek amacıyla **hibrit ve esnek bir mimariyle** kurgulanmıştır. 

Proje ilk aşamada `.NET 10 Web API` tabanlı bir backend katmanı ile tasarlanmış; veri modelleri, servisler ve API uç noktaları kurumsal standartlarda inşa edilmiştir. Projenin nihai fazında ise proaktif bir kararla, son kullanıcının veya jürinin yerel bilgisayarında .NET SDK kurulumu, yerel sunucu tetikleme veya veritabanı bağımlılığı gibi operasyonel bariyerleri ortadan kaldırmak hedeflenmiştir. 

Bu doğrultuda, kullanıcı deneyimini maksimize etmek için arketip rezonans algoritmaları Client-Side (İstemci Taraflı) JavaScript katmanına taşınarak optimize edilmiştir. Böylece proje; kurumsal bir backend felsefesine sahip, tek bir HTML dosyasıyla sıfır kurulumla her platformda anında çalışabilen benzersiz bir yapıya dönüştürülmüştür.

---

## 🧠 Geliştirme Aşamaları ve Teknik Katmanlar

### 1. Veri Modelleme & Çekme Süreci (Data Ingestion & Mapping)
* **Arketip Veri Tabanı:** Tarot terminolojisinin en köklü yapısı olan 22 Major Arcana ve 56 Minor Arcana (Değnek, Kupa, Kılıç, Tılsım serileri) olmak üzere **78 kartlık evrensel destenin tamamı** derin anlam katmanlarıyla birlikte sisteme entegre edilmiştir.
* **Akıllı Görsel Entegrasyon:** Kartların orijinal Rider-Waite illüstrasyonları, evrensel kütüphane altyapısıyla dinamik olarak eşleştirilmiştir. Ters açılımlarda kart görsellerinin 180° dönmesi, CSS transformasyon motorları aracılığıyla dinamik olarak manipüle edilmiştir.

### 2. Algoritmik Altyapı & Rezonans Motoru
* **Fisher-Yates Shuffle:** Saf matematiksel rastgeleliği yakalamak için JavaScript `Math.random()` fonksiyonu, doğrusal zaman karmaşıklığında ($O(n)$) en adil dağıtımı sunan **Fisher-Yates Karıştırma Algoritması** ile harmanlanmıştır. Destenin aurası her buton tetiklendiğinde tamamen sıfırlanıp yeniden karıştırılır.
* **Olasılık ve Dinamik Analiz:** Her kartın düz açılım (☀️) veya ters açılım (🔄) gelme olasılıkları %50 frekans dengesiyle hesaplanır. Çekilen kartın açılımdaki konumuna göre anlam parametreleri dinamik olarak çözülür.

### 3. Katmanlı Backend Mimari Tasarımı (Repository Altyapısı)
Projenin köklerinde yer alan ve ölçeklenebilirliği kanıtlayan backend organizasyonu şu şekildedir:
* **TarotSim.Core:** Kart nesnelerini, ezoterik veri modellerini ve sistemin temel kontratlarını (interface) barındıran çekirdek katman.
* **TarotSim.API:** İstekleri karşılayan Controller yapılarını, `appsettings.json` konfigürasyonlarını ve servis kayıtlarını yöneten, dış dünyaya açık kapı.

### 4. Frontend & Kullanıcı Deneyimi Paneli
* **Mistik UI/UX:** Koyu tema dokusu, neon aura ışımaları ve tipografi seçimleriyle kullanıcının uygulama moduna girmesi kolaylaştırılmıştır.
* **Dinamik Açılım Matrisi:** Kullanıcıya tek sayfada 3 farklı derinlik sunulur:
  1. *Günün Odak Kartı* (1 Kart)
  2. *Üç Zaman Açılımı* (Geçmiş - Şimdi - Gelecek)
  3. *Kelt Haçı Açılımı* (10 Kartlık dev stratejik matris)

### 5. Test ve Kalite Güvence (QA)
* **TarotSim.Tests:** Projenin mantıksal doğrulamasını yapmak, sahte verilerle (Mock) veri akışını izlemek ve karıştırma algoritmasının tüm kartları eksiksiz döndürdüğünü doğrulamak amacıyla kurgulanan test katmanı.

---

## 🛡️ Güvenlik ve Modern Canlı Dağıtım (Deployment)

* **Secret Scanning & Güvenlik Duvarı:** Projenin geliştirme aşamasında entegre edilen harici API anahtarları ve servis konfigürasyonları, GitHub Push Protection protokolleri standartlarında taranmış ve güvenlik katmanları doğrulanmıştır.
* **GitHub Pages Entegrasyonu:** Sunucu maliyetlerini ortadan kaldıran istemci taraflı optimizasyon sayesinde proje, ana dizindeki mimari üzerinden doğrudan buluta (GitHub Pages) deploy edilmeye hazır hale getirilmiştir.

---

## 🛠️ Yerel Çalıştırma Talimatı

Uygulama harici hiçbir SDK veya sunucu bağımlılığına ihtiyaç duymaz:
1. Bu depoyu bilgisayarınıza klonlayın veya zip olarak indirin.
2. `TarotSim.API/wwwroot/index.html` dosyasını tarayıcınızda (Chrome, Safari, Edge) çift tıklayarak açın.
3. Kozmik frekansınızı seçin ve kaderi karıştırmaya başlayın.

---
*Geleneksel sembolizmin yazılım mimarisiyle yeniden doğuşu. Dila tarafından geliştirildi.*

## 🤖 Yapay Zeka (AI) Destekli Mühendislik ve Co-Pilot Kullanımı

Bu projenin geliştirme döngüsünde, modern yazılım dünyasının getirdiği üretken yapay zeka (Generative AI) pratiklerinden stratejik olarak faydalanılmıştır. Geliştirme sürecinde **Gemini** ve **Claude** modelleri birer "Pair Programmer" (Eş Yazılımcı) olarak ekosisteme dahil edilmiştir:

* **Prompt Mühendisliği ile Veri Doğrulama:** 78 kartın her birine ait düz ve ters ezoterik anlam parametrelerinin, geleneksel Rider-Waite sembolizmine %100 sadık kalacak şekilde rafine edilmesi ve JSON veri setine dönüştürülmesi aşamalarında AI modellerinden semantik destek alınmıştır.
* **Kod Refaktörleme ve Optimizasyon:** Katmanlı backend mimarisinden client-side mimariye geçiş aşamasında, JavaScript kod bloklarının tarayıcı performansını optimize etmek ve Fisher-Yates algoritmasının sınır koşullarını doğrulamak adına kod temizleme (refactoring) süreçlerinde yapay zekanın analitik yeteneklerinden yararlanılmıştır.

Bu yaklaşım, bir yazılımcı olarak yapay zekayı bir tehdit değil, operasyonel hızı ve kod kalitesini artıran güçlü bir co-pilot aracı olarak yönetme vizyonumu yansıtmaktadır.
