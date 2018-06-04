using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BallsCounter : MonoBehaviour
{
	[SerializeField] AudioClip sound;
	AudioSource audioSource;
	[SerializeField] Text bonusPoints;
	[SerializeField] Text ballsText;
	[SerializeField] IntValue points;
	[SerializeField] IntValue balls;
	[SerializeField] int pointsPerBall = 1000;
	private readonly int delta = 10000;
	[SerializeField] Stage stage;

	private readonly float delayBeforeCount = 2f;
	private readonly float iterationDelay = 0.1f;

	private readonly string textFormat = "000000";
	private readonly string ballsTextFormat = "-1000x00";

	private Text[] texts;
	private Image image;

	public UnityEvent onDone;

	private void Awake()
	{
		bonusPoints.text = textFormat;
		ballsText.text = ballsTextFormat;
		SetAudioComponent();
		texts = GetComponentsInChildren<Text>();
		image = GetComponentInChildren<Image>();
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

	private void Hide()
	{
		EnableText(false);
		image.enabled = false;
	}

	private void Show()
	{
		EnableText(true);
		image.enabled = true;
	}

	private void EnableText(bool on)
	{
		foreach (var item in texts)
		{
			item.enabled = on;
		}
	}

	private IEnumerator CalculatePoints()
	{
		yield return new WaitForSeconds(delayBeforeCount);

		for (int i = pointsPerBall; i <= balls.value * pointsPerBall; i += pointsPerBall)
		{
			int balls = i / pointsPerBall;
			ballsText.text = balls.ToString(ballsTextFormat);
			bonusPoints.text = i.ToString(textFormat);
			points.value += pointsPerBall;
			audioSource.PlayOneShot(sound);
			yield return new WaitForSeconds(iterationDelay);
		}
		onDone.Invoke();
		balls.value = balls.defaultValue;
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
