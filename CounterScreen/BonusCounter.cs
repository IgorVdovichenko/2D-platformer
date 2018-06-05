using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public abstract class BonusCounter: MonoBehaviour
{
	[SerializeField]
	protected AudioClip sound;
	protected AudioSource audioSource;
	[SerializeField]
	protected Text levelBonus;
	[SerializeField]
	protected IntValue points;
	protected const int delta = 10000;
	[SerializeField]
	protected Stage stage;

	protected const float delayBeforeCount = 2f;
	protected const float iterationDelay = 0.1f;

	private Text[] texts;
	protected const string textFormat = "000000";

	public UnityEvent onDone;

	protected void Awake()
	{
		texts = GetComponentsInChildren<Text>();
		SetAudioComponent();
		Hide();
	}

	private void SetAudioComponent()
	{
		try
		{
			audioSource = GetAudioSource();
		}
		catch (System.Exception ex)
		{
			Debug.LogError(ex.Message);
			if (UnityEditor.EditorApplication.isPlaying == true)
				UnityEditor.EditorApplication.isPlaying = false;
		}
	}

	private AudioSource GetAudioSource()
	{
		AudioSource output;
		output = GetComponent<AudioSource>();
		if (output == null)
		{
			string message =
				string.Format("Game object {0} misses Audio Source component", gameObject.name);
			throw new System.Exception(message);
		}
		else
			return output;
	}

	protected virtual void Show()
	{
		EnableText(true);
	}

	protected virtual void Hide()
	{
		EnableText(false);
	}

	private void EnableText(bool on)
	{
		foreach (var item in texts)
		{
			item.enabled = on;
		}
	}

	public void Activate(float delay)
	{
		StartCoroutine(Activation(delay));
	}

	private IEnumerator Activation(float delay)
	{
		yield return new WaitForSeconds(delay);
		Show();
		StartCoroutine(CalculatePoints());
	}

	protected abstract IEnumerator CalculatePoints();
}
