using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public static BaseTerrain terrainPrefab;
    [HideInInspector] public static Plant plantPrefab;

    private GameObject plot;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        // Get references
        terrainPrefab = Resources.Load<BaseTerrain>("Prefabs/Terrain");
        plantPrefab = Resources.Load<Plant>("Prefabs/Plant");
        plot = GameObject.Find("Plot");

        GeneratePlot();
    }

    // Creates the game's plot
    public void GeneratePlot()
    {
        // Z Row
        for (int zValue = 0; zValue > -6; zValue--)
        {
            // Create a separator gameobject
            GameObject row = new($"Row {zValue * -1 + 1}");
            row.transform.SetParent(plot.transform);
            row.transform.position = plot.transform.position;

            // Genreate the rest of the row
            for (int xValue = 0; xValue < 6; xValue++)
            {
                Instantiate(terrainPrefab, new Vector3(xValue, 0, zValue), Quaternion.identity, row.transform);
            }
        }
    }
}
