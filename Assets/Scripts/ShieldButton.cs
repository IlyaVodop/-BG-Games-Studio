using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
public class ShieldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Inject] UiManager _uiManager;
    public void OnPointerDown(PointerEventData eventData)
    {
        _uiManager.PressedShieldButton();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _uiManager.UnPressedShieldButton();
    }
}
