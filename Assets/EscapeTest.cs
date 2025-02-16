using UnityEngine;

public class EscapeTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed!");
        }
    }
}
