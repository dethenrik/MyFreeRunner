using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    private CharacterController controller;
    private PlayerController playerController;

    public float slideSpeed;
    public float slideDuration;
    private bool isSliding = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();

        // Hent værdier fra PlayerPrefs
        slideSpeed = PlayerPrefs.GetFloat("SlideSpeed", 5.0f);
        slideDuration = PlayerPrefs.GetFloat("SlideDuration", 5.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && controller.isGrounded && playerController.speed > 0.1f && !isSliding)
        {
            StartCoroutine(Slide());
        }
    }

    private System.Collections.IEnumerator Slide()
    {
        isSliding = true;

        float originalHeight = controller.height;
        controller.height = originalHeight / 2;

        float slideTime = 0f;
        Vector3 slideDirection = Camera.main.transform.forward;
        slideDirection.y = 0;

        while (slideTime < slideDuration)
        {
            controller.Move(slideDirection.normalized * slideSpeed * Time.deltaTime);
            slideTime += Time.deltaTime;
            yield return null;
        }

        controller.height = originalHeight;
        isSliding = false;
    }
}
