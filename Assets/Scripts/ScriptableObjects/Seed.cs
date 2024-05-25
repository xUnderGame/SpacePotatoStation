using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Seed", menuName = "SpacePotatoStation/Seed", order = 0)]
public class Seed : ScriptableObject {
    public Plant plant;
    public Image icon;
    public string description;
    public float price;
}