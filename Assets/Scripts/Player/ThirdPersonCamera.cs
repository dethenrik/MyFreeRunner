using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;        // Spillerens transform
    public Vector3 offset;          // Afstand mellem kamera og spiller
    public float rotationSpeed = 3.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 2.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, -35, 60);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, 0, -offset.magnitude);
        Vector3 position = player.position + rotation * offset;

        transform.position = position;
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
