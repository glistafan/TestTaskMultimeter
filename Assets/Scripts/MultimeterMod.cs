using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Mode", order = 1)]
public class MultimeterMod : ScriptableObject
{
    [SerializeField] private string namePrefab;

    [SerializeField] private ModType modType;
    public string GetName => namePrefab;
    public ModType GetModType => modType;
    public float Calculate(float r, float p)
    {
        switch (modType)
        {
            case ModType.VMod:
                return Mathf.Sqrt(p * r);
            case ModType.VACMod:
                return 0.01f;
            case ModType.AMod:
                return Mathf.Sqrt(p * r) / r;
            case ModType.ResistanceMod:
                return r;
            default:
                return 0;
        }
    }

    
}
