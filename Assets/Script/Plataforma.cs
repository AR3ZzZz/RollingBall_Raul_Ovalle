using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] float direccion ;
    [SerializeField] float fuerza ;
    [SerializeField] float contador = 10;
    bool dire;
    Vector3 movimiento = new Vector3(1, 0, 0);

    void Start()
    {
        


    }

    void Update()
    {

        if (contador >= 0)
        {
            contador -= Time.deltaTime;
        }


        if (direccion == 0)
        {
            transform.Translate((movimiento) * Time.deltaTime * fuerza);
        }
        else if (direccion == 1) 
        {
            transform.Translate((-movimiento)* Time.deltaTime * fuerza);

        }


        if (dire = true && contador <= 0)
        {
            direccion = 1;
            contador = 10;
            dire = false;
        }

        if (dire = false && contador <= 0)
        {
            direccion = 0;
            dire = true;
            contador = 10;
        }
    }
}
