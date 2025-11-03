using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    public TMP_Text scoreText;
    public TMP_Text targetText;
    public TMP_Text timerText; // Assign a TMP for the timer
    public GameObject gameOverPanel; // Assign a Panel with "Game Over" text and a restart button

    [Header("Game Settings")]
    public int score = 0;
    public string targetColor;
    public float gameTime = 60f; // Countdown time in seconds
    private float currentTime;
    private bool gameEnded = false;

    private string[] possibleColors = { "Red", "Blue", "Yellow" }; // Updated to match your prefabs

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        SetRandomTargetColor();
        UpdateUI();
        currentTime = gameTime;
        gameOverPanel.SetActive(false); // Hide game over screen initially
    }

    void Update()
    {
        if (!gameEnded)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
            if (currentTime <= 0)
            {
                EndGame();
            }
        }
    }

    public void CollectCollectible(string collectedColor)
    {
        if (collectedColor == targetColor)
        {
            score += 10; // Increase for correct
            AudioManager.instance.PlayCorrectSound(); // Play correct sound
            SetRandomTargetColor();
        }
        else
        {
            score -= 5; // Decrease for incorrect
            AudioManager.instance.PlayIncorrectSound(); // Play incorrect sound
            // Show "Wrong Choice" message (via UI or log)
            Debug.Log("Wrong Choice!"); // You can replace with a TMP popup if desired
        }
        UpdateUI();
    }

    private void SetRandomTargetColor()
    {
        targetColor = possibleColors[Random.Range(0, possibleColors.Length)];
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString();
        targetText.text = "Target: " + targetColor;
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString();
    }

    public void EndGame()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true); // Show game over screen
        AudioManager.instance.PlayLoseSound(); // Play lose sound
        // Optional: Pause game or disable player movement
    }

    // Call this from a restart button on the game over panel
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}