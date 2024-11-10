using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack : MonoBehaviour
{
    [SerializeField] GameObject balaSpawn;
    [SerializeField] GameObject balaAliada;
    [SerializeField] GameObject balaDisparable;
    [SerializeField] Player player;
    Color redColor = Color.red;
    Color greenColor = Color.green;
    Renderer disparableColor;
    bool disparable;
    bool disparar;

    void Start()
    {
        disparar = false;
        disparable = false;
        balaDisparable.SetActive(false);
        disparableColor = balaDisparable.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!disparar)
        {
            if (player.Puntos >= 2 && disparable)
            {
                disparableColor.sharedMaterial.color = greenColor;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject clon;
                    clon = Instantiate(balaAliada, balaSpawn.transform.position, balaSpawn.transform.rotation);
                    player.Puntos -= 2;
                    balaDisparable.SetActive(false);
                    disparar = true;
                }
            }
            else
            {
                disparableColor.sharedMaterial.color = redColor;
            }
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!disparar)
        {
            if (other.CompareTag("Player"))
            {
                disparable = true;
                balaDisparable.SetActive(true);

            }
        }
           


    }

    private void OnTriggerExit(Collider other)
    {
        if (!disparar)
        {
            if (other.CompareTag("Player"))
            {
                disparable = false;
                balaDisparable.SetActive(false);

            }
        }
           

    }

    

    
}
