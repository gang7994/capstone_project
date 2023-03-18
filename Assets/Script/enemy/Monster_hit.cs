using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_hit : MonoBehaviour
{
    Animator anims;
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
        /*if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (GetComponentInParent<Monster_old>().isChase)
            {
                Vector3 reactVec = transform.parent.position;
                anims.SetBool("isDamage", true);
                GetComponentInParent<Monster_old>().curHealth -= 20;
                StartCoroutine(GetComponentInParent<Monster_old>().OnDamage(reactVec));
                GetComponentInParent<Monster_old>().Delay = 1.8f;
                Destroy(other.gameObject);
            }

        }*/
    }
}
