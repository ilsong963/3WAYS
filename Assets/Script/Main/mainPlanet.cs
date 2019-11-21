using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainPlanet : MonoBehaviour
{
    float first_x, first_y;
    int speed;
    Vector3 dir = new Vector3(-2, -1, 0);

    // Start is called before the first frame update
    void Start()
    {
        first_x= transform.position.x;
        first_y= transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(1, 3);
        transform.Translate(dir * speed*4*Time.deltaTime);

        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (targetScreenPos.x < -5 || targetScreenPos.y<-7)
        {
            transform.position = new Vector3(first_x, first_y);
        }
    }
}
