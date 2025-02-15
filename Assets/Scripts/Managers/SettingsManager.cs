using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  // Hvis du bruger TextMeshPro

public class SettingsManager : MonoBehaviour
{
    public Slider speedSlider, jumpSlider, gravitySlider, slideSpeedSlider, slideDurationSlider, wallRunSpeedSlider, jumpOffWallForceSlider, pushOffForceSlider;
    public Text speedText, jumpText, gravityText, slideSpeedText, slideDurationText, wallRunSpeedText, jumpOffWallForceText, pushOffForceText;

    private void Start()
    {
        // Load values from PlayerPrefs, med en standardværdi på 5, undtagen gravity
        speedSlider.value = PlayerPrefs.GetFloat("Speed", 5.0f);
        jumpSlider.value = PlayerPrefs.GetFloat("JumpHeight", 5.0f);
        gravitySlider.value = PlayerPrefs.GetFloat("Gravity", -9.81f);
        slideSpeedSlider.value = PlayerPrefs.GetFloat("SlideSpeed", 5.0f);
        slideDurationSlider.value = PlayerPrefs.GetFloat("SlideDuration", 5.0f);
        wallRunSpeedSlider.value = PlayerPrefs.GetFloat("WallRunSpeed", 5.0f);
        jumpOffWallForceSlider.value = PlayerPrefs.GetFloat("JumpOffWallForce", 5.0f);
        pushOffForceSlider.value = PlayerPrefs.GetFloat("PushOffForce", 5.0f);

        // Opdater tekst ved start
        UpdateSliderTexts();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Speed", speedSlider.value);
        PlayerPrefs.SetFloat("JumpHeight", jumpSlider.value);
        PlayerPrefs.SetFloat("Gravity", gravitySlider.value);
        PlayerPrefs.SetFloat("SlideSpeed", slideSpeedSlider.value);
        PlayerPrefs.SetFloat("SlideDuration", slideDurationSlider.value);
        PlayerPrefs.SetFloat("WallRunSpeed", wallRunSpeedSlider.value);
        PlayerPrefs.SetFloat("JumpOffWallForce", jumpOffWallForceSlider.value);
        PlayerPrefs.SetFloat("PushOffForce", pushOffForceSlider.value);
        PlayerPrefs.Save();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    // Opdaterer tekstene, når en slider ændres
    public void UpdateSliderTexts()
    {
        speedText.text = "Speed: " + speedSlider.value.ToString("F1");
        jumpText.text = "Jump Height: " + jumpSlider.value.ToString("F1");
        gravityText.text = "Gravity: " + gravitySlider.value.ToString("F1");
        slideSpeedText.text = "Slide Speed: " + slideSpeedSlider.value.ToString("F1");
        slideDurationText.text = "Slide Duration: " + slideDurationSlider.value.ToString("F1");
        wallRunSpeedText.text = "Wall Run Speed: " + wallRunSpeedSlider.value.ToString("F1");
        jumpOffWallForceText.text = "Jump Off Wall Force: " + jumpOffWallForceSlider.value.ToString("F1");
        pushOffForceText.text = "Push Off Force: " + pushOffForceSlider.value.ToString("F1");
    }
}
