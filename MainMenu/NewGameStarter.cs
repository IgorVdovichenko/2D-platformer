using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class NewGameStarter : MonoBehaviour
{
    [SerializeField] AudioClip StartGameSound;
    [SerializeField] float delayBeforeStart;

    [SerializeField] string stageToLoad = "Selection";

    AudioSource audioSource;

    public float DelayBeforeStart
    {
        get
        {
            if (delayBeforeStart < 1) delayBeforeStart = 1;
            return delayBeforeStart;
        }
        set
        {
            if (value < 1) delayBeforeStart = 1;
            delayBeforeStart = value;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartNewGame()
    {
        audioSource.PlayOneShot(StartGameSound);
        DisableAllButtons();
        Invoke("Load", DelayBeforeStart);
    }

    void DisableAllButtons()
    {
        Button[] allButtons = FindObjectsOfType<Button>();

        foreach (var item in allButtons)
        {
            item.interactable = false;

            ButtonSound buttonSound = item.gameObject.GetComponent<ButtonSound>();
            if (buttonSound != null) buttonSound.active = false;
        }
    }

    void Load()
    {
        SceneManager.LoadScene(stageToLoad);
    }
}
