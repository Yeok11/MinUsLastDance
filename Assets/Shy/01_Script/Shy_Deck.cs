using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Deck : MonoBehaviour
{
    public static Shy_Deck instance;

    private void Awake()
    {
        transform.parent = GameObject.Find("Managers").transform;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public List<Shy_TileSO> tileDeck;
    public List<Shy_DiceSO> diceDeck;

   
}
