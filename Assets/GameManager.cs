using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;    // <-- Button i�in
using TMPro;             // <-- TextMeshPro i�in

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Statik skor (�rne�in sahne yeniden y�klense bile korunur)
    private static int persistentScore = 0;

    [Header("Nesne Ayarlar�")]
    [Tooltip("Oyundaki toplam nesne say�s�. 0'a inince sahne yeniden y�klenir.")]
    public int totalObjects = 12;

    [Header("UI Bile�enleri")]
    [Tooltip("Skoru g�stermek istedi�iniz TextMeshPro bile�eni.")]
    public TextMeshProUGUI scoreText;

    [Tooltip("Sadece bir kez kullan�labilen Double Score butonunu Inspector�dan atayabilirsiniz.")]
    public Button doubleScoreButton;

    [Tooltip("Oyun bitti�inde g�stermek istedi�iniz (opsiyonel) TextMeshPro bile�eni.")]
    public TextMeshProUGUI gameOverText;

    // Double Score butonu sadece 1 defa kullan�labilecek
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
        // Oyun ba��nda e�er gameOverText atanm��sa kapatabilirsiniz
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        // Score UI g�ncelle
        UpdateScoreUI();

        // Buton Inspector�dan atand�ysa, bu sat�rla t�klanma olay�n� da ekleyebilirsiniz.
        // Ancak genelde OnClick'i Inspector�dan da ba�layabilirsiniz. Bu iste�e ba�l�d�r.
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
    /// Double Score butonuna t�klan�nca �a�r�lacak metot.
    /// Sadece 1 defa �al���r; ikinci kez �a�r�l�rsa i�lem yapmaz.
    /// </summary>
    public void DoubleScore()
    {
        if (!hasUsedDoubleScore)
        {
            // Skoru ikiye katla
            persistentScore *= 2;
            UpdateScoreUI();

            // Art�k ikinci kez kullan�lmas�n
            hasUsedDoubleScore = true;

            // Butonu pasif hale getir (Inspector'da atanan buton referans�yla)
            if (doubleScoreButton != null)
            {
                doubleScoreButton.interactable = false;
            }
        }
        else
        {
            Debug.Log("Double Score butonu zaten kullan�ld�!");
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
