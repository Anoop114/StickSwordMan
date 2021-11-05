using UnityEngine;
using System;
public class Movement : MonoBehaviour
{
    [Header("Refrance")]
    public SwipeControl swipe;
    public GameObject playerBody;
    public Animator palyerAnimator;

    [Header("Change Values")]
    public float speed;

    //private
    private Transform localTransform;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = playerBody.GetComponent<Transform>();
        localTransform = this.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if(swipe.SwipeLeft)
        {
            Debug.Log("left");
            MovePlayerLeft();
            // palyerAnimator.SetBool("attack",false);
        }
        else if(swipe.SwipeRight)
        {
            Debug.Log("right");
            MovePlayerRight();
            // palyerAnimator.SetBool("attack",false);
        }
        else if(swipe.SwipeDown)
        {
            Debug.Log("down");
            MovePlayerBackword();
            palyerAnimator.SetBool("back",true);
        }
        else if(swipe.SwipeUp)
        {
            Debug.Log("up");
            MovePlayerForward();
            palyerAnimator.SetBool("jump",true);
        }
        else
        {
            // playerTransform.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        
    }

    private void MovePlayerRight()
    { 
        playerTransform.position = Vector3.MoveTowards(playerTransform.position,Vector3.right,speed*Time.deltaTime);
    }
    private void MovePlayerLeft()
    { 
        playerTransform.position = Vector3.MoveTowards(playerTransform.position,Vector3.left,speed*Time.deltaTime);
    }
    private void MovePlayerForward()
    {
        playerTransform.position = Vector3.MoveTowards(playerTransform.position,Vector3.forward,speed*Time.deltaTime);
        
        palyerAnimator.SetBool("jump",false);
    }
    private void MovePlayerBackword()
    { 
        playerTransform.position = Vector3.MoveTowards(playerTransform.position,Vector3.back,speed*Time.deltaTime);
        palyerAnimator.SetBool("back",false);
    }
    
}
