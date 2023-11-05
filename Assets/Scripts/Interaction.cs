using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    void Interact();
}
public class Interaction : MonoBehaviour
{
    IInteractable interactable;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      text.SetActive(interactable != null);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null)
        {
            interactable = other.GetComponent<IInteractable>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        interactable = null;
    }

    void OnInteract()
    {
        if (interactable != null)
            interactable.Interact();
        GetComponent<Player>().enabled = false;
        enabled = false;
        GetComponent<PlayerInput>().enabled = false;
    }
}
