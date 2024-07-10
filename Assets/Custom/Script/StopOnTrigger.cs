using UnityEngine;

public class StopOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ????
            Time.timeScale = 0f;

            // ????
            AudioListener.pause = true;

            // ?????????
            Camera.main.GetComponent<firstPerson>().enabled = false; // ??????????????????????????????
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}