using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] GameObject player;
    Vector3 direccion;
    void Start()
    {
         direccion = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-direccion.normalized * velocidad * Time.deltaTime);
    }
}
