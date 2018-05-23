using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class NewGameStarter : MonoBehaviour
{
    [SerializeField] AudioClip StartGameSound;
    [SerializeField] float delayBeforeStart;
	private readonly float minDelay = 1f;

    [SerializeField] string stageToLoad = "Selection";

    AudioSource audioSource;

    public float DelayBeforeStart
    {
        get
        {
            if (delayBeforeStart < minDelay)
				delayBeforeStart = minDelay;
            return delayBeforeStart;
        }
        set
        {
            if (value < minDelay)
				delayBeforeStart = minDelay;
            delayBeforeStart = value;
        }
    }

    private void Awake()
    {
        SetAudioSource();
    }

	private void SetAudioSource()
	{
		try
		{
			audioSource = Utilities.GetComponent<AudioSource>(gameObject);
		}

		catch (System.Exception ex)
		{
			Debug.LogError(ex.Message);
			Utilities.StopEditorApplication();
		}
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

        foreach (var button in allButtons)
		{
			button.interactable = false;
			DisableButtonSounds(button);
		}
	}

	private void DisableButtonSounds(Button button)
	{
		ButtonSound buttonSound = button.gameObject.GetComponent<ButtonSound>();
		if (buttonSound != null)
			buttonSound.enabled = false;
	}

	void Load()
    {
        SceneManager.LoadScene(stageToLoad);
    }
}

