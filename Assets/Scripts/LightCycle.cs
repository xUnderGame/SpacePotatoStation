using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycle : MonoBehaviour
{
    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        if (GameManager.Instance.nTurns >=(GameManager.Instance.maxTurns * 0.75))
        {
            lt.color = new Color32(255, 244, 214, 255);
        }
        else if (GameManager.Instance.nTurns >= (GameManager.Instance.maxTurns * 0.50))
        {
            lt.color = new Color32(255, 221, 129, 255);
        }
        else if (GameManager.Instance.nTurns >= (GameManager.Instance.maxTurns * 0.25))
        {
            lt.color = new Color32(255, 196, 35, 255);
        }
        else if (GameManager.Instance.nTurns < (GameManager.Instance.maxTurns * 0.25))
        {
            lt.color = new Color32(0, 0, 0, 255);
        }
        else
        {
            lt.color = new Color32(255, 244, 214, 255);
        }
    }
}
