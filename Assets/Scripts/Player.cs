using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Text hptext;

    void Update()
    {
        string hptext = gameObject.GetComponent<character>().hp.ToString();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}