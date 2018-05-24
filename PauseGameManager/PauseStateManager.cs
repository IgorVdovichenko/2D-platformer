
using UnityEngine;

public class PauseStateManager
{
    public IPause currentState { get; set; }
    public IPause unpausedState { get; set; }
    public IPause pauseMenuState { get; set; }
    public IPause weaponMenuState { get; set; }

    GameObject pauseMenu;
    GameObject weaponMenu;

    PauseAudioSettings audioSettings;

    public PauseStateManager(GameObject pauseMenu, GameObject weaponMenu, PauseAudioSettings audioSettings)
    {
        this.pauseMenu = pauseMenu;
        this.weaponMenu = weaponMenu;
        this.audioSettings = audioSettings;
        unpausedState = new UnpausedState(this);
        pauseMenuState = new PauseMenuState(this);
        weaponMenuState = new WeaponMenuState(this);
        currentState = unpausedState;
        pauseMenu.SetActive(false);
        weaponMenu.SetActive(false);
    }

    public void SelectPauseMenu()
    {
        if (Input.GetKeyDown("escape"))
            currentState.SelectPauseMenu();
    }

    public void SelectWeaponMenu()
    {
        if (Input.GetKeyDown("left ctrl"))
            currentState.SelectWeaponsMenu();
    }

    void PauseOn()
    {
        audioSettings.AudioSource.PlayOneShot(audioSettings.Sound);
        audioSettings.Music.Pause();
        Time.timeScale = 0;
    }

    void PauseOff()
    {
        audioSettings.AudioSource.PlayOneShot(audioSettings.Sound);
        audioSettings.Music.Play();
        Time.timeScale = 1;
    }

    public void ActivatePauseMenu()
    {
        PauseOn();
        pauseMenu.SetActive(true);
    }

    public void DeactivatePauseMenu()
    {
        PauseOff();
        pauseMenu.SetActive(false);
    }

    public void ActivateWeaponMenu()
    {
        PauseOn();
        weaponMenu.SetActive(true);
    }

    public void DeactivateWeaponMenu()
    {
        PauseOff();
        weaponMenu.SetActive(false);
    }
}
