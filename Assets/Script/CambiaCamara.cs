using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamara : MonoBehaviour
{
    [SerializeField] GameObject camaraNormal;
    [SerializeField] GameObject camaraCenital;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            camaraNormal.SetActive(false);
            camaraCenital.SetActive(true);
        }
    }
}
