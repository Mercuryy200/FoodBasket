using TMPro;
using UnityEngine;

public class ScoreUIView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreUIView : scoreText non initialisé (vérifiez l'Inspector).");
            enabled = false;
        }
    }

    public void DisplayScore(int value)
    {
        if (!enabled)
            return;
        scoreText.text = $"Score : {value}";
    }
}
