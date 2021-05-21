using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundWOneBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> ChordsInTact;
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject panel;
    [SerializeField] private Color color;
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color correctColor;
    [SerializeField] private GameObject nextLvlButton;

    private List<string> CorrectChord = new List<string>()
    {
        "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty", "Empty",
        "Empty", "Empty", "Empty", "Empty"
    };

    public void PlayChords()
    {
        backgroundPanel.GetComponent<Image>().color = color;
        StaticCharacteristics.SoundOff = false;
        panel.SetActive(true);
        StartCoroutine(PlayAudio());

    }

    private IEnumerator PlayAudio()
    {
        var index = 0;
        while (index < 16 && !StaticCharacteristics.SoundOff)
        {
            ChordsInTact[index].GetComponent<AudioSource>().Play();
            panel.transform.position = ChordsInTact[index].transform.position;
            yield return new WaitForSeconds(0.1f);
            index++;
        }
        panel.SetActive(false);
        CheckCorrectChords();
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
                nextLvlButton.SetActive(true);
            }
            else
            {
                backgroundPanel.GetComponent<Image>().color = wrongColor;
                break;
            }
        }

    }
}
