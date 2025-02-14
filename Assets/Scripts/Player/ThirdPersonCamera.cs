using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float rotationSpeed = 3.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 2.0f;

    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, -35, 60);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        RaycastHit hit;
        if (Physics.Raycast(player.position, desiredPosition - player.position, out hit, maxDistance))
        {
            float distance = Vector3.Distance(player.position, hit.point) - 0.2f;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            transform.position = player.position + rotation * (Vector3.forward * -distance);
        }
        else
        {
            transform.position = desiredPosition;
        }

        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
