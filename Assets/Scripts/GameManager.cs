using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public static Terrain terrainPrefab;
    [HideInInspector] public static Plant plantPrefab;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        // Get references
        terrainPrefab = Resources.Load<Terrain>("Prefabs/Terrain");
        plantPrefab = Resources.Load<Plant>("Prefabs/Plant");
    }

    // Creates the game's plot
    public void GeneratePlot()
    {

    }
}
