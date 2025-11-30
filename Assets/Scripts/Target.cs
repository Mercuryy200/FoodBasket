using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int pointValue;
    private GameManager gameManager;
    private const string gmName = "Game Manager";


    private void Awake()
    {
        var gm = GameObject.Find(gmName);
        if (gm == null)
        {
            enabled = false;
            Debug.LogError($"{gmName} was not found in the scene");
            return;
        }
        gameManager = gm.GetComponent<GameManager>();
        if (gameManager == null)
        {
            enabled = false;
            Debug.LogError($"GameManager component missing on {gmName}");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.score += pointValue;

        }
        if(other.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
    }
}
