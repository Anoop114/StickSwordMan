using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Refrance")]
    // public GameObject enemy;
    public float moveSpeed = 1f;
    private Animator enemyAnimator;

    private Rigidbody enemyBody;
    private Transform enemyTransform;
    private Animator playerAnimate;

    void Start()
    {
        
        playerAnimate = this.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            enemyBody = other.gameObject.GetComponent<Rigidbody>();
            enemyAnimator = other.gameObject.GetComponent<Animator>();
            enemyTransform = other.gameObject.GetComponent<Transform>();

            Vector3 direction = transform.position - other.transform.position;
            MoveTowardsPlayer(direction,enemyTransform);
            enemyAnimator.SetBool("attack",true);
            playerAnimate.SetBool("attack",true);
        }
        
    }
    private void MoveTowardsPlayer(Vector3 direction, Transform enemyTransform)
    {
        enemyBody.MovePosition((Vector3)transform.position + (direction*moveSpeed*Time.deltaTime));
        enemyTransform.localRotation = Quaternion.Euler(enemyTransform.transform.localRotation.eulerAngles.x, enemyTransform.transform.localRotation.eulerAngles.y, enemyTransform.transform.localRotation.eulerAngles.z);
    }

}
