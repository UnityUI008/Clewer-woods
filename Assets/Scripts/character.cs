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

    void Dead(string name) 
    {
        if (player)
        {
            Debug.Log($"Player dead by: {name}");
            img.gameObject.SetActive(true);
            Destroy(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    public void DamageMe(int damage, string name)
    {
        if (hp > 0 && hp > damage) { hp = hp - damage; }
        else if (hp > 0 && hp < damage) { Dead(name); }
        else if (hp <= 0 || hp < damage) { Dead(name); }
        else { hp -= damage; }
    }
    void Update()
    {
        if (hp <= 0) { Dead("Update"); }
    }
}
