using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Plant", menuName = "SpacePotatoStation/Plant", order = 0)]
public class Plant : ScriptableObject {
    public enum States { Initial, Completed, Decay }
    public States currentState;
    public List<Image> sprites;
    // public List<Effect> Effects;
    public int growthTime;
    private int currentGrowthTime;

    public void InvokeEffects() {}
}