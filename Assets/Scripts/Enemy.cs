using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public int maxHP = 100;
    public Image spr;
    public int attack = 10;
    public TMP_Text hpText;
    public Image hpBar;

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
        UpdateUI();
    }
    void UpdateUI()
    {
        hpBar.fillAmount = (float)hp / maxHP;
        hpText.text = "HP: " + hp + "/" + maxHP;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}