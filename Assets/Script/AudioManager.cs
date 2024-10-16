using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceSfx;

    public void ReproducirSonido(AudioClip clip)
    {
        //1Time
        audioSourceSfx.PlayOneShot(clip);
    }
}
