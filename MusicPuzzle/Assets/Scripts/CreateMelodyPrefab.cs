using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateMelodyPrefab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject noteInTact;
    [SerializeField] private GameObject perent;
    //[SerializeField] private GameObject note;
    [SerializeField] private GameObject notePlace;

    void Start()
    {
    }

    void Update()
    {
        if (perent.transform.childCount > 1)
            Destroy(perent.transform.GetChild(0).gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //notePlace.color = new Color(255,255,255,255);
        //Instantiate(note, transform);
        notePlace.GetComponent<Image>().sprite = noteInTact.GetComponent<Image>().sprite;
        notePlace.GetComponent<AudioSource>().clip = noteInTact.GetComponent<AudioSource>().clip;
        notePlace.name = noteInTact.name;
        Instantiate(notePlace, perent.transform);//.sprite = noteInTact.GetComponent<Image>().sprite;
        //ChordsStats.FillMelodyDict(note.GetComponent<PrefabMove>().MelodyType, null, noteInTact.gameObject);
    }
}
