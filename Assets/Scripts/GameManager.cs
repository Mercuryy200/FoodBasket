using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> targets;

    [SerializeField] private float spawnRate = 1.0f;

    [SerializeField] public float score;
    [SerializeField] private float timeRemaining = 60f;
    [SerializeField] private bool timerIsRunning = false;
    private const float spawnHeight = 7f;
    private const float xSpawnRange = 4f;
    private const float zPosition = 0f; 

    private bool isGameActive = true;


    void Start()
    {
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
                timerIsRunning = false;
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

    public void StartGame()
    {
        StartCoroutine(nameof(SpawnTarget));
        timerIsRunning = true;
    }
    public void GameOver()
    {
        isGameActive = false;
        timerIsRunning = false;
        Debug.Log("Game Over");
    }

}
