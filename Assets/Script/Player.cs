using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] int fuerzaSalto;
    [SerializeField] int fuerzaMov;
    [SerializeField] TMP_Text puntosText;
    [SerializeField] Vector3 Direccion;
    int puntos;
    Rigidbody rb;
    float h;
    float v;
    Vector3 Inicio;
    int saltosPosibles = 0;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Inicio = gameObject.transform.position;
        rb.AddForce(Direccion * fuerzaMov, ForceMode.VelocityChange);

    }

    void Update()
    {
       // h = Input.GetAxisRaw("Horizontal");
       // v = Input.GetAxisRaw("Vertical");

       

        Salto();

    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(h, 0, v).normalized * fuerzaMov, ForceMode.Force);
    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && saltosPosibles > 0 )
        {
            rb.AddForce(new Vector3(0, 1, 0) * fuerzaSalto, ForceMode.Impulse);
            saltosPosibles--;   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable")) 
        {
         puntos += 3;
         puntosText.SetText("Score: " + puntos);
         Destroy(other.gameObject);    
        }
        if (other.CompareTag("Vacio"))
        {
            rb.isKinematic = true;
            gameObject.transform.position = Inicio;
            rb.isKinematic = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            if (saltosPosibles < 1)
            {
                saltosPosibles++;
            }
            Debug.Log(saltosPosibles);


        }
    }

}
