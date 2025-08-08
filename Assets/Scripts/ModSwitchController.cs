using System.Collections.Generic;
using UnityEngine;

public class ModSwitchController : MonoBehaviour
{
    [SerializeField] private float resistance = 1000;
    [SerializeField] private float power = 400;
    [SerializeField] private ModMarkerCreator modMarkerCreator;
    [SerializeField] private List<MultimeterMod> mods = new List<MultimeterMod>();
    private float modSelectAngle;   
    private int currentIndex;  
    private int modeCount;
    private bool switchSelected;
    private float offsetAngle = 4;



    private void Start()
    {
        modeCount = mods.Count;
        if (modeCount == 0)
        {
            return;
        }

        modSelectAngle = 360f / modeCount;
        transform.rotation = Quaternion.Euler(0, 0, -modSelectAngle - offsetAngle);
        currentIndex = 1;
        modMarkerCreator.CreateMarks(mods, modSelectAngle);
        CalculatedNewValue();

        EventManager.OnMouseScroll += OnScroll;
        EventManager.OnModSwitchUnselected += () => switchSelected = false;
        EventManager.OnModSwitchSelected += () => switchSelected = true;
    }

    private void OnScroll(float delta)
    {
        if (!switchSelected)
        {
            return;
        }

        if (delta > 0)
        {

            if (currentIndex != 0)
            {
                currentIndex--;
            }
            else
            {
                currentIndex = mods.Count - 1;
            }
        }
        else if (delta < 0)
        {
            if (currentIndex != mods.Count - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }

        if(mods[currentIndex].GetModType == ModType.PlaceHolder)
        {
            OnScroll(delta);
        }
        RotateToSelectMode();

        EventManager.MultimeterModChanged(mods[currentIndex].GetModType);
        CalculatedNewValue();

    }

    private void RotateToSelectMode()
    {
        float targetAngle = currentIndex * modSelectAngle;
        transform.rotation = Quaternion.Euler(0, 0, -targetAngle - offsetAngle);
    }

    private void CalculatedNewValue()
    {
        var newValue = mods[currentIndex].Calculate(resistance, power);
        EventManager.MultimeterValueChanged(newValue);
    }
}
