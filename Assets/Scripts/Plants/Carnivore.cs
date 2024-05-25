using UnityEngine;

public class Carnivore : Plant
{
    public bool hasBeenFedToday;
    public int daysWithoutEating;

    internal override void Start()
    {
        base.Start();
        completedGrowthTime = 2;
        deathTimer = -1;
        hasBeenFedToday = false;
        daysWithoutEating = 0;
    }
    public override void Interact()
    {
        if (status == Status.Decay || hasBeenFedToday) return;

        GameManager.Instance.IncreaseFood(5);
        // GameManager.Instance.
        hasBeenFedToday = true;
    }

    public override void Effect(bool daily = false)
    {
        if (status == Status.Decay) return;

        BaseTerrain terrain;

        // Do something else if you are being triggered by a daily event
        if (daily)
        {
            if (daysWithoutEating > 2) Disable();
            return;
        }

        // Status stuff
        switch (status)
        {
            case Status.Completed:
                for (int i = 0; i < 3; i++)
                {
                    terrain = GameManager.Instance.GetTerrain(positionsAround[Random.Range(0, positionsAround.Count)]);
                    if (!terrain) break;
                    if (!terrain.growingPlant) break;

                    daysWithoutEating = 0;
                    GameManager.Instance.IncreaseFood(Random.Range(0, 3));
                    terrain.growingPlant.Disable();
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
    }
}
