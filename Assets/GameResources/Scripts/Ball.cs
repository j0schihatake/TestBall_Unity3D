using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Vector3 mousePos;

    private Rigidbody2D rigidbody;
    private Transform transform;

    public float jumpPower = 3000f;
    public float movePower = 3000f;

    private void Start()
    {
        transform = gameObject.transform;
       rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Вообще это в тестовом не указали:
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            rigidbody.AddForce(Vector2.left * movePower);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            rigidbody.AddForce(Vector2.right * movePower);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * jumpPower);
        }
    }

    void Update()
    {
        if(Game.Instance.gameState == Game.state.game) {
            if(Input.touchCount > 0)
            {
                mousePos = Input.GetTouch(0).position;
            }
            else if(Input.GetMouseButtonDown(0))
            {
                mousePos = Input.mousePosition;
            }
        }

        rotate();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Game.Instance.score += 1;
    }

    private void rotate() {

        Vector3 objectPos = new Vector3(0, 0, 0);
        Vector3 dir = new Vector3(0, 0, 0);

        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        dir = mousePos - objectPos;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90)); 
    }
}
