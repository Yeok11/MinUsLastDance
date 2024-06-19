using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RhythmGameManager : MonoBehaviour
{
    public static RhythmGameManager instance;

    public Queue<GameObject> noteQ = new Queue<GameObject>();
    //Queue는 List랑 비슷한 역할을 하는데 [0]번째 요소밖에 니가 못 건드려. 가장 먼저 넣은게[0]번째가 되고 [0]번째를 니가 쓰면
    //그게 Queue에서 빠지면서 [1]번째 요소가 [0]번째가 되고
    //Queue의 [0]번째 노트에서만 판정을 처리한다. 1234

    public UnityEvent turnChangeEvent = new UnityEvent();
    private int noteCount = 0;

    public void NoteProcessHandle()
    {
        noteCount++;
        if(noteCount == 16)
        {
            turnChangeEvent?.Invoke();
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
