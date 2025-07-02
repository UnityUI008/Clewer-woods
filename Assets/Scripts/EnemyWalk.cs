using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWalk : MonoBehaviour
{
    public Transform target;
    public LayerMask obstacleMask;
    private bool enter = false;

    // private Rigidbody2D body;
    public float speed = 3f;

    void Start()
    {
        // body = GetComponent<Rigidbody2D>();
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player"))
        {
            character PlayerCharacter = other.GetComponent<character>();
            if (PlayerCharacter != null)
            {
                PlayerCharacter.DamageMe(GetComponent<character>().damage, gameObject.name);

            }
        }
    }
    */

    void Update()
    {
        if (GetComponent<character>().ai)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            // Проверка прямой видимости
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, obstacleMask);
            if (hit.collider == null)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                // здесь можно добавить обход или стоять
            }
        }
    }
}
