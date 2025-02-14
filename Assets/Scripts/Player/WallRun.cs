using UnityEngine;

public class WallRun : MonoBehaviour
{
    private CharacterController controller;
    private PlayerController playerController;

    public float wallRunSpeed = 6f;
    public float jumpOffWallForce = 10f;  // Øget for et kraftigere skub
    public float pushOffForce = 5f;       // Kraft til at skubbe væk fra væggen
    private bool isWallRunning = false;
    private Vector3 wallNormal;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (isWallRunning)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = Camera.main.transform.TransformDirection(move);
            move = Vector3.ProjectOnPlane(move, wallNormal);

            controller.Move(move * Time.deltaTime * wallRunSpeed);

            if (!CheckWall())
            {
                Debug.Log("No Wall Detected - Falling!");
                StopWallRun();
            }
        }

        if (Input.GetButtonDown("Jump") && isWallRunning)
        {
            JumpOffWall();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f && hit.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Wall Detected on Wall Layer!");
            wallNormal = hit.normal;
            StartWallRun();
        }
    }

    void StartWallRun()
    {
        if (!isWallRunning)
        {
            isWallRunning = true;
            playerController.enabled = false;
            Debug.Log("Wall Run Started");
        }
    }

    void JumpOffWall()
    {
        isWallRunning = false;
        playerController.enabled = true;

        // Brug væggens normale og spillerens retning til at skubbe væk
        Vector3 awayFromWall = wallNormal * pushOffForce;  // Skub væk fra væggen
        Vector3 upwards = Vector3.up * jumpOffWallForce;    // Hop opad
        Vector3 finalJump = awayFromWall + upwards;

        controller.Move(finalJump * Time.deltaTime);
        Debug.Log("Jumped Off Wall away from Wall!");
    }


    void StopWallRun()
    {
        isWallRunning = false;
        playerController.enabled = true;
        Debug.Log("Wall Run Stopped");
    }

    bool CheckWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -wallNormal, out hit, 1f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                return true;
            }
        }
        return false;
    }
}
