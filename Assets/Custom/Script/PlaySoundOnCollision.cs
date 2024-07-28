using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioClip soundClip; // ?????????????????????
    public float volume = 1.0f; // ????????
    private bool hasPlayed = false; // ???????

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasPlayed)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // ???????????????????????
                AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
                foreach (AudioSource source in allAudioSources)
                {
                    source.Stop();
                }

                // ?????????????????
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                }

                // ???????
                audioSource.clip = soundClip;
                audioSource.volume = volume;

                // ???????
                audioSource.Play();

                hasPlayed = true; // ???????????
            }
        }
    }
}
