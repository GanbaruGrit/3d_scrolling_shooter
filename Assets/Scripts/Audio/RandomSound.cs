using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] public AudioSource randomSound;
    [SerializeField] public AudioClip[] audioSources;

    public void CallAudio()
    {
        //Invoke("RandomSoundness", 10);
        RandomSounds();
    }

    void RandomSounds()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
}