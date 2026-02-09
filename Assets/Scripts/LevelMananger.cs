using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMananger : MonoBehaviour
{
    [SerializeField] float timeLoadScene = 0.3f;

    public void LoadGame()
    {
        LoadScene("GameScene");
        FindFirstObjectByType<ScoreKeeper>().ResetScore();
    }

    public void LoadStartGame()
    {
        LoadScene("StartScene");
    }

    public void LoadEndGame()
    {
        LoadScene("EndScene");
    }

    void LoadScene(string sceneName)
    {
        StartCoroutine(LoadGameScene());
        IEnumerator LoadGameScene()
        {
            yield return new WaitForSeconds(timeLoadScene);
            SceneManager.LoadScene(sceneName);
        }
    }

    public void QuitGame()
    {
        print("Quit game....");
        Application.Quit(); // does not work on web browser
    }

}
