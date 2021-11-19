using UnityEngine;
using TMPro;
public class TextUpdate : MonoBehaviour
{
    [Header("Refrance")]
    public TMP_Text playerHealth;

    public PlayerHealthAndWeapon playerHealthWeapon;

    private void Start() {
        playerHealth.text = "Health:"+playerHealthWeapon.health.ToString();
    }

    public void UpdateText()
    {
        playerHealth.text = "Health:"+playerHealthWeapon.health.ToString();
    }

}
