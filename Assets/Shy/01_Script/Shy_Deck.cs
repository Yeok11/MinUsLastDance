using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if(tileDeck.Count == 0)
        {
            for (int i = 0; i < normalDeck.Count; i++)
            {
                Shy_TileSO stSO = new Shy_TileSO(normalDeck[i]);
                tileDeck.Add(stSO);
            }
        }
    }

    public List<Shy_TileSO> tileDeck;
    public List<Shy_TileSO> normalDeck;
    public List<Shy_DiceSO> diceDeck;
   
}
