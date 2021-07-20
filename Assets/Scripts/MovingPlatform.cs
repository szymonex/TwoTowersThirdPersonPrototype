using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed = 0.8f;
    [SerializeField] private Transform startPointObj;
    [SerializeField] private Transform endPointObj;

    private Vector3 currentPosition;
    private Vector3 startPoint;
    private Vector3 endPoint;

    void Start()
    {
        startPoint = startPointObj.transform.position;
        endPoint = endPointObj.transform.position;
        Destroy(startPointObj.gameObject);
        Destroy(endPointObj.gameObject);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        currentPosition = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currentPosition;
    }
}
