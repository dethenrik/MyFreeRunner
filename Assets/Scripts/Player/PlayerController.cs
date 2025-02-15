using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 playerVelocity;

    private bool isGrounded;
    public float speed;
    public float jumpHeight;
    public float gravity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Hent værdier fra PlayerPrefs
        speed = PlayerPrefs.GetFloat("Speed", 5.0f);
        jumpHeight = PlayerPrefs.GetFloat("JumpHeight", 5.0f);
        gravity = PlayerPrefs.GetFloat("Gravity", -9.81f);
    }

    void FixedUpdate()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0;

        controller.Move(move * Time.fixedDeltaTime * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else if (!isGrounded && controller.collisionFlags == CollisionFlags.Sides)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                Debug.Log("Wall Jump!");
            }
        }

        playerVelocity.y += gravity * Time.fixedDeltaTime;
        controller.Move(playerVelocity * Time.fixedDeltaTime);
    }
}
