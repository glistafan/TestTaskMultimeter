using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TMP_Text textV;
    [SerializeField] private TMP_Text textVac;
    [SerializeField] private TMP_Text textA;
    [SerializeField] private TMP_Text textR;

    private Dictionary<ModType, (TMP_Text, string)> modTMPDictionary;

    private ModType currentMod;

    void Awake()
    {
        modTMPDictionary = new Dictionary<ModType, (TMP_Text, string)>
        {
            { ModType.VMod, (textV, "V") },
            { ModType.VACMod, (textVac, "V~") },
            { ModType.AMod, (textA, "A") },
            { ModType.ResistanceMod, (textR, "Ω")}
        };
        EventManager.OnMultimeterModChanged += (ModType newMod) => currentMod = newMod;
        EventManager.OnMultimeterValueChanged += ChangeValue;
    }

    private void ChangeValue(float value)
    {
        foreach (var keyValuePair in modTMPDictionary)
        {
            if (keyValuePair.Key == currentMod)
            {
                keyValuePair.Value.Item1.text = $"{keyValuePair.Value.Item2} {Math.Round(value, 2)}";
            }
            else
            {
                keyValuePair.Value.Item1.text = $"{keyValuePair.Value.Item2} 0";
            }
        }
    }
}
