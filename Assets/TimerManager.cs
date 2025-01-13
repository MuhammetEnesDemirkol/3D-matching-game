using UnityEngine;
using UnityEngine.UI;    // Button i�in
using TMPro;            // TextMeshPro i�in

public class TimerManager : MonoBehaviour
{
    [Header("Zaman Ayarlar�")]
    [Tooltip("Oyunun ba�lang�� s�resi (saniye). 30 -> 30'dan geri sayar.")]
    public float timeLeft = 30f;

    [Header("UI Bile�enleri (TextMeshPro)")]
    [Tooltip("Kalan s�reyi g�sterecek TextMeshPro bile�eni.")]
    public TextMeshProUGUI timerText;

    [Tooltip("S�re bitti�inde aktif olacak, 'Game Over' yaz�s� i�eren TextMeshPro bile�eni.")]
    public TextMeshProUGUI gameOverText;

    [Header("Ekstra S�re Butonu")]
    [Tooltip("S�reye bir defa +10 saniye eklemek i�in kullan�lacak buton.")]
    public Button addTimeButton;

    // Oyun bitti mi?
    private bool isGameOver = false;

    // Ekstra s�re butonu sadece 1 defa kullan�labilsin
    private bool hasUsedExtraTime = false;

    private void Start()
    {
        // Ba�ta "Game Over" yaz�s�n� gizle
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        // TimerText'i ilk kez g�ncelle
        UpdateTimerText();

        // E�er butonu Inspector'dan ba�lad�ysan�z, buradan da ekleyebilirsiniz:
        // addTimeButton.onClick.AddListener(AddExtraTime);

        // Butonun varsay�lan olarak aktif/etkile�imli oldu�undan emin olal�m
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

                // "Game Over" yaz�s� ekrana gelsin
                if (gameOverText != null)
                    gameOverText.gameObject.SetActive(true);

                // Oyunu durdurmak isterseniz:
                // Time.timeScale = 0f;
            }

            UpdateTimerText();
        }
    }

    /// <summary>
    /// S�reye +10 saniye ekleyen metod.
    /// Yaln�zca bir kez kullan�labilir (hasUsedExtraTime kontrol�).
    /// </summary>
    public void AddExtraTime()
    {
        // E�er oyun bitmediyse ve hen�z buton kullan�lmad�ysa
        if (!isGameOver && !hasUsedExtraTime)
        {
            timeLeft += 10f;
            hasUsedExtraTime = true;

            // Butonu bir daha kullan�lamaz hale getirelim
            if (addTimeButton != null)
                addTimeButton.interactable = false;
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Kalan s�reyi tam say� �eklinde g�sterelim
            timerText.text = Mathf.Ceil(timeLeft).ToString();
        }
    }
}
