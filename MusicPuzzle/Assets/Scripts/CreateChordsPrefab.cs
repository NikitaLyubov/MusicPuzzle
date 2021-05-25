using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateChordsPrefab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject nota;
    [SerializeField] private GameObject place;
    [SerializeField] private GameObject perent;

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
        place.GetComponent<Image>().sprite = nota.GetComponent<Image>().sprite;
        place.GetComponent<AudioSource>().clip = nota.GetComponent<AudioSource>().clip;
        place.name = nota.name;
        Instantiate(place, perent.transform);
    }


}
