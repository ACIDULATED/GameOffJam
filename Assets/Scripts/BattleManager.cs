using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject charPanel;
    public GameObject fightPanel;
    public GameObject enemyPanel;
    public GameObject inventoryPanel;
    public GameObject handQTE;
    public GameObject knifeQTE;
    public RectTransform cursor;
    public float knifeWaitTime = 0.5f;
    bool qteSuccess = false;
    Enemy[] enemies;
    int currentlySelected;
    enum State { QTE, Selection, none }
    String quickTimeEvent;
    State state;
    bool select;
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
        handQTE.SetActive(true);
        StartCoroutine(HandsEvent());
        
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
        yield return null;
    }
    IEnumerator HandsEvent()
    {
        yield return null;
    }
    IEnumerator KnifeEvent()
    {
        knifeQTE.SetActive(true);
        //change text at bottom
        //turn on red light
        yield return new WaitForSeconds(0.5f);
        //turn on yellow light
        yield return new WaitForSeconds(0.5f);
        //turn on green light
        yield return new WaitForSeconds(0.5f);
        //turn on Z button
        qteSuccess = false;
        yield return new WaitForSeconds(knifeWaitTime);
        if (qteSuccess == true)
        {
            //do damage
        }
    }

    void OnInteract()
    {
        if (state == State.QTE)
            qteSuccess = true;
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
        StartCoroutine(quickTimeEvent);
    }
}
