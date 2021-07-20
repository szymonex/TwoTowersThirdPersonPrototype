using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        collision.transform.parent = transform;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        collision.transform.parent = null;
    //    }
    //}
}
