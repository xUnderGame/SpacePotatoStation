using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TerrainUI : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _cam;
    public RawImage icon;
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
