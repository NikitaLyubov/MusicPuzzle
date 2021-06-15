using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundWOneBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> ChordsInTact;
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject hint;
    [SerializeField] private Color color;
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color correctColor;
    [SerializeField] private GameObject nextLvlButton;

    private List<string> CorrectChords = new List<string>()
    {
        "Lia akk(Clone)", "Em akk(Clone)", "F akk(Clone)", "Do akk(Clone)",  "Lia akk(Clone)", "Em akk(Clone)", "F akk(Clone)", "Do akk(Clone)", "Empty", "Empty", "Empty", "Empty",
        "Empty", "Empty", "Empty", "Empty"
    };
    private List<string> correctMelodyList = new List<string>()
    {
        "Ля(Clone)", "Ре(Clone)", "До(Clone)", "Ля(Clone)", "Ре(Clone)", "До(Clone)", "Ре(Clone)", "Ми(Clone)", "Фа(Clone)", "Ми(Clone)", "Ре(Clone)", "До(Clone)",
        "Empty", "Empty", "Empty", "Empty"
    };


    private List<string> DemoChords = new List<string>()
    {
        "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty",
        "Empty", "Empty", "Empty", "Empty"
    };

    public void PlayChords()
    {
        backgroundPanel.GetComponent<Image>().color = color;
        StaticCharacteristics.SoundOff = false;
        panel.SetActive(true);
        StartCoroutine(gameObject.tag == "Note" ? PlayMelody() : PlayAudio());
        StaticCharacteristics.FourthHintIsActive = false;
    }

    private IEnumerator PlayAudio()
    {
        var startPos = panel.transform.position;
        var index = 0;
        while (index < 16 && !StaticCharacteristics.SoundOff)
        {
            ChordsInTact[index].GetComponent<AudioSource>().Play();
            panel.transform.position = ChordsInTact[index].transform.position;
            yield return new WaitForSeconds(1.6f);
            
            index++;
        }

        panel.transform.position = startPos;
        CheckCorrectChords();
    }

    private IEnumerator PlayMelody()
    {
        var startPos = panel.transform.position;
        var index = 0;
        while (index < 16 && !StaticCharacteristics.SoundOff)
        {
            ChordsInTact[index].GetComponent<AudioSource>().Play();
            panel.transform.position = ChordsInTact[index].transform.position;
            if (index == 2 || index == 5 || index == 8)
                yield return new WaitForSeconds(0.4f);
            else
                yield return new WaitForSeconds(0.6f);
            index++;
        }

        panel.transform.position = startPos;
        CheckCorrectChords();
    }

    public void StopPlayingSound()
    {
        StaticCharacteristics.SoundOff = true;
    }

    private void CheckCorrectChords()
    {

        for (var i = 0; i < ChordsInTact.Count; i++)
        {
            if (ChordsInTact[i].name == CorrectChords[i] && backgroundPanel.tag == "Chord")
            {
                backgroundPanel.GetComponent<Image>().color = correctColor;
                nextLvlButton.SetActive(true);
            }
            else if (ChordsInTact[i].name == correctMelodyList[i] && backgroundPanel.tag == "Note")
            {
                backgroundPanel.GetComponent<Image>().color = correctColor;
                nextLvlButton.SetActive(true);
            }
            else if (ChordsInTact[i].name == DemoChords[i] && backgroundPanel.tag == "Demo")
            {
                backgroundPanel.GetComponent<Image>().color = correctColor;
                nextLvlButton.SetActive(true);
            }
            else
            {
                backgroundPanel.GetComponent<Image>().color = wrongColor;
                nextLvlButton.SetActive(false);
                break;
            }
        }
    }
}
