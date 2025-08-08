using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverDetect : MonoBehaviour
{
    private Color highlightColor = Color.white;
    private Color originalColor;
    private MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        originalColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = highlightColor;
        EventManager.ModSwitchSelected();
    }

    void OnMouseExit()
    {
        rend.material.color = originalColor;
        EventManager.ModSwitchUnselected();
    }
}
