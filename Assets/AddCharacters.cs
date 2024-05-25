using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCharacters : MonoBehaviour
{
    public UIManager uIManager;
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddNCharacters(GameManager.Instance.nTurns - GameManager.Instance.characters.Count));
    }


    private IEnumerator AddNCharacters(int n) 
    {
        for (int i = 0; i < GameManager.Instance.nTurns; i++)
        {
            uIManager.ActivateName();
            yield return waitForKeyPress(KeyCode.Return);
            GameManager.Instance.characters.Add(input.text);
            uIManager.DeactivateName();
        }
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done)
        {
            if(Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }
}
