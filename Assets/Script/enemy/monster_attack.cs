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
        /**earth_stop = GetComponentInParent<Monster_old>().earth_stop;
        if (earth_stop)
        {
            Attack_Check = false;
        }**/
        if (Attack_Check)
        {
            GetComponentInParent<Monster_old>().isAttack = true;
        }
        else
        {
            GetComponentInParent<Monster_old>().isAttack = false;
        }

        
    }

    private void OnTriggerEnter(Collider other)   // ���� ���� �������� �ȿ� Ÿ���� ������ ��� ������, ���� ������ ���� ���ľ���
    {
        if (other.transform.tag == "Player")  // Ÿ���� �������� �ȿ� �������� �̹� ����Ʈ�� �ִ��� üũ�ϰ� ����Ʈ�� ����
        {
            bool check_temp = true;
            foreach (Collider temp in attack_list)
            {
                if (other == temp)
                {
                    check_temp = false;
                    break;
                }
            }
            if (check_temp)
            {
                attack_list.Add(other);
                if (GetComponentInParent<Monster_old>().target == other)
                {
                    Attack_Check = true;
                    target = other;
                }
            }
            target_check();

        }
        if (other.transform.tag == "TowerAttack")
        {
            bool check_temp = true;
            foreach (Collider temp in attack_list)
            {
                if (other == temp)
                {
                    check_temp = false;
                    break;
                }
            }
            if (check_temp)
            {
                attack_list.Add(other);
                if (GetComponentInParent<Monster_old>().target == other)
                {
                    Attack_Check = true;
                    target = other;
                }
            }
            target_check();

        }
        if (other.transform.tag == "base")
        {
            bool check_temp = true;
            foreach (Collider temp in attack_list)
            {
                if (other == temp)
                {
                    check_temp = false;
                    break;
                }
            }
            if (check_temp)
            {
                attack_list.Add(other);
                if (GetComponentInParent<Monster_old>().target == other)
                {
                    Attack_Check = true;
                    target = other;
                }
            }
            target_check();

        }
        /**if (other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("TowerAttack")|| other.gameObject.CompareTag("base"))
        {
            if(GetComponentInParent<Monster_old>().target == other.transform)
            {
                target = other;
            }
        }**/

    }

    void target_check()
    {
        bool check_temp = false;
        foreach(Collider temp in attack_list)
        {
            foreach(Collider temp2 in GetComponentInParent<Monster_old>().target_list)
            {
                if(temp == temp2)
                {
                    check_temp = true;
                    break;
                }
            }
        }
        if (check_temp)
        {
            Attack_Check = true;
        }
        else
        {
            Attack_Check = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (Collider temp in attack_list)
        {
            if (other == temp)
            {
                attack_list.Remove(temp);
                if(other = target)
                {
                    Attack_Check = false;
                    target_check();
                }
                break;
            }
        }
        target_check();
        /**if (other == target)
        {
            target = null;
        }**/


    }
}
