using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Refrance")]
    public Transform player;
    private Rigidbody enemyBody;

    private void Start() {
        enemyBody = this.GetComponent<Rigidbody>();
    }

    private void Update() {
        if(player != null)
        {
            Vector3 dir = player.position - enemyBody.position;
            dir = new Vector3(dir.x,dir.y*0,dir.z);
            Quaternion rot = Quaternion.LookRotation(dir);
            enemyBody.rotation = rot;
        }
        
    }

}
