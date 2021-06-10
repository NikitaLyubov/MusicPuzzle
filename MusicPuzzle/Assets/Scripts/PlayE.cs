using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayE : MonoBehaviour
{
    [SerializeField] private GameObject exampleGameObject;
    public void PlaySound()
    {
        exampleGameObject.GetComponent<AudioSource>().Play();
    }

    public void StopSound()
    {
        exampleGameObject.GetComponent<AudioSource>().Stop();
    }
}
