using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    bool check;
    float delay;
    void Start()
    {
        delay = 0;
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.GetComponent<Player>().attack_time && character.GetComponent<Player>().isSword)
        {
            delay += Time.deltaTime;
            if (delay > 0.1f && delay < 0.4f)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }
        else
        {
            delay = 0;
            check = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Monster")
        {
            if (check)
            {
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Monster")
        {
            if (check)
            {
                Destroy(other.gameObject);
            }
        }
    }

}
