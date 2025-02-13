using UnityEngine;

public class WallRun : MonoBehaviour
{
    private CharacterController controller;
    private PlayerController playerController;

    public float wallRunSpeed = 6f;
    public float jumpOffWallForce = 8f;
    private bool isWallRunning = false;
    private Vector3 wallNormal;

    private bool wallRunCooldown = false;  // Til forsinkelse efter hop

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
            move = Vector3.ProjectOnPlane(move, wallNormal);  // Bevægelse parallelt med væggen

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

        // Nulstil wall run cooldown, når spilleren rammer jorden
        if (controller.isGrounded && wallRunCooldown)
        {
            wallRunCooldown = false;
            Debug.Log("Wall Run Cooldown Reset");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f && !wallRunCooldown)
        {
            Debug.Log("Wall Detected!");
            wallNormal = hit.normal;
            StartWallRun();
        }
    }

    void StartWallRun()
    {
        if (!isWallRunning)
        {
            isWallRunning = true;
            playerController.enabled = false;  // Deaktiver standard controller
            Debug.Log("Wall Run Started");
        }
    }

    void JumpOffWall()
    {
        isWallRunning = false;
        playerController.enabled = true;  // Genaktiver standard controller
        Vector3 jumpDirection = wallNormal + Vector3.up;
        controller.Move(jumpDirection * jumpOffWallForce * Time.deltaTime);
        wallRunCooldown = true;  // Start cooldown efter hop
        Debug.Log("Jumped Off Wall! Cooldown Activated");
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
            return true;  // Der er stadig væg
        }
        return false;  // Ingen væg fundet
    }
}
