using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Material material;

    void Start()
    {
        material = this.gameObject.GetComponent<SpriteRenderer>().material;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int random = Random.Range(0, 7);

        switch(random) {
            case 0:
                material.color = Color.white;
                break;
            case 1:
                material.color = Color.black;
                break;
            case 2:
                material.color = Color.green;
                break;
            case 3:
                material.color = Color.blue;
                break;
            case 4:
                material.color = Color.yellow;
                break;
        }
    }
}
