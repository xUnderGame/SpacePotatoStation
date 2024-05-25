using System.Collections.Generic;

public class Spores : Plant
{

    public List<Plant> hasBeenProtected;
    internal override void Start()
    {
        base.Start();
        hasBeenProtected = new();
        completedGrowthTime = 3;
        deathTimer = 3;
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
            deathTimer--;
            if (deathTimer < 0) Disable();
        }

        // Status stuff
        switch (status)
        {
            case Status.Completed:
                foreach (var pos in positionsAround)
                {
                    terrain = GameManager.Instance.GetTerrain(pos);
                    if (!terrain) break;
                    if (!terrain.growingPlant) break;
                    if (hasBeenProtected.Contains(terrain.growingPlant)) break;

                    hasBeenProtected.Add(terrain.growingPlant);
                    terrain.growingPlant.isProtected = true;
                }
                break;

            default:
                break;
        }
    }

    // Disable effect
    public override void Disable()
    {
        ChangeStatus(Status.Decay);
        foreach (var plant in hasBeenProtected)
        {
            plant.isProtected = false;
        }
    }
}
