using System.Collections.Generic;
using UnityEngine;

public class Booster : Plant
{
    public List<Plant> hasBeenDefaultBoosted;
    public List<Plant> hasBeenCompleteBoosted;

    internal override void Start()
    {
        base.Start();
        hasBeenDefaultBoosted = new();
        hasBeenCompleteBoosted = new();
        completedGrowthTime = 5;
        deathTimer = -1;
    }
    public override void Interact()
    {
        if (status == Status.Decay) return;
    }

    public override void Effect(bool daily = false)
    {
        if (status == Status.Decay) return;
        
        BaseTerrain terrain;

        // Do something else if you are being triggered by a daily event
        if (daily)
        {
            if (status == Status.Growing) GameManager.Instance.IncreaseHappy(-3);
            return;
        }

        // Status stuff
        switch (status)
        {
            // Default boost
            case Status.Initial:
            case Status.Growing:
                foreach (var pos in positionsAround)
                {
                    terrain = GameManager.Instance.GetTerrain(pos);
                    if (!terrain) break;
                    if (!terrain.growingPlant) break;
                    if (hasBeenDefaultBoosted.Contains(terrain.growingPlant)) break;

                    hasBeenDefaultBoosted.Add(terrain.growingPlant);
                    terrain.growingPlant.harvestBoost += 1;
                }
                break;

            // Full boost
            case Status.Completed:
                foreach (var pos in positionsAround)
                {
                    terrain = GameManager.Instance.GetTerrain(pos);
                    if (!terrain) break;
                    if (!terrain.growingPlant) break;
                    if (hasBeenCompleteBoosted.Contains(terrain.growingPlant)) break;
                    if (hasBeenDefaultBoosted.Contains(terrain.growingPlant)) terrain.growingPlant.harvestBoost -= 1;

                    hasBeenCompleteBoosted.Add(terrain.growingPlant);
                    terrain.growingPlant.harvestBoost += 3;
                }
                break;

            default:
                break;
        }
    }

    // Disable effect
    public override void Disable()
    {
        status = Status.Decay;
        foreach (var plant in hasBeenDefaultBoosted) { plant.isProtected = false; }
        foreach (var plant in hasBeenCompleteBoosted) { plant.isProtected = false; }
    }
}
