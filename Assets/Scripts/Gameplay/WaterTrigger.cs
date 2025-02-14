using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public Transform player;      // Spilleren
    public Vector3 startPosition; // Startpositionen

    private void Start()
    {
        startPosition = player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit water! Resetting position.");
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;  // Deaktiver controller midlertidigt
                other.transform.position = startPosition;
                controller.enabled = true;   // Genaktiver controller
            }
        }
    }

}
