using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateMelodyPrefab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject noteInTact;
    [SerializeField] private GameObject note;
    [SerializeField] private Image notePlace;

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        notePlace.color = new Color(255,255,255,255);
        Instantiate(note, transform);
        notePlace.sprite = noteInTact.GetComponent<Image>().sprite;
        ChordsStats.FillMelodyDict(note.GetComponent<PrefabMove>().MelodyType, null, noteInTact.gameObject);
    }
}
