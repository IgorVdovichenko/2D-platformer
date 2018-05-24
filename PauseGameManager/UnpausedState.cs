
public class UnpausedState : IPause
{
    PauseStateManager pauseStateManager;

    public UnpausedState(PauseStateManager pauseStateManager)
    {
        this.pauseStateManager = pauseStateManager;
    }

    public void SelectPauseMenu()
    {
        pauseStateManager.ActivatePauseMenu();
        pauseStateManager.currentState = pauseStateManager.pauseMenuState;
    }

    public void SelectWeaponsMenu()
    {
        pauseStateManager.ActivateWeaponMenu();
        pauseStateManager.currentState = pauseStateManager.weaponMenuState;
    }
}
