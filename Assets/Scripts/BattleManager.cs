using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject charPanel;
    public GameObject fightPanel;
    public GameObject enemyPanel;
    public GameObject inventoryPanel;
    public GameObject handQTE;
    public GameObject knifeQTE;
    public GameObject enemyTurnPanel;
    public TMP_Text statusText;
    public RectTransform cursor;
    public float knifeWaitTime = 0.5f;
    bool qteSuccess = false;
    Enemy[] enemies;
    int currentlySelected;
    enum State { KnifeQTE,HandsQTE, Selection, none }
    String quickTimeEvent;
    State state;
    bool select;
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;
    public GameObject ZKey;
    public int maxHP = 100;
    public int HP = 100;
    public int knifeDmg = 15;
    public int punchDmg = 35;
    public int defense = 5;
    int mashCounter;
    public TMP_Text mashCounterText;
    public Image hpBar;
    public TMP_Text hpText; 
    // Start is called before the first frame update
    void Start()
    {
        enemies = enemyPanel.GetComponentsInChildren<Enemy>();
        print(enemies.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnFight()
    {
        mainPanel.SetActive(false);
        fightPanel.SetActive(true);
    }
    public void OnHands()
    {
        fightPanel.SetActive(false);
        cursor.gameObject.SetActive(true);
        currentlySelected = 0;
        cursor.SetParent(enemies[currentlySelected].transform);
        cursor.anchoredPosition = Vector2.zero;
        state = State.Selection;
        quickTimeEvent = "HandsEvent";

    }
    public void OnKnife()
    {
        fightPanel.SetActive(false);
        cursor.gameObject.SetActive(true);
        currentlySelected = 0;
        cursor.SetParent(enemies[currentlySelected].transform);
        cursor.anchoredPosition = Vector2.zero;
        state = State.Selection;
        quickTimeEvent = "KnifeEvent";
    }
    public void OnInventory()
    {

    }

    public void OnTwins()
    {
        // do nothing, maybe play a sound
    }

    public void OnFlee()
    {

    }

    IEnumerator EnemyTurn()
    {
        enemyTurnPanel.SetActive(true);
        foreach(Enemy i in enemies)
        {
            TakeDamage(i.attack);
            statusText.text = i.name + " attacked!";
            //play attack effect
            yield return new WaitForSeconds(3);
        }
        enemyTurnPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    IEnumerator HandsEvent()
    {
        state = State.HandsQTE;
        handQTE.SetActive(true);
        mashCounter = 0;
        mashCounterText.text = "3";
        yield return new WaitForSeconds(1);
        mashCounterText.text = "2";
        yield return new WaitForSeconds(1);
        mashCounterText.text = "1";
        state = State.none;
        enemies[currentlySelected].TakeDamage(Mathf.Min(2 * mashCounter, punchDmg));
        yield return new WaitForSeconds(1);
        handQTE.SetActive(false);
        StartCoroutine(EnemyTurn());
    }
    IEnumerator KnifeEvent()
    {
        state = State.KnifeQTE;
        redLight.SetActive(false);
        yellowLight.SetActive(false);
        greenLight.SetActive(false);
        ZKey.SetActive(false);
        knifeQTE.SetActive(true);
        redLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        yellowLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        greenLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ZKey.SetActive(true);
        qteSuccess = false;
        yield return new WaitForSeconds(knifeWaitTime);
        if (qteSuccess == true)
        {
            enemies[currentlySelected].TakeDamage(knifeDmg);
        }
        state = State.none;
        yield return new WaitForSeconds(1);
        knifeQTE.SetActive(false);
        StartCoroutine(EnemyTurn());
    }

    void OnInteract()
    {
        if (state == State.KnifeQTE)
            qteSuccess = true;
        if (state == State.HandsQTE)
            mashCounter += 1;
        if (state == State.Selection)
            OnSelect();
    }
    void OnLeft()
    {
        print("On Left");
        if (state == State.Selection)
        {
            print("On Left If");
            currentlySelected -= 1;
            if (currentlySelected < 0)
                currentlySelected = enemies.Length - 1;
            print(currentlySelected);
            cursor.SetParent(enemies[currentlySelected].transform);
            cursor.anchoredPosition = Vector2.zero;
        }
    }
    void OnRight()
    {
        print("On Right");
        if (state == State.Selection)
        {
            print("On Right If");
            currentlySelected += 1;
            if (currentlySelected > enemies.Length - 1)
                currentlySelected = 0;
            print(currentlySelected);
            cursor.SetParent(enemies[currentlySelected].transform);
            cursor.anchoredPosition = Vector2.zero;
        }
    }

    private void OnSelect()
    {
        cursor.gameObject.SetActive(false);
        StartCoroutine(quickTimeEvent);
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            GameOver();
        }
        UpdateUI();
    }
    void UpdateUI()
    {
        hpBar.fillAmount = (float)HP / maxHP;
        hpText.text = "HP: " + HP + "/" + maxHP;
    }
    void GameOver()
    {

    }
}
