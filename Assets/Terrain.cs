using System.Collections.Generic;
using UnityEngine;

public class BaseTerrain : MonoBehaviour
{   
    [HideInInspector] public List<ScriptableSeed> available;
    [HideInInspector] public Plant growingPlant;

    internal int[] matrixPosition;
    private ScriptableTerrain terrainSB = null;
    private Transform holder;
    private Renderer ren;

    private void Start()
    {
        if (terrainSB == null) terrainSB = Resources.Load<ScriptableTerrain>("ScriptableObjects/Terrains/SandTerrain");
        
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

        Instantiate(GameManager.plantPrefab, holder);
    }

    // Removes current plant from the terrain
    public void Cut()
    {
        if (growingPlant == null) return;

        Destroy(growingPlant);
        growingPlant = null;
    }

    // Loads the scriptable attached to this component
    private void LoadScriptable()
    {
        if (terrainSB == null) return;

        ren.material = terrainSB.material;
        available = terrainSB.available;
    }
}
