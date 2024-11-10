using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStone : MonoBehaviour
{
    float timerAttack;
    [SerializeField] float timerCooldown;
    [SerializeField] float movDownSpeed;
    [SerializeField] float movUpSpeed;
    [SerializeField] Vector3 dir;
    bool prepared;
    void Start()
    {
        prepared = true;
        timerAttack = Random.Range(2, 7);
    }

    void Update()
    {
        if (prepared)
        {
            timerAttack -= Time.deltaTime;
            if (timerAttack < 0)
            {
               Moving(-dir, movDownSpeed);
            }
        }
        else 
        {
            Moving(dir, movUpSpeed);
            timerCooldown -= Time.deltaTime;
            if (timerCooldown <= 0)
            {
                prepared = true;
            }
        }
    }

    void Moving(Vector3 y, float speed)
    {
        transform.Translate(y * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suelo")) 
        {
            prepared = false;
            timerCooldown = 5;
            timerAttack = Random.Range(2, 7);
        }
       
    }
}
