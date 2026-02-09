using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreKeeper scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        scoreText.text = "FINAL SCORE:\n" + scoreKeeper.GetScore().ToString();
    }
}
