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
            if (attack_type_range) // ���Ÿ� ����
            {
                if (isBoss)
                {
                    GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
                    temp.GetComponent<Monster_bullet>().monster = gameObject;
                    temp.GetComponent<Monster_bullet>().fire(transform.forward);
                    Debug.Log("���Ÿ� ���� ����");
                    attack = false;
                }
                else
                {
                    GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
                    temp.GetComponent<Monster_bullet>().monster = gameObject;
                    temp.GetComponent<Monster_bullet>().fire(transform.forward);
                    Debug.Log("���Ÿ� ���� ����");
                    attack = false;
                }
            }
        }
        else
        {
            delay = 0;
        }

        
    }


    private void OnTriggerStay(Collider other)   // ���� ���� ������ ���� �� ������ ����
    {
        
        if (attack)
        {
            if (isBoss)  // ���� �ٰŸ�
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
                                    Debug.Log("�÷��̾� ���� ��");
                                    GetComponentInParent<Monster_old>().AttackOn();
                                    attack = false;
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("TowerAttack"))
                                    {
                                        Debug.Log("Ÿ�� ���� ��");
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("base"))
                                    {
                                        Debug.Log("���̽� ���� ��");
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                            }
                        }


                    }
                }
            }
            else  // �Ϲݸ�
            {
                if(!attack_type_range) // �ٰŸ�
                {
                    if (delay > 0.3f)
                    {
                        if (GetComponentInParent<Monster_old>().target != null)
                        {
                            if (other.gameObject.CompareTag(GetComponentInParent<Monster_old>().target.gameObject.tag))
                            {
                                if (other.gameObject.CompareTag("Player"))
                                {
                                    Debug.Log("�÷��̾� ���� ��");
                                    GetComponentInParent<Monster_old>().AttackOn();
                                    attack = false;
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("TowerAttack"))
                                    {
                                        Debug.Log("Ÿ�� ���� ��");
                                        GetComponentInParent<Monster_old>().AttackOn();
                                        attack = false;
                                    }
                                }
                                if (delay > 0.3f)
                                {
                                    if (other.gameObject.CompareTag("base"))
                                    {
                                        Debug.Log("���̽� ���� ��");
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
