using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{   public int maxHealth, curHealth;
    public int damage;

    public Transform player;
    public Transform home;

    Rigidbody rigid;
    Collider collider;
    Material material;
    NavMeshAgent navi;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        navi = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void chase()
    {
        bool isPlayerChase = true;
        if (isPlayerChase)
        {
            //�÷��̾ ����
        }
        else {
            //���� ���� �̵�
        }

    }

    void closeAttack()
    {

    }

    void farAttack()
    {

    }

    void die()
    {

    }

}
