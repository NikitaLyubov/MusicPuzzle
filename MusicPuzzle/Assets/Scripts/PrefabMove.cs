using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrefabMove : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool IsDown = false;

    public ChordType ChordType;
    public MelodyType MelodyType;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.pointerCurrentRaycast.screenPosition;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        IsDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsDown = false;
        if (!StaticCharacteristics.InTrigger)
            Destroy(this.gameObject);
    }
}
