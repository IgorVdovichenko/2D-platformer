
public class PauseMenuState : IPause
{
    PauseStateManager pauseStateManager;

    public PauseMenuState(PauseStateManager pauseStateManager)
    {
        this.pauseStateManager = pauseStateManager;
    }

    public void SelectPauseMenu()
    {
        pauseStateManager.DeactivatePauseMenu();
        pauseStateManager.currentState = pauseStateManager.unpausedState;
    }

    public void SelectWeaponsMenu() { }
}
