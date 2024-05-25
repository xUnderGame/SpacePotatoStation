using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableSeed", menuName = "SpacePotatoStation/ScriptableSeed", order = 0)]
public class ScriptableSeed : ScriptableObject
{
    public enum PlantTypes { Captus }
    public PlantTypes plant;
    public Image icon;
    public string description;
    public float price;
}