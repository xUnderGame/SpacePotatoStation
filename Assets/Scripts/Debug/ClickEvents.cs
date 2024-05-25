using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UIManager uIManager;
    public void OnPointerDown (PointerEventData eventData) 
    {
        uIManager.ActivateShop();   
    }

    public void OnPointerUp(PointerEventData eventData) {}

    public void OnPointerClick(PointerEventData eventData) {}

    public void OnPointerEnter(PointerEventData eventData) {}

    public void OnPointerExit(PointerEventData eventData) {}
}