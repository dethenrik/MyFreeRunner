using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public GameObject exitMenuUI; // Reference til Exit Menu UI
    private bool isPaused = false; // Tjekker om menuen er åben

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitMenuUI.activeSelf) 
            {
                CloseMenu(); // Hvis menuen allerede er åben, luk den
            }
            else 
            {
                OpenMenu(); // Hvis menuen er lukket, åbn den
            }
        }
    }

    void OpenMenu()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Hvis scenen er StartMenu, BaneVælger eller Indstillinger, gør ingenting
        if (currentScene == "StartMenu" || currentScene == "BaneVælger" || currentScene == "Indstillinger")
            return;

        isPaused = true;
        exitMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause spillet
        Cursor.lockState = CursorLockMode.None; // Lås musen op
        Cursor.visible = true; // Gør musen synlig
        Debug.Log("Exit Menu Åbnet!");
    }

    void CloseMenu()
    {
        isPaused = false;
        exitMenuUI.SetActive(false);
        Time.timeScale = 1f; // Genoptag spillet
        Cursor.lockState = CursorLockMode.Locked; // Lås musen igen
        Cursor.visible = false; // Skjul musen
        Debug.Log("Exit Menu Lukket!");
    }

    public void ContinueGame()
    {
        CloseMenu(); // Luk menuen korrekt, så den virker med Escape igen
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
