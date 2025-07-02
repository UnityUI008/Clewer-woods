using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    public float timeDestroy = 3f;
    public float speed = 15f;
    public int damage;
    private Rigidbody2D rb;
    /*
    const int layerMaskOnlyPlayer = 1 << 8;
    int layerMaskWithoutPlayer = ~layerMaskOnlyPlayer;
    */

    void Start()
    {
        damage = Player.GetComponent<character>().damage;
        rb = GetComponent<Rigidbody2D>();

        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        rb.velocity = transform.up * speed;
        Invoke(nameof(DestroyBullet), timeDestroy);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.CompareTag("Enemy"))
        {
            character enemyCharacter = other.GetComponent<character>();
            if (enemyCharacter != null)
            {
                enemyCharacter.DamageMe(damage, gameObject.name);
                DestroyBullet();
            }
        }
        else if (other.CompareTag("Player") == false) 
        {
            DestroyBullet();            
        }
    }
}
