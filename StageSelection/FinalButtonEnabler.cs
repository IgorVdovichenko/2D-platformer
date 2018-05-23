using UnityEngine;

public class FinalButtonEnabler: IActivator
{
    public GameObject FinalButton { get; set; }
    public GameObject CentralText { get; set; }

    public FinalButtonEnabler(GameObject finalButton, GameObject centralText)
    {
        FinalButton = finalButton;
        CentralText = centralText;
    }

    public void Activate()
    {
        FinalButton.SetActive(true);
        CentralText.SetActive(false);
    }

	public void Deactivate()
	{
		FinalButton.SetActive(false);
		CentralText.SetActive(true);
	}
}
