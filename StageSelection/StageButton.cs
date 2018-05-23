using UnityEngine;
using UnityEngine.UI;

class StageButton: MonoBehaviour
{
    Button button;
    [SerializeField] Image background;
    [SerializeField] Stage stage;

    private void Awake()
	{
		SetButton();
		button.onClick.AddListener(() => stage.LoadStage());
	}

	private void OnEnable()
	{
		if (stage.cleared == true)
			SetInactive();
	}

	private void SetButton()
	{
		try
		{
			button = Utilities.GetComponent<Button>(gameObject);
		}
		catch (System.Exception ex)
		{
			Debug.LogError(ex.Message);
			Utilities.StopEditorApplication();
		}
	}

	void SetInactive()
	{
		SetBackground(Color.black);
		button.interactable = false;
		DisableSound();
	}

	void SetBackground(Color color)
	{
		if (background != null)
			background.color = color;
		else
		{
			string message = string.Format("Reference to background is not set on {0}", gameObject.name);
			Debug.LogWarning(message);
		}
	}

	private void DisableSound()
	{
		ButtonSound sound = button.gameObject.GetComponent<ButtonSound>();
		if (sound != null)
			sound.enabled = false;
	}
}
