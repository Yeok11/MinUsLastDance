using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Manager_Tile : MonoBehaviour
{
    public List<Shy_Tile> tileObjs;
    public List<Shy_Tile> usedTiles;
    public List<Shy_TileSO> tileSOList;
    [SerializeField] internal Shy_Manager_DataMes smd;

    private void ChangeTileSkill(Shy_Tile _targetTile, Shy_TileSO _changeData)
    {
        //������
        if(_targetTile.skillData != null) tileSOList.Add(_targetTile.skillData);
        //�ֱ�
        _targetTile.skillData = _changeData;
        //����Ʈ�� ������ ����
        if(_changeData != null) tileSOList.Remove(_changeData);
    }

    public void TileSetting(Shy_Tile _targetTile, int _randPer = 40)
    {
        int skillNum = Random.Range(0, tileSOList.Count);

        //40%Ȯ���� �⺻ Ÿ��
        int r = Random.Range(0, 100);
        if (r < _randPer || tileSOList.Count == 0)
        {
            ChangeTileSkill(_targetTile, null);
        }
        else
        {
            Debug.Log(_targetTile.gameObject.name + "�� ��ũ��Ʈ ���� ����");
            ChangeTileSkill(_targetTile, tileSOList[skillNum]);
        }
        StartCoroutine(RollAnime(_targetTile));
    }

    private IEnumerator RollAnime(Shy_Tile tile)
    {
        tile.transform.rotation = Quaternion.Euler(0, 0, 0);
        int rot = 0;
        while (rot <= 720)
        {
            if (rot == 180 && tile.skillData != null) tile.Setting();
            tile.transform.rotation = Quaternion.Euler(0, rot, 0);
            rot += 10;
            yield return new WaitForSeconds(0.005f);
        }
    }

    private void Init()
    {
        //SO�̸� �ޱ�
        for (int i = 0; i < Shy_Deck.instance.tileDeck.Count; i++)
        {
            tileSOList.Add(Shy_Deck.instance.tileDeck[i]);
        }
        Debug.Log("tile Deck reflect Suc");

        //��ü Ÿ�� ����
        for (int i = 0; i < tileObjs.Count; i++)
        {
            tileObjs[i].tileManager = this;
        }
        Debug.Log("tileManager Init suc");
    }

    private void Start()
    {
        Init();

        for (int i = tileSOList.Count; i > 0; --i)
        {
            //ChangeTileSkill(tileObjs[Random.Range(0, tileObjs.Count)], tileSOList[Random.Range(0, tileSOList.Count)]);
            TileSetting(tileObjs[Random.Range(0, tileObjs.Count)], 8);
        }
    }


    public void UsedTileUpdate()
    {
        while (usedTiles.Count != 0)
        {
            TileSetting(usedTiles[0]);
            usedTiles.RemoveAt(0);
        }
    }
}
