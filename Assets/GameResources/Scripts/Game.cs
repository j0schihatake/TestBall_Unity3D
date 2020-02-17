using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public GameObject menu;
    public GameObject game;
    public Image background;

    public Text text;

    public int score = 0;

    public Ball ball;

    public Transform startTransform;

    public state gameState;
    public enum state { 
        menu,
        game,
    }

    void Start()
    {
        Instance = this;
        gameState = state.menu;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            ball.transform.position = startTransform.position;
            switchMenu();
        }
    }

    private void switchMenu() {
        menu.SetActive(!menu.activeSelf);
        game.SetActive(!menu.activeSelf);
        if(gameState == state.menu)
        {
            gameState = state.game;
        }
        else {
            text.text = score.ToString();
            gameState = state.menu;
        }
    }

    public void goToNextLevel(float gravity) {
        switchMenu();
    }

    public void initLevel(int gravity) {
        ball.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;

        if(gravity == 9.8f)
        {
            background.color = Color.blue;
        }
        else if(gravity == 1.6f)
        {
            background.color = Color.gray;
        }
        else {
            background.color = Color.black;
        }
    }
}
