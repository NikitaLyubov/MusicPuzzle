using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TactAdding : MonoBehaviour
{ 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        StaticCharacteristics.InTrigger = true;
        if (!other.gameObject.GetComponent<PrefabMove>().IsDown && other.tag == "Chord")
        {
            Destroy(other.gameObject);
            gameObject.name = other.gameObject.name;
            gameObject.GetComponent<Image>().sprite = ChordsStats.ChordDict[other.GetComponent<PrefabMove>().ChordType].sPrefab.GetComponent<Image>().sprite;
            gameObject.GetComponent<AudioSource>().clip = other.GetComponent<AudioSource>().clip;
            gameObject.name = other.gameObject.name;
        }
        if(!other.gameObject.GetComponent<PrefabMove>().IsDown && other.tag == "Note")
        {
            Destroy(other.gameObject);
            gameObject.name = other.gameObject.name;
            gameObject.GetComponent<Image>().sprite = ChordsStats.MelodyDict[other.GetComponent<PrefabMove>().MelodyType].sPrefab.GetComponent<Image>().sprite;
            gameObject.GetComponent<AudioSource>().clip = other.GetComponent<AudioSource>().clip;
            gameObject.name = other.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StaticCharacteristics.InTrigger = false;
    }
}
