using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Spawn : MonoBehaviour
{
    public GameObject sessaomapa; 

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Triged")) 
        {
            Instantiate(sessaomapa, new Vector3(0, 0, -57), Quaternion.identity); 
        }
    }
}
