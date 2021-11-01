using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject enemy;
    public GameObject looseGameUI;
    public GameObject playerUI;
    private PlayerHealthAndWeapon playerHealth;
    private EnemyHealthAndAttack enemyHealth;
    private TextUpdate playerTextUpdate;
    private GameManager manager;

    void Start()
    {
        enemyHealth = enemy.GetComponent<EnemyHealthAndAttack>();
        playerTextUpdate = playerUI.GetComponent<TextUpdate>();
        manager = playerUI.GetComponent<GameManager>();
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
                Destroy(other.gameObject);
                manager.PauseGame();
                looseGameUI.SetActive(true);
            }
        }
    }
}
