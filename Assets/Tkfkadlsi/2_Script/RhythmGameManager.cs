using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RhythmGameManager : MonoBehaviour
{
    public static RhythmGameManager instance;

    public Queue<GameObject> noteQ = new Queue<GameObject>();

    public UnityEvent turnChangeEvent = new UnityEvent();
    public int nodeCount = 0;

    public void NoteProcessHandle()
    {
        
    }

    private void Awake()
    {
        instance = this;
    }
}
