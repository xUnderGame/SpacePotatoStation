using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInfoController : MonoBehaviour
{
    private GameObject _terrainInfo;
    // Start is called before the first frame update
    void Start()
    {
        _terrainInfo = GameObject.Find("TerrainInfo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
