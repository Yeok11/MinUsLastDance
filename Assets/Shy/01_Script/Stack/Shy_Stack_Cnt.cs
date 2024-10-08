using TMPro;
using UnityEngine;


public class Shy_Stack_Cnt : Shy_Stack
{
    public int count;
    [SerializeField] private TextMeshProUGUI tmp;

    private void Update()
    {
        tmp.text = count.ToString();
    }
}
