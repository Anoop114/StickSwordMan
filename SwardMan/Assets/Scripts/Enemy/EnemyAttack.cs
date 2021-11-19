using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Refrance")]
    public Animator enemyAnimation;

   void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enemyAnimation.SetBool("attack",true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            enemyAnimation.SetBool("attack",false);
        }
    }
}
