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


    private void OnTriggerStay(Collider other)   // 적이 게속 사정거리 안에 있으면 주기적으로 공격이 실행됨. 
    {
        
        if (attack)
        {
            if(delay > 0.3f)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log("어택 됨");
                    GetComponentInParent<Monster_old>().AttackOn();
                    attack = false;
                }
            }
            if (delay > 0.3f)
            {
                if (other.gameObject.CompareTag("TowerAttack"))
                {
                    Debug.Log("어택 됨");
                    GetComponentInParent<Monster_old>().AttackOn();
                    attack = false;
                }
            }
            if (delay > 0.3f)
            {
                if (other.gameObject.CompareTag("base"))
                {
                    Debug.Log("어택 됨");
                    GetComponentInParent<Monster_old>().AttackOn();
                    attack = false;
                }
            }
        }
        
    }
}
