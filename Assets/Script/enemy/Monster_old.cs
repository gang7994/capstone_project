using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_old : MonoBehaviour
{
    public int maxHealth, curHealth;
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

    Rigidbody rigid;
    SphereCollider collider;
    Material materi;
    NavMeshAgent navi;
    public Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>();
        materi = GetComponentInChildren<SkinnedMeshRenderer>().material;
        navi = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        isAttack = false;
        Delay = 0;
        isAttackDelay = false;

        

        Invoke("ChaseStart", 2);
    }
    private void Start()
    {
        target = house.transform;
        navi.velocity = Vector3.zero;
        navi.stoppingDistance = 4f;
    }
    void Update()
    {
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
            if (!isAttackDelay)
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

    void OnTriggerEnter(Collider other){
        if (other.transform.tag == "Player")
        {
            target = other.transform;
            navi.velocity = Vector3.zero;
            navi.stoppingDistance = 2;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = other.transform;
            navi.stoppingDistance = 2;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            target = house.transform;
            navi.velocity = Vector3.zero;
            navi.stoppingDistance = 4f;
        }
    }

    public IEnumerator OnDamage(Vector3 reactVec)
    {
        materi.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if (curHealth > 1)
        {
            materi.color = Color.white;
            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            rigid.AddForce(reactVec * 5, ForceMode.Impulse);
            anim.SetBool("isDamage", false);
        }
        else
        {
            materi.color = Color.gray;
            anim.SetBool("isDie", true);
            anim.SetBool("isDamage", false);
            gameObject.layer = LayerMask.NameToLayer("MonsterDied");
            navi.isStopped = true;
            navi.velocity = Vector3.zero;
            isChase = false;
            Destroy(gameObject, 3);
            Debug.Log("몬스터 사망2");
        }
        
    }
    public void MonsterAttack()
    {
        anim.SetBool("isAttack", true);
        isAttackDelay = true;
        Attack_range.GetComponent<Attack_range>().attack = true;
        Debug.Log("몬스터 공격");
               
    }
    void AttackDelay()
    {
        anim.SetBool("isAttack", false);
        Attack_range.GetComponent<Attack_range>().attack = false;
        isAttackDelay = false;
    }

    public void AttackOn()
    {
        if (isChase)
        {
            target.GetComponent<Player>().Health -= damage;
            Debug.Log("데미지 10");
        }
        
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
