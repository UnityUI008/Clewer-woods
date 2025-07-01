using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}