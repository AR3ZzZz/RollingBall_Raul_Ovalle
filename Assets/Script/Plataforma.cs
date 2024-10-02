using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    //[SerializeField] float direccion ;
    [SerializeField] float fuerza ;
    [SerializeField] float tiempoReinicio;
    [SerializeField] Vector3 direccion;
    [SerializeField] Vector3 rotacion;


    float contador;
    bool dire = true;
    
    void Start()
    {
        contador = tiempoReinicio ;


    }

    void Update()
    {

        if (contador >= 0)
        {
            contador -= Time.deltaTime;
        }

        if (dire == true)
        {
            transform.Translate((direccion) * Time.deltaTime * fuerza, Space.World);
        }
        else if (dire == false)
        {
            transform.Translate((-direccion) * Time.deltaTime * fuerza, Space.World);

        }

        if (dire == true)
        {
            transform.Rotate((rotacion) * Time.deltaTime * fuerza, Space.World);
        }
        else if (dire == false)
        {
            transform.Rotate((-rotacion) * Time.deltaTime * fuerza, Space.World);

        }

        if (dire == true && contador <= 0)
        {

            dire = false;
            contador = tiempoReinicio;
        }
        else if (dire == false && contador <= 0)
        {

            dire = true;
            contador = tiempoReinicio;
        }







    }
}
