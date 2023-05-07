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
                    Destroy(other.gameObject);
                    
                }
                else if(other.gameObject.GetComponent<Bullet>().property_type == "Ice") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    Destroy(other.gameObject);
                    
                }
                else if(other.gameObject.GetComponent<Bullet>().property_type == "Earth") {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    Destroy(other.gameObject);
                    
                }
                else {
                    anims.SetBool("isDamage", true);
                    GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                    StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                    Destroy(other.gameObject);
                }
                
                GetComponentInParent<Monster_old>().curHealth -= other.gameObject.GetComponent<Bullet>().bulletAtk;
                StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Tower_Bullet"))
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                Debug.Log("Ÿ�����ݸ���");
                Vector3 reactVec = transform.parent.position;
                anims.SetBool("isDamage", true);
                print("towerATK"+ other.gameObject.GetComponent<TowerShoot>().towerAtk);
                GetComponentInParent<Monster_old>().curHealth -= 20;
                StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                other.GetComponent<TowerShoot>().DestroyBullet();
            }

        }

    }
}
