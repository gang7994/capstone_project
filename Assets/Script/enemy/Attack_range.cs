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
    GameObject monster_bullet;
    float bullet_delay;
    void Start()
    {
        attack = false;
        delay = 0;
        isBoss = GetComponentInParent<Monster_old>().isBoss;
        attack_type_range = GetComponentInParent<Monster_old>().Attack_Type_range;
        if (attack_type_range)
        {
            monster_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            monster_bullet.SetActive(false);
            bullet_delay = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attack_type_range)
        {
            if (bullet_delay > 2)
            {
                monster_bullet.SetActive(false);
            }
            bullet_delay += Time.deltaTime;
        }
        
        if (attack)
        {
            delay += Time.deltaTime;
            if (attack_type_range) // 원거리 공격
            {
                if (isBoss)
                {
                    bullet_delay = 0;
                    monster_bullet.SetActive(true);
                    monster_bullet.transform.position = transform.position;
                    monster_bullet.GetComponent<Monster_bullet>().monster = gameObject;
                    monster_bullet.GetComponent<Monster_bullet>().fire(transform.forward);
                    attack = false;
                }
                else
                {
                    bullet_delay = 0;
                    monster_bullet.SetActive(true);
                    monster_bullet.transform.position = transform.position;
                    monster_bullet.GetComponent<Monster_bullet>().monster = gameObject;
                    monster_bullet.GetComponent<Monster_bullet>().fire(transform.forward);
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
                                    GetComponentInParent<Monster_old>().AttackOn();
                                    attack = false;
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("TowerAttack"))
                                    {
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("FenceAttack"))
                                    {
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("base"))
                                    {
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
                                    GetComponentInParent<Monster_old>().AttackOn();
                                    attack = false;
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("TowerAttack"))
                                    {
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("FenceAttack"))
                                    {
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("base"))
                                    {
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
