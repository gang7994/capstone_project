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
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }
        else if(GetComponent<Animator>().GetBool("isAttack")){
            Instantiate(Rock, FirePos.transform.position, FirePos.transform.rotation);    
        }
        
    }
}
