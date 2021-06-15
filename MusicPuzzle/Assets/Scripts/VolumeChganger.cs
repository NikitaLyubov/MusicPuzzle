using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChganger : MonoBehaviour
{
    private float musicVolume = 1f;

    private void Start()
    {

    }

    private void Update()
    {
        AudioListener.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }


}
