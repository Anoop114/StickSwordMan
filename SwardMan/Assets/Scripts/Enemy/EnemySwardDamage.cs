using UnityEngine;

public class EnemySwardDamage : MonoBehaviour
{
    public GameObject enemy;
    public GameObject playerUI;
    public GameObject LooseUI;
    public GameManager manager;
    public GameObject Joystick;
    private PlayerHealthAndWeapon playerHealth;
    private EnemyHealthAndAttack enemyHealth;
    private TextUpdate playerTextUpdate;

    private void Start() {
        enemyHealth = enemy.GetComponent<EnemyHealthAndAttack>();
        playerTextUpdate = playerUI.GetComponent<TextUpdate>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealthAndWeapon>();
            playerHealth.health -= enemyHealth.enemySwardDamage;
            playerTextUpdate.UpdateText();
            if(playerHealth.health <= 0)
            {
                Joystick.SetActive(false);
                LooseUI.SetActive(true);
                manager.PauseGame();
                Destroy(other.gameObject);
            }
        }
    }
}
