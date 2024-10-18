using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] int fuerzaSalto;
    [SerializeField] int fuerzaPad;
    [SerializeField] int fuerzaMov;
    [SerializeField] TMP_Text puntosText;
    [SerializeField] Vector3 Direccion;
    [SerializeField] float distanciaRayo;
    int puntos;
    Rigidbody rb;
    float h;
    float v;
    Vector3 Inicio;
    //int saltosPosibles = 0;
    

    

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

       

        if (DetectaSuelo())
        {
            Salto();
        }

    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(h, 0, v).normalized * fuerzaMov, ForceMode.Force);
    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * fuerzaSalto, ForceMode.VelocityChange);
            
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
        if (collision.gameObject.CompareTag("JumpPad"))
        {
            rb.AddForce(new Vector3(0, 1, 0) * fuerzaPad, ForceMode.VelocityChange);
        }
    }

    bool DetectaSuelo()
    {
        bool detectaSuelo = Physics.Raycast(gameObject.transform.position, Vector3.down, distanciaRayo);
        Debug.DrawRay(gameObject.transform.position, Vector3.down, Color.red, 1f);
        return detectaSuelo;
    }

}
