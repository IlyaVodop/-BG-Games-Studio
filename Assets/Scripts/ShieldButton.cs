using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        UiManager.Instance.PressedShieldButton();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UiManager.Instance.UnPressedShieldButton();
    }
}
