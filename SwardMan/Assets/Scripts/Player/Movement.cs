using UnityEngine;
using System;
public class Movement : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject player;
    public GameObject playerBody;
    public float speed;
    public Animator palyerAnimator;
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            MovePlayer();
            palyerAnimator.SetBool("run",true);
        }else
        {
            palyerAnimator.SetBool("run",false);
        }
        playerBody.transform.localRotation = Quaternion.Euler(0,0,0);
    }
    
    private void MovePlayer()
    {
        player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z+speed*Time.deltaTime);
       
    }
}
