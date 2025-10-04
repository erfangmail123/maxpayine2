using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Slider healthBar;
    public Text ammoText;
    public PlayerShooting player;
    public Health playerHealth;

    void Update()
    {
        if (playerHealth != null)
        {
            healthBar.value = playerHealth.currentHealth / playerHealth.maxHealth;
        }

        if (player != null)
        {
            ammoText.text = "Ammo: " + player.currentAmmo + "/" + player.maxAmmo;
        }
    }
}
