# Nesne Eşleştirme ve Skor Sistemi Projesi

Bu proje, Unity kullanarak geliştirilmiş bir **Nesne Eşleştirme Oyunu** örneğidir. Oyuncu, aynı türdeki nesneleri yok ederek skor kazanır, zaman geri sayar ve belirli ek özelliklerle (Double Score, +10 saniye vb.) oyuna çeşitlilik katılır.

# Özellikler

1. **Nesne Eşleştirme Mantığı**  
   - \`CheckMatching\` script’i ile sahnede aynı türdeki iki nesne tespit edildiğinde bu nesneler yok edilir.  
   - Yanlış eşleşme durumunda nesneler fırlatılabilir veya başka bir aksiyon tanımlanabilir.

2. **Skor Sistemi (Statik Skor)**  
   - \`GameManager\` (veya benzeri) script, sahneyi yeniden yükleseniz bile skoru korur.  
   - \`AddScore(int)\` fonksiyonu başarılı eşleşmelerde çağrılarak skor artırılır.  

3. **Zaman Geri Sayımı**  
   - 30’dan geri sayan bir sayaç (\`TimerManager\` vb. script).  
   - Süre bittiğinde “Game Over” yazısı aktif olur ve oyun durdurulabilir (\`Time.timeScale = 0\`) ya da farklı bir mantık izlenebilir.

4. **Double Score**  
   - Oyuncu, butona **sadece bir kez** basarak mevcut skoru ikiye katlayabilir.  
   - Buton tıklandıktan sonra devre dışı (interactable = false) kalır.

5. **+10 Saniye Butonu**  
   - Oyuncu, yine yalnızca bir defa kullanabileceği butonla süreye +10 saniye ekleyebilir.  
   - Oyun boyunca en fazla bir kez basılabilir.

6. **Build ve WebGL Desteği**  
   - Proje **WebGL Build Support** yüklü Unity Editor ile Web için de derlenebilir.  
   - `File > Build Settings > WebGL > Switch Platform` adımlarıyla WebGL platformuna geçip “Build” alınabilir.

---



- **Scripts/**: Projenin C# kodlarını barındırır.  
- **Prefabs/**: Nesne prefab’ları (küp, silindir vb.).  
- **Scenes/**: Unity sahneleri.  
- **UI/**: Canvas, butonlar ve diğer arayüz bileşenleri.

---

## **Kurulum ve Çalıştırma**

1. **Unity Versiyonu**:  
   - Projenin sorunsuz açılması için Unity **(2020 veya üzeri)** ve **WebGL Build Support** modülüne ihtiyaç duyulabilir.  

2. **Projenin İndirilmesi**  
   - Kaynak kodu veya proje klasörünü klonlayın/indirin.  
   - Unity Hub üzerinden **Add** butonuyla proje klasörünü ekleyin.

3. **Açma ve Düzenleme**  
   - Unity Hub’da projeyi seçip **Open** diyerek açabilirsiniz.  
   - \`Scenes\` klasöründeki ana sahneyi (\`MainScene\` vb.) açın.

4. **Oyun Testi (Play Mode)**  
   - Unity Editor içerisinde **Play** butonuna tıklayarak oyunu test edin.  
   - Nesneleri sürükleyip bırakabilir, eşleştirme sonucunda skor kazanabilirsiniz.  
   - Sayaç geri sayar, süre bittiğinde “Game Over” görünebilir.  
   - Butonlarla (Double Score, +10 Saniye) ekstra özellikleri deneyebilirsiniz.

---

## **WebGL’e Build Alma**

1. **WebGL Modülü Kurulumu**  
   - Unity Hub → **Installs** → İlgili Unity sürümü → **Add Modules** → **WebGL Build Support**.

2. **Build Settings**  
   - **File > Build Settings** penceresini açın.  
   - Solda **WebGL** platformunu seçip **Switch Platform** butonuna tıklayın.  
   - **Scenes in Build** listesinin doğru sahneleri içerdiğinden emin olun.  

3. **Build**  
   - **Build** veya **Build and Run** butonuna basın.  
   - Derleme işlemi tamamlandığında Unity, seçtiğiniz klasöre WebGL dosyalarını (index.html, .data, .wasm vb.) çıkarır.  
   - Test etmek için basit bir yerel sunucu (örn. Python `http.server`) veya Unity’nin **Build and Run** seçeneğini kullanın.

---

## **Örnek Oynanış Senaryosu**

1. **Oyuna Başlama**  
   - Süre 30’dan geriye saymaya başlar.  
   - Ekranda başlangıç skoru (0) görünür.

2. **Nesne Eşleştirme**  
   - Aynı türde iki nesneyi doğru şekilde yerleştirerek yok edin.  
   - **GameManager** → `AddScore(10);` ile skor artar.

3. **Buton Kullanımları**  
   - **Double Score Butonu**: Bir kez tıklayın, skor ikiye katlansın. Sonra buton devre dışı kalır.  
   - **+10 Saniye Butonu**: Süreye ek 10 sn ekleyin, bir daha kullanılamaz.

4. **Süre Bittiğinde**  
   - “Game Over” yazısı aktifleşir, başka etkileşim kalmaz (\`Time.timeScale = 0\` vb.).

---

## **Katkıda Bulunanlar ve Geliştirme**

- **Kod**: [Sizin/ekibinizin isimleri], CheckMatching, GameManager, TimerManager vb.  
- **Model ve Prefablar**: [Küp, Silindir, Sphere vb. Unity primitive veya özel modeller].  
- **UI**: [Butonlar, TextMeshPro bileşenleri].

Proje serbestçe geliştirilebilir ve yeni özellikler eklenebilir (örn. farklı zorluk seviyeleri, çevrimiçi skor tablosu, farklı objeler vb.).

---

## **Lisans (Opsiyonel)**

Eğer belirli bir lisans altında paylaşıyorsanız (MIT, Apache 2.0, vb.), buraya ekleyebilirsiniz.

**Örnek**:

```
MIT License

Copyright (c) 2023 ...
Permission is hereby granted, free of charge, to any person obtaining a copy of this software ...
```

---

Bu örnek **README.md** taslağını projenizin ihtiyaçlarına göre özgürce güncelleyebilir, daha fazla teknik detay veya kurulum bilgisi ekleyebilirsiniz. Projenize dair net, anlaşılır ve kılavuz niteliğinde bir belge oluşturmak, projeyi kullanacak veya inceleyecek kişilerin işini kolaylaştıracaktır.
