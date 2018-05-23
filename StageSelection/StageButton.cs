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
			button = GetButton();
		}
		catch (System.Exception ex)
		{
			Debug.LogError(ex.Message);
			if (UnityEditor.EditorApplication.isPlaying == true)
			{
				UnityEditor.EditorApplication.isPlaying = false;
			}
		}
	}

	private Button GetButton()
	{
		Button output = GetComponent<Button>();
		if (output == null)
		{
			string message =
				string.Format("Game object {0} misses required Button component", gameObject.name);
			throw new System.Exception(message);
		}
		else
			return output;
	}

	void SetInactive()
	{
		background.color = Color.black;
		button.interactable = false;
		DisableSound();
	}

	private void DisableSound()
	{
		ButtonSound sound = button.gameObject.GetComponent<ButtonSound>();
		if (sound != null)
			sound.enabled = false;
	}
}
