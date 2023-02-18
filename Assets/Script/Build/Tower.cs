using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int      durability = 100;
    public int      attack_val = 10;
    public int      slot_num = 0;
    public int      level = 0;

    public int[] types = new int[5];

    public int select_number;


    public GameObject Bullet;

    public Transform FirePos;

    public Material[] ranShoot = new Material[5];

    private List<GameObject> collEnemys = new List<GameObject>();
    SphereCollider attack_Collider;
    public float coolTime = 0.5f;
    
    public float attackRange = 30.0f;

    float timer;


    
    void Start()
    { 
        types[0] = 0;
        types[1] = 0;
        types[2] = 0;
        types[3] = 0;
        types[4] = 0;
        attack_Collider = GetComponent<SphereCollider>();
        timer = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        Level_Manager(level);
        attack_Collider.radius = attackRange;
        timer += Time.deltaTime;
        if(timer > coolTime){
            AutoAttack(FirePos,collEnemys);
            timer = 0.0f;
        }
            
    }
    public void Level_Manager(int level)
    {
        durability = 100 + 10 * level;
        attack_val = level;
        slot_num = (level / 5);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Monster")
        {
            collEnemys.Add(collision.gameObject);
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        foreach (GameObject go in collEnemys)
        {
            if (go == collision.gameObject)
            {
                collEnemys.Remove(go);
                break;
            }
        }
    }
    
    public void AutoAttack(Transform firePos, List<GameObject> collEnemy){
        if (collEnemy.Count != 0){
            foreach (GameObject go in collEnemy){
                firePos.transform.LookAt(go.transform);
                int type = types[Random.Range(0,5)];
                Bullet.GetComponent<TrailRenderer>().material = ranShoot[type];
                Instantiate(Bullet, firePos.transform.position, firePos.transform.rotation);

            }
        }
        
        
        if (Input.GetMouseButtonDown(0)){
            Instantiate(Bullet, firePos.transform.position, firePos.transform.rotation);
        }
    }
    

    void DestroyBullet(){
        Destroy(Bullet);
    }

    
    

    
}
