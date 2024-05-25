using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ScriptablePlant", menuName = "SpacePotatoStation/ScriptablePlant", order = 0)]
public class ScriptablePlant : ScriptableObject 
{    
    public List<Image> sprites;
    // public List<Effect> Effects;
    public int growthTime;
}