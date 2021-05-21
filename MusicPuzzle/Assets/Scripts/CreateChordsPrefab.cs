using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateChordsPrefab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject nota;
    [SerializeField] private GameObject thisChord;
    [SerializeField] private Image notePlace;
    

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Instantiate(nota, transform.parent);
        notePlace.color = new Color(255, 255, 255, 255);
        Instantiate(thisChord, transform);
        notePlace.sprite = nota.GetComponent<Image>().sprite;
        ChordsStats.FillChordDict(thisChord.GetComponent<PrefabMove>().ChordType, thisChord.gameObject, nota.gameObject);
    }


}
