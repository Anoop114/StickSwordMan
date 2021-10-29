using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject enemy;
    private PlayerHealthAndWeapon playerHealth;
    private EnemyHealthAndAttack enemyHealth;

    void Start()
    {
        enemyHealth = enemy.GetComponent<EnemyHealthAndAttack>();
    }

   void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<PlayerHealthAndWeapon>();
            playerHealth.health -= enemyHealth.enemySwardDamage;
            
            if(playerHealth.health <= 0)
            {
                playerHealth.health = 100;
                Debug.Log(playerHealth.health);
                Destroy(other.gameObject);
            }
        }
    }
}
