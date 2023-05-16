using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_range : MonoBehaviour
{
    // Start is called before the first frame update
    public bool attack;
    float delay;
    void Start()
    {
        attack = false;
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            delay += Time.deltaTime;
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
            if(delay > 0.3f)
            {
                if(GetComponentInParent<Monster_old>().target != null)
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
