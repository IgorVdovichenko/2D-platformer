using UnityEngine;

public class StagesInitilizer : MonoBehaviour
{
    [SerializeField] Stage[] stages;

    private void Start()
    {
        foreach (var item in stages)
        {
            item.cleared = false;
        }
    }
}
