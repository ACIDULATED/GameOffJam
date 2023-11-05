using System.Collections;
using TMPro;
using UnityEngine;

public class TextReveal : MonoBehaviour
{
    private TMP_Text textComponent;
    private bool hasTextChanged;
    public float textTime = 0.05f;
    public AudioSource auSo;
    void Awake()
    {
        textComponent = gameObject.GetComponent<TMP_Text>();
    }


    void Start()
    {
        //StartCoroutine(RevealWords(m_TextComponent));
    }


    void OnEnable()
    {
        // Subscribe to event fired when text object has been regenerated.
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
    }

    void OnDisable()
    {
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
    }


    // Event received when the text object has changed.
    void ON_TEXT_CHANGED(Object obj)
    {
        hasTextChanged = true;
    }


    /// <summary>
    /// Method revealing the text one character at a time.
    /// </summary>
    /// <returns></returns>
    public IEnumerator RevealCharacters(DialogueLine dl)
    {
        textComponent.text = dl.text;
        auSo.clip = dl.clip;
        textComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = textComponent.textInfo;

        int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
        int visibleCount = 0;

        while (visibleCount <= totalVisibleCharacters)
        {

            textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?
            visibleCount += 1;
            auSo.Play();

            yield return new WaitForSeconds(dl.textSpeed);
        }
    }
}