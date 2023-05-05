using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_hit : MonoBehaviour
{
    Animator anims;
    Material materi;
    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponentInParent<Monster_old>().anim;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player_Bullet"))
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                Debug.Log("타워공격맞음");
                Vector3 reactVec = transform.parent.position;
                anims.SetBool("isDamage", true);
                GetComponentInParent<Monster_old>().curHealth -= 20;
                StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Tower_Bullet"))
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                Debug.Log("타워공격맞음");
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
