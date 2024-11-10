using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float velocidad;
    float timer = 10;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position += (transform.forward * velocidad * Time.deltaTime);
        if (timer < 0)
        {
            Destroy(gameObject);//Optimizar 
        }
    }
}
