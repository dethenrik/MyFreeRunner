using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadBane1()
    {
        SceneManager.LoadScene("Bane1");
    }

    public void LoadBane2()
    {
        SceneManager.LoadScene("Bane2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
