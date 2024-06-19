using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm : MonoBehaviour
{
    [SerializeField]
    GameObject poorNote, note, r_Note;

    public int bpm;

    public int[] remark;

    private void Start()
    {
        remark = new int[] { 1, 0, 0, 0, 1, 0, 0, 2, 1, 0, 0, 0, 1, 0, 2, 0 };
    }

    private void Update()
    {
        StartCoroutine(RhythmCorutine());
    }

    private IEnumerator RhythmCorutine()
    {
        switch (remark)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }

        yield return new WaitForSeconds(60 / bpm);
    }
}
