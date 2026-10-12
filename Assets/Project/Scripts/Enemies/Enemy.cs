
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
   [SerializeField] private Transform target;
  [SerializeField] private float moveSpeed = 1.5f;
   private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        Vector2 nextPosition = Vector2.MoveTowards(_rb.position, target.position ,moveSpeed*Time.fixedDeltaTime);
        _rb.MovePosition(nextPosition);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
