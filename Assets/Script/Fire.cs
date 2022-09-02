using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Rock;
    public Transform bulletPos;

    void Update()
    {
        if (Input.GetMouseButton(1)){
            GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Rigidbody bullletRigid = instantBullet.GetComponent<Rigidbody>();
            bullletRigid.velocity = bulletPos.forward * 1;
        }
        else if(GetComponent<Animator>().GetBool("isAttack")){
            Instantiate(Rock, bulletPos.position, bulletPos.rotation);    

        }
        
    }
}
