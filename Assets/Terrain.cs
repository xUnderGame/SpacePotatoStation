using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static ScriptableSeed;
using static Plant;

public class BaseTerrain : MonoBehaviour, IPointerClickHandler
{   
    [HideInInspector] public List<ScriptableSeed> available;
    [HideInInspector] public Plant growingPlant;

    internal int[] matrixPosition;
    private ScriptableTerrain terrainSB = null;
    private Transform holder;
    private Renderer ren;

    private void Start()
    {
        if (terrainSB == null) terrainSB = GameManager.Instance.sandyTerrain;
        // if (terrainSB == null) terrainSB = GameManager.Instance.dirtTerrain;

        holder = transform.Find("PlantHolder");
        ren = GetComponent<Renderer>();
        growingPlant = null;
        LoadScriptable();

        // Plant(Resources.Load<ScriptableSeed>("ScriptableObjects/Seed/CactusSeed"));
    }

    // Plants a plant onto the terrain
    public void Plant(ScriptableSeed seed)
    {
        if (!available.Contains(seed) || growingPlant != null || seed == null) return;
        switch(seed.plant)
        {
            case PlantTypes.Captus:
                growingPlant = Instantiate(GameManager.captusPrefab, holder);
                break;
            case PlantTypes.Aqua:
                growingPlant = Instantiate(GameManager.aquaPrefab, holder);
                break;
            case PlantTypes.Pepperoni:
                growingPlant = Instantiate(GameManager.pepperoniPrefab, holder);
                break;
            case PlantTypes.Booster:
                growingPlant = Instantiate(GameManager.boosterPrefab, holder);
                break;
            case PlantTypes.Spores:
                growingPlant = Instantiate(GameManager.sporesPrefab, holder);
                break;
        }
            
        // Plants positions for better access
        growingPlant.terrainPosition = matrixPosition;
        growingPlant.positionsVertical.Add(new int[] { matrixPosition[0] + 1, matrixPosition[1] });
        growingPlant.positionsVertical.Add(new int[] { matrixPosition[0] - 1, matrixPosition[1] });
        growingPlant.positionsHorizontal.Add(new int[] { matrixPosition[0], matrixPosition[1] - 1 });
        growingPlant.positionsHorizontal.Add(new int[] { matrixPosition[0], matrixPosition[1] + 1 });
        growingPlant.positionsAround.Add(new int[] { matrixPosition[0] + 1, matrixPosition[1] - 1 });
        growingPlant.positionsAround.Add(new int[] { matrixPosition[0] + 1, matrixPosition[1] + 1 });
        growingPlant.positionsAround.Add(new int[] { matrixPosition[0] - 1, matrixPosition[1] - 1 });
        growingPlant.positionsAround.Add(new int[] { matrixPosition[0] - 1, matrixPosition[1] + 1 });
        growingPlant.positionsAround.Add(growingPlant.positionsVertical[0]);
        growingPlant.positionsAround.Add(growingPlant.positionsVertical[1]);
        growingPlant.positionsAround.Add(growingPlant.positionsHorizontal[0]);
        growingPlant.positionsAround.Add(growingPlant.positionsHorizontal[1]);

        // Run default (on creation) effect
        growingPlant.Effect(); 
    }

    // Removes current plant from the terrain
    public void Cut()
    {
        if (growingPlant == null) return;

        growingPlant.Disable();
        Destroy(growingPlant);
        growingPlant = null;
    }

    // Changes a terrain's type
    public void ChangeTerrain(ScriptableTerrain newSB)
    {
        if (newSB == null || growingPlant != null || terrainSB == newSB) return;
        terrainSB = newSB;
        LoadScriptable();
    }

    // Loads the scriptable attached to this component
    private void LoadScriptable()
    {
        if (terrainSB == null) return;

        ren.material = terrainSB.material;
        available = terrainSB.available;
    }

    // UI Events //
    private void OnMouseEnter()
    {
        GameManager.Instance.TerrainInfo.SetActive(true);
        GameManager.Instance.TerrainInfo.transform.position = new Vector3(transform.position.x, GameManager.Instance.TerrainInfo.transform.position.y, transform.position.z);
    }
    private void OnMouseExit()
    {
        GameManager.Instance.TerrainInfo.SetActive(false);
    }

    public void OnPointerClick(PointerEventData data)
    {
        // TESTING TESTING TESTING TESTING TESTING TESTING 
        if (growingPlant != null) { growingPlant.status = Status.Completed; growingPlant.Effect(); }
        else Plant(Resources.Load<ScriptableSeed>("ScriptableObjects/Seed/CaptusSeed"));
    }
}
