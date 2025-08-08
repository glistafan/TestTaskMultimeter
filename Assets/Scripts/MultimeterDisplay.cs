using System;
using TMPro;
using UnityEngine;

public class MultimeterDisplay : MonoBehaviour
{
    [SerializeField] TextMeshPro DisplayTextMeshPro;
    void Awake()
    {
        EventManager.OnMultimeterValueChanged += OnValueChanged;
    }

    private void OnValueChanged(float value)
    {
        DisplayTextMeshPro.text = Math.Round(value, 2).ToString();
    }
}
