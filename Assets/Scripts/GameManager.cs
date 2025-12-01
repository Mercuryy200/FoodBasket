using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;
    private float originalSpawnRate; 

    [Header("Game Stats")]
    [SerializeField] public float score;
    [SerializeField] private float timeRemaining = 60f;
    [SerializeField] private bool timerIsRunning = false;

    [Header("Difficulty Settings")]
    [SerializeField] private float difficultyIncreaseInterval = 5f; 
    [SerializeField] private float gravityMultiplier = 1.1f; 
    [SerializeField] private float spawnRateDivider = 1.1f;

    private const float spawnHeight = 7f;
    private const float xSpawnRange = 4f;
    private const float zPosition = 0f; 

    public bool isGameActive = true;
    private Vector3 originalGravity;
    private GameObject player;
    private PlayerController playerController;
    
    [Header("UI Objects")]
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField]private TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public Button startButton;

    [System.NonSerialized]
    public ScoreUIView scoreUIView;
    public ScoreService scoreService;
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError($"Player was not found in the scene");
        }
        playerController = player.GetComponent<PlayerController>();
        if (playerController== null)
        {
            Debug.LogError($"PlayerController Component missing on Player");
        }
        scoreService = new ScoreService();
        scoreUIView = GetComponent<ScoreUIView>();
        if (scoreUIView == null)
        {
            enabled = false;
            Debug.LogError($"{scoreUIView.name} component is missing in {gameObject.name}");
            return;
        }
    }

    void Start()
    {
        originalGravity = Physics.gravity;
        originalSpawnRate = spawnRate;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = $"{Mathf.RoundToInt(timeRemaining)}";
            }
            else
            {
                timeRemaining = 0;
                GameOver();
            }
        }
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            if (isGameActive)
            {
                int index = Random.Range(0, targets.Count);
                float randomSpawnX = Random.Range(-xSpawnRange, xSpawnRange);
                var spawnPos = new Vector3(randomSpawnX, spawnHeight, zPosition);
                Instantiate(targets[index], spawnPos, Quaternion.identity);
            }
        }
    }

    private IEnumerator IncreaseDifficultyRoutine()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(difficultyIncreaseInterval);
            Physics.gravity *= gravityMultiplier;
            if (spawnRate > 0.2f)
            {
                spawnRate /= spawnRateDivider;
            }
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        scoreService.AddPoints(scoreToAdd);
        scoreUIView.DisplayScore(scoreService.Score);
    }

    public void StartGame()
    {
        isGameActive = true;
        timerIsRunning = true;
        spawnRate = originalSpawnRate; 
        Physics.gravity = originalGravity; 
        scoreUIView.scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        playerController.enabled = true;
        StartCoroutine(nameof(SpawnTarget));
        StartCoroutine(nameof(IncreaseDifficultyRoutine)); 
    }

    public void GameOver()
    {
        
        isGameActive = false;
        timerIsRunning = false;
        playerController.enabled = false;
        scoreUIView.scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        finalScoreText.text = $"Final Score: {scoreService.Score}";
        Physics.gravity = originalGravity;   
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}