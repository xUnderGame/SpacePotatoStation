using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameObject background;
    public GameObject gameUI;
    public GameObject nameWindow;
    public GameObject shopWindow;

    void Start () {
        background.SetActive(false);
        gameUI.SetActive(true);
        nameWindow.SetActive(false);
        shopWindow.SetActive(false);

        // ActivateName();
    }

    public void ActivateShop() 
    {
        background.SetActive(true);
        shopWindow.SetActive(true);
    }

    public void DeactivateShop() 
    {
        background.SetActive(false);
        shopWindow.SetActive(false);
    }

    public void ActivateName()
    {
        background.SetActive(true);
        nameWindow.SetActive(true);
    }

    public void DeactivateName()
    {
        background.SetActive(false);
        nameWindow.SetActive(false);
    }
}