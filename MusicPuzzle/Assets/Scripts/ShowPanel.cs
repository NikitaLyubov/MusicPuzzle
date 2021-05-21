using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    [SerializeField] private GameObject LvlsPanel;
    [SerializeField] private GameObject MenuPanel;
    public void ShowChoiseOfLvls()
    {
        LvlsPanel.SetActive(!LvlsPanel.activeSelf);
        MenuPanel.SetActive(!LvlsPanel.activeSelf);
    }
}
