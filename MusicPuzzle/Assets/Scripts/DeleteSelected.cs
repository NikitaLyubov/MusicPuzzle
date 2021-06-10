using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSelected : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject nextHint;
    private Sprite component;
    void Start()
    {
        component = GetComponent<Image>().sprite;
    }

    public void ClearButton()
    {
        gameObject.name = "Empty";
        gameObject.GetComponent<Image>().sprite = component;
        gameObject.GetComponent<AudioSource>().clip = null;
        if (StaticCharacteristics.ThirdHintIsActive)
        {
            hint.SetActive(false);
            nextHint.SetActive(true);
        }

        StaticCharacteristics.ThirdHintIsActive = false;
    }
}
