using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_old : MonoBehaviour
{
    public int maxHealth, curHealth;
    public int damage;

    public Transform target;
    public bool isChase;

    Rigidbody rigid;
    SphereCollider collider;
    Material materi;
    NavMeshAgent navi;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>();
        materi = GetComponentInChildren<SkinnedMeshRenderer>().material;
        navi = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        Invoke("ChaseStart", 2);
    }
    void Update()
    {
        if (isChase){
            navi.SetDestination(target.position);
            anim.SetBool("isMove", true);
        }
        /*
        if(curHealth < 1)
        {
            Debug.Log("몬스터 사망1");
            Destroy(gameObject);
        }*/
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")){
            Vector3 reactVec = transform.position;
            anim.SetBool("isDamage", true);
            StartCoroutine(OnDamage(reactVec));
        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
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
            isChase = false;
            Destroy(gameObject, 3);
            Debug.Log("몬스터 사망2");
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
