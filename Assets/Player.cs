using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public bool action = true;
    public List<string> availableCharacters = new List<string>();
    public string nameTag = "";
    [SerializeField] private Vector3 shipPosition;

    private void Start()
    {
        availableCharacters = GameManager.Instance.characters;
    }

    private void Update() 
    {
        float distance = Vector3.Distance(shipPosition, (Vector2)transform.position);
        if (!action && distance < 0.5f)
        {
            ChangeCharacter();

        }
    }
    public void ActionDone() {
        action = false;
        GetComponent<NavMeshAgent>().destination = shipPosition;
    }
    public void ChangeCharacter() {
        //  animation
        // invisible
        nameTag = availableCharacters[0];
        availableCharacters.RemoveAt(0);

        // visible
    }
}
