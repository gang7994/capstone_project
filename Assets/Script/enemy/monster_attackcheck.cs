using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_attackcheck : MonoBehaviour
{
    public bool base_attack;
    // Start is called before the first frame update
    void Start()
    {
        base_attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        base_attack = GetComponentInParent<Monster_old>().base_attack;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")  // 타겟이 감지범위 안에 들어왔을때 이미 리스트에 있는지 체크하고 리스트에 넣음
        {
            if (!base_attack)
            {
                if (GetComponentInParent<Monster_old>().isChase)
                {
                    /**if(GetComponentInParent<Monster_old>().target == null)
                    {
                        GetComponentInParent<Monster_old>().isAttack = false;
                    }**/
                    bool check_temp = true;
                    foreach (Collider temp in GetComponentInParent<Monster_old>().target_list)
                    {
                        if (other == temp)
                        {
                            check_temp = false;
                        }
                    }
                    if (check_temp)
                    {
                        GetComponentInParent<Monster_old>().target_list.Add(other);
                    }
                }
            }
            

        }
        if (other.transform.tag == "TowerAttack")
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                bool check_temp = true;
                foreach (Collider temp in GetComponentInParent<Monster_old>().target_list)
                {
                    if (other == temp)
                    {
                        check_temp = false;
                    }
                }
                if (check_temp)
                {
                    GetComponentInParent<Monster_old>().target_list.Add(other);
                }
            }

        }
        if (other.transform.tag == "FenceAttack")
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                bool check_temp = true;
                foreach (Collider temp in GetComponentInParent<Monster_old>().target_list)
                {
                    if (other == temp)
                    {
                        check_temp = false;
                    }
                }
                if (check_temp)
                {
                    GetComponentInParent<Monster_old>().target_list.Add(other);
                }
            }

        }
        /**if (other.transform.tag == "base")
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                bool check_temp = true;
                foreach (Collider temp in GetComponentInParent<Monster_old>().target_list)
                {
                    if (other == temp)
                    {
                        check_temp = false;
                    }
                }
                if (check_temp)
                {
                    GetComponentInParent<Monster_old>().target_list.Add(other);
                }
            }

        }**/


    }

    private void OnTriggerExit(Collider other)   // 탐지범위에서 벗어났을 때 리스트안에 있으면 리스트에서 제거
    {
        foreach (Collider temp in GetComponentInParent<Monster_old>().target_list)
        {
            if (other == temp)
            {
                GetComponentInParent<Monster_old>().target_list.Remove(temp);
                break;
            }
        }
        /**if (target != null)
        {
            if(other.gameObject == target.gameObject)
            {
                target = house.transform;
                navi.velocity = Vector3.zero;
                navi.stoppingDistance = 4f;
                target_check = false;
            }

        }**/

    }
}
