using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            transform.parent = other.transform;
            Debug.Log("Kolizja z platforma!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            transform.parent = null;
        }
    }
}
