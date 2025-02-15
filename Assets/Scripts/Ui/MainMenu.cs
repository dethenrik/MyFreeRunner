using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("BaneVælger");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Indstillinger");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
