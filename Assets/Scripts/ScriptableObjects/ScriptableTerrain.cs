using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Terrain", menuName = "SpacePotatoStation/Terrain", order = 0)]
public class ScriptableTerrain : ScriptableObject
{
    public List<ScriptableSeed> available;
    public Material material;
}