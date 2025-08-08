
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModMarkerCreator : MonoBehaviour
{
    [SerializeField] private TMP_Text markerPrefab;
    [SerializeField] private float radius;
    private float offsetAngle = 135;

    public void CreateMarks(List<MultimeterMod> mods, float modeAngleSelect)
    {
        for (int i = 0; i < mods.Count; i++)
        {
            float angleRad = Mathf.Deg2Rad * (i * modeAngleSelect + offsetAngle);
            Vector3 pos = new Vector3(Mathf.Sin(angleRad) * radius, Mathf.Cos(angleRad) * radius, -10);
            TMP_Text marker = Instantiate(markerPrefab, transform);
            marker.transform.localPosition = pos;
            marker.text = mods[i].GetName;
        }
    }
}
