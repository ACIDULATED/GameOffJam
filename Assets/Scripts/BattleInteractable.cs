using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleInteractable : MonoBehaviour, IInteractable
{
    public DialogueLine[] dl;
    public Dialogue d;
    public string scene;
    public void Interact()
    {
        StartCoroutine(Battle());
    }
    IEnumerator Battle()
    {
        yield return StartCoroutine(d.playDialogue(dl));
        SceneManager.LoadScene(scene);
    }
}
