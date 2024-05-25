using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Public references //
    [HideInInspector] public static BaseTerrain terrainPrefab;
    [HideInInspector] public static Plant captusPrefab;
    [HideInInspector] public static Plant aquaPrefab;
    [HideInInspector] public static Plant pepperoniPrefab;
    [HideInInspector] public static Plant boosterPrefab;
    [HideInInspector] public static Plant sporesPrefab;
    [HideInInspector] public static Plant carnivorePrefab;
    [HideInInspector] public ScriptableTerrain sandyTerrain;
    [HideInInspector] public ScriptableTerrain dirtTerrain;
    [HideInInspector] public ScriptableTerrain gravelTerrain;
    [HideInInspector] public ScriptableTerrain swampTerrain;
    public GameObject TerrainInfo;
    public int foodValue;
    public int waterValue;
    public int happyValue;

    private readonly int maxCapacity = 5;
    private List<List<BaseTerrain>> plot;
    private GameObject plotObject;

    public int nTurns, maxTurns;
    public List<string> characters;
    public int nAliens;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        // Get references
        terrainPrefab = Resources.Load<BaseTerrain>("Prefabs/Terrain");
        captusPrefab = Resources.Load<Plant>("Prefabs/Plants/Captus");
        aquaPrefab = Resources.Load<Plant>("Prefabs/Plants/Aqua");
        pepperoniPrefab = Resources.Load<Plant>("Prefabs/Plants/Pepperoni");
        boosterPrefab = Resources.Load<Plant>("Prefabs/Plants/Booster");
        sporesPrefab = Resources.Load<Plant>("Prefabs/Plants/Spores");
        carnivorePrefab = Resources.Load<Plant>("Prefabs/Plants/Carnivora");
        sandyTerrain = Resources.Load<ScriptableTerrain>("ScriptableObjects/Terrains/SandTerrain");
        dirtTerrain = Resources.Load<ScriptableTerrain>("ScriptableObjects/Terrains/DirtTerrain");
        gravelTerrain = Resources.Load<ScriptableTerrain>("ScriptableObjects/Terrains/GravelTerrain");
        swampTerrain = Resources.Load<ScriptableTerrain>("ScriptableObjects/Terrains/SwampTerrain");

        TerrainInfo = GameObject.Find("TerrainInfo");
        plotObject = GameObject.Find("Plot");

        // Defaults
        foodValue = 100;
        waterValue = 50;
        happyValue = 50;

        // Do plot
        if (TerrainInfo) TerrainInfo.SetActive(false);
        plot = new(capacity: maxCapacity);
        GeneratePlot();

        //Set maxTurns
        ResetTurns();
    }

    // Creates the game's plot
    public void GeneratePlot(float gridIncrement = 0.75f)
    {
        float yOffset = 0f;

        // Z axis
        for (int zValue = 0; zValue < 6; zValue++)
        {
            float xOffset = 0f;

            // Create a row
            GameObject row = new($"Row {zValue + 1}");
            row.transform.SetParent(plotObject.transform);
            row.transform.position = plotObject.transform.position;
            List<BaseTerrain> genRow = new(capacity: maxCapacity);

            // Generate the rest of them
            for (int xValue = 0; xValue < 6; xValue++)
            {
                int[] pos = { zValue, xValue };
                BaseTerrain generatedTerrain = Instantiate(terrainPrefab, new Vector3(row.transform.position.x + xValue + xOffset, row.transform.position.y, row.transform.position.z + zValue + yOffset), Quaternion.Euler(-90, 0, 0), row.transform);
                generatedTerrain.gameObject.name = $"Terrain ({zValue}, {xValue})";

                // Add the Terrain to the generated row
                generatedTerrain.matrixPosition = pos;
                genRow.Add(generatedTerrain);

                xOffset += gridIncrement;
            }
            yOffset += gridIncrement;

            // Add to the plot
            plot.Add(genRow);
        }
    }

    // Funciones control de turnos
    public void AddTurns(int num)
    {
        nTurns += num;
    }

    public void SubstractTurns(int num)
    {
        nTurns -= num;
    }

    public void ResetTurns()
    {
        maxTurns = nAliens;
        nTurns = maxTurns;
    }

    // Funciones control de aliens
    public void AddAliens(int num)
    {
        nAliens += num;
    }

    public void SustractAliens(int num)
    {
        nAliens -= num;
    }

    // Get a terrain in the matrix
    public BaseTerrain GetTerrain(int[] pos)
    {
        if (pos[0] > maxCapacity || pos[0] < 0 || pos[1] > maxCapacity || pos[1] < 0) return null;
        return plot[pos[0]][pos[1]];
    }

    // Increases your water quantity
    public void IncreaseWater(int value)
    {
        if (waterValue + value > 100) waterValue = 100;
        else waterValue += value;
    }

    // Increases your food quantity
    public void IncreaseFood(int value)
    {
        if (foodValue + value > 100) foodValue = 100;
        else foodValue += value;
    }

    // Increases your happiness quantity
    public void IncreaseHappy(int value)
    {
        if (happyValue + value > 100) happyValue = 100;
        else happyValue += value;
    }
}
