using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableSeed", menuName = "SpacePotatoStation/ScriptableSeed", order = 0)]
public class ScriptableSeed : ScriptableObject
{
    public enum PlantTypes { Captus, Aqua, Pepperoni, Booster, Spores, Carnivore }
    public PlantTypes plant;
    public Texture icon;
    public string description;
    public float price;
}