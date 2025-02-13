using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 playerVelocity;

    private bool isGrounded;
    public float speed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Camera.main.transform.TransformDirection(move);  // Ændring: Bevægelse i forhold til kameraet
        move.y = 0;  // Undgå kameraets hældning

        controller.Move(move * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
