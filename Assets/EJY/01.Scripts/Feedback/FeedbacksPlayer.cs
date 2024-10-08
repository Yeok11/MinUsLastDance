using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeedbacksPlayer : MonoBehaviour
{
    private List<Feedback> _feedbacks;

    private void Awake()
    {
        _feedbacks = GetComponentsInChildren<Feedback>().ToList();
    }

    public void FeedbacksPlay(float damage)
    {
        FeedbacksStop();
        _feedbacks.ForEach(feedback => feedback.PlayFeedback(damage));
        
    }

    public void FeedbacksStop()
    {
        _feedbacks.ForEach(feedback => feedback.StopFeedback());

    }
}
