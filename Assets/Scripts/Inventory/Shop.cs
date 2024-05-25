using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private UIManager uIManager;
    private ScriptableSeed[] possibleSeeds;
    private ScriptableSeed[] randomSeeds;
    [SerializeField]
    private GameObject[] ShopItems;
    public GameObject ShopItemPrefab;
    public int offsetY;
    public int itemAmount;
    private void Start() {
        UpdateShop();
    }

    // When a day starts, Update Shop 
    private void UpdateShop()
    {
        var children = transform.childCount;
        ShopItems = new GameObject[itemAmount];
        possibleSeeds = Resources.LoadAll<ScriptableSeed>("ScriptableObjects/Seed");
        GetRandomSeeds(itemAmount);

        for (int i = 0 + children; i < itemAmount + children; i++) 
        {
            Instantiate(ShopItemPrefab, transform);
            var newItem = transform.GetChild(i);
            var title = newItem.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            var description = newItem.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
            var amount = newItem.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();
            var price = newItem.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
            var icon = newItem.GetChild(4).GetComponent<RawImage>();

            ScriptableSeed newSeed = randomSeeds[i - children];
            title.text = newSeed.name;
            description.text = newSeed.description;
            amount.text = "5";
            price.text = $"{newSeed.price}$";
            icon.texture = newSeed.icon;

            newItem.transform.position = newItem.transform.position + new Vector3(0, offsetY + 250 * i, 0);
            newItem.GetComponent<ShopItem>().seed = newSeed;
            ShopItems[i - children] = newItem.gameObject;
        }
    }

    // When a day ends, remove shop items
    private void RemoveShopItems()
    {
        foreach (Transform child in transform) 
        {
            if (child.name == "ShopItem(Clone)") Destroy(child.gameObject);
        }
    }

    private void GetRandomSeeds(int n)
    {
        randomSeeds = new ScriptableSeed[n];
        ScriptableSeed newSeed = possibleSeeds[0];

        for (int i = 0; i < n; i++)
        {     
            // until new seed appears
            bool seedAlreadyIn = true;
            while (seedAlreadyIn)
            {
                seedAlreadyIn = false;
                newSeed = possibleSeeds[Random.Range(0, possibleSeeds.Length)];
                foreach (var seed in randomSeeds) 
                {
                    if (seed != null) 
                    {
                        if (seed.name == newSeed.name) { seedAlreadyIn = true; }
                    }
                }
            }

            randomSeeds[i] = newSeed;
        }
    }

    public void CloseShop() {
        uIManager.DeactivateShop();
    }
}
