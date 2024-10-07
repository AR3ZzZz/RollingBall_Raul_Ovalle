using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int fuerzaSalto;
    [SerializeField] int fuerzaMov;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector3(h,0,v).normalized * fuerzaMov, ForceMode.Force);

        Salto();

    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * fuerzaSalto, ForceMode.Impulse);
        }
    }

}
