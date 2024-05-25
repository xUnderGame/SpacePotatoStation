using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerrainUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _cam;
    public TextMeshProUGUI terrainStatus;
    public TextMeshProUGUI plantStatus;
    public TextMeshProUGUI growthProgress;
    //public TextMeshProUGUI fertilize;
    void Start()
    {
        _cam = Camera.main;
        terrainStatus.text = "Terrrain: Type 1";
        plantStatus.text = "Plant: Growing";
        growthProgress.text = "Progress: 60%";
        //fertilize.text = "creciendo";
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
    }
}
