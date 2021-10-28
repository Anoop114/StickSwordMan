using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject player;
    private PlayerHealthAndWeapon playerHealth;
    private EnemyHealthAndAttack enemyHealth;
    private Animator playerAnimate;
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealthAndWeapon>();
        playerAnimate = player.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemyHealth = other.GetComponent<EnemyHealthAndAttack>();
            enemyHealth.enemyHealth -= playerHealth.swardDamage;
            if(enemyHealth.enemyHealth <= 0)
            {
                Destroy(other.gameObject);
                playerAnimate.SetBool("attack",false);
            }
        }
    }
    
}
