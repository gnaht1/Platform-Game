using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        

    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}