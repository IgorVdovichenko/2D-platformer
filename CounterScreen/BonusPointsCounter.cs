using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class BonusPointsCounter : MonoBehaviour
{
	[SerializeField]
	private AudioClip sound;
	private AudioSource audioSource;
	[SerializeField]
	private Text levelBonus;
	[SerializeField]
	private IntValue points;
	private readonly int delta = 10000;
	[SerializeField]
	private Stage stage;

	private const float delayBeforeCount = 2f;
	private const float iterationDelay = 0.1f;

	private readonly string textFormat = "000000";

	public UnityEvent onDone;

	private void Awake()
	{
		levelBonus.text = textFormat;
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

	IEnumerator CalculatePoints()
	{
		yield return new WaitForSeconds(delayBeforeCount);

		for (int i = delta; i <= stage.BonusPoints; i += delta)
		{
			points.value += delta;
			levelBonus.text = i.ToString(textFormat);
			audioSource.PlayOneShot(sound);
			yield return new WaitForSeconds(iterationDelay);
		}
		onDone.Invoke();
	}

	private void Hide()
	{
		Text[] texts = GetComponentsInChildren<Text>();
		foreach (var item in texts)
		{
			item.enabled = false;
		}
	}

	private void Show()
	{
		Text[] texts = GetComponentsInChildren<Text>();
		foreach (var item in texts)
		{
			item.enabled = true;
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
}
