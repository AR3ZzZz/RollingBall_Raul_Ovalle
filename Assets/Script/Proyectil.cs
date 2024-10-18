using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float velocidad;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }
}
