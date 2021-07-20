using UnityEngine;

public class TrapController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameManager.Instance.ShowGameOverPanel();
            Destroy(collision.gameObject);
        }
    }
}
