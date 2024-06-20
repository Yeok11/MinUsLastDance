using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm : MonoBehaviour
{

    /*0�̸� �׳� �� ���ڴ� �Ѱ�
    1�̸� ��� square�� ���� �����غ���
    2�� ������ square�� �����غ���*/

    [SerializeField]
    private GameObject poorNote, note, r_Note;

    public Transform line;

    public float bpm = 60;

    public int[] remark;

    public int index = 0;

    private bool spawnDone = false;

    private void Start()
    {
        remark = new int[] { 1, 0, 0, 0, 1, 0, 0, 2, 1, 0, 0, 0, 1, 0, 2, 0 };
        StartCoroutine(RhythmCoroutine());
    }



    private void CheckNote()
    {
        if (index >= remark.Length)
        {
            index = 0;
        }
    }
    
    private IEnumerator RhythmCoroutine()
    {
        while (true)
        {
            Debug.Log(remark[index]);
            if (spawnDone == false)
            {
                switch (remark[index])
                {
                    case 0:
                        {
                            Instantiate(poorNote,line);
                            spawnDone = true;
                            break;
                        }
                    case 1:
                        {
                            Instantiate(note, line);
                            spawnDone = true;
                            break;
                        }
                    case 2:
                        {
                            Instantiate(r_Note, line);
                            spawnDone = true;
                            break;
                        }
                }
            }
            yield return new WaitForSeconds(60f / bpm);
            index++;
            spawnDone = false;
            if(index >= remark.Length)
            {
                index = 0;
            }
        }
    }
}
