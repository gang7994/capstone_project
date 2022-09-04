using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject bullet, rock;
    public Transform bulletPos;

    private bool is_top;
    bool isShootKeyInput, isAttackKetInput;
    bool isAttackReady;

    float stick_hAxis, stick_vAxis, key_hAxis, key_vAxis;
    float attackDelay;

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
        GetInput();
        Move();
        Attack();
    }
    
    void GetInput()
    {
        stick_hAxis = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        stick_vAxis = CrossPlatformInputManager.GetAxisRaw("Vertical");
        key_hAxis = Input.GetAxisRaw("Horizontal");
        key_vAxis = Input.GetAxisRaw("Vertical");
        isAttackKetInput = CrossPlatformInputManager.GetButtonDown("Attack");
        isShootKeyInput = Input.GetMouseButton(1);
        //is_top = GameObject.Find("Main Camera").GetComponent<BuildCamera>().isTopview;
    }

    void Move()
    {
        //if (is_top)
        //    moveVec = Vector3.zero;
        //else
        //{
            moveVec = stick_hAxis * Vector3.right + stick_vAxis * Vector3.forward + key_hAxis * Vector3.right + key_vAxis * Vector3.forward;
            moveVec = moveVec.normalized;
        //}

        transform.position += moveVec * speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);

        anim.SetBool("isMove", moveVec != Vector3.zero);
    }
    
    void Attack()
    {
        attackDelay += Time.deltaTime;
        isAttackReady = 0.5f < attackDelay;

        if (isShootKeyInput && isAttackReady)
        {
            GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Rigidbody bullletRigid = instantBullet.GetComponent<Rigidbody>();
            bullletRigid.velocity = bulletPos.forward * 1;
            attackDelay = 0;
            anim.SetBool("isShoot", isShootKeyInput);
        }
        else if (isAttackKetInput && isAttackReady)
        {
            anim.SetBool("isAttack", isAttackKetInput);
            GameObject instantRock = Instantiate(rock, bulletPos.position, bulletPos.rotation);
            Rigidbody rockRigid = instantRock.GetComponent<Rigidbody>();
            rockRigid.velocity = bulletPos.forward * 0.05f;
            attackDelay = 0;
        }
        else
        {
            anim.SetBool("isShoot", false);
            anim.SetBool("isAttack", false);
        }
    }
}
