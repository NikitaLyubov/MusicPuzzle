using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanel : MonoBehaviour
{
    [SerializeField] private GameObject LvlsPanel;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private Text Notes;
    [SerializeField] private Text Chords;

    public void ShowChoiseOfLvls()
    {
        LvlsPanel.SetActive(!LvlsPanel.activeSelf);
        MenuPanel.SetActive(!LvlsPanel.activeSelf);
    }
}
