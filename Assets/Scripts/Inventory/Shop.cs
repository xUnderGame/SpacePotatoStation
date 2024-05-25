using UnityEngine;

public class Shop : MonoBehaviour
{
    private ScriptableSeed[] possibleSeeds;
    private ScriptableSeed[] randomSeeds;
    private GameObject[] ShopItems;
    public GameObject ShopItem;
    public int offsetY;
    public int itemAmount;
    void Start()
    {
        ShopItems = new GameObject[itemAmount];
        possibleSeeds = Resources.LoadAll<ScriptableSeed>("ScriptableObjects/Seed");
        GetRandomSeeds(itemAmount);

        var children = transform.childCount;
        for (int i = 0 + children; i < itemAmount + children; i++) 
        {
            Instantiate(ShopItem, transform);
            var newItem = transform.GetChild(i);
            var title = newItem.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            var description = newItem.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
            var amount = newItem.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();

            title.text = randomSeeds[i - children].name;
            description.text = randomSeeds[i - children].description;
            amount.text = "5";

            newItem.transform.position = newItem.transform.position + new Vector3(0, offsetY + 250 * i, 0);
            ShopItems[0] = newItem.gameObject;
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
}
