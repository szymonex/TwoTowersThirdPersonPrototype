using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTargetController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            GameManager.Instance.ShotDownObjectsCounterUpdate();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
