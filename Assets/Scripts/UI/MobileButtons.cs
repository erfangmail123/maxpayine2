using UnityEngine;
using UnityEngine.UI;

public class MobileButtons : MonoBehaviour
{
    public Button shootButton;
    public Button bulletTimeButton;
    public PlayerShooting playerShooting;

    void Start()
    {
        if (shootButton != null) shootButton.onClick.AddListener(() => playerShooting.OnShootButton());
        if (bulletTimeButton != null) bulletTimeButton.onClick.AddListener(() => playerShooting.TriggerBulletTime());
    }
}