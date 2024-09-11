using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shy_Manager_Tile : MonoBehaviour
{
    public List<Shy_Tile> tileObjs;
    public List<Shy_TileSO> tileSOList;

    private void ChangeTileSkill(Shy_Tile _targetTile, Shy_TileSO _changeData)
    {
        //������
        if(_targetTile.skillData != null) tileSOList.Add(_targetTile.skillData);
        //�ֱ�
        _targetTile.skillData = _changeData;
        //����Ʈ�� ������ ����
        if(_changeData != null) tileSOList.Remove(_changeData);
        _targetTile.UpdateImage();
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
    }

    private void Init()
    {
        //��ü Ÿ�� ����
        for (int i = 0; i < tileObjs.Count; i++)
        {
            tileObjs[i].tileManager = this;
        }
        Debug.Log("tileManager Init suc");
    }

    private void Start()
    {
        //SO�̸� �ޱ�
        for (int i = 0; i < Shy_Deck.instance.tileDeck.Count; i++)
        {
            tileSOList.Add(Shy_Deck.instance.tileDeck[i]);
        }
        Debug.Log("tile Deck reflect Suc");

        Init();

        for (int i = tileSOList.Count; i > 0; --i)
        {
            ChangeTileSkill(tileObjs[Random.Range(0, tileObjs.Count)], tileSOList[Random.Range(0, tileSOList.Count)]);
        }
    }
}
