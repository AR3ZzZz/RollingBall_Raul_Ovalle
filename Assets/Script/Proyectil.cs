using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] float velocidad;
    
    void Start()
    {
        Debug.Break();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.right * velocidad * Time.deltaTime);
    }
}
