using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;
    public Image HungerBar;
    public Image WaterBar;
    public Image HappyBar;

    public void Awake() { Instance = this; }

    public void UpdateHungerBar(float amount) { HungerBar.fillAmount = amount; }
    public void UpdateWaterBar(float amount) { WaterBar.fillAmount = amount; }
    public void UpdateHappyBar(float amount) { HappyBar.fillAmount = amount; }
}
