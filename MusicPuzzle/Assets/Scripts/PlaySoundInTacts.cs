using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlaySoundInTacts : MonoBehaviour
{
    [SerializeField] private List<GameObject> ChordsInTact;
    [SerializeField] private List<GameObject> NotesInTact;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject Notepanel;
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject NotebackgroundPanel;
    [SerializeField] private Color color;
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color correctColor;
    [SerializeField] private GameObject nextLvlButton;

    private List<string> CorrectChord = new List<string>()
    {
        "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", 
        "Empty", "Empty", "Empty", "Empty"
    };

    private List<string> CorrectNotes = new List<string>()
    {
        "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty",
        "Empty", "Empty", "Empty", "Empty"
    };

    private void Start()
    {
    }

    private void Update()
    {
        if (NotebackgroundPanel.GetComponent<Image>().color == correctColor && backgroundPanel.GetComponent<Image>().color == correctColor)
            nextLvlButton.SetActive(true);
    }

    public void PlayChords()
    {
        backgroundPanel.GetComponent<Image>().color = color;
        NotebackgroundPanel.GetComponent<Image>().color = color;
        StaticCharacteristics.SoundOff = false;
        panel.SetActive(true);
        Notepanel.SetActive(true);
        StartCoroutine(PlayAudio());

    }

    private IEnumerator PlayAudio()
    {
        var index = 0;
        while (index < 16 && !StaticCharacteristics.SoundOff)
        {
            ChordsInTact[index].GetComponent<AudioSource>().Play();
            NotesInTact[index].GetComponent<AudioSource>().Play();
            panel.transform.position = ChordsInTact[index].transform.position;
            Notepanel.transform.position = NotesInTact[index].transform.position;
            yield return new WaitForSeconds(0.5f);
            index++;
        }
        panel.SetActive(false);
        Notepanel.SetActive(false);
        
        CheckCorrectChords();
        CheckCorrectNotes();
    }

    public void StopPlayingSound()
    {
        StaticCharacteristics.SoundOff = true;
        panel.SetActive(false);
    }

    private void CheckCorrectChords()
    {

        for (var i = 0; i < ChordsInTact.Count; i++)
        {
            if (ChordsInTact[i].name == CorrectChord[i])
            {
                backgroundPanel.GetComponent<Image>().color = correctColor;
            }
            else
            {
                backgroundPanel.GetComponent<Image>().color = wrongColor;
                break;
            }
        }

    }

    private void CheckCorrectNotes()
    {

        for (var i = 0; i < NotesInTact.Count; i++)
        {
            if (NotesInTact[i].name == CorrectNotes[i])
            {
                NotebackgroundPanel.GetComponent<Image>().color = correctColor;
            }
            else
            {
                NotebackgroundPanel.GetComponent<Image>().color = wrongColor;
                break;
            }
        }

    }
}
