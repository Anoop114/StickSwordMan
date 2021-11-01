using UnityEngine;
using System;
public class Movement : MonoBehaviour
{
    [Header("Refrance")]
    public Camera mainCam;
    public GameObject playerBody;
    public Animator palyerAnimator;

    [Header("Change Values")]
    public float speed = 0.25f;
    public float swipeSpeed = 10f;
    public float dragSpeed = 5f;

    //private
    private Transform localTransform;
    private Transform playerTransform;
    private Vector3 lastMousePos;
    private Vector3 mousePos;
    private Vector3 newMousePos;

    private void Start()
    {
        playerTransform = playerBody.GetComponent<Transform>();
        localTransform = this.GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            MovePlayer();
            palyerAnimator.SetBool("run", true);
        }
        else
        {
            palyerAnimator.SetBool("run", false);
        }
        playerTransform.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void MovePlayer()
    {
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dragSpeed));

        float xDifference = mousePos.x - lastMousePos.x;
        newMousePos.x = localTransform.position.x + xDifference * swipeSpeed * Time.deltaTime;
        newMousePos.x = Mathf.Clamp(newMousePos.x, -0.4f, 0.4f);
        newMousePos.y = localTransform.position.y;
        newMousePos.z = localTransform.position.z;

        localTransform.position = newMousePos + localTransform.forward * speed * Time.deltaTime;
        
        lastMousePos = mousePos;
    }
}
