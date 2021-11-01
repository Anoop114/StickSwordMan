using UnityEngine;
using TMPro;
public class TextUpdate : MonoBehaviour
{
    [Header("Refrance")]
    public TMP_Text playerHealth;
    public TMP_Text playerSwardPower;

    public PlayerHealthAndWeapon playerHealthWeapon;

    private void Start() {
        playerHealth.text = "Health:"+playerHealthWeapon.health.ToString();
        playerSwardPower.text = "Sward Damage:"+playerHealthWeapon.swardDamage.ToString();
    }

    public void UpdateText()
    {
        playerHealth.text = "Health:"+playerHealthWeapon.health.ToString();
        playerSwardPower.text = "Sward Damage:"+playerHealthWeapon.swardDamage.ToString();
    }

}
