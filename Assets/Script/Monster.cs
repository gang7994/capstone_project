using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public int maxHealth, curHealth;
    public Transform target;
    public bool isChase;

    Rigidbody rigid;
    CapsuleCollider capCollider;
    Material materi;
    NavMeshAgent navi;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        capCollider = GetComponent<CapsuleCollider>();
        materi = GetComponentInChildren<SkinnedMeshRenderer>().material;
        navi = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        Invoke("ChaseStart", 2);
    }
    void Update()
    {
        if (isChase)
            navi.SetDestination(target.position);
    }

    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        curHealth -= bullet.damage;
        Vector3 reactVec = transform.position - other.transform.position;
        Destroy(other.gameObject);
        StartCoroutine(OnDamage(reactVec));

        Debug.Log("Bullet Attack : " + curHealth);
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        materi.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            materi.color = Color.white;
            //더 보기 좋게 수정 필요
            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            rigid.AddForce(reactVec * 5, ForceMode.Impulse);
        }
        else
        {
            materi.color = Color.gray;
            anim.SetBool("isDeath", true);
            gameObject.layer = 10;
            Destroy(gameObject, 3);
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
        anim.SetBool("isWalk", true);
    }
}
