using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public static BaseTerrain terrainPrefab;
    [HideInInspector] public static Plant plantPrefab;
    public GameObject TerrainInfo;

    private readonly int maxCapacity = 5;
    private List<List<BaseTerrain>> plot;
    private GameObject plotObject;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        // Get references
        terrainPrefab = Resources.Load<BaseTerrain>("Prefabs/Terrain");
        plantPrefab = Resources.Load<Plant>("Prefabs/Plant");
        TerrainInfo = GameObject.Find("TerrainInfo");
        plotObject = GameObject.Find("Plot");

        // Do plot
        if (TerrainInfo) TerrainInfo.SetActive(false);
        plot = new(capacity: maxCapacity);
        GeneratePlot();
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
                BaseTerrain generatedTerrain = Instantiate(terrainPrefab, new Vector3(row.transform.position.x + xValue + xOffset, row.transform.position.y, row.transform.position.z + zValue + yOffset), row.transform.rotation, row.transform);
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
}
