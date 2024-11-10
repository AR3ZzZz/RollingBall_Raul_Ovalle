using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] int jumpHeight;
    [SerializeField] int jumpadForce;
    [SerializeField] int movForce;
    [SerializeField] TMP_Text puntosText;
    [SerializeField] GameManager gameManager;
    [SerializeField] Vector3 Direccion;
    [SerializeField] float RayDistance;
    [SerializeField] float slowDuration;
    [SerializeField] float speedDuration;

    int generelDmg = 1;
    int hp = 2;
    int puntos;

    Rigidbody rb;

    float h;
    float v;    

    Vector3 spawnPos;

    bool slow = false;
    bool speedX2 = false;
    
    float timerSlow;
    float timerSpeed;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPos = gameObject.transform.position;
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
            rb.AddForce(new Vector3(h, 0, v).normalized * movForce * 2, ForceMode.Force);
        }
        else
        {
            rb.AddForce(new Vector3(h, 0, v).normalized * movForce, ForceMode.Force);
        }

    }

    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(new Vector3(0, 1, 0) * jumpHeight, ForceMode.Impulse);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable")) 
        {
         puntos += 1;
         puntosText.SetText("Balas: " + puntos);
         Destroy(other.gameObject);    
        }
        if (other.CompareTag("Vacio"))
        {
            rb.isKinematic = true;
            gameObject.transform.position = spawnPos;
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
        if (other.CompareTag("Danho"))
        {
            RecibirDanho(generelDmg);
        }
        if (other.CompareTag("Bullet"))
        {
            RecibirDanho(generelDmg);
            Destroy(other.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpPad"))
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpadForce, ForceMode.VelocityChange);
        }
    }

    bool DetectaSuelo()
    {
        bool detectaSuelo = Physics.Raycast(gameObject.transform.position, Vector3.down, RayDistance);
        Debug.DrawRay(gameObject.transform.position, Vector3.down, Color.red, 1f);
        return detectaSuelo;
    }

    public void RecibirDanho(int x)
    {
        hp -= x;
        Muerte();
    }

    void Muerte()
    {
        if(hp <= 0)
        {
            gameManager.Lose();
        }
    }

}
