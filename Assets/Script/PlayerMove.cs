using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    private bool is_top;

    float stick_hAxis, stick_vAxis, key_hAxis, key_vAxis;
    float shoot;
    Vector3 moveVec;
    Animator anim;

    void Start()
    {
        
    }

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        stick_hAxis = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        stick_vAxis = CrossPlatformInputManager.GetAxisRaw("Vertical");
        key_hAxis = Input.GetAxisRaw("Horizontal");
        key_vAxis = Input.GetAxisRaw("Vertical");
        shoot = Input.GetAxis("Fire2");
        is_top = GameObject.Find("Main Camera").GetComponent<BuildCamera>().isTopview;
        
        if (is_top)
            moveVec = Vector3.zero;
        else
            moveVec = stick_hAxis * Vector3.right + stick_vAxis * Vector3.forward + key_hAxis * Vector3.right + key_vAxis * Vector3.forward;

        transform.position += moveVec * speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);
        anim.SetBool("isMove", moveVec != Vector3.zero);

        if (CrossPlatformInputManager.GetButtonDown("Attack"))
            anim.SetBool("isAttack", true);
        else
            anim.SetBool("isAttack", false);

        if(shoot != 0)  
            anim.SetBool("isShoot", true);
        else
            anim.SetBool("isShoot", false);
    }
}
