using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;

    static ScoreKeeper instance;

    // Update is called once per frame
    void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateScore()
    {
        currentScore += 1;
    }

    public void SetScore(int score)
    {
        currentScore = score;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        SetScore(0);
    }
}
