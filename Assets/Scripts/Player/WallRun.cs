using UnityEngine;

public class WallRun : MonoBehaviour
{
    private CharacterController controller;
    private PlayerController playerController;

    public float wallRunSpeed;
    public float jumpOffWallForce;
    public float pushOffForce;
    private bool isWallRunning = false;
    private Vector3 wallNormal;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();

        // Hent værdier fra PlayerPrefs
        wallRunSpeed = PlayerPrefs.GetFloat("WallRunSpeed", 5.0f);
        jumpOffWallForce = PlayerPrefs.GetFloat("JumpOffWallForce", 5.0f);
        pushOffForce = PlayerPrefs.GetFloat("PushOffForce", 5.0f);
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

        Vector3 awayFromWall = wallNormal * pushOffForce;
        Vector3 upwards = Vector3.up * jumpOffWallForce;
        Vector3 finalJump = awayFromWall + upwards;

        controller.Move(finalJump * Time.deltaTime);
        Debug.Log("Jumped Off Wall!");
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
