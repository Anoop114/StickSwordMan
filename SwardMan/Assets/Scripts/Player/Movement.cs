using UnityEngine;
using System;
public class Movement : MonoBehaviour
{
    [Header("Refrance")]
    public GameObject player;
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
    }
    
    private void MovePlayer()
    {
        player.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z+speed*Time.deltaTime);
        player.transform.localRotation = Quaternion.Euler(player.transform.localRotation.eulerAngles.x, player.transform.localRotation.eulerAngles.y, player.transform.localRotation.eulerAngles.z);
    }
}
