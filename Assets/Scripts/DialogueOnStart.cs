using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnStart : MonoBehaviour
{
    public DialogueLine[] dl;
    public Dialogue d;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(d.playDialogue(dl));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
