using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] GameObject player;
    
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * velocidad * Time.deltaTime);
    }
}
