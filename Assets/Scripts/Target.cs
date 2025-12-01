using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private int pointValue;
    private GameManager gameManager;
    private const string gmName = "Game Manager";
    private AudioSource targetAudio;
    public AudioClip collisionSound; 

    public ParticleSystem explosionParticle;

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
        targetAudio = GetComponent<AudioSource>();
        if (targetAudio == null)
        {
            enabled = false;
            Debug.LogError($"TargetAudio component missing on {gameObject.name}");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collisionSound != null)
            {
                AudioSource.PlayClipAtPoint(collisionSound, transform.position, 1.0f);
            }
            if( explosionParticle != null)
            {
                Instantiate(explosionParticle, transform.position, transform.rotation);
            }
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);

        }
        if(other.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
    }
}
