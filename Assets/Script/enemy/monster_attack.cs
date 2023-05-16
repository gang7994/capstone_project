using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_attack : MonoBehaviour
{
    Animator anims;
    public GameObject Character;
    public bool Attack_Check;
    public List<Collider> attack_list = new List<Collider>();
    // Start is called before the first frame update
    public Collider target;
    public bool earth_stop;
    
    void Start()
    {
        anims = GetComponentInParent<Monster_old>().anim;
        Attack_Check = false;
        target = null;
        earth_stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        earth_stop = GetComponentInParent<Monster_old>().earth_stop;
        if (earth_stop)
        {
            Attack_Check = false;
        }
        else
        {
            if (GetComponentInParent<Monster_old>().target != null)
            {
                if (target != null)
                {
                    if (target.transform != GetComponentInParent<Monster_old>().target)
                    {
                        target = null;
                    }
                }

            }

            if (GetComponentInParent<Monster_old>().isChase)
            {
                if (target != null)
                {
                    GetComponentInParent<Monster_old>().isAttack = true;
                    Attack_Check = true;
                }
                else
                {
                    GetComponentInParent<Monster_old>().isAttack = false;
                    Attack_Check = false; ;
                }

            }
        }

        
    }

    private void OnTriggerEnter(Collider other)   // 몬스터 공격 사정범위 안에 타겟이 들어왔을 경우 공격함, 현재 문제가 있음 고쳐야함
    {
        if(other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("TowerAttack")|| other.gameObject.CompareTag("base"))
        {
            if(GetComponentInParent<Monster_old>().target == other.transform)
            {
                target = other;
            }
        }
        
        
        /**if (other.gameObject.tag == "Player")
        {
            if (GetComponentInParent<Monster_old>().target.gameObject.tag == "Player")
            {
                if (GetComponentInParent<Monster_old>().isChase)
                {
                    GetComponentInParent<Monster_old>().isAttack = true;
                    Attack_Check = true;
                }
                
            }
        }
        if (other.gameObject.tag == "TowerAttack")
        {
            if (GetComponentInParent<Monster_old>().target.gameObject.tag == "TowerAttack")
            {
                if (GetComponentInParent<Monster_old>().isChase)
                {
                    GetComponentInParent<Monster_old>().isAttack = true;
                    Attack_Check = true;
                }
            }
        }
        if (other.gameObject.tag == "base")
        {
            if (GetComponentInParent<Monster_old>().target.gameObject.tag == "base")
            {
                if (GetComponentInParent<Monster_old>().isChase)
                {
                    GetComponentInParent<Monster_old>().isAttack = true;
                    Attack_Check = true;
                }
            }
        }**/
    }

    /**private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GetComponentInParent<Monster_old>().target != null)
            {
                if (GetComponentInParent<Monster_old>().target.gameObject.tag == "Plyaer")
                {
                    if (GetComponentInParent<Monster_old>().isChase)
                    {
                        GetComponentInParent<Monster_old>().isAttack = true;
                        Attack_Check = true;
                    }
                }
            }
        }
        if(other.gameObject.tag == "TowerAttack")
        {
            if(GetComponentInParent<Monster_old>().target != null)
            {
                if (GetComponentInParent<Monster_old>().target.gameObject.tag == "TowerAttack")
                {
                    if (GetComponentInParent<Monster_old>().isChase)
                    {
                        GetComponentInParent<Monster_old>().isAttack = true;
                        Attack_Check = true;
                    }
                }
            }
            

        }
        if (other.gameObject.tag == "base")
        {
            if (GetComponentInParent<Monster_old>().target != null)
            {
                if (GetComponentInParent<Monster_old>().target.gameObject.tag == "base")
                {
                    if (GetComponentInParent<Monster_old>().isChase)
                    {
                        GetComponentInParent<Monster_old>().isAttack = true;
                        Attack_Check = true;
                    }
                }
            }


        }
    }**/

    private void OnTriggerExit(Collider other)
    {
        if(other == target)
        {
            target = null;
        }
        /**if (other.gameObject.tag == "Player")
        {
            if (GetComponentInParent<Monster_old>().target != null)
            {
                if (GetComponentInParent<Monster_old>().target.gameObject.tag == "Player")
                {
                    GetComponentInParent<Monster_old>().isAttack = false;
                    Attack_Check = false;
                }
            }
        }
        if (other.gameObject.tag == "TowerAttack")
        {
            if (GetComponentInParent<Monster_old>().target != null) {
                if (GetComponentInParent<Monster_old>().target.gameObject.tag == "TowerAttack")
                {

                    GetComponentInParent<Monster_old>().isAttack = false;
                    Attack_Check = false;
                }
            }
        }**/
        
    }
}
