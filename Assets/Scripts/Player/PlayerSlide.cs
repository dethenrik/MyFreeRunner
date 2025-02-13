using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    private CharacterController controller;
    private PlayerController playerController;

    public float slideSpeed = 8.0f;
    public float slideDuration = 0.8f;
    private bool isSliding = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && controller.isGrounded && playerController.speed > 0.1f && !isSliding)
        {
            StartCoroutine(Slide());
        }
    }

    private System.Collections.IEnumerator Slide()
    {
        isSliding = true;

        float originalHeight = controller.height;
        controller.height = originalHeight / 2;  // Sænker karakterens højde

        float slideTime = 0f;
        Vector3 slideDirection = transform.forward;

        while (slideTime < slideDuration)
        {
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);
            slideTime += Time.deltaTime;
            yield return null;
        }

        controller.height = originalHeight;  // Gendanner karakterens højde
        isSliding = false;
    }
}
