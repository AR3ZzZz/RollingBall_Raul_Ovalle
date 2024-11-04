using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Targeteo")]
    [SerializeField] float minDistance;
    [SerializeField] Transform target;
    [SerializeField] bool batalla = true;
    [SerializeField] float smooth;

    [Header("RayoBoss")]
    [SerializeField] float distanciaRayo;
    [SerializeField] Transform rayOrigin;
     LineRenderer lineRenderer;

    
    private Vector3 currentVelocity;

    public bool Batalla { get => batalla; set => batalla = value; }

    void Start()
    {
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
        //RayoBoss();

        //if (batalla)
        //{
        //    if (DisparoActivo())
        //    {


        //    }
        //}

    }
    public bool DisparoActivo()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDistance && target != null)
        {
            Vector3 dirATarget = (target.transform.position - transform.position).normalized;
            transform.forward = Vector3.SmoothDamp(transform.forward, dirATarget, ref currentVelocity, smooth);
            lineRenderer.SetPosition(1, transform.position + transform.forward * distanciaRayo);
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
            batalla = true;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }

    void RayoBoss()
    {
        if (Physics.Raycast(rayOrigin.position, transform.forward, out RaycastHit hitInfo, distanciaRayo))
        {                       
            Debug.Log("Rayo alcanz�: " + hitInfo.collider.name);
            //lineRenderer.SetPosition(1, hitInfo.collider.transform.position);

        }
        Debug.DrawRay(rayOrigin.position, transform.forward * distanciaRayo, Color.green);
    }
}
