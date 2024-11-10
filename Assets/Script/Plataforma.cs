using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Plataforma : MonoBehaviour
{
    //[SerializeField] float direccion ;
    [SerializeField] float fuerzaMov ;
    [SerializeField] float fuerzaRot;
    [SerializeField] float tiempoReinicio;
    [SerializeField] Vector3 direccion;
    [SerializeField] Vector3 rotacion;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip sonidoPuntos;


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
            transform.Translate((direccion) * Time.deltaTime * fuerzaMov, Space.World);
        }
        else if (dire == false)
        {
            transform.Translate((-direccion) * Time.deltaTime * fuerzaMov, Space.World);

        }

        if (dire == true)
        {
            transform.Rotate((rotacion) * Time.deltaTime * fuerzaRot, Space.World);
        }
        else if (dire == false)
        {
            transform.Rotate((-rotacion) * Time.deltaTime * fuerzaRot, Space.World);

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
