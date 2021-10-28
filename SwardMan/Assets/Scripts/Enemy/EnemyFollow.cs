using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject player;
    public Transform enemy;
    public float moveSpeed = 1f;
    public Animator enemyAnimator;

    private Rigidbody enemyBody;
    private Movement playerAnimate;

    void Start()
    {
        enemyBody = this.GetComponent<Rigidbody>();
        playerAnimate = player.GetComponent<Movement>();
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 direction = other.transform.position - transform.position;
            MoveTowardsPlayer(direction);
            enemyAnimator.SetBool("attack",true);
            playerAnimate.palyerAnimator.SetBool("attack",true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enemyAnimator.SetBool("attack",false);
            playerAnimate.palyerAnimator.SetBool("attack",false);
        }
    }
    private void MoveTowardsPlayer(Vector3 direction)
    {
        enemyBody.MovePosition((Vector3)transform.position + (direction*moveSpeed*Time.deltaTime));
        enemy.localRotation = Quaternion.Euler(enemy.transform.localRotation.eulerAngles.x, enemy.transform.localRotation.eulerAngles.y, enemy.transform.localRotation.eulerAngles.z);
    }

}
