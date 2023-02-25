using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerShoot : MonoBehaviour
{
    float timer;
    public GameObject target;
    public float coolTime = 0.5f;
    public Material[] mat = new Material[5]; 

    public Material[] ranShoot = new Material[5];
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Monster")
        {
            DestroyBullet();
        }
    }

    void Update(){
        timer += Time.deltaTime;

        Vector3 direction = target.transform.position - transform.position; //tower.cs에서 넘어온 타켓 정보 중 위치값을 계산
        transform.Translate(direction.normalized * 10f * Time.deltaTime, Space.World); //업데이트로 통해 이동하는 적의 위치를 실시간으로 갱신
    }

    void DestroyBullet(){
        Destroy(gameObject, 1f*Time.deltaTime);
    }

    
    
}