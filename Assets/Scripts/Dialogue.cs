using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public TextReveal tr;
    public InputActionReference submit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public IEnumerator playDialogue(DialogueLine[] dl)
    {
        for (int i = 0; i < dl.Length; i++)
        {
            StartCoroutine(tr.RevealCharacters(dl[i]));
            while (!submit.action.triggered)
            { 
                yield return null;
            }
        }
    }

    void OnSubmit()
    {

    }
}

[System.Serializable]
public class DialogueLine
{
   public string text;
   public AudioClip clip;
   public float textSpeed = 0.05f;
}