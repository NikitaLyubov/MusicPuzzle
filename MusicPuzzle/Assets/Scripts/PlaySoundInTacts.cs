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
        "Lia(Clone)", "Empty", "Em(Clone)", "Empty", "F(Clone)", "Empty", "F(Clone)", "Empty", "Lia(Clone)", "Empty", "Em(Clone)", "Empty",
        "F(Clone)", "Empty", "F(Clone)", "Empty"
    };

    private List<string> CorrectNotes = new List<string>()
    {
        "Empty", "Фа(Clone)", "Empty", "Ре(Clone)", "Empty", "Ре(Clone)", "Empty", "Си(Clone)", "Empty", "Фа(Clone)", "Empty", "Ре(Clone)",
        "Empty", "Ре(Clone)", "Empty", "Си(Clone)"
    };

    private Vector3 pos1, pos2;

    private void Start()
    {
        pos1 = panel.transform.position;
        pos2 = Notepanel.transform.position;
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
            if (index % 2 == 1)
                yield return new WaitForSeconds(0.4f);
            else
                yield return new WaitForSeconds(1.2f);
            index++;
        }
        //panel.SetActive(false);
        //Notepanel.SetActive(false);
        
        CheckCorrectChords();
        CheckCorrectNotes();
    }

    public void StopPlayingSound()
    {
        StaticCharacteristics.SoundOff = true;
        panel.transform.position = pos1;
        Notepanel.transform.position = pos2;
        //panel.SetActive(false);
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
