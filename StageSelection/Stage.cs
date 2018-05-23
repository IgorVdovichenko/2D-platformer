using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="New Stage", menuName ="Stage")]
public class Stage : ScriptableObject
{
    [SerializeField] string sceneName;
    [SerializeField] int bonusPoints;
    [SerializeField] AudioClip music;

    public bool cleared;

    public string SceneName { get { return sceneName; } }
    public int BonusPoints { get { return bonusPoints; } }
    public AudioClip Music { get { return music; } }

    public void LoadStage()
    {
        SceneManager.LoadScene(SceneName);
    }
}
