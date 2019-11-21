using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetMove : MonoBehaviour
{

    public float speed;
    Vector3 dec;
    GameObject Player;
    private float die = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        dec = new Vector3(Player.transform.position.x - this.transform.position.x, Player.transform.position.y - this.transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(dec * speed * Time.deltaTime);


        die += Time.deltaTime;
        if (die > 8f)
        {
            Destroy(gameObject);
        }
    }
}
