using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_attackcheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
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


    }

    private void OnTriggerExit(Collider other)
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
