using UnityEngine;

public class CameraFreeze : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        transform.Rotate(-vertical, horizontal, 0);
    }
}
