using UnityEngine;

public class DestroyingBullet : MonoBehaviour
{
    [SerializeField] float delay = 3.0f;

    private void Start()
    {
        Destroy(gameObject, delay);
    }
}
