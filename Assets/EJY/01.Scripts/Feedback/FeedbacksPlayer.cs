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

    public void FeedbacksPlay()
    {
        Debug.Log("�ǵ�� ����");
        FeedbacksStop();
        _feedbacks.ForEach(feedback => feedback.PlayFeedback());
    }

    public void FeedbacksStop()
    {
        _feedbacks.ForEach(feedback => feedback.StopFeedback());

    }
}
