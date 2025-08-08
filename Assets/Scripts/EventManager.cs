using System;

public static class EventManager
{
    public static event Action<float> OnMouseScroll;
    
    public static void TriggerMouseScroll(float delta)
    {
        OnMouseScroll?.Invoke(delta);
    }
    public static event Action<float> OnMultimeterValueChanged;
    public static void MultimeterValueChanged(float value)
    {
        OnMultimeterValueChanged?.Invoke(value);
    }

    public static event Action<ModType> OnMultimeterModChanged;
    public static void MultimeterModChanged(ModType modType)
    {
        OnMultimeterModChanged?.Invoke(modType);
    }

    public static event Action OnModSwitchSelected;
    public static void ModSwitchSelected()
    {
        OnModSwitchSelected?.Invoke();
    }

    public static event Action OnModSwitchUnselected;
    public static void ModSwitchUnselected()
    {
        OnModSwitchUnselected?.Invoke();
    }
}

