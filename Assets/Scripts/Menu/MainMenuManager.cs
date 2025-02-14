using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start button pressed!");  // Debug-tjek
        SceneManager.LoadScene("Bane1");
    }


    public void OpenBaneSelector()
    {
        Debug.Log("Banevælger åbnes...");
        // Implementer banevælger-UI her
    }

    public void OpenSettings()
    {
        Debug.Log("Indstillinger åbnes...");
        // Implementer indstillings-UI her
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
