using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_attack : MonoBehaviour
{
    Animator anims;
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponentInParent<Monster_old>().anim;
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponentInParent<Monster_old>().isAttack = true;

        }
        if(other.gameObject.tag == "TowerAttack")
        {
            GetComponentInParent<Monster_old>().isAttack = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Character)
        {
            GetComponentInParent<Monster_old>().isAttack = false;
        }
    }
}
