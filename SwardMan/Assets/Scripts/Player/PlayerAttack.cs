using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{
    [Header("Refrance")]
    public Image enemyHealthBar;
    public GameObject player;
    public GameObject WinUI;
    public GameObject Joystick;
    public GameManager manager;
    private PlayerHealthAndWeapon playerHealth;
    private EnemyHealthAndAttack enemyHealth;

    private int enemyMaxHealth;
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealthAndWeapon>();
        enemyMaxHealth = 200;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemyHealth = other.GetComponent<EnemyHealthAndAttack>();
            enemyHealth.enemyHealth -= playerHealth.swardDamage;
            enemyHealthBar.fillAmount = (float)enemyHealth.enemyHealth/(float)enemyMaxHealth;
            if(enemyHealth.enemyHealth <= 0)
            {
                Joystick.SetActive(false);
                WinUI.SetActive(true);
                manager.PauseGame();
                Destroy(other.gameObject);
            }
        }
    }
}
