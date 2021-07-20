using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunBarrel;
    [SerializeField] private float bulletForce;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float lastShot = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if(Time.time > lastShot + fireRate)
        {
            var bulletClone = Instantiate(bullet, gunBarrel.transform.position, Quaternion.identity);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(gunBarrel.transform.up * bulletForce * Time.deltaTime, ForceMode.Impulse);

            lastShot = Time.time;
        }
        else
        {
            Debug.Log("Can't fire. The interval between shots is too short!");
        }
    }
}
