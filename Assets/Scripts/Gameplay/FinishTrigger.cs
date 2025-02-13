using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer timer = Object.FindFirstObjectByType<Timer>();

            if (timer != null)
            {
                timer.StopTimer();
                Debug.Log("Finish Line Reached! Timer Stopped.");
            }
        }
    }
}
