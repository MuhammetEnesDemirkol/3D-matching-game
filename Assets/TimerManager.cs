using UnityEngine;
using UnityEngine.UI;    // Button için
using TMPro;            // TextMeshPro için

public class TimerManager : MonoBehaviour
{
    [Header("Zaman Ayarlarý")]
    [Tooltip("Oyunun baþlangýç süresi (saniye). 30 -> 30'dan geri sayar.")]
    public float timeLeft = 30f;

    [Header("UI Bileþenleri (TextMeshPro)")]
    [Tooltip("Kalan süreyi gösterecek TextMeshPro bileþeni.")]
    public TextMeshProUGUI timerText;

    [Tooltip("Süre bittiðinde aktif olacak, 'Game Over' yazýsý içeren TextMeshPro bileþeni.")]
    public TextMeshProUGUI gameOverText;

    [Header("Ekstra Süre Butonu")]
    [Tooltip("Süreye bir defa +10 saniye eklemek için kullanýlacak buton.")]
    public Button addTimeButton;

    // Oyun bitti mi?
    private bool isGameOver = false;

    // Ekstra süre butonu sadece 1 defa kullanýlabilsin
    private bool hasUsedExtraTime = false;

    private void Start()
    {
        // Baþta "Game Over" yazýsýný gizle
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        // TimerText'i ilk kez güncelle
        UpdateTimerText();

        // Eðer butonu Inspector'dan baðladýysanýz, buradan da ekleyebilirsiniz:
        // addTimeButton.onClick.AddListener(AddExtraTime);

        // Butonun varsayýlan olarak aktif/etkileþimli olduðundan emin olalým
        if (addTimeButton != null)
            addTimeButton.interactable = true;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                isGameOver = true;

                // "Game Over" yazýsý ekrana gelsin
                if (gameOverText != null)
                    gameOverText.gameObject.SetActive(true);

                // Oyunu durdurmak isterseniz:
                // Time.timeScale = 0f;
            }

            UpdateTimerText();
        }
    }

    /// <summary>
    /// Süreye +10 saniye ekleyen metod.
    /// Yalnýzca bir kez kullanýlabilir (hasUsedExtraTime kontrolü).
    /// </summary>
    public void AddExtraTime()
    {
        // Eðer oyun bitmediyse ve henüz buton kullanýlmadýysa
        if (!isGameOver && !hasUsedExtraTime)
        {
            timeLeft += 10f;
            hasUsedExtraTime = true;

            // Butonu bir daha kullanýlamaz hale getirelim
            if (addTimeButton != null)
                addTimeButton.interactable = false;
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Kalan süreyi tam sayý þeklinde gösterelim
            timerText.text = Mathf.Ceil(timeLeft).ToString();
        }
    }
}
