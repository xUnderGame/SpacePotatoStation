using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Seed", menuName = "SpacePotatoStation/Seed", order = 0)]
public class ScriptableSeed : ScriptableObject
{
    public ScriptablePlant plant;
    public Image icon;
    public string description;
    public float price;
}