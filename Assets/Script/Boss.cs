using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float minDistance;
    [SerializeField] Transform target;
    [SerializeField] bool batalla = true;
    [SerializeField] float smooth;
    [SerializeField] float distanciaRayo;

    private Vector3 currentVelocity;
    Vector3 rayOrigin;
    Vector3 rayDirection;

    public bool Batalla { get => batalla; set => batalla = value; }

    void Start()
    {

    }

    void Update()
    {
        RayoBoss();

        if (batalla)
        {
            if (DisparoActivo())
            {


            }
        }

    }
    public bool DisparoActivo()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < minDistance && target != null)
        {
            Vector3 dirATarget = (target.transform.position - transform.position).normalized;
            transform.forward = Vector3.SmoothDamp(transform.forward, dirATarget, ref currentVelocity, smooth);
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
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, distanciaRayo))
        {
            if (hitInfo.collider.name == "Player")
            {
                Debug.Log("PlayerHit");
            }
        }
        Debug.DrawRay(rayOrigin, rayDirection * distanciaRayo, Color.red);
    }
}
