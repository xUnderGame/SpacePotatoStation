public class Aqua : Plant
{
    internal override void Start()
    {
        base.Start();
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
            GameManager.Instance.IncreaseWater(3 + harvestBoost);
            return;
        }

        // Status stuff
        switch (status)
        {
            case Status.Completed:
                // Gravel on top
                terrain = GameManager.Instance.GetTerrain(positionsVertical[0]);
                if (terrain) terrain.ChangeTerrain(GameManager.Instance.gravelTerrain);

                // Swamp below
                terrain = GameManager.Instance.GetTerrain(positionsVertical[1]);
                if (terrain) terrain.ChangeTerrain(GameManager.Instance.swampTerrain);
                break;

            default:
                break;
        }
    }

    // Disable effect
    public override void Disable() { }
}
