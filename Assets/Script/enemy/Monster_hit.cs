using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_hit : MonoBehaviour
{
    Animator anims;
    Material materi;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponentInParent<Monster_old>().anim;
        player = GameObject.Find("MainCharacter").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)   // ������ �ǰ�����
    {
        int can_fierce = GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_fierce;
        float shock = GameObject.Find("Main Camera").GetComponent<Elemental>().lightning_shock;// 
        if (other.gameObject.layer == LayerMask.NameToLayer("Player_Bullet"))
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                Vector3 reactVec = transform.parent.position;
                if(other.gameObject.GetComponent<Bullet>().property_type == "Fire") {
                    print("불 특성 공격 맞음");
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    Destroy(other.gameObject);
                    GetComponentInParent<Monster_old>().Fire_Damage_Effect();
                }
                else if(other.gameObject.GetComponent<Bullet>().property_type == "Lightning") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    if(can_fierce == 0) Destroy(other.gameObject);
                    can_fierce -= 1;
                    GetComponentInParent<Monster_old>().Lightning_Damage_Effect();
                    
                }
                else if(other.gameObject.GetComponent<Bullet>().property_type == "Ice") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    Destroy(other.gameObject);
                    GetComponentInParent<Monster_old>().frozen = true;
                    Debug.Log("동상 걸려");
                }
                else if(other.gameObject.GetComponent<Bullet>().property_type == "Earth") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    Destroy(other.gameObject);
                    
                    GetComponentInParent<Monster_old>().Earth_Damage_Effect();
                }
                else {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    Destroy(other.gameObject);
                }
            
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Tower_Bullet"))
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                Vector3 reactVec = transform.parent.position;
                if(other.gameObject.GetComponent<TowerShoot>().property_type == "F") {
                    print("불 특성 공격 맞음");
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<TowerShoot>().towerAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    other.GetComponent<TowerShoot>().DestroyBullet();
                    GetComponentInParent<Monster_old>().Fire_Damage_Effect();
                }
                else if(other.gameObject.GetComponent<TowerShoot>().property_type == "L") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<TowerShoot>().towerAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    other.GetComponent<TowerShoot>().DestroyBullet();
                    GetComponentInParent<Monster_old>().Lightning_Damage_Effect();
                }
                else if(other.gameObject.GetComponent<TowerShoot>().property_type == "I") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<TowerShoot>().towerAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    other.GetComponent<TowerShoot>().DestroyBullet();
                    GetComponentInParent<Monster_old>().frozen = true;
                    Debug.Log("동상 걸려");
                }
                else if(other.gameObject.GetComponent<TowerShoot>().property_type == "E") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<TowerShoot>().towerAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    other.GetComponent<TowerShoot>().DestroyBullet();
                    GetComponentInParent<Monster_old>().Earth_Damage_Effect();
                }
                else{
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<TowerShoot>().towerAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    other.GetComponent<TowerShoot>().DestroyBullet();
                }
            }

        }

    }
}
