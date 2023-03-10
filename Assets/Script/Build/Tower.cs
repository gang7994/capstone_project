using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tower : MonoBehaviour
{
    public float    max_hp = 100.0f;
    public float    hp = 100f;
    public float    attack_val = 10.0f;
    public float    defence_val = 0.0f;

    public int      slot_num = 0;
    public int      level = 0;

    public List<int> types = new List<int>();
    public float empty_type_num;
    public float fire_type_num;
    public float lightning_type_num;
    public float ice_type_num;
    public float earth_type_num;
    public float fire_weight = 0; 
    public float lightning_weight = 0;
    public float ice_weight = 0;
    public float earth_weight = 0;

    public int select_number;


    public GameObject Bullet;

    public Transform FirePos;

    public Material[] ranShoot = new Material[5];

    private List<GameObject> collEnemys = new List<GameObject>();
    SphereCollider attack_Collider;
    public float coolTime = 0.5f;
    
    public float attackRange = 30.0f;

    float timer;

    
    public static List<int> property_memory = new List<int>();
    public List<bool> property_memory_run = new List<bool>(); 

    
    public List<string> all_property = new List<string> {"1F0","1F1","1F2","1F3",
                                                    "1L0","1L1","1L2","1L3",
                                                    "1I0","1I1","1I2","1I3",
                                                    "1E0","1E1","1E2","1E3",
                                                    "2F0","2F1","2F2",
                                                    "2L0","2L1","2L2",
                                                    "2I0","2I1","2I2",
                                                    "2E0","2E1","2E2",
                                                    "3F0","3F1", "3L0","3L1", "3I0","3I1", "3E0","3E1"};
    public List<Action> all_function = new List<Action>();

    
    void Start()
    { 
        types[0] = 0;
        types[1] = 0;
        types[2] = 0;
        types[3] = 0;
        types[4] = 0;   
        attack_Collider = GetComponent<SphereCollider>();
        timer = 0.0f;

        for(int i = 0; i < 80;i++) property_memory_run.Add(false);
        all_function.Add(Fire_Tower_Weight); //Function 0
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(Lightning_Tower_Weight); //Funciotn 4 
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(Ice_Tower_Weight); //Function 8
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(Earth_Tower_Weight); // Function 12
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        all_function.Add(TestPrint);
        
    }

    void Update()
    {
        Level_Manager(level);

        
        attack_Collider.radius = attackRange;
        timer += Time.deltaTime;
        if(timer > coolTime){
            AutoAttack(FirePos,collEnemys);
            timer = 0.0f;
        }
        check_tower();
        Apply_Characteristic();
        
        //string numbersString = string.Join(", ", property_memory_run);
        //Debug.Log(numbersString);
    }

    public void Level_Manager(int level)
    {
        //max_hp = 100 + 10 * level;
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
                empty_type_num = (float)types.FindAll(n => n == 0).Count;
                fire_type_num = (float)types.FindAll(n => n == 1).Count;
                lightning_type_num = (float)types.FindAll(n => n == 2).Count;
                ice_type_num = (float)types.FindAll(n => n == 3).Count;
                earth_type_num = (float)types.FindAll(n => n == 4).Count;
                Bullet.GetComponent<TrailRenderer>().material = ranShoot[Random_type_attack()];
                GameObject bullet = Instantiate(Bullet, firePos.transform.position, firePos.transform.rotation);
                TowerShoot towerShoot = bullet.GetComponent<TowerShoot>(); 
                towerShoot.target = go; 
            }
        }
    }

    public void Apply_Characteristic(){
       /* 
        for(int i = 0; i<property_memory.Count;i++){
            string tmp = property_memory[i];
            print(tmp);
            int index = all_property.IndexOf(tmp);
            print("index"+index);
            //all_function[index]();
        }
        */
        for(int i = 0; i<property_memory.Count;i++){
            if(!property_memory_run[i]) {
                all_function[property_memory[i]]();
                property_memory_run[i] = true;
            }
        }
    }
    
    public void TestPrint(){
        print("zzz");
    }
    
    
    int Random_type_attack() {
        
        if(fire_type_num != 0) fire_type_num += fire_weight;
        print("fire"+fire_type_num);
        if(lightning_type_num != 0) lightning_type_num += lightning_weight;
        if(ice_type_num != 0) ice_type_num += ice_weight;
        if(earth_type_num != 0) earth_type_num += earth_weight;
        float[] weights = {empty_type_num, fire_type_num, lightning_type_num, ice_type_num, earth_type_num};
        print(fire_type_num+" "+  lightning_type_num+" "+ice_type_num+" "+earth_type_num);
        float total_weight = 0;
        for(int i = 0; i<weights.Length; i++) {
            total_weight += weights[i];
        }
        int pivot = Mathf.RoundToInt(total_weight* UnityEngine.Random.Range(0f,1f));
        float weight = 0f;

        for(int i = 0; i < weights.Length;i++){
            weight += weights[i];
            if(pivot <= weight) {
                return i;
            }
        }
        return 0;

    }

    void DestroyBullet(){
        Destroy(Bullet);
    }

    public void check_tower(){
        GameObject warning = transform.Find("SmokeBright").gameObject;
        GameObject danger1 = transform.Find("SmokeDark").gameObject;
        GameObject danger2 = transform.Find("RedFire").gameObject;

        if(hp > max_hp/2){
            warning.SetActive(false);
            danger1.SetActive(false);
            danger2.SetActive(false);
        }
        else if(hp <= max_hp/2 && hp > max_hp/4){
            warning.SetActive(true);
            danger1.SetActive(false);
            danger2.SetActive(false);
        }
        else{
            warning.SetActive(false);
            danger1.SetActive(true);
            danger2.SetActive(true);
        }
    }

    public void Fire_Tower_Weight() { //Function 0
        fire_weight += 0.5f;
    }

    public void Lightning_Tower_Weight() { //Function 4
        lightning_weight += 0.5f;
    }

    public void Ice_Tower_Weight() { //Function 8
        ice_weight += 0.5f;
    }   

    public void Earth_Tower_Weight() { //Function 12
        earth_weight += 0.5f;
    }

}

public class Fire : MonoBehaviour {
    public float damage =  10.0f;
    public float duration = 1.0f;
}

public class Lightning : MonoBehaviour {
    public float damage = 10.0f;
    public float duration = 1.0f;
}

public class Earth : MonoBehaviour {
    public float duration = 1.0f;

}

public class Ice : MonoBehaviour {
    public float duration = 1.0f;

}