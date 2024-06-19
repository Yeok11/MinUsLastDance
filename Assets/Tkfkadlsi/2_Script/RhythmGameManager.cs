using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RhythmGameManager : MonoBehaviour
{
    public static RhythmGameManager instance;

    public Queue<GameObject> noteQ = new Queue<GameObject>();
    //Queue�� List�� ����� ������ �ϴµ� [0]��° ��ҹۿ� �ϰ� �� �ǵ��. ���� ���� ������[0]��°�� �ǰ� [0]��°�� �ϰ� ����
    //�װ� Queue���� �����鼭 [1]��° ��Ұ� [0]��°�� �ǰ�
    //Queue�� [0]��° ��Ʈ������ ������ ó���Ѵ�. 1234

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
