using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    public int Health;
    bool isAttackKetInput;
    public bool isAttackReady, attack_time, check;
    /*public GameObject sword, gun,shotgun;*/
    public bool isSword, isGun, isShotgun;
    public GameObject bullet;
    public GameObject icicle;
    public GameObject sw_btn, g_btn, sg_btn;
    public GameObject LevelUp_UI;
    public GameObject TypePanel;
    public GameObject TypeIcon1, TypeIcon2, TypeIcon3, TypeIcon4, TypeIcon5;
    public Sprite FireImage, LightImage, IceImage, EarthImage, WhiteImage;
    public GameObject health_bar;
    public GameObject health_text;
    public GameObject blizzard;
    
    public AudioSource audioSource;
    public GameObject MainCamera;

    GameObject earthShield;
    GameObject earthUnbreakableEffect;
    float stick_hAxis, stick_vAxis, key_hAxis, key_vAxis;
    float attackDelay;
    int[] Type = new int[5];
    int selectNumber;
    
    public float weapon_atkVal = 10.0f; 



    /*Ư�� ���� ����*/
    public int fire_num = 0;
    public int lightning_num = 0;
    public int ice_num = 0;
    public int earth_num = 0;
    public float fire_weight;
    public float fire_duration;
    public float fire_damage;
    public float lightning_weight;
    public float lightning_duration;
    public float lightning_AtkSpeed;
    public float ice_weight;
    public float ice_duration;
    public float ice_Character_armour;
    public float earth_weight;
    public float earth_duration;
    public float earth_Character_MaxHp;
    float empty_weight;
    int attack_type;

    public bool isInvincible = false;
    private bool ice_blizzard = false;

    Vector3 moveVec;
    Animator anim;

    void Start()
    {
        Health = 100;
        Type[0] = 0;
        Type[1] = 0;
        Type[2] = 0;
        Type[3] = 0;
        Type[4] = 0;
        isSword = false;
        isGun = true;
        isShotgun = false;
        anim.SetBool("isSword", false);
        anim.SetBool("isGun", true);
        anim.SetBool("isShotgun", false);
        attackDelay = 1.0f;
        LevelUp_UI.SetActive(false);
        TypePanel.SetActive(false);

        earthShield = transform.Find("GlowZoneGreen").gameObject;
        earthShield.SetActive(false);   
        earthUnbreakableEffect = transform.Find("GlowZoneWhite").gameObject;
        earthUnbreakableEffect.SetActive(false);             
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        health_bar.GetComponent<Slider>().value = Health;
        health_text.GetComponent<Text>().text = Health.ToString();
        attackDelay += Time.deltaTime;
        if (isGun)
        {
            isAttackReady = 0.2f < attackDelay;
            attack_time = 1.0f - MainCamera.GetComponent<Elemental>().lightning_character_atkSpeed < attackDelay;
        }
        /**if (isSword)
        {
            isAttackReady = 0.4f < attackDelay;
            attack_time = 0.7f < attackDelay;
        }
        else
        {
            isAttackReady = 0.5f < attackDelay;
            attack_time = 1.2f < attackDelay;
        }**/
        SetValue();
        GetInput();
        Move();
        Attack();

        if(Health <= 0) { 
            Health = 0;
            GameObject.Find("UI").GetComponent<UI>().Gameover_Panel_active();
            print("Game Over");
        }

        if(GameObject.Find("Main Camera").GetComponent<Elemental>().earth_weapon_armour!=0 && earth_num!=0) {
            earthShield.SetActive(true);
            earthShield.transform.localScale = new Vector3(1.0f,1.0f,(float)(earth_num*0.5));
        }
        else earthShield.SetActive(false);
    }

    public void SetValue()   // setting value
    {
        fire_duration = MainCamera.GetComponent<Elemental>().fire_duration;
        lightning_duration = MainCamera.GetComponent<Elemental>().lightning_duration;
        ice_duration = MainCamera.GetComponent<Elemental>().ice_duration;
        earth_duration = MainCamera.GetComponent<Elemental>().earth_duration;

        fire_damage = MainCamera.GetComponent<Elemental>().fire_character_damage;
        lightning_AtkSpeed = MainCamera.GetComponent<Elemental>().lightning_character_atkSpeed;
        ice_Character_armour = MainCamera.GetComponent<Elemental>().ice_character_armour;
        earth_Character_MaxHp = MainCamera.GetComponent<Elemental>().earth_character_MaxHp;
        int temp_fire = 0;
        int temp_lightning = 0;
        int temp_ice = 0;
        int temp_earth = 0;
        int temp_empty = 0;
        for (int i = 0; i < Type.Length; i++)
        {     
            if(Type[i] == 0)
            {
                temp_empty += 1;
            }else if(Type[i] == 1)
            {
                temp_fire += 1;
            }else if(Type[i] == 2)
            {
                temp_lightning += 1;
            }else if(Type[i] == 3)
            {
                temp_ice += 1;
            }else if(Type[i] == 4)
            {
                temp_earth += 1;
            }
        }
        empty_weight = temp_empty;
        fire_weight = temp_fire + MainCamera.GetComponent<Elemental>().fire_character_weight;
        lightning_weight = temp_lightning + MainCamera.GetComponent<Elemental>().lightning_character_weight;
        ice_weight = temp_ice + MainCamera.GetComponent<Elemental>().ice_character_weight;
        earth_weight = temp_earth + MainCamera.GetComponent<Elemental>().earth_character_weight;
        fire_num = temp_fire;
        lightning_num = temp_lightning;
        ice_num = temp_ice;
        earth_num = temp_earth;


    }

    public void UpgradeOn()
    {
        LevelUp_UI.SetActive(true);
    }
    public void UpgradeOff()
    {
        LevelUp_UI.SetActive(false);
    }

    
    void GetInput()
    {
        stick_hAxis = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        stick_vAxis = CrossPlatformInputManager.GetAxisRaw("Vertical");
        key_hAxis = Input.GetAxisRaw("Horizontal");
        key_vAxis = Input.GetAxisRaw("Vertical");
        isAttackKetInput = CrossPlatformInputManager.GetButtonDown("Attack");

        //is_top = GameObject.Find("Main Camera").GetComponent<BuildCamera>().isTopview;
    }

    void Move()
    {
        //if (is_top)
        //    moveVec = Vector3.zero;
        //else
        //{
            
        //}
        if (isAttackReady){
            transform.position += moveVec * GameObject.Find("Main Camera").GetComponent<Elemental>().character_speed * Time.deltaTime;
            transform.LookAt(transform.position + moveVec);
            moveVec = stick_hAxis * Vector3.right + stick_vAxis * Vector3.forward + key_hAxis * Vector3.right + key_vAxis * Vector3.forward;
            moveVec = moveVec.normalized;

            anim.SetBool("isMove", moveVec != Vector3.zero);
        }
        
    }
    
    void Attack()
    {
        
        /**if (isSword)
        {
            if (isAttackKetInput && isAttackReady && attack_time)
            {
                attackDelay = 0;
                anim.SetBool("isAttack", true);
                anim.SetBool("timeout", false);    
            }else if(attack_time){
                anim.SetBool("timeout", true);
            }
            else if (isAttackReady)
            {
                anim.SetBool("isAttack", false);
            }
        }**/
        if(isGun)   // 총 발사
        {
            if (isAttackKetInput && isAttackReady && attack_time)
            {
                float all = empty_weight + fire_weight + lightning_weight + ice_weight + earth_weight;
                int ran = Mathf.RoundToInt(all * UnityEngine.Random.Range(0f, 1f));
                if (ran <= empty_weight)
                {
                    bullet.GetComponent<Bullet>().property_type = "None";
                    bullet.GetComponent<Bullet>().bulletAtk = weapon_atkVal;
                    attack_type = 0;
                    
                }
                else if (ran <= empty_weight+fire_weight)
                {
                    bullet.GetComponent<Bullet>().property_type = "Fire";
                    attack_type = 1;
                    List<int> fireCritical = new List<int> {0,0,0,0,0};
                    for(int i=0; i<GameObject.Find("Main Camera").GetComponent<Elemental>().fire_weapon_critical;i++) fireCritical[i] = 1;
                    if(fireCritical[UnityEngine.Random.Range(0,5)]==1) {
                        bullet.GetComponent<Bullet>().bulletAtk = weapon_atkVal *2;
                        bullet.GetComponent<Bullet>().property_type = "FireCritical";
                    }
                    else{  
                        bullet.GetComponent<Bullet>().bulletAtk = weapon_atkVal;
                    }
                    if(GameObject.Find("Main Camera").GetComponent<Elemental>().fire_weapon_flamethrower) { //&&추가로 특성슬롯이 불 속성으로 다 차는 조건문 추가해야함
                        //화염 방사기 기능 구현 할곳
                    }
                }
                else if (ran <= empty_weight+fire_weight+lightning_weight)
                {
                    attack_type = 2;
                    bullet.GetComponent<Bullet>().property_type = "Lightning";
                    bullet.GetComponent<Bullet>().bulletAtk = weapon_atkVal;
                }
                else if (ran <= empty_weight+fire_weight+lightning_weight+ice_weight)
                {
                    attack_type = 3;
                    bullet.GetComponent<Bullet>().property_type = "Ice";
                    bullet.GetComponent<Bullet>().bulletAtk = weapon_atkVal;
                    if(GameObject.Find("Main Camera").GetComponent<Elemental>().ice_blizzard) {
                        if(!ice_blizzard){
                            InvokeRepeating("Ice_Blizzard",0,10);
                            ice_blizzard = true;
                        }
                        if(GameObject.Find("Day Bar").GetComponent<DayManager>().isNight == false) {
                            CancelInvoke("Ice_Blizzard");
                            blizzard.SetActive(false);
                            ice_blizzard = false;
                        }
                    }
                    
                }
                else if(ran <= empty_weight+fire_weight+lightning_weight+ice_weight+earth_weight)
                {
                    attack_type = 4;
                    bullet.GetComponent<Bullet>().property_type = "Earth";
                    bullet.GetComponent<Bullet>().bulletAtk = weapon_atkVal;
                    if(GameObject.Find("Main Camera").GetComponent<Elemental>().earth_drain !=0) {
                        if(Health < 100) Health += (int)(GameObject.Find("Main Camera").GetComponent<Elemental>().earth_drain/2);
                    }
                    if(GameObject.Find("Main Camera").GetComponent<Elemental>().earth_weapon_unbreakable) {
                        List<int> earthWeaponUnbreakable = new List<int> {0,0,0,0,1};
                        if(earthWeaponUnbreakable[UnityEngine.Random.Range(0,5)]==1) {
                            StartCoroutine(Earth_Weapon_Unbreakable_Effect());
                        }
                    }
                }
                attackDelay = 0;
                anim.SetBool("isShoot", true);
                anim.SetBool("timeout", false);
                GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
                
                temp.GetComponent<Bullet>().fire(transform.forward,true);
                if(GameObject.Find("Main Camera").GetComponent<Elemental>().icicle_damage > 0 && attack_type == 3){
                    GameObject icicle1 = Instantiate(icicle, transform.position, Quaternion.identity);
                    icicle1.transform.Rotate(new Vector3(0f, 10f, 0f));
                    GameObject icicle2 = Instantiate(icicle, transform.position, Quaternion.identity);
                    icicle2.transform.Rotate(new Vector3(0f, -10f, 0f));
                    icicle1.GetComponent<Bullet>().fire(transform.forward,true);
                    icicle2.GetComponent<Bullet>().fire(transform.forward,true);   
                }

                audioSource.Play();
                
            }
            else if (attack_time)
            {
                anim.SetBool("timeout", true);
            }
            else if (isAttackReady)
            {
                anim.SetBool("isShoot", false);
            }
        }
        /**else if(isShotgun)
        {
            if (isAttackKetInput && isAttackReady && attack_time)
            {
                anim.SetBool("isShot", true);
                anim.SetBool("timeout", false);
                attackDelay = 0;
                Invoke("shotgunShoot", 0.1f);
            }
            else if (attack_time)
            {
                anim.SetBool("timeout", true);
            }
            else if (isAttackReady)
            {
                anim.SetBool("isShot", false);
            }
        }**/


    }
    /*void shotgunShoot() {
        GameObject temp1 = Instantiate(bullet, transform.position, Quaternion.identity);
        GameObject temp2 = Instantiate(bullet, transform.position, Quaternion.Euler(0, -10f, 0));
        GameObject temp3 = Instantiate(bullet, transform.position, Quaternion.Euler(0, 10f, 0));
        temp1.GetComponent<Bullet>().fire(transform.forward, false);
        temp2.GetComponent<Bullet>().fire(transform.forward, false);
        temp3.GetComponent<Bullet>().fire(transform.forward, false);
    }*/

    /*public void changeSword()
    {
        if (!isSword && attack_time)
        {
            isSword = true;
            isGun = false;
            isShotgun = false;
            anim.SetBool("isSword", true);
            anim.SetBool("isGun", false);
            anim.SetBool("isShotgun", false);
            sword.SetActive(true);
            gun.SetActive(false);
            shotgun.SetActive(false);
            sw_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -400, 0);
            g_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, -450, 0);
            sg_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -450, 0);
            sw_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            g_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            sg_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
    }
    public void changeGun()
    {
        if (!isGun && attack_time)
        {
            isSword = false;
            isGun = true;
            isShotgun = false;
            anim.SetBool("isSword", false);
            anim.SetBool("isGun", true);
            anim.SetBool("isShotgun", false);
            sword.SetActive(false);
            gun.SetActive(true);
            shotgun.SetActive(false);
            g_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -400, 0);
            sg_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, -450, 0);
            sw_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -450, 0);
            g_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            sg_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            sw_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
    }
    public void changeShotgun()
    {
        if (!isShotgun && attack_time)
        {
            isSword = false;
            isGun = false;
            isShotgun = true;
            anim.SetBool("isSword", false);
            anim.SetBool("isGun", false);
            anim.SetBool("isShotgun", true);
            sword.SetActive(false);
            gun.SetActive(false);
            shotgun.SetActive(true);
            sg_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -400, 0);
            sw_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(-150, -450, 0);
            g_btn.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, -450, 0);
            sg_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
            sw_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            g_btn.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
        }
    }*/

    public void ExitPanel()   // Ư������ �гΰ���
    {
        TypePanel.SetActive(false);
        selectNumber = 0;
    }

    public void select1()
    {
        selectNumber = 1;
        TypePanel.SetActive(true);
    }
    public void select2()
    {
        selectNumber = 2;
        TypePanel.SetActive(true);
    }
    public void select3()
    {
        selectNumber = 3;
        TypePanel.SetActive(true);
    }
    public void select4()
    {
        selectNumber = 4;
        TypePanel.SetActive(true);
    }
    public void select5()
    {
        selectNumber = 5;
        TypePanel.SetActive(true);
    }
    public void ResetBtn()
    {
        TypeIcon1.SetActive(false);
        TypeIcon2.SetActive(false);
        TypeIcon3.SetActive(false);
        TypeIcon4.SetActive(false);
        TypeIcon5.SetActive(false);
        Type[0] = 0;
        Type[1] = 0;
        Type[2] = 0;
        Type[3] = 0;
        Type[4] = 0;
    }

    public void selectFire()
    {
        if(selectNumber == 1)
        {
            TypeIcon1.SetActive(true);
            TypeIcon1.GetComponent<Image>().sprite = FireImage;
            Type[0] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.SetActive(true);
            TypeIcon2.GetComponent<Image>().sprite = FireImage;
            Type[1] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.SetActive(true);
            TypeIcon3.GetComponent<Image>().sprite = FireImage;
            Type[2] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.SetActive(true);
            TypeIcon4.GetComponent<Image>().sprite = FireImage;
            Type[3] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.SetActive(true);
            TypeIcon5.GetComponent<Image>().sprite = FireImage;
            Type[4] = 1;
            TypePanel.SetActive(false);
        }
    }
    public void selectLight()
    {
        if (selectNumber == 1)
        {
            TypeIcon1.SetActive(true);
            TypeIcon1.GetComponent<Image>().sprite = LightImage;
            Type[0] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.SetActive(true);
            TypeIcon2.GetComponent<Image>().sprite = LightImage;
            Type[1] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.SetActive(true);
            TypeIcon3.GetComponent<Image>().sprite = LightImage;
            Type[2] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.SetActive(true);
            TypeIcon4.GetComponent<Image>().sprite = LightImage;
            Type[3] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.SetActive(true);
            TypeIcon5.GetComponent<Image>().sprite = LightImage;
            Type[4] = 2;
            TypePanel.SetActive(false);
        }
    }
    public void selectIce()
    {
        if (selectNumber == 1)
        {
            TypeIcon1.SetActive(true);
            TypeIcon1.GetComponent<Image>().sprite = IceImage;
            Type[0] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.SetActive(true);
            TypeIcon2.GetComponent<Image>().sprite = IceImage;
            Type[1] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.SetActive(true);
            TypeIcon3.GetComponent<Image>().sprite = IceImage;
            Type[2] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.SetActive(true);
            TypeIcon4.GetComponent<Image>().sprite = IceImage;
            Type[3] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.SetActive(true);
            TypeIcon5.GetComponent<Image>().sprite = IceImage;
            Type[4] = 3;
            TypePanel.SetActive(false);
        }
    }
    public void selectEarth()
    {
        if (selectNumber == 1)
        {
            TypeIcon1.SetActive(true);
            TypeIcon1.GetComponent<Image>().sprite = EarthImage;
            Type[0] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.SetActive(true);
            TypeIcon2.GetComponent<Image>().sprite = EarthImage;
            Type[1] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.SetActive(true);
            TypeIcon3.GetComponent<Image>().sprite = EarthImage;
            Type[2] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.SetActive(true);
            TypeIcon4.GetComponent<Image>().sprite = EarthImage;
            Type[3] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.SetActive(true);
            TypeIcon5.GetComponent<Image>().sprite = EarthImage;
            Type[4] = 4;
            TypePanel.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Gold")
        {
            Destroy(collision.gameObject);
            GameObject.Find("Main Camera").GetComponent<GameManager>().money += (int)(1000*(1+GameObject.Find("Main Camera").GetComponent<Elemental>().character_moneyLuck));
        }
    }

    public IEnumerator Earth_Weapon_Unbreakable_Effect(){
        isInvincible = true;
        earthUnbreakableEffect.SetActive(true);
        yield return new WaitForSecondsRealtime(3.0f);
        earthUnbreakableEffect.SetActive(false);
        isInvincible = false;
    }

    
    void Ice_Blizzard(){
        blizzard.SetActive(true);
        GameObject[] temp = GameObject.FindGameObjectsWithTag("MonsterAttack");
        foreach(GameObject monster in temp){
            monster.GetComponent<Monster_old>().freeze = true;
        }
    }
    
}
