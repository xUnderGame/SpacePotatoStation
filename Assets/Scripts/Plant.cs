using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public enum Status { Initial, Growing, Completed, Decay }
    [HideInInspector] public Status status;
    [HideInInspector] public int completedGrowthTime;
    [HideInInspector] public int currentGrowthTime;

    internal int[] terrainPosition;
    internal List<int[]> positionsVertical = new(capacity: 2);
    internal List<int[]> positionsHorizontal = new(capacity: 1);
    internal List<int[]> positionsAround = new(capacity: 2);
    internal int deathTimer = -1;
    internal Renderer ren;

    internal virtual void Start()
    {
        ren = GetComponent<Renderer>();
        status = Status.Initial;
        currentGrowthTime = 0;
    }

    // Invokes a plant's effect based on its current status
    public abstract void Effect();

    // Interact with the plant
    public abstract void Interact();
}
