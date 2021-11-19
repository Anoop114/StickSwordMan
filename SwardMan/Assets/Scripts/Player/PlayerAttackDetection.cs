using UnityEngine;

public class PlayerAttackDetection : MonoBehaviour
{
    public Animator playerAnimator;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("EnemyCylinder"))
        {
            playerAnimator.SetBool("attack",true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("EnemyCylinder"))
        {
            playerAnimator.SetBool("attack",false);
        }
    }
}
