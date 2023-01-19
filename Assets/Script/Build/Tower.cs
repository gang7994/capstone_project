using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int      durability = 100;
    public int      attack_val = 10;
    public int      slot_num = 0;
    public int      level = 0;


    private List<GameObject> collEnemys = new List<GameObject>();
    SphereCollider attack_Collider;
    private float   attackRate = 0.5f;
    
    public float attackRange = 30.0f;

    
    void Start()
    {
        attack_Collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Level_Manager(level);
        attack_Collider.radius = attackRange;
    }
    public void Level_Manager(int level)
    {
        durability = 100 + 10 * level;
        attack_val = level;
        slot_num = (level / 10);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Monster")
        {
            collEnemys.Add(collision.gameObject);
            print("공격, 리스트 추가");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        foreach (GameObject go in collEnemys)
        {
            if (go == collision.gameObject)
            {
                collEnemys.Remove(go);
                print("충돌끝, 리스트 삭제");
                break;
            }
        }
    }
}
