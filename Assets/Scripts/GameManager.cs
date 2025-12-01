using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;
    private float originalSpawnRate; // To store the starting speed

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

    private bool isGameActive = true;
    private Vector3 originalGravity;
    private GameObject player;
    private PlayerController playerController;

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
    }

    void Start()
    {
        originalGravity = Physics.gravity;
        originalSpawnRate = spawnRate;
        
        StartGame();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
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
            int index = Random.Range(0, targets.Count);
            float randomSpawnX = Random.Range(-xSpawnRange, xSpawnRange);
            var spawnPos = new Vector3(randomSpawnX, spawnHeight, zPosition );
            Instantiate(targets[index], spawnPos, Quaternion.identity);
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

    public void StartGame()
    {
        isGameActive = true;
        timerIsRunning = true;
        spawnRate = originalSpawnRate; 
        Physics.gravity = originalGravity; 
        StartCoroutine(nameof(SpawnTarget));
        StartCoroutine(nameof(IncreaseDifficultyRoutine)); 
    }

    public void GameOver()
    {
        isGameActive = false;
        timerIsRunning = false;
        playerController.enabled = false;
        Physics.gravity = originalGravity;   
        Debug.Log("Game Over");
    }
}