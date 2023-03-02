using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_range : MonoBehaviour
{
    // Start is called before the first frame update
    public bool attack;
    float delay;
    void Start()
    {
        attack = false;
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            delay += Time.deltaTime;
        }
        else
        {
            delay = 0;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        
        if (attack)
        {
            if(delay > 0.3f)
            {
                if (other.gameObject.tag == "Player")
                {
                    Debug.Log("╬Нец ╣й");
                    GetComponentInParent<Monster_old>().AttackOn();
                    attack = false;
                }
            }    
        }
        
    }
}
