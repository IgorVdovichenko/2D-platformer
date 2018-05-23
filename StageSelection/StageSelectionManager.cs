using UnityEngine;
using UnityEngine.UI;

public class StageSelectionManager : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject text;
    [SerializeField] Button[] buttons;

    IActivator buttonActivator;

    [Header("Music Settings")]
    [SerializeField] AudioClip musicClip;
    IControlAudio music;
	private readonly string musicTag = "Music";

    private void Awake()
    {
		SetMusicComponent();
		buttonActivator = new FinalButtonEnabler(button, text);
    }

    private void Start()
    {
		SetFinalStageButtonStatus();
		PlayMusic();
	}

	private void SetMusicComponent()
	{
		GameObject obj = GameObject.FindGameObjectWithTag(musicTag);
		if (obj == null)
		{
			string message = string.Format("Game object tagged {0} not found!", musicTag);
			Debug.LogError(message);
		}
		music = obj.GetComponent<IControlAudio>();
		if (music == null)
		{
			string message =
				string.Format("Game object tagged {0} misses IControlAudio component", musicTag);
		}
	}

	private void SetFinalStageButtonStatus()
	{
		if (Utilities.AllButtonsInactive(buttons))
			buttonActivator.Activate();
		else
			buttonActivator.Deactivate();
	}

	private void PlayMusic()
	{
		if (music != null)
		{
			music.SetClip(musicClip);
			music.Play();
		}
	}
}
