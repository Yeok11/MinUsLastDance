using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    /*보드에 미리 정해둔 배치대로 벽, 길, 적, 상점, 도착지점, 플레이어가 배치될 거임.
    (표시는 지금 안 정했으니까 색깔만으로 구분 해놓으삼)
    당연히 벽으로는 갈 수 없고, 적, 상점에 닿으면 해당 씬으로 넘어감.
    도착지점에 닿으면 다음 스테이지를 불러옴.
    씬에 넘어갔다가 해당 씬을 클리어하면 돌아오고, 돌아왔을 때에 위치는 상호작용 했던 그 위치로.
    (씬 이동과 스테이지 소환, 스테이지 데이터 유지 정도만 만드삼.)*/

    //씬이동 = 됨 !
    //스테이지 소환 /2차원 배열?????(일단 배경은 깜...) 순서 꼬임 존재 고치기, CSV 같은거 받아오기
    //데이터 유지(좌표 = 해결) > SO 받아와서 일단 해결(더 좋은 방식이 있을까...) > 잘됨 꿋
    
    public GameObject Player;

    public Vector3 playerPostion;
    [SerializeField]
    private EJD_PlayerPositionSO playerPos;

    public enum Scene
    {None ,Goal, Enemy, Shop}

    public Scene ChkWhatScene = new Scene();

    private void Awake()
    {
        playerPos.isOut = false;
    }
    public void Start()
    {
        this.gameObject.transform.position = new Vector2(playerPos.xPos, playerPos.yPos);
        if (playerPos.firstMove == true)
        {
            playerPos.isOut = true;
            playerPos.firstMove = false;
        }
    }

    private void Update()
    {
        playerPos.xPos = this.gameObject.transform.position.x;
        playerPos.yPos = this.gameObject.transform.position.y;

        //ChangeManager();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") && playerPos.isOut == true) ChkWhatScene = Scene.Enemy;

        else if (other.gameObject.CompareTag("Shop") && playerPos.isOut == true) ChkWhatScene = Scene.Shop;

        else if (other.gameObject.CompareTag("Goal") && playerPos.isOut == true) ChkWhatScene = Scene.Goal;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerPos.isOut = true;
        ChkWhatScene = Scene.None;
    }

    public void ChangeManager()
    {
        switch (ChkWhatScene)
        {
            case Scene.Goal:
                SceneManager.LoadScene("TestNextStage");
                break;
            case Scene.Enemy:
                SceneManager.LoadScene("Battle");
                break;
            case Scene.Shop:
                SceneManager.LoadScene("Shop");
                break;
            case Scene.None:
                break;
        }

    }
}
