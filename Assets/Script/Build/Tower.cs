using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tower : MonoBehaviour
{
    public float    basic_max_hp = 100.0f;
    public float    max_hp = 100.0f;
    public float    hp = 100f;
    public float    basic_attack_val = 10.0f;
                                                                    public float   Q0f;
    public float    defence_val = 0;
    public float    basic_coolTime = 0.5f;  
    public float    coolTime = 0;

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
    public int poolSize = 50;
    public Queue<GameObject> bulletPool;

    public Transform FirePos;

    public Material[] ranShoot = new Material[7];

    private List<GameObject> collEnemys = new List<GameObject>();
    SphereCollider attack_Collider;
    
    
    public float attackRange = 30.0f;

    float timer;

    
    int damageNum = 0; //Function 1 value
    int speedNum = 0; //Function 3 value
    int armourNum = 0; //Function 5 value
    int maxHpNum = 0; //Function 7 value
    int fireCriticalNum = 0; //Function 8 value
    int lightningCriticalNum = 0; //Function 9 value

    

    bool isFunction1 = false;
    bool isFunction3 = false;
    bool isFunction5 = false;
    bool isFunction7 = false;
    bool isFunction11 = false;


    
    public static List<string> property_memory = new List<string>();
    public List<bool> property_memory_run = new List<bool>(); 

    public List<Action> all_function = new List<Action>();

    
    void Start()
    { 
        bulletPool = new Queue<GameObject>();
        InitalizePool(poolSize);
        

        types[0] = 0;
        types[1] = 0;
        types[2] = 0;
        types[3] = 0;
        types[4] = 0;   
        attack_Collider = GetComponent<SphereCollider>();
        timer = 0.0f;

        for(int i = 0; i < 80;i++) property_memory_run.Add(false);
        //Tier 1
        all_function.Add(Fire_Tower_Weight); //Function 0
        all_function.Add(Fire_Tower_Damage); //Function 1
        all_function.Add(Lightning_Tower_Weight); //Funciotn 2
        all_function.Add(Lightning_Tower_AtkSpeed); //Function 3
        all_function.Add(Ice_Tower_Weight); //Function 4
        all_function.Add(Ice_Tower_Armour); // Function 5
        all_function.Add(Earth_Tower_Weight); // Function 6
        all_function.Add(Earth_Tower_MaxHp);//Functon 7

        //all_function.Add(Fire_Send_Duration); //Function 178
        //all_function.Add(Fire_Send_Damage); //Function 2
        //all_function.Add(Lightning_Send_Duration); //Function 5
        //all_function.Add(Lightning_Send_Damage); //Function 6
        //all_function.Add(Ice_Send_Duration); // Function 9
        //all_function.Add(Ice_Send_Exhaust); // Function 10
        //all_function.Add(Earth_Send_Duration);// Function 13
        //all_function.Add(Earth_Tower_Heal); //Function 14
        

        //Tier 2
        all_function.Add(Fire_Tower_Critical); // Function 8
        all_function.Add(Lightning_Tower_Critical); // Function 9
        all_function.Add(TestPrint); // Function 10
        all_function.Add(TestPrint); // Function 11

        
        //Tier 3
        all_function.Add(TestPrint); // Function 12
        all_function.Add(TestPrint); // Function 13
        all_function.Add(TestPrint); // Function 14
        all_function.Add(TestPrint); // Function 15
    }

    void Update()
    {
        Level_Manager(level);

        
        attack_Collider.radius = attackRange;
        timer += Time.deltaTime;
        
        if(timer > coolTime){
            AutoAttack(FirePos, collEnemys);
            timer = 0.0f;
        }
        check_tower();  
        Apply_Characteristic();

        
        
        string numbersString = string.Join(", ", property_memory_run);
        Debug.Log(numbersString);
    }

    public void InitalizePool(int poolSize) {
        
        for(int i = 0; i < poolSize; i++){
            GameObject bullet = Instantiate(Bullet);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public void ReturnObject(GameObject bullet){
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    public void Level_Manager(int level)
    {
        //max_hp = 100 + 10 * level;
        //attack_val = level;
        slot_num = (level / 5);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "MonsterAttack")
        {
            collEnemys.Add(collision.transform.parent.gameObject);
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

                if(isFunction1) {
                    attack_val = basic_attack_val + (basic_attack_val/10)*fire_type_num;
                }

                if(isFunction3) {
                    coolTime = basic_coolTime - (basic_coolTime/10)*lightning_type_num;
                }

                if(isFunction5) {
                    defence_val = basic_defence_val + (basic_defence_val/10)*ice_type_num;
                }
                
                if(isFunction7) {
                    max_hp = basic_max_hp + (basic_attack_val/10)*earth_type_num;
                }
                int type_num = Random_type_attack();

                if (bulletPool.Count == 0)
                {
                    GameObject bulletObj = Instantiate(Bullet);
                    bulletObj.SetActive(false);
                    bulletPool.Enqueue(bulletObj);
                }
                GameObject bullet = bulletPool.Dequeue();
                bullet.transform.position = firePos.transform.position;
                bullet.transform.rotation = firePos.transform.rotation;
                bullet.SetActive(true);
                TowerShoot towerShoot = bullet.GetComponent<TowerShoot>(); 
                
                if(type_num == 0) {
                    towerShoot.property_type = "None";
                }
                else if(type_num == 1) {
                    towerShoot.property_type = "F";
                    //리스트 5개 해서 하나 나오면 [1,0,0,0,0]
                    List<int> fireCritical = new List<int> {0,0,0,0,0};
                    for(int i=0; i<fireCriticalNum;i++) fireCritical[i] = 1;
                    if(fireCritical[UnityEngine.Random.Range(0,5)]==1) {
                        type_num = 5;
                        towerShoot.towerAtk = attack_val*2;
                        print("화염치명타");

                    }
                    else{  
                        towerShoot.towerAtk = attack_val;
                    }
                    towerShoot.property_exhaust = towerShoot.fire_exhaust;
                }
                else if(type_num == 2) {
                    towerShoot.property_type = "L";
                    //리스트 5개 해서 하나 나오면 [1,0,0,0,0]
                    List<int> lightningCritical = new List<int> {0,0,0,0,0};
                    for(int i=0; i<lightningCriticalNum;i++) lightningCritical[i] = 1;
                    if(lightningCritical[UnityEngine.Random.Range(0,5)]==1) {
                        type_num = 6;
                        towerShoot.towerAtk = attack_val*2;
                        print("전기치명타");


                    }
                    else{  
                        towerShoot.towerAtk = attack_val;
                    }

                    towerShoot.property_exhaust = towerShoot.lightning_exhaust;
                }
                else if(type_num == 3) {
                    towerShoot.property_type = "I";
                    towerShoot.towerAtk = attack_val;
  

                }
                else if(type_num == 4){
                    towerShoot.property_type = "E";
                    towerShoot.towerAtk = attack_val;
                }

                bullet.GetComponent<TrailRenderer>().material = ranShoot[type_num];
                
                towerShoot.target = go; 
            }
        }
    }

    public void Apply_Characteristic(){
        for(int i = 0; i<property_memory.Count;i++){
            if(!property_memory_run[i]) {
                all_function[int.Parse(property_memory[i].Substring(3,1))]();
                property_memory_run[i] = true;
            }
        }
        
    }
    
    public void TestPrint(){
        print("zzz");
    }
    
    
    int Random_type_attack() {
        
        if(fire_type_num != 0) fire_type_num += fire_weight;
        if(lightning_type_num != 0) lightning_type_num += lightning_weight;
        if(ice_type_num != 0) ice_type_num += ice_weight;
        if(earth_type_num != 0) earth_type_num += earth_weight;
        float[] weights = {empty_type_num, fire_type_num, lightning_type_num, ice_type_num, earth_type_num};
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
    
    // Skill Function
    //Tier. 1
    public void Fire_Tower_Weight() { //Function 0
        fire_weight += 0.5f;
    }
    public void Fire_Tower_Damage(){  //Function 1
        isFunction1 = true;
        damageNum += 1;
    }
    public void Lightning_Tower_Weight() { //Function 2
        lightning_weight += 0.5f;
    }
    public void Lightning_Tower_AtkSpeed(){  //Function 3
        isFunction3 = true;
        speedNum += 1;
    }
    public void Ice_Tower_Weight() { //Function 4
        ice_weight += 0.5f;
    }   
    public void Ice_Tower_Armour(){  //Function 5
        isFunction5 = true;
        armourNum += 1;
    }
    public void Earth_Tower_Weight() { //Function 6
        earth_weight += 0.5f;
    }

    public void Earth_Tower_MaxHp(){ //Function 7
        isFunction7 = true;
        maxHpNum += 1;
    } 

    //Tier. 2
    public void Fire_Tower_Critical(){ //Function 8
        fireCriticalNum+=1;
    }

    public void Lightning_Tower_Critical(){ //Function 9
        lightningCriticalNum+=1;
    }



    public void Earth_Tower_Reflex(){ //Function 11
        isFunction11 = true;
    }

    /*
        public void Fire_Send_Duration(){  //Function 1
        TowerShoot towerShoot = Bullet.GetComponent<TowerShoot>(); 
        towerShoot.fire_duration += 1.0f;
    }

     public void Fire_Send_Damage(){  //Function 2
        TowerShoot towerShoot = Bullet.GetComponent<TowerShoot>(); 
        towerShoot.fireAtk += 1.0f;
    }
    public void Lightning_Send_Duration(){ //Function 5
        TowerShoot towerShoot = Bullet.GetComponent<TowerShoot>(); 
        towerShoot.lightning_duration += 1.0f;
    }

    public void Lightning_Send_Damage(){ //Function 6
        TowerShoot towerShoot = Bullet.GetComponent<TowerShoot>(); 
        towerShoot.lightningAtk += 1.0f;
    }

    public void Ice_Send_Duration(){ //Function 9
        TowerShoot towerShoot = Bullet.GetComponent<TowerShoot>(); 
        towerShoot.ice_duration += 1.0f;
    }
    public void Ice_Send_Exhaust(){ //Function 10
        TowerShoot towerShoot = Bullet.GetComponent<TowerShoot>(); 
        towerShoot.ice_exhaust += 1.0f;
    }
    public void Earth_Send_Duration(){ //Function 13
        TowerShoot towerShoot = Bullet.GetComponent<TowerShoot>(); 
        towerShoot.earth_duration += 1.0f;
    }
    public void Earth_Tower_Heal() { //Function 14
        isFunction14 = true;
        healNum += 1;
    }
    */
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