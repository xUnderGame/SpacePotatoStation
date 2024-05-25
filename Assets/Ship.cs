using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ship : MonoBehaviour, IPointerDownHandler
{
    public UIManager uIManager;
    public void OnPointerDown (PointerEventData eventData) 
    {
        uIManager.ActivateShop();   
    }
}
