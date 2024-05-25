using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.TerrainTools.PaintContext;

public class TerrainInteraction : MonoBehaviour
{
    //private GameObject _terrainInfo;
    void Start()
    {
        //_terrainInfo = GameObject.Find("TerrainInfo");
        GameManager.Instance.TerrainInfo.SetActive(false);
    }

    void Update()
    {
    }

    private void OnMouseEnter()
    {
        GameManager.Instance.TerrainInfo.SetActive(true);
        GameManager.Instance.TerrainInfo.transform.position = new Vector3(transform.position.x, GameManager.Instance.TerrainInfo.transform.position.y, transform.position.z);
    }

    private void OnMouseExit()
    {
        GameManager.Instance.TerrainInfo.SetActive(false);
    }


}
