using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_range : MonoBehaviour
{
    // Start is called before the first frame update
    public bool attack;
    public float delay;
    bool isBoss;
    bool attack_type_range;
    public GameObject bullet;
    void Start()
    {
        attack = false;
        delay = 0;
        isBoss = GetComponentInParent<Monster_old>().isBoss;
        attack_type_range = GetComponentInParent<Monster_old>().Attack_Type_range;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            delay += Time.deltaTime;
            if (attack_type_range) // 원거리 공격
            {
                if (isBoss)
                {
                    GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
                    temp.GetComponent<Monster_bullet>().monster = gameObject;
                    temp.GetComponent<Monster_bullet>().fire(transform.forward);
                    Debug.Log("원거리 공격 생성");
                    attack = false;
                }
                else
                {
                    GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
                    temp.GetComponent<Monster_bullet>().monster = gameObject;
                    temp.GetComponent<Monster_bullet>().fire(transform.forward);
                    Debug.Log("원거리 공격 생성");
                    attack = false;
                }
            }
        }
        else
        {
            delay = 0;
        }

        
    }


    private void OnTriggerStay(Collider other)   // 적이 공격 범위에 있을 시 데미지 적용
    {
        
        if (attack)
        {
            if (isBoss)  // 보스 근거리
            {
                if (!attack_type_range) {
                    if (delay > 0.3f)
                    {
                        if (GetComponentInParent<Monster_old>().target != null)
                        {
                            if (other.gameObject.CompareTag(GetComponentInParent<Monster_old>().target.gameObject.tag))
                            {
                                if (other.gameObject.CompareTag("Player"))
                                {
                                    Debug.Log("플레이어 어택 됨");
                                    GetComponentInParent<Monster_old>().AttackOn();
                                    attack = false;
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("TowerAttack"))
                                    {
                                        Debug.Log("타워 어택 됨");
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("base"))
                                    {
                                        Debug.Log("베이스 어택 됨");
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                            }
                        }


                    }
                }
            }
            else  // 일반몹
            {
                if(!attack_type_range) // 근거리
                {
                    if (delay > 0.3f)
                    {
                        if (GetComponentInParent<Monster_old>().target != null)
                        {
                            if (other.gameObject.CompareTag(GetComponentInParent<Monster_old>().target.gameObject.tag))
                            {
                                if (other.gameObject.CompareTag("Player"))
                                {
                                    Debug.Log("플레이어 어택 됨");
                                    GetComponentInParent<Monster_old>().AttackOn();
                                    attack = false;
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("TowerAttack"))
                                    {
                                        Debug.Log("타워 어택 됨");
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("base"))
                                    {
                                        Debug.Log("베이스 어택 됨");
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                            }
                        }


                    }
                }
            }

        }
        
    }
}
