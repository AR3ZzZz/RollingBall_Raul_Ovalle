using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Targeteo")]
    [SerializeField] float minDistance;
    [SerializeField] Transform target;
    
    [SerializeField] float smooth;

    [Header("RayoBoss")]
    [SerializeField] float rayDistance;
    [SerializeField] Transform rayOrigin;
    [SerializeField] int rayDmg;
     LineRenderer lineRenderer;

    
    private Vector3 currentVelocity;
    [SerializeField] int vidas;
    [SerializeField] GameManager gameManager;



    void Start()
    {
        vidas = 4;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.material.color = Color.red;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
    }

    void Update()
    {
        DisparoActivo();
       
        if (vidas <= 0 ) 
        {
            gameManager.Win();
        }
    }
    public bool DisparoActivo()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDistance && target != null)
        {
            Vector3 dirATarget = (target.transform.position - transform.position).normalized;
            transform.forward = Vector3.SmoothDamp(transform.forward, dirATarget, ref currentVelocity, smooth);
            lineRenderer.SetPosition(1, transform.position + transform.forward * rayDistance);
            RayoBoss();            
            bool dentroDeRango = true;
            return dentroDeRango;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vidas--;
            Destroy(other.gameObject);
        }

    }
    

    void RayoBoss()
    {
        if (Physics.Raycast(rayOrigin.position, transform.forward, out RaycastHit hitInfo, minDistance))
        {
            if (hitInfo.transform.CompareTag("Player")) 
            {
                hitInfo.transform.GetComponent<Player>().RecibirDanho(rayDmg);                
            }
        }
        Debug.DrawRay(rayOrigin.position, transform.forward * minDistance, Color.red);
    }
}
