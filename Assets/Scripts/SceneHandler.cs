using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public string returnScene;
    public Vector3 returnPos;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == returnScene)
        {
            var player = FindObjectOfType<Player>().transform.position = returnPos;
            Destroy(gameObject);
        }
    }
}
