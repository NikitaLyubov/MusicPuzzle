using System;
using System.Collections.Generic;
using UnityEngine;

 public enum ChordType
 {
    Do,
    Re,
    Mi,
    Fa
 }

public enum MelodyType
{
    Do,
    Re,
    Mi,
    Fa,
    Sol,
    Lya,
    Si
}

public static class ChordsStats
{

    public static Dictionary<ChordType, (GameObject fPrefab, GameObject sPrefab)> ChordDict = new Dictionary<ChordType, (GameObject fPrefab, GameObject sPrefab)>();

    public static Dictionary<MelodyType, (GameObject fPrefab, GameObject sPrefab)> MelodyDict = new Dictionary<MelodyType, (GameObject fPrefab, GameObject sPrefab)>();

    public static void FillChordDict(ChordType chrodType, GameObject chord, GameObject notaSprite)
    {
        if (!ChordDict.ContainsKey(chrodType))
            ChordDict[chrodType] = (chord, notaSprite);
    }

    public static void FillMelodyDict(MelodyType melodyType, GameObject nota, GameObject notaSprite)
    {
        if (!MelodyDict.ContainsKey(melodyType))
            MelodyDict[melodyType] = (nota, notaSprite);
    }
}
