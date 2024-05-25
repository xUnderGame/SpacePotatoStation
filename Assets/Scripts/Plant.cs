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
    private Renderer ren;

    private void Start()
    {
        ren = GetComponent<Renderer>();
        currentGrowthTime = 0;
        status = Status.Initial;
        LoadScriptable();
    }

    // Invokes a plant's effect based on its current status
    public void InvokeEffect()
    {
        switch (status)
        {
            case Status.Initial:
                effects[0].Call(); 
               break;
            case Status.Growing:
                effects[1].Call();
                break;
            case Status.Completed:
                effects[2].Call();
                break;
            case Status.Decay:
                ren.material.color = new Color(0.22f, 0.22f, 0.22f);
                effects[3].Call();
                break;
        }
    }

    // Loads the scriptable attached to this component
    private void LoadScriptable()
    {
        if (plantSB == null) return;

        effects = plantSB.effects;
        completedGrowthTime = plantSB.growthTime;
    }
}
