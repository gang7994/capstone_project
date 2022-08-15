using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    void Start(){
        Invoke("DestroyBullet", 1);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 0.3f);
    }

    void DestroyBullet(){
        Destroy(gameObject);
    }
}
