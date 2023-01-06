using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    bool isAttackKetInput;
    public bool isAttackReady, attack_time, check;
    public GameObject sword, gun,shotgun;
    public bool isSword, isGun, isShotgun;
    public GameObject bullet;
    public GameObject sw_btn, g_btn, sg_btn;

    float stick_hAxis, stick_vAxis, key_hAxis, key_vAxis;
    float attackDelay;

    Vector3 moveVec;
    Animator anim;

    void Start()
    {
        isSword = true;
        isGun = false;
        isShotgun = false;
        anim.SetBool("isSword", true);
        anim.SetBool("isGun", false);
        anim.SetBool("isShotgun", false);
        sword.SetActive(true);
        gun.SetActive(false);
        attackDelay = 1.0f;
    }

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackDelay += Time.deltaTime;
        if (isSword)
        {
            isAttackReady = 0.5f < attackDelay;
            attack_time = 0.7f < attackDelay;
        }else if (isGun)
        {
            isAttackReady = 0.5f < attackDelay;
            attack_time = 0.7f < attackDelay;
        }
        else
        {
            isAttackReady = 1f < attackDelay;
            attack_time = 1.2f < attackDelay;
        }
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

        //is_top = GameObject.Find("Main Camera").GetComponent<BuildCamera>().isTopview;
    }

    void Move()
    {
        //if (is_top)
        //    moveVec = Vector3.zero;
        //else
        //{
            
        //}
        if (attack_time){
            transform.position += moveVec * speed * Time.deltaTime;
            transform.LookAt(transform.position + moveVec);
            moveVec = stick_hAxis * Vector3.right + stick_vAxis * Vector3.forward + key_hAxis * Vector3.right + key_vAxis * Vector3.forward;
            moveVec = moveVec.normalized;

            anim.SetBool("isMove", moveVec != Vector3.zero);
        }
        
    }
    
    void Attack()
    {
        
        if (isSword)
        {
            if (isAttackKetInput && isAttackReady && attack_time)
            {
                attackDelay = 0;
                anim.SetBool("isAttack", true);
                anim.SetBool("timeout", false);    
            }else if(attack_time){
                anim.SetBool("timeout", true);
            }
            else if (isAttackReady)
            {
                anim.SetBool("isAttack", false);
            }
        }
        else if(isGun)
        {
            if (isAttackKetInput && isAttackReady && attack_time)
            {
                attackDelay = 0;
                anim.SetBool("isShoot", true);
                anim.SetBool("timeout", false);
                GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
                temp.GetComponent<Bullet>().fire(transform.forward,true);
                
            }
            else if (attack_time)
            {
                anim.SetBool("timeout", true);
            }
            else if (isAttackReady)
            {
                anim.SetBool("isShoot", false);
            }
        }
        else if(isShotgun)
        {
            if (isAttackKetInput && isAttackReady && attack_time)
            {
                anim.SetBool("isShot", true);
                anim.SetBool("timeout", false);
                attackDelay = 0;
                Invoke("shotgunShoot", 0.3f);
            }
            else if (attack_time)
            {
                anim.SetBool("timeout", true);
            }
            else if (isAttackReady)
            {
                anim.SetBool("isShot", false);
            }
        }


    }
    void shotgunShoot() {
        GameObject temp1 = Instantiate(bullet, transform.position, Quaternion.identity);
        GameObject temp2 = Instantiate(bullet, transform.position, Quaternion.Euler(0, -10f, 0));
        GameObject temp3 = Instantiate(bullet, transform.position, Quaternion.Euler(0, 10f, 0));
        temp1.GetComponent<Bullet>().fire(transform.forward, false);
        temp2.GetComponent<Bullet>().fire(transform.forward, false);
        temp3.GetComponent<Bullet>().fire(transform.forward, false);
    }

    public void changeSword()
    {
        if (!isSword && attack_time)
        {
            isSword = true;
            isGun = false;
            isShotgun = false;
            anim.SetBool("isSword", true);
            anim.SetBool("isGun", false);
            anim.SetBool("isShotgun", false);
            sword.SetActive(true);
            gun.SetActive(false);
            shotgun.SetActive(false);
            sw_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -400, 0);
            g_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, -450, 0);
            sg_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -450, 0);
            sw_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            g_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            sg_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
    }
    public void changeGun()
    {
        if (!isGun && attack_time)
        {
            isSword = false;
            isGun = true;
            isShotgun = false;
            anim.SetBool("isSword", false);
            anim.SetBool("isGun", true);
            anim.SetBool("isShotgun", false);
            sword.SetActive(false);
            gun.SetActive(true);
            shotgun.SetActive(false);
            g_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -400, 0);
            sg_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, -450, 0);
            sw_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -450, 0);
            g_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            sg_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            sw_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
    }
    public void changeShotgun()
    {
        if (!isShotgun && attack_time)
        {
            isSword = false;
            isGun = false;
            isShotgun = true;
            anim.SetBool("isSword", false);
            anim.SetBool("isGun", false);
            anim.SetBool("isShotgun", true);
            sword.SetActive(false);
            gun.SetActive(false);
            shotgun.SetActive(true);
            sg_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -400, 0);
            sw_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, -450, 0);
            g_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -450, 0);
            sg_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            sw_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            g_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
    }
}
