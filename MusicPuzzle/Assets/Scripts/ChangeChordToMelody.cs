using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChordToMelody : MonoBehaviour
{
    [SerializeField] private GameObject panelChordsGameObject;
    [SerializeField] private GameObject panelMelodyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPanel()
    {
        panelChordsGameObject.SetActive(!panelChordsGameObject.activeSelf);
        panelMelodyGameObject.SetActive(!panelMelodyGameObject.activeSelf);
    }
}
