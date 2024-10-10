using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaloGolpeador : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]Vector3 direccionR;
    [SerializeField]int fuerza;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(direccionR * fuerza, ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

    }
}
