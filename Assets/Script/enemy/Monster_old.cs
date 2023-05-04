using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_old : MonoBehaviour
{
    public float maxHealth, curHealth;
    public int damage;
    public GameObject house;
    public GameObject Attack_range;
    public Transform target;
    public bool isChase;
    public bool isAttack;
    public float Delay;
    bool isAttackDelay;
    float RoSpeed = 5;
    public float attack_time;
    public bool target_check;
    Color meshColor;
    public List<Collider> target_list = new List<Collider>();

    Rigidbody rigid;
    CapsuleCollider collider;
    Material materi;
    public NavMeshAgent navi;
    public Animator anim;
    private GameManager gameManager;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        materi = GetComponentInChildren<SkinnedMeshRenderer>().material;
        navi = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        isAttack = false;
        Delay = 0;
        isAttackDelay = false;
        target_check = false;
        meshColor = materi.color;
        
        Invoke("ChaseStart", 2);
    }
    private void Start()
    {
        target = house.transform;
        navi.velocity = Vector3.zero;
        navi.stoppingDistance = 2f;
    }
    void Update()
    {
        if(target_list.Count == 0)
        {
            target = house.transform;
        }
        else
        {
            target = target_list[0].transform;
        }
        Delay += Time.deltaTime;
        if (isAttackDelay)
        {
            navi.isStopped = true;
        }
        else
        {
            navi.isStopped = false;
        }
        if (isAttack)
        {
            if (Delay > 2.0f)
            {
                MonsterAttack();
                Delay = 0;
                }
            else if (Delay > attack_time)
            {
                AttackDelay();
            }

        }
        else
        {
            if (Delay > attack_time)
            {
                AttackDelay();
            }
        }
        if (isChase){
            if (!isAttackDelay && target != null)
            {
                navi.SetDestination(target.position);
                anim.SetBool("isMove", true);
                if (Delay > 0.7f)
                {
                    Vector3 Pos = target.position - transform.position;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Pos), Time.deltaTime * RoSpeed);
                    /*transform.LookAt(target);*/
                }
            }
            
            
        }
        if (anim.GetBool("isDamage"))
        {
            navi.isStopped = true;
        }
        else
        {
            navi.isStopped = false;
        }

    }

    

    public IEnumerator OnDamage(Vector3 reactVec)
    {
        materi.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if (curHealth > 1)
        {
            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            rigid.AddForce(reactVec * 5, ForceMode.Impulse);
            anim.SetBool("isDamage", false);
            Debug.Log("damaged");
            materi.color = meshColor;
        }
        else
        {
            materi.color = Color.gray;
            anim.SetBool("isDie", true);
            anim.SetBool("isDamage", false);
            gameObject.layer = LayerMask.NameToLayer("MonsterDied");
            navi.isStopped = true;
            navi.velocity = Vector3.zero;
            navi.speed = 0;
            isChase = false;
            target = null;
            Destroy(gameObject, 3);
            StartCoroutine("Die");
            // Debug.Log("몬스터 사망2");
        }
        
    }
    public void MonsterAttack()
    {
        anim.SetBool("isAttack", true);
        navi.isStopped = true;
        navi.velocity = Vector3.zero;
        navi.speed = 0;
        isAttackDelay = true;
        Attack_range.GetComponent<Attack_range>().attack = true;
        // Debug.Log("몬스터 공격");
               
    }
    void AttackDelay()
    {
        if (isChase)
        {
            navi.isStopped = false;
            navi.speed = 1;
            anim.SetBool("isAttack", false);
            Attack_range.GetComponent<Attack_range>().attack = false;
            isAttackDelay = false;
        }
        
    }

    public void AttackOn()
    {
        if (isChase)
        {
            //target.GetComponent<Player>().Health -= damage;
            // Debug.Log("데미지 10");
        }
        
    }

    private IEnumerator Die()
    {
        gameManager.SendMessage("ChangeMonsterNumText", -1);
        yield break;
    }

    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }

    }
    /*
    void FixedUpdate()
    {
        FreezeVelocity();
    }
    */
    void ChaseStart()
    {
        isChase = true;
    }

    
}
