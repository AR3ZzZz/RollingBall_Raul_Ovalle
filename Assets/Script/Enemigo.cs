using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float minDistance;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject cannon;
    [SerializeField] float spawnBala;
    
    float timer = 0;

    

    void Start()
    {
        
    }

    void Update()
    {
        if (EnRango())
        {
            if (timer < 0)
            {
                GameObject clon;
                clon = Instantiate(bala, cannon.transform.position, cannon.transform.rotation);
                timer = Random.Range(3, 7);
            }
            else
            {
                timer -= Time.deltaTime;
            }


        }

    }

    public bool EnRango()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDistance && target != null)
        {

            transform.LookAt(target);
            bool dentroDeRango = true;
            return dentroDeRango;
        }
        else
        {
            return false;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
}
