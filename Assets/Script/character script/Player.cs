using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public int Health;
    bool isAttackKetInput;
    public bool isAttackReady, attack_time, check;
    /*public GameObject sword, gun,shotgun;*/
    public bool isSword, isGun, isShotgun;
    public GameObject bullet;
    public GameObject sw_btn, g_btn, sg_btn;
    public GameObject LevelUp_UI;
    public GameObject TypePanel;
    public GameObject TypeIcon1, TypeIcon2, TypeIcon3, TypeIcon4, TypeIcon5;
    public Sprite FireImage, LightImage, IceImage, EarthImage, WhiteImage;
    public GameObject health_bar;
    public GameObject health_text;
    public Material Fire;
    public Material Lightning;
    public Material Ice;
    public Material Earth;
    public Material Normal;
    public AudioSource audioSource;

    float stick_hAxis, stick_vAxis, key_hAxis, key_vAxis;
    float attackDelay;
    int[] Type = new int[5];
    int selectNumber;

    /*특성 전용 변수*/
    public float fire_weight;
    public float fire_duration;
    public float fire_Atk;
    public float fire_DamageNum;
    public float lightning_weight;
    public float lightning_duration;
    public float lightning_Atk;
    public float lightning_AtkSpeed;
    public float ice_weight;
    public float ice_duration;
    public float ice_exhaust;
    public float Character_armour;
    public float earth_weight;
    public float earth_duration;
    public float Character_heal;
    public float Character_MaxHp;

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

        /*특성 전용 변수 기본값*/
       
        
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
        //isAttackReady 는 공격모션 시간 attack_time 은 다음공격까지 딜레이 isattackReady 이후 움직임
        attackDelay += Time.deltaTime;
        if (isSword)
        {
            isAttackReady = 0.4f < attackDelay;
            attack_time = 0.7f < attackDelay;
        }else if (isGun)
        {
            isAttackReady = 0.3f < attackDelay;
            attack_time = 0.5f < attackDelay;
        }
        else
        {
            isAttackReady = 0.5f < attackDelay;
            attack_time = 1.2f < attackDelay;
        }
        GetInput();
        Move();
        Attack();
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
            transform.position += moveVec * speed * Time.deltaTime;
            transform.LookAt(transform.position + moveVec);
            moveVec = stick_hAxis * Vector3.right + stick_vAxis * Vector3.forward + key_hAxis * Vector3.right + key_vAxis * Vector3.forward;
            moveVec = moveVec.normalized;

            anim.SetBool("isMove", moveVec != Vector3.zero);
        }
        
    }
    
    void Attack()
    {
        
        if (isSword)
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
        }
        else if(isGun)
        {
            if (isAttackKetInput && isAttackReady && attack_time)
            {
                int ran = Random.Range(0, 5);
                if (Type[ran] == 0)
                {
                    bullet.GetComponent<MeshRenderer>().material = Normal;
                }
                else if (Type[ran] == 1)
                {
                    bullet.GetComponent<MeshRenderer>().material = Fire;
                }
                else if (Type[ran] == 2)
                {
                    bullet.GetComponent<MeshRenderer>().material = Lightning;
                }
                else if (Type[ran] == 3)
                {
                    bullet.GetComponent<MeshRenderer>().material = Ice;
                }
                else
                {
                    bullet.GetComponent<MeshRenderer>().material = Earth;
                }

                attackDelay = 0;
                anim.SetBool("isShoot", true);
                anim.SetBool("timeout", false);
                GameObject temp = Instantiate(bullet, transform.position, Quaternion.identity);
                temp.GetComponent<Bullet>().fire(transform.forward,true);
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
        else if(isShotgun)
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
        }


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

    public void ExitPanel()   // 특성선택 패널관리
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
        TypeIcon1.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon2.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon3.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon4.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon5.GetComponent<Image>().sprite = WhiteImage;
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
            TypeIcon1.GetComponent<Image>().sprite = FireImage;
            Type[0] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.GetComponent<Image>().sprite = FireImage;
            Type[1] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.GetComponent<Image>().sprite = FireImage;
            Type[2] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.GetComponent<Image>().sprite = FireImage;
            Type[3] = 1;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.GetComponent<Image>().sprite = FireImage;
            Type[4] = 1;
            TypePanel.SetActive(false);
        }
    }
    public void selectLight()
    {
        if (selectNumber == 1)
        {
            TypeIcon1.GetComponent<Image>().sprite = LightImage;
            Type[0] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.GetComponent<Image>().sprite = LightImage;
            Type[1] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.GetComponent<Image>().sprite = LightImage;
            Type[2] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.GetComponent<Image>().sprite = LightImage;
            Type[3] = 2;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.GetComponent<Image>().sprite = LightImage;
            Type[4] = 2;
            TypePanel.SetActive(false);
        }
    }
    public void selectIce()
    {
        if (selectNumber == 1)
        {
            TypeIcon1.GetComponent<Image>().sprite = IceImage;
            Type[0] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.GetComponent<Image>().sprite = IceImage;
            Type[1] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.GetComponent<Image>().sprite = IceImage;
            Type[2] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.GetComponent<Image>().sprite = IceImage;
            Type[3] = 3;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.GetComponent<Image>().sprite = IceImage;
            Type[4] = 3;
            TypePanel.SetActive(false);
        }
    }
    public void selectEarth()
    {
        if (selectNumber == 1)
        {
            TypeIcon1.GetComponent<Image>().sprite = EarthImage;
            Type[0] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 2)
        {
            TypeIcon2.GetComponent<Image>().sprite = EarthImage;
            Type[1] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 3)
        {
            TypeIcon3.GetComponent<Image>().sprite = EarthImage;
            Type[2] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 4)
        {
            TypeIcon4.GetComponent<Image>().sprite = EarthImage;
            Type[3] = 4;
            TypePanel.SetActive(false);
        }
        else if (selectNumber == 5)
        {
            TypeIcon5.GetComponent<Image>().sprite = EarthImage;
            Type[4] = 4;
            TypePanel.SetActive(false);
        }
    }
}
