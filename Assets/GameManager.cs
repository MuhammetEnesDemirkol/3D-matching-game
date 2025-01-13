using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;    // <-- Button için
using TMPro;             // <-- TextMeshPro için

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Statik skor (örneðin sahne yeniden yüklense bile korunur)
    private static int persistentScore = 0;

    [Header("Nesne Ayarlarý")]
    [Tooltip("Oyundaki toplam nesne sayýsý. 0'a inince sahne yeniden yüklenir.")]
    public int totalObjects = 12;

    [Header("UI Bileþenleri")]
    [Tooltip("Skoru göstermek istediðiniz TextMeshPro bileþeni.")]
    public TextMeshProUGUI scoreText;

    [Tooltip("Sadece bir kez kullanýlabilen Double Score butonunu Inspector’dan atayabilirsiniz.")]
    public Button doubleScoreButton;

    [Tooltip("Oyun bittiðinde göstermek istediðiniz (opsiyonel) TextMeshPro bileþeni.")]
    public TextMeshProUGUI gameOverText;

    // Double Score butonu sadece 1 defa kullanýlabilecek
    private bool hasUsedDoubleScore = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Oyun baþýnda eðer gameOverText atanmýþsa kapatabilirsiniz
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        // Score UI güncelle
        UpdateScoreUI();

        // Buton Inspector’dan atandýysa, bu satýrla týklanma olayýný da ekleyebilirsiniz.
        // Ancak genelde OnClick'i Inspector’dan da baðlayabilirsiniz. Bu isteðe baðlýdýr.
        // doubleScoreButton.onClick.AddListener(DoubleScore);
    }

    public void OnObjectsDestroyed(int count)
    {
        totalObjects -= count;

        if (totalObjects <= 0)
        {
            RestartGame();
        }
    }

    public void AddScore(int amount)
    {
        persistentScore += amount;
        UpdateScoreUI();
    }

    /// <summary>
    /// Double Score butonuna týklanýnca çaðrýlacak metot.
    /// Sadece 1 defa çalýþýr; ikinci kez çaðrýlýrsa iþlem yapmaz.
    /// </summary>
    public void DoubleScore()
    {
        if (!hasUsedDoubleScore)
        {
            // Skoru ikiye katla
            persistentScore *= 2;
            UpdateScoreUI();

            // Artýk ikinci kez kullanýlmasýn
            hasUsedDoubleScore = true;

            // Butonu pasif hale getir (Inspector'da atanan buton referansýyla)
            if (doubleScoreButton != null)
            {
                doubleScoreButton.interactable = false;
            }
        }
        else
        {
            Debug.Log("Double Score butonu zaten kullanýldý!");
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + persistentScore;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Opsiyonel
    public void ShowGameOverMessage(string message = "Game Over!")
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = message;
        }
    }
}
