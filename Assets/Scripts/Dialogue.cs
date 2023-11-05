using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public TextReveal tr;
    public InputActionReference submit;
    public GameObject box;
    public GameObject player;
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
        box.SetActive(true);
        for (int i = 0; i < dl.Length; i++)
        {
            yield return StartCoroutine(tr.RevealCharacters(dl[i]));
            while (!submit.action.triggered)
            { 
                yield return null;
            }
        }
        box.SetActive(false);
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<Interaction>().enabled = true;
        player.GetComponent<PlayerInput>().enabled = true;
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