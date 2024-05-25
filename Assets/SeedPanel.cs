using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SeedPanel : MonoBehaviour
{
    public GameObject panelPrefab;
    public Inventory inventory;
    public int offsetY = 0;

    void Start()
    {
        UpdateSeeds();
    }

    public void UpdateSeeds()
    {
        for (int i = 0; i < inventory.slots.Count; i++) 
        {
            Instantiate(panelPrefab, transform);
            var newPanel = transform.GetChild(i);

            var seedName = newPanel.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            var amount = newPanel.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();

            seedName.text = inventory.slots[i].type.name;
            amount.text = $"{inventory.slots[i].quantity}";

            newPanel.transform.position = newPanel.transform.position + new Vector3(0, offsetY + 250 * i, 0);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
