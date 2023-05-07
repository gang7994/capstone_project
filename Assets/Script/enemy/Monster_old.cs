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
    public GameObject coinPrefab;
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
        damage = 10;
    }
    void Update()
    {
        if(target_list.Count == 0)  //주변에 타겟이 없으면 베이스를 타겟으로함, 타겟이 여럿일 경우 가장 처음에 접촉한 타겟을 목표로 함
        {
            target = house.transform;
        }
        else
        {
            target = target_list[0].transform;
        }
        Delay += Time.deltaTime;
        if (isAttack)  // 공격중일때 멈추기
        {
            navi.isStopped = true;
            navi.velocity = Vector3.zero;
            
        }
        else
        {
            navi.isStopped = false;
        }
        if (isAttack)  // 공격주기  Delay 시간이 몬스터 공격 속도, attackTime은 한 공격에 걸리는 시간
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
        if (isChase){  // 공격중이 아니고 타겟이 있을때 타겟을 따라감, 밑에 if문은 공격후 타겟을 자연스럽게 바라보게 함
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
        if (anim.GetBool("isDamage"))   // 데미지 입을 시 멈춤, 지금은 사용X
        {
            navi.isStopped = true;
        }
        else
        {
            navi.isStopped = false;
        }

    }

    

    public IEnumerator OnDamage(Vector3 reactVec)   //몬스터 데미지 입음
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
            /*
            coinPrefab = GameObject.Find("CoinGold");
            GameObject instance = Instantiate(coinPrefab);
            Vector3 pos = this.gameObject.transform.position;
            instance.transform.position = pos;
            */

            // Debug.Log("몬스터 사망2");
        }
        
    }
    public void MonsterAttack()   // 몬스터 사정거리 안에 적이 있을 시 공격 쿨타임마다 실행됨
    {
        anim.SetBool("isAttack", true);
        navi.isStopped = true;
        navi.velocity = Vector3.zero;
        navi.speed = 0;
        isAttackDelay = true;
        Attack_range.GetComponent<Attack_range>().attack = true;
        // Debug.Log("몬스터 공격");
               
    }
    void AttackDelay()   // 공격중이 아닐때
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

    public void AttackOn()   // 몬스터의 공격에 피해를 입히는 부분
    {
        Debug.Log("공격성공");
        if (isChase)
        {
            if (target.gameObject.CompareTag("Player"))
            {
                target.GetComponent<Player>().Health -= damage;
                Debug.Log("캐릭터 데미지 10");
            }else if(target.gameObject.CompareTag("TowerAttack"))
            {
                target.GetComponentInParent<Tower>().hp -= damage;
                Debug.Log("타워 데미지 10");
            }
            else if(target.gameObject.CompareTag("base"))
            {
                target.GetComponent<Base>().hp -= damage;
                Debug.Log("베이스 데미지 10");
            }
            
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
