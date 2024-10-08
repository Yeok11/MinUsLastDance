using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EJD_ChangeScene : MonoBehaviour
{
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
