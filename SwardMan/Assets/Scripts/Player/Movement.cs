using UnityEngine;
using System;
using CnControls;
public class Movement : MonoBehaviour
{
    [Header("Straight the player")]
    public Transform[] bones;
    public bool keepBonesStraight;
    public Animator palyerAnimator;

    [Header("Change Values")]
    public float speed;
    public float turnSpeed;
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
        palyerAnimator.SetBool("run",true);
    }

    private void Update() {
        if(Input.GetMouseButton(0))
        {
            Vector3 touchMagnitude = new Vector3(CnInputManager.GetAxis("Horizontal"),CnInputManager.GetAxis("Vertical"),0);
            Vector3 touchPos = transform.position + touchMagnitude;
            Vector3 touchDir = touchPos - transform.position;
            float angle = Mathf.Atan2(touchDir.y,touchDir.x) * Mathf.Rad2Deg;
            angle -= 90;
            Quaternion rot = Quaternion.AngleAxis(angle,Vector3.down);
            this.transform.rotation = Quaternion.Lerp(transform.rotation,rot,turnSpeed * Mathf.Min(Time.deltaTime,0.04f));
        }
    }
    void FixedUpdate()
    {
        playerRb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }

    private void LateUpdate() {
        if(keepBonesStraight)
        {
            foreach (Transform item in bones)
            {
                item.eulerAngles = new Vector3(0,item.eulerAngles.y,item.eulerAngles.z);
            }
        }
    }
}
