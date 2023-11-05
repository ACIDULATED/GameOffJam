using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : MonoBehaviour, IInteractable
{
    public DialogueLine[] dl;
    public Dialogue d;
    public void Interact()
    {
        StartCoroutine(d.playDialogue(dl));
    }
}
