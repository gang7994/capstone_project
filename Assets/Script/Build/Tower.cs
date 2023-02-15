using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int      durability = 100;
    public int      attack_val = 10;
    public int      slot_num = 0;
    public int      level = 0;

    public int num_of_inchant;

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
        slot_num = (level / 10);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Monster")
        {
            collEnemys.Add(collision.gameObject);
            print("����, ����Ʈ �߰�");
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        foreach (GameObject go in collEnemys)
        {
            if (go == collision.gameObject)
            {
                collEnemys.Remove(go);
                print("�浹��, ����Ʈ ����");
                break;
            }
        }
    }
    
    public void AutoAttack(Transform firePos, List<GameObject> collEnemy){
        if (collEnemy.Count != 0){
            foreach (GameObject go in collEnemy){
                firePos.transform.LookAt(go.transform);
                Instantiate(Bullet, firePos.transform.position, firePos.transform.rotation);

            }
        }
        else{
            Debug.Log("몬스터 없음!");
        }
        
        if (Input.GetMouseButtonDown(0)){
            Instantiate(Bullet, firePos.transform.position, firePos.transform.rotation);
        }
    }
    

    void DestroyBullet(){
        Destroy(Bullet);
    }
}
