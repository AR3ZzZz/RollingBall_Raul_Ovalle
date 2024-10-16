using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedCubos : MonoBehaviour
{
    bool iniciarTimer = false;
    float timer = 0;
    [SerializeField] Rigidbody[] rb;


    private void Start()
    {
        rb = GetComponentsInChildren<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (iniciarTimer)
        {
            timer += Time.unscaledDeltaTime;
            if (timer > 4)
            {
                Time.timeScale = 1f;
                for (int i = 0; i < rb.Length; i++)
                {
                    rb[i].useGravity = true;
                }
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            iniciarTimer = true;
            Time.timeScale = 0.2f;
        }
    }
}
