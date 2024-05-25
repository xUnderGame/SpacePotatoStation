using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public enum Status { Initial, Growing, Completed, Decay }
    [HideInInspector] public Status status;
    [HideInInspector] public int completedGrowthTime;
    [HideInInspector] public int currentGrowthTime;

    internal int[] terrainPosition;
    internal List<int[]> positionsVertical = new(capacity: 1);
    internal List<int[]> positionsHorizontal = new(capacity: 1);
    internal List<int[]> positionsAround = new();
    internal bool hasBeenWatered = false;
    internal bool isProtected = false;
    internal int harvestBoost = 0;
    internal int deathTimer = -1;

    // Models //
    internal GameObject stageOne;
    internal GameObject stageTwo;
    internal GameObject stageThree;

    internal virtual void Start()
    {
        stageOne = transform.Find("Initial").gameObject;
        stageTwo = transform.Find("Growing").gameObject;
        stageThree = transform.Find("Completed").gameObject;
        status = Status.Initial;
        currentGrowthTime = 0;
    }

    // Invokes a plant's effect based on its current status
    public abstract void Effect(bool daily = false);

    // Interact with the plant
    public abstract void Interact();

    // Disable a plant
    public abstract void Disable();

    // Change a plant's state
    public void ChangeStatus(Status newStatus)
    {
        status = newStatus;

        if (newStatus == Status.Decay)
        {
            if (stageOne.activeSelf) stageOne.GetComponent<Renderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
            if (stageTwo.activeSelf) stageTwo.GetComponent<Renderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
            if (stageThree.activeSelf) stageThree.GetComponent<Renderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
            return;
        }

        // Cycle through models
        stageOne.SetActive(false);
        stageTwo.SetActive(false);
        stageThree.SetActive(false);
        transform.Find(newStatus.ToString()).gameObject.SetActive(true);
    }
}
