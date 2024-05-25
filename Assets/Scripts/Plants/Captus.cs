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

    public override void Effect()
    {
        if (status == Status.Decay) return;

        BaseTerrain terrain;

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
}
