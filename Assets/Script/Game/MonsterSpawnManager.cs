using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    int count;
    public Transform player;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count > 60)
        {
            count = 0;
            int tempR = Random.Range(0, 4);
            if(tempR == 0)
            {
                GameObject temp = Instantiate(enemy, new Vector3(50, 0.5f, Random.Range(-50,50)), Quaternion.identity);
                temp.GetComponent<Monster>().target = player;
            }else if(tempR == 1)
            {
                GameObject temp = Instantiate(enemy, new Vector3(-50, 0.5f, Random.Range(-50, 50)), Quaternion.identity);
                temp.GetComponent<Monster>().target = player;
            }
            else if(tempR == 2)
            {
                GameObject temp = Instantiate(enemy, new Vector3(Random.Range(-50, 50), 0.5f,50 ), Quaternion.identity);
                temp.GetComponent<Monster>().target = player;
            }
            else
            {
                GameObject temp = Instantiate(enemy, new Vector3(Random.Range(-50, 50), 0.5f, -50), Quaternion.identity);
                temp.GetComponent<Monster>().target = player;
            }
            
        }
    }
}
