using UnityEngine;

public abstract class Feedback : MonoBehaviour
{
    public abstract void PlayFeedback(float damage);
    public abstract void StopFeedback();

    private void OnDisable()
    {
        StopFeedback();
    }
}
