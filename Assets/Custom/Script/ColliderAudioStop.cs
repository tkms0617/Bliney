using UnityEngine;

public class TimeStopOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0f; // ????
    }
}
