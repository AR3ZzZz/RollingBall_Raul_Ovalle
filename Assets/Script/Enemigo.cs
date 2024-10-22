using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float minDistance;
    [SerializeField] GameObject bala;
    [SerializeField] float spawnBala;
    float timer = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnRango())
        {
            if (timer < 0)
            {
                Debug.Log("Piu");
                Debug.Log(transform.eulerAngles);
                GameObject clon;
                clon = Instantiate(bala, transform.position + Vector3.forward * spawnBala, transform.rotation * Quaternion.Euler(0,45,0));
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
