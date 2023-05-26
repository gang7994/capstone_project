using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_old : MonoBehaviour
{
    public float maxHealth, curHealth;
    public float monster_speed = 2;
    public int damage;
    public GameObject house;
    public GameObject Attack_range;
    public GameObject coinPrefab;
    public Transform target;
    public bool isChase;
    public bool isAttack;
    public float Delay;
    bool isAttackDelay;
    public float attack_speed;
    float RoSpeed = 5;
    public float attack_time;
    public bool target_check;
    public bool frozen = false;
    public bool freeze = false;
    private float earth_atk_decrease = 0;
    public bool earth_stop = false;
    public bool isBoss;
    public bool Attack_Type_range;
    Color meshColor;

    public List<Collider> target_list = new List<Collider>();
    public Material[] normal_monster_state = new Material[1];
    public Material[] fire_monster_state = new Material[1];
    public Material[] lightning_monster_state = new Material[1];
    public Material[] lightning_shock_state = new Material[1];
    public Material[] earth_monster_state = new Material[1];
    public Material[] ice_monster_state = new Material[1];
    public Material[] freeze_monster_state = new Material[1];
    public GameObject[] monsters;
    
    private float fire_cooltime;
    private float ligntning_cooltime = 5.0f;

    Rigidbody rigid;
    Material materi;
    Renderer rd;
    public NavMeshAgent navi;
    public Animator anim;
    private GameManager gameManager;
    public void Awake()
    {
        house = GameObject.Find("Baker_house");
        rd = GetComponentInChildren<SkinnedMeshRenderer>();
        rigid = GetComponent<Rigidbody>();
        materi = GetComponentInChildren<SkinnedMeshRenderer>().material;
        navi = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        isAttack = false;
        Delay = 0;
        isAttackDelay = false;
        target_check = false;
        meshColor = materi.color;
        
        Invoke("ChaseStart", 2);
    }
    private void Start()
    {
        
        target = house.transform;
        navi.velocity = Vector3.zero;
        navi.stoppingDistance = 1f;
        damage = 10;
    }
    void Update()
    {
        if (isAttack)
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            anim.SetBool("isMove", true);
        }
        monsters = GameObject.FindGameObjectsWithTag("MonsterAttack");
        Array.Sort(monsters, (monster1, monster2) => 
            Vector3.Distance(monster1.transform.position, transform.position).CompareTo(
                Vector3.Distance(monster2.transform.position, transform.position)
            )
        );
        if(target_list.Count == 0)  //주변에 타겟이 없으면 베이스를 타겟으로함, 타겟이 여럿일 경우 가장 처음에 접촉한 타겟을 목표로 함
        {
            target = house.transform;
        }
        else
        {
            while (target_list.Count != 0)
            {
                if (target_list[0].CompareTag("TowerAttack"))
                {
                    if (target_list[0].GetComponentInParent<Tower>().hp < 1)
                    {
                        target_list.Remove(target_list[0]);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }
            if (target_list.Count == 0)
            {
                target = house.transform;
            }
            else
            {
                target = target_list[0].transform;
            }
        }
        Delay += Time.deltaTime;
        if (isAttack)  // 공격중일때 멈추기
        {
            navi.isStopped = true;
            navi.velocity = Vector3.zero;
            
        }
        else
        {
            navi.isStopped = false;
        }
        if (isAttack)  // 공격주기  Delay 시간이 몬스터 공격 속도, attackTime은 한 공격에 걸리는 시간
        {
            if (Delay > attack_speed)
            {
                MonsterAttack();
                Delay = 0;
            }
            else if (Delay > attack_time)
            {
                AttackDelay();
            }

        }
        else
        {
            if (Delay > attack_time)
            {
                AttackDelay();
            }
        }
        if (isChase){  // 공격중이 아니고 타겟이 있을때 타겟을 따라감, 밑에 if문은 공격후 타겟을 자연스럽게 바라보게 함
            if (!isAttackDelay && target != null)
            {
                navi.SetDestination(target.position);
                
                if (Delay > 0.7f)
                {
                    Vector3 Pos = target.position - transform.position;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Pos), Time.deltaTime * RoSpeed);
                    /*transform.LookAt(target);*/
                }
            }
            
            
        }
        if (anim.GetBool("isDamage"))   // 데미지 입을 시 멈춤, 지금은 사용X
        {
            navi.isStopped = true;
        }
        else
        {
            navi.isStopped = false;
        }
        if (earth_stop)
        {
            navi.isStopped = true;
        }
        else
        {
            navi.isStopped = false;
        }
        if(frozen){ // 동상 시 느려짐 구현해야 함. GameObject.Find("Main Camera").GetComponent<Elemental>().ice_atk_decrease 변수를 받아 공격속도 제어해야 함.
            rd.materials = ice_monster_state;
            monster_speed = 1;
            Invoke("Unfrozen",GameObject.Find("Main Camera").GetComponent<Elemental>().ice_duration);
            anim.speed = 1-(GameObject.Find("Main Camera").GetComponent<Elemental>().ice_atk_decrease);
            attack_time = 0.7f*(1-(GameObject.Find("Main Camera").GetComponent<Elemental>().ice_atk_decrease));
        }
        if(freeze){//빙결 상태. 완전히 멈춤.
            isChase = false;
            rd.materials = freeze_monster_state;
            monster_speed = 0;
            anim.speed = 0;
            Invoke("Unfrozen",GameObject.Find("Main Camera").GetComponent<Elemental>().ice_duration);
            navi.isStopped = true;
            navi.velocity = Vector3.zero;
        }

    }
    void Unfrozen(){
        rd.materials = normal_monster_state;
        frozen = false;
        freeze = false;
        monster_speed = 2;
        anim.speed = 1;
        attack_time = 0.7f;
    }

    

    public IEnumerator OnDamage(Vector3 reactVec)   //몬스터 데미지 입음
    {
        materi.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if (curHealth > 1)
        {
            reactVec = reactVec.normalized;
            reactVec += Vector3.up;
            //rigid.AddForce(reactVec * 5, ForceMode.Impulse);
            anim.SetBool("isDamage", false);
            materi.color = meshColor;
        }
        else
        {
            materi.color = Color.gray;
            anim.SetBool("isDie", true);
            anim.SetBool("isDamage", false);
            gameObject.layer = LayerMask.NameToLayer("MonsterDied");
            navi.isStopped = true;
            navi.velocity = Vector3.zero;
            navi.speed = 0;
            isChase = false;
            target = null;
            Destroy(gameObject, 3);
            StartCoroutine("Die");
            
            coinPrefab = GameObject.Find("CoinGold");
            GameObject instance = Instantiate(coinPrefab);
            Vector3 pos = this.gameObject.transform.position;
            instance.transform.position = pos;
            instance.transform.Translate(new Vector3(0f, 1f, 0f), Space.World);
            

            // Debug.Log("몬스터 사망2");
        }
        
    }
    public void MonsterAttack()   // 몬스터 사정거리 안에 적이 있을 시 공격 쿨타임마다 실행됨
    {
        anim.SetBool("isAttack", true);
        navi.isStopped = true;
        navi.velocity = Vector3.zero;
        navi.speed = 0;
        isAttackDelay = true;
        Attack_range.GetComponent<Attack_range>().attack = true;
        Debug.Log("몬스터 공격");
               
    }
    void AttackDelay()   // 공격중이 아닐때
    {
        if (isChase)
        {
            navi.isStopped = false;
            navi.speed = monster_speed;
            anim.SetBool("isAttack", false);
            Attack_range.GetComponent<Attack_range>().attack = false;
            isAttackDelay = false;
        }
        
    }

    public void AttackOn()   // 몬스터의 공격에 피해를 입히는 부분
    {
        Debug.Log("공격성공");
        if (isChase)
        {
           if(target != null)
            {
                if (target.gameObject.CompareTag("Player"))
                {
                    int total_damage = (int)(damage - (GameObject.Find("Main Camera").GetComponent<Elemental>().earth_weapon_armour * target.GetComponent<Player>().earth_num) -
                    earth_atk_decrease * target.GetComponent<Player>().earth_num);
                    if (target.GetComponent<Player>().isInvincible == false) {
                        if(target.GetComponent<Player>().Health - total_damage >0) target.GetComponent<Player>().Health -= total_damage;
                        else target.GetComponent<Player>().Health = 0;
                    }
                }
                else if (target.gameObject.CompareTag("TowerAttack"))
                {
                    int total_damage = (int)(damage - earth_atk_decrease * target.GetComponentInParent<Tower>().earth_type_num);
                    target.GetComponentInParent<Tower>().hp -= total_damage;
                    if (GameObject.Find("Main Camera").GetComponent<Elemental>().function31 != 0 && target.GetComponentInParent<Tower>().earth_type_num > 0)
                    {
                        StartCoroutine(Earth_Reflex(target));
                    }
                    
                    Debug.Log("타워 데미지 10");
                }
                else if (target.gameObject.CompareTag("base"))
                {
                    if(target.GetComponent<Base>().hp - damage > 0){
                        target.GetComponent<Base>().hp -= damage;
                    }
                    else target.GetComponent<Base>().hp = 0;
                }
            }
        }
    }

    private IEnumerator Die()
    {
        gameManager.SendMessage("ChangeMonsterNumText", -1);
        gameManager.SendMessage("KillCount", 1);
        yield break;
    }

    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }

    }
    /*
    void FixedUpdate()
    {
        FreezeVelocity();
    }
    */
    void ChaseStart()
    {
        isChase = true;
    }

    void ChaseStop()
    {
        isChase = false;
        float StopTime = 2.0f;
        Invoke("ChaseStart", StopTime);
    }


    public void Fire_Damage_Effect(){
        InvokeRepeating("Fire_Dot_Damage_Coroutine", 0f, 1f);
        if(GameObject.Find("Main Camera").GetComponent<Elemental>().fire_tower_eternal) fire_cooltime = 100f;
        else fire_cooltime = GameObject.Find("Main Camera").GetComponent<Elemental>().fire_duration;
        Invoke("Stop_Fire_Dot_Damage", fire_cooltime);
    }

    void Fire_Dot_Damage_Coroutine(){
        StartCoroutine(Fire_Dot_Damage());
    }

    public IEnumerator Fire_Dot_Damage(){
        if(anim.GetBool("isDie")== false){
            rd.materials = fire_monster_state; //화상상태 머티리얼
            yield return new WaitForSeconds(0.1f);
            anim.SetBool("isDamage", true);
            curHealth -= GameObject.Find("Main Camera").GetComponent<Elemental>().fire_dot_damage;      
            if(curHealth < 1) { 
                materi.color = Color.gray;
                anim.SetBool("isDie", true);
                if(GameObject.Find("Main Camera").GetComponent<Elemental>().fire_spread_one==1) {
                    if (monsters.Length != 0){ 
                        monsters[1].GetComponent<Monster_old>().Fire_Damage_Effect();
                    }
                }
                else if(GameObject.Find("Main Camera").GetComponent<Elemental>().fire_spread_one==2) {
                    if (monsters.Length != 0){ 
                        monsters[1].GetComponent<Monster_old>().Fire_Damage_Effect();
                        monsters[2].GetComponent<Monster_old>().Fire_Damage_Effect();
                    }
                }
                anim.SetBool("isDamage", false);
                gameObject.layer = LayerMask.NameToLayer("MonsterDied");
                navi.isStopped = true;
                navi.velocity = Vector3.zero;
                navi.speed = 0;
                isChase = false;
                target = null;
                Destroy(gameObject, 3);
                StartCoroutine("Die");
            }
            anim.SetBool("isDamage", false);
            rd.materials = normal_monster_state; //일반상태 머티리얼
        }
    }
    public void Stop_Fire_Dot_Damage(){
        CancelInvoke("Fire_Dot_Damage_Coroutine");
    }
    
    public void Lightning_Damage_Effect(){
        InvokeRepeating("Lightning_Dot_Damage_Coroutine", 0f, 0.2f);
        Invoke("Stop_Lightning_Dot_Damage", GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_duration);
    }

    void Lightning_Dot_Damage_Coroutine(){
        StartCoroutine(Lightning_Dot_Damage());
    }

    public IEnumerator Lightning_Dot_Damage(){
        if(anim.GetBool("isDie")== false){
            rd.materials = lightning_monster_state;
            monster_speed = 0;
            yield return new WaitForSeconds(0.1f);          
            rd.materials = normal_monster_state;
        } 
    }
    public void Stop_Lightning_Dot_Damage(){
        CancelInvoke("Lightning_Dot_Damage_Coroutine");
        monster_speed = 2;
    }
    
    public void Shocking_Damage_Effect(){
        InvokeRepeating("Shocking_Dot_Damage_Coroutine", 0f, 0.2f);
        Invoke("Stop_Shocking_Dot_Damage", GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_shock +GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_duration);
    }

    void Shocking_Dot_Damage_Coroutine(){
        StartCoroutine(Shocking_Dot_Damage());
    }

    public IEnumerator Shocking_Dot_Damage(){
        if(anim.GetBool("isDie")== false){
            rd.materials = lightning_shock_state;
            isChase = false;
            navi.SetDestination(UnityEngine.Random.insideUnitSphere);
            yield return new WaitForSeconds(0.1f);          
            rd.materials = normal_monster_state;
        } 
    }
    public void Stop_Shocking_Dot_Damage(){
        CancelInvoke("Shocking_Dot_Damage_Coroutine");
        monster_speed = 2;
        //isChase = true;
    }
    
    

    public IEnumerator Earth_Reflex(Transform target){
        rd.materials = earth_monster_state; 
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("isDamage", true);
        curHealth -= GameObject.Find("Main Camera").GetComponent<Elemental>().earth_tower_reflex * target.GetComponentInParent<Tower>().earth_type_num;      
        if(curHealth < 1) { 
            materi.color = Color.gray;
            anim.SetBool("isDie", true);
            anim.SetBool("isDamage", false);
            gameObject.layer = LayerMask.NameToLayer("MonsterDied");
            navi.isStopped = true;
            navi.velocity = Vector3.zero;
            navi.speed = 0;
            isChase = false;
            target = null;
            Destroy(gameObject, 3);
            StartCoroutine("Die");
        }
        anim.SetBool("isDamage", false);
        rd.materials = normal_monster_state; //일반상태 머티리얼
    }

    public void Earth_Damage_Effect(){
        StartCoroutine(Earth_Damage());
    }

    public IEnumerator Earth_Damage(){
        rd.materials = earth_monster_state;
        navi.isStopped = true;
        navi.velocity = Vector3.zero;
        navi.speed = 0;
        anim.SetBool("isMove", false);
        yield return new WaitForSecondsRealtime(GameObject.Find("Main Camera").GetComponent<Elemental>().earth_duration);
        navi.isStopped = false;
        anim.SetBool("isMove", true);
        rd.materials = normal_monster_state; //일반상태 머티리얼
        if(GameObject.Find("Main Camera").GetComponent<Elemental>().function39!=0) StartCoroutine(Earth_AtkDecrease_Effect());
    }

    public IEnumerator Earth_AtkDecrease_Effect(){
        print("공격력------------------감소");
        earth_atk_decrease = GameObject.Find("Main Camera").GetComponent<Elemental>().earth_atkDecrease;
        yield return new WaitForSecondsRealtime(3.0f);
        earth_atk_decrease=0;
        print("공격력------------------증가");

    }

    public IEnumerator Earth_AllBind_Effect(){
        rd.materials = earth_monster_state;
        navi.speed = 0;
        yield return new WaitForSecondsRealtime(3.0f);
        rd.materials = normal_monster_state;
        navi.speed = 2;
    }
    
}
	