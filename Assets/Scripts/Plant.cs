using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public enum Status { Initial, Growing, Completed, Decay }
    [HideInInspector] public Status status;
    [HideInInspector] public int completedGrowthTime;
    [HideInInspector] public int currentGrowthTime;

    private List<Effect> effects;
    private readonly ScriptablePlant plantSB;

    private void Start()
    {
        currentGrowthTime = 0;
        status = Status.Initial;
        LoadScriptable();
    }

    // Invokes a plant's effect based on its current status
    public void InvokeEffect() { }

    // Loads the scriptable attached to this component
    private void LoadScriptable()
    {
        if (plantSB == null) return;

        effects = plantSB.effects;
        completedGrowthTime = plantSB.growthTime;
    }
}
