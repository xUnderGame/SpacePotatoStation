public class Captus : Plant
{
    internal override void Start()
    {
        base.Start();
        completedGrowthTime = 3;
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
            return;
        }

        // Status stuff
        switch (status)
        {
            case Status.Initial:
                foreach (var pos in positionsHorizontal)
                {
                    terrain = GameManager.Instance.GetTerrain(pos);
                    if (terrain) terrain.ChangeTerrain(GameManager.Instance.dirtTerrain);
                }
                break;

            case Status.Completed:
                foreach (var pos in positionsVertical)
                {
                    terrain = GameManager.Instance.GetTerrain(pos);
                    if (terrain) terrain.ChangeTerrain(GameManager.Instance.dirtTerrain);
                }
                break;

            default:
                break;
        }
    }

    // Disable effect
    public override void Disable() { }
}
