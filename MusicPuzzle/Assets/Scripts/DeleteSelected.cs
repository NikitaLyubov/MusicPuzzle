using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSelected : MonoBehaviour
{
    private Sprite component;
    void Start()
    {
        component = GetComponent<Image>().sprite;
    }

    void Update()
    {
        
    }

    public void ClearButton()
    {
        gameObject.name = "Empty";
        gameObject.GetComponent<Image>().sprite = component;
        gameObject.GetComponent<AudioSource>().clip = null;
    }
}
