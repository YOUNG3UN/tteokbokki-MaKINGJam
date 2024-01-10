using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource outroAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        outroAudioSource = GetComponent<AudioSource>();
        outroAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
