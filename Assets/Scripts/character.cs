using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public int hp = 100;
    public bool ai = true;
    public bool player = false;
    public int damage;
    [SerializeField]
    private GameObject img;

    void Dead() 
    {
        if (player)
        {
            Debug.Log($"Player dead by: {null}");
            img.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    void DamageMe(int damage)
    {
        if (hp > 0 && hp > damage) { hp = hp - damage; }
        else if (hp > 0 && hp < damage) { Dead(); }
    }
    void Update()
    {
        if (hp <= 0) { Dead(); }
    }
}
