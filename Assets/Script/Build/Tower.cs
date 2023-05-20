using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tower : MonoBehaviour
{
    public int      select_number;
    public float    basic_max_hp = 100.0f;
    public float    max_hp = 100.0f;
    public float    hp = 100f;
    public float    basic_attack_val = 3.0f;
    public float    attack_val = 0;
    public float    basic_defence_val = 10.0f;
    public float    defence_val = 0;
    public float    basic_coolTime = 0.5f;  
    public float    coolTime = 0;

    public int      slot_num = 0;
    public int      level = 0;

    public GameObject Bullet;
    public int poolSize = 50;
    public Queue<GameObject> bulletPool;

    public Transform FirePos;

    public Material[] ranShoot = new Material[7];
    public AudioSource[] shootSound;
    public Material[] frozen_tower = new Material[3];

    public Material[] tower_base = new Material[3];
    public List<int> types = new List<int>();

    private List<GameObject> collEnemys = new List<GameObject>();
    private List<GameObject> allEnemys = new List<GameObject>();
    SphereCollider attack_Collider;
    
    public float empty_type_num;
    public float fire_type_num;
    public float lightning_type_num;
    public float ice_type_num;
    public float earth_type_num;

    public bool frozen = false;
    
    GameObject earthEffect;
    GameObject lightningEffect;
    float timer;

    void Start()
    { 
        bulletPool = new Queue<GameObject>();
        earthEffect = transform.Find("GreenShockwaveMissilev2").gameObject;
        earthEffect.SetActive(false);
        lightningEffect = transform.Find("YellowShockwaveMissilev2").gameObject;
        lightningEffect.SetActive(false);
        InitalizePool(poolSize);
        types[0] = 0;
        types[1] = 0;
        types[2] = 0;
        types[3] = 0;
        types[4] = 0;   
        attack_Collider = GetComponent<SphereCollider>();
        timer = 0.0f;
        shootSound = gameObject.GetComponents<AudioSource>();
    }

    void Update()
    {
        Level_Manager(level);

        
        attack_Collider.radius = GameObject.Find("Main Camera").GetComponent<Elemental>().tower_atkRange;
        timer += Time.deltaTime;
        
        if(timer > coolTime  && hp > 0){

            AutoAttack(FirePos, collEnemys);
            timer = 0.0f;
        }
        if(GameObject.Find("Main Camera").GetComponent<Elemental>().function5!=0) {
            defence_val = basic_defence_val + (basic_defence_val/20)*ice_type_num*GameObject.Find("Main Camera").GetComponent<Elemental>().ice_tower_armour;
        }
        if(GameObject.Find("Main Camera").GetComponent<Elemental>().function7!=0) {
            max_hp = basic_max_hp + (basic_attack_val/20)*earth_type_num*GameObject.Find("Main Camera").GetComponent<Elemental>().earth_tower_MaxHp;
        }
        check_tower();         
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
        slot_num = (level / 5);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("MonsterAttack"))
        {
            collEnemys.Add(collision.transform.gameObject);
        }
        if (collision.CompareTag("MonsterAttack")) {
            allEnemys.Add(collision.transform.gameObject);

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
        foreach (GameObject go in allEnemys)
        {
            if (go == collision.gameObject)
            {
                allEnemys.Remove(go);
                break;
            }
        }
    }

    public void AutoAttack(Transform firePos, List<GameObject> collEnemy){
        if (collEnemy.Count != 0){
            for(int n = 0; n< collEnemy.Count;n++){
                if(collEnemy[n].GetComponentInParent<Monster_old>().curHealth <= 0) collEnemys.Remove(collEnemy[n]);
                else {
                    firePos.transform.LookAt(collEnemy[n].transform);
                    empty_type_num = (float)types.FindAll(n => n == 0).Count;
                    fire_type_num = (float)types.FindAll(n => n == 1).Count;
                    lightning_type_num = (float)types.FindAll(n => n == 2).Count;
                    ice_type_num = (float)types.FindAll(n => n == 3).Count;
                    earth_type_num = (float)types.FindAll(n => n == 4).Count;
                    
                    if(GameObject.Find("Main Camera").GetComponent<Elemental>().function1!=0) {
                        attack_val = basic_attack_val + (basic_attack_val/20)*fire_type_num*GameObject.Find("Main Camera").GetComponent<Elemental>().fire_tower_damage;
                    }

                    if(GameObject.Find("Main Camera").GetComponent<Elemental>().function3!=0) {
                        coolTime = basic_coolTime - (basic_coolTime/20)*lightning_type_num*GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_tower_atkSpeed;
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
                        towerShoot.towerAtk = attack_val;
                    }
                    else if(type_num == 1) {
                        towerShoot.property_type = "F";
                        //리스트 5개 해서 하나 나오면 [1,0,0,0,0]
                        List<int> fireCritical = new List<int> {0,0,0,0,0,0,0,0};
                        for(int i=0; i<GameObject.Find("Main Camera").GetComponent<Elemental>().fire_tower_critical;i++) fireCritical[i] = 1;
                        if(fireCritical[UnityEngine.Random.Range(0,5)]==1) {
                            type_num = 5;
                            towerShoot.towerAtk = attack_val*2;


                        }
                        else{  
                            towerShoot.towerAtk = attack_val;
                        }
                    }
                    else if(type_num == 2) {
                        towerShoot.property_type = "L";
                        //리스트 5개 해서 하나 나오면 [1,0,0,0,0]
                        List<int> lightningCritical = new List<int> {0,0,0,0,0,0,0,0};
                        for(int i=0; i<GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_tower_critical;i++) lightningCritical[i] = 1;
                        if(lightningCritical[UnityEngine.Random.Range(0,5)]==1) {
                            type_num = 6;
                            towerShoot.towerAtk = attack_val*2;
                        }
                        else{  
                            towerShoot.towerAtk = attack_val;
                        }
                        if(GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_tower_shock){
                            List<int> earthAllBind = new List<int> {0,0,0,0,0,0,0,1,1,1};
                            if(earthAllBind[UnityEngine.Random.Range(0,10)]==1) {
                                StartCoroutine(Lightning_shock_all());
                                foreach(GameObject monster in allEnemys) {
                                    monster.GetComponent<Monster_old>().Lightning_Damage_Effect();
                                } 
                            }
                        }
                    }
                    else if(type_num == 3) {      
                        towerShoot.property_type = "I";
                        towerShoot.towerAtk = attack_val;
                    }
                    else if(type_num == 4){
                        towerShoot.property_type = "E";
                        towerShoot.towerAtk = attack_val;
                        if(GameObject.Find("Main Camera").GetComponent<Elemental>().earth_drain !=0) {
                            if(hp < max_hp) hp+= GameObject.Find("Main Camera").GetComponent<Elemental>().earth_drain;
                        }
                        //리스트 5개 해서 하나 나오면 [1,0,0,0,0]
                        if(GameObject.Find("Main Camera").GetComponent<Elemental>().earth_tower_all_bind) {
                            List<int> earthAllBind = new List<int> {0,0,0,0,0,0,0,0,0,1};
                            if(earthAllBind[UnityEngine.Random.Range(0,10)]==1) {
                                StartCoroutine(Earth_Effect_Active());
                                foreach(GameObject monster in allEnemys) {
                                    StartCoroutine(monster.GetComponent<Monster_old>().Earth_AllBind_Effect());
                                } 
                            }
                        }
                    }
                    bullet.GetComponent<TrailRenderer>().material = ranShoot[type_num];
                    shootSound[type_num].Play();
                    towerShoot.target = collEnemy[n];
                }
                 
   
            }
            empty_type_num = (float)types.FindAll(n => n == 0).Count;
            fire_type_num = (float)types.FindAll(n => n == 1).Count;
            lightning_type_num = (float)types.FindAll(n => n == 2).Count;
            ice_type_num = (float)types.FindAll(n => n == 3).Count;
            earth_type_num = (float)types.FindAll(n => n == 4).Count;
        }
    }

    void Unfrozen(){
        frozen = false;
        Renderer rd = this.GetComponent<MeshRenderer>();
        rd.materials = tower_base;
    }


    int Random_type_attack() {
        if(fire_type_num != 0) fire_type_num += GameObject.Find("Main Camera").GetComponent<Elemental>().fire_tower_weight;
        if(lightning_type_num != 0) lightning_type_num += GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_tower_weight;
        if(ice_type_num != 0) ice_type_num += GameObject.Find("Main Camera").GetComponent<Elemental>().ice_tower_weight;
        if(earth_type_num != 0) earth_type_num += GameObject.Find("Main Camera").GetComponent<Elemental>().earth_tower_weight;
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
    
    public IEnumerator Lightning_shock_all(){
        lightningEffect.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        lightningEffect.SetActive(false);
    }

    public IEnumerator Earth_Effect_Active(){
        earthEffect.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        earthEffect.SetActive(false);
    }
}