using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintsScript : MonoBehaviour
{
    public void HideThisHint()
    {
        gameObject.SetActive(false);
    }
}
