using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Plant", menuName = "SpacePotatoStation/Plant", order = 0)]
public class ScriptablePlant : ScriptableObject
{
    public List<MeshRenderer> meshes;
    public List<Effect> effects;
    public int growthTime;
}