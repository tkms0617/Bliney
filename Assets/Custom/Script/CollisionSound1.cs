using UnityEngine;

public class CollisionSound1 : MonoBehaviour
{

    public AudioClip sound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}