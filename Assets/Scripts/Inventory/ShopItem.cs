using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Inventory inventoryManager;
    public ScriptableSeed seed; // Assigned from script on instantiation
    public Image background;
    public TextMeshProUGUI amount;

    private void Start() 
    {
        inventoryManager = GameObject.FindWithTag("GameManager").GetComponent<Inventory>();
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
        int amountNum = int.Parse(Regex.Split(amount.text, @"\D+")[0]);
        if (amountNum > 0)
        {
            inventoryManager.AddItem(seed);
            amount.text = $"{amountNum - 1}";
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = new Color(1f, 1f, 1f, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = new Color(1f, 1f, 1f, 0.8f);
    }
}
