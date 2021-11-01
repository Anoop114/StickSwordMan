using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject player;
    public GameObject playerUI;
    private PlayerHealthAndWeapon playerHealth;
    private EnemyHealthAndAttack enemyHealth;
    private TextUpdate playerTextUpdate;
    private Transform playerTransform;
    private Animator playerAnimate;
    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealthAndWeapon>();
        playerAnimate = player.GetComponent<Animator>();
        playerTransform = player.GetComponent<Transform>();
        playerTextUpdate = playerUI.GetComponent<TextUpdate>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemyHealth = other.GetComponent<EnemyHealthAndAttack>();
            enemyHealth.enemyHealth -= playerHealth.swardDamage;
            if(enemyHealth.enemyHealth <= 0)
            {
                PlayerRestores();
                Destroy(other.gameObject);
            }
        }
    }
    void PlayerRestores()
    {
        playerHealth.health = 100;
        playerHealth.swardDamage += 5;
        playerTransform.localScale = new Vector3(playerTransform.localScale.x+0.2f,playerTransform.localScale.y+0.2f,playerTransform.localScale.z+0.2f);
        playerAnimate.SetBool("attack",false);
        playerTextUpdate.UpdateText();
    }
}
