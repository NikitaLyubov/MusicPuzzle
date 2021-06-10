using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TactAdding : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    [SerializeField] private GameObject nextHint;

    private void OnTriggerStay2D(Collider2D other)
    {
        StaticCharacteristics.InTrigger = true;
        if (!other.gameObject.GetComponent<PrefabMove>().IsDown && other.tag == "Chord" && (gameObject.tag == "Chord" || gameObject.tag == "Demo"))
        {
            Destroy(other.gameObject);
            if (StaticCharacteristics.SecondHintIsActive && gameObject.tag == "Demo")
            {
                hint.SetActive(false);
                nextHint.SetActive(true);
            }
            StaticCharacteristics.SecondHintIsActive = false;
            gameObject.name = other.gameObject.name;
            gameObject.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;
            gameObject.GetComponent<AudioSource>().clip = other.GetComponent<AudioSource>().clip;
            gameObject.name = other.gameObject.name;
        }
        if (!other.gameObject.GetComponent<PrefabMove>().IsDown && other.tag == "Note" && gameObject.tag == "Note")
        {
            Destroy(other.gameObject);
            gameObject.name = other.gameObject.name;
            gameObject.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;//hordsStats.MelodyDict[other.GetComponent<PrefabMove>().MelodyType].sPrefab.GetComponent<Image>().sprite;
            gameObject.GetComponent<AudioSource>().clip = other.GetComponent<AudioSource>().clip;
            gameObject.name = other.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StaticCharacteristics.InTrigger = false;
    }
}
