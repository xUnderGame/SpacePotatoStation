public class Pepperoni : Plant
{
    internal override void Start()
    {
        base.Start();
        completedGrowthTime = 6;
        deathTimer = -1;
    }
    public override void Interact()
    {
        if (status == Status.Decay) return;
    }

    public override void Effect(bool daily = false)
    {
        if (status == Status.Decay) return;

        // Do something else if you are being triggered by a daily event
        if (daily)
        {
            if (!hasBeenWatered) return;
            if (status == Status.Initial || status == Status.Growing) GameManager.Instance.IncreaseFood(2 + harvestBoost);
            else if (status == Status.Completed) GameManager.Instance.IncreaseFood(5 + harvestBoost);
        }
    }

    // Disable effect
    public override void Disable() { }
}
