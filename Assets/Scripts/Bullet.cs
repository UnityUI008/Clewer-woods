using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeDestroy = 3f;
    public float speed = 3f;
    private Rigidbody2D rb;
    const int layerMaskOnlyPlayer = 1 << 8;
    int layerMaskWithoutPlayer = ~layerMaskOnlyPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        rb.velocity = transform.up * speed;
        Invoke("DestroyBullet", timeDestroy);

        // Проверяем, есть ли объекты на пути пули
        CheckForCollision();
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    void CheckForCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, speed * Time.deltaTime, layerMaskWithoutPlayer);
        if (hit.collider != null)
        {
            // Если луч попал в какой-либо объект, уничтожаем пулю
            DestroyBullet();
        }
    }

    void FixedUpdate()
    {
        // Проверяем на столкновение каждый фрейм
        CheckForCollision();
    }
}