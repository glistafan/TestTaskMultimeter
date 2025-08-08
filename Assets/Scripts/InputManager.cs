using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        float scrollDelta = Input.mouseScrollDelta.y;

        if (Mathf.Abs(scrollDelta) > 0.01f)
        {
            EventManager.TriggerMouseScroll(scrollDelta);
        }
    }
}
