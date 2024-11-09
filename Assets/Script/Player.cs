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
    [SerializeField] float slowDuration;
    [SerializeField] float speedDuration;

    int puntos;

    Rigidbody rb;

    float h;
    float v;    

    Vector3 Inicio;

    bool slow = false;
    bool speedX2 = false;
    
    float timerSlow;
    float timerSpeed;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Inicio = gameObject.transform.position;
        //rb.AddForce(Direccion * fuerzaMov, ForceMode.VelocityChange);

    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
       
        if (slow)
        {
            timerSlow -= Time.deltaTime;
            if (timerSlow < 0)
            {
                slow = false;
                Time.timeScale = 1.0f;

            }
        }
        if (speedX2)
        {
            timerSpeed -= Time.deltaTime;
        }
       

        if (DetectaSuelo())
        {
            Salto();
        }

    }

    private void FixedUpdate()
    {
        if (speedX2)
        {
            rb.AddForce(new Vector3(h, 0, v).normalized * fuerzaMov * 2, ForceMode.Force);
        }
        else
        {
            rb.AddForce(new Vector3(h, 0, v).normalized * fuerzaMov, ForceMode.Force);
        }

    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(new Vector3(0, 1, 0) * fuerzaSalto, ForceMode.Impulse);
            
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
        if (other.CompareTag("BoostSlow"))
        {
            Time.timeScale = 0.5f;
            slow = true;
            timerSlow = slowDuration;
            Debug.Log(slow);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BoostSpeed"))
        {
            speedX2 = true;
            timerSpeed = speedDuration;

            Destroy(other.gameObject);
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
