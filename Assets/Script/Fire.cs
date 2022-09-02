using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Rock;
    public Transform FirePos;

    void Update()
    {
        if (Input.GetMouseButton(1)){
            Shoot();
        }
        else if(GetComponent<Animator>().GetBool("isAttack")){
            Invoke("Swing",1);
        }
        
    }

    void Shoot(){
        Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
    }
    void Swing(){
            Instantiate(Rock, FirePos.transform.position, FirePos.transform.rotation);    
    }
}
