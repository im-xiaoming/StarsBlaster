using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] GameObject Hp;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    public void DestroyHealth()
    {
        RawImage[] images = Hp.GetComponentsInChildren<RawImage>();
        if (images.Length > 0)
        {
            Destroy(images[images.Length - 1]);
        }
    }

    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = "Score " + scoreKeeper.GetScore().ToString();
    }
}
