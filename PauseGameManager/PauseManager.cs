
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PauseManager : MonoBehaviour, IPauseManager
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject weaponMenu;

    MusicManager music;
	const string musicObjectTag = "Music";
    AudioSource audioSource;
    [SerializeField] AudioClip sound;

    PauseStateManager pause;

	private const string mainSceneName = "Title";

	public void DisablePausing()
	{
		enabled = false;
	}

	private void Awake()
    {
        SetReferences();
    }

    private void SetReferences()
    {
        music = GameObject.FindGameObjectWithTag(musicObjectTag).GetComponent<MusicManager>();
        audioSource = GetComponent<AudioSource>();
        PauseAudioSettings pauseAudio = new PauseAudioSettings(audioSource, music, sound);
        pause = new PauseStateManager(pauseMenu, weaponMenu, pauseAudio);
    }

    private void Update()
    {
        pause.SelectPauseMenu();
        pause.SelectWeaponMenu();
    }

	public void Continue()
	{
		pause.DeactivatePauseMenu();
		pause.currentState = pause.unpausedState;
	}

	public void Quit()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(mainSceneName);
		music.Stop();
		Time.timeScale = 1;
	}
}
