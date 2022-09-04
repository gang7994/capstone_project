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
        /*
        if (Input.GetMouseButton(1)){

            GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Rigidbody bullletRigid = instantBullet.GetComponent<Rigidbody>();
            bullletRigid.velocity = bulletPos.forward * 1;
            Shoot();
        }
        else if(GetComponent<Animator>().GetBool("isAttack")){
            Invoke("Swing",1);
        }
        */
    }

    void Shoot(){
        Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
    }
    void Swing(){
            Instantiate(Rock, FirePos.transform.position, FirePos.transform.rotation);    
    }
}
