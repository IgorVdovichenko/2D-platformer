
public class WeaponMenuState : IPause
{
    PauseStateManager pauseStateManager;

    public WeaponMenuState(PauseStateManager pauseStateManager)
    {
        this.pauseStateManager = pauseStateManager;
    }

    public void SelectPauseMenu() { }
    
    public void SelectWeaponsMenu()
    {
        pauseStateManager.DeactivateWeaponMenu();
        pauseStateManager.currentState = pauseStateManager.unpausedState;
    }
}
