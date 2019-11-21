using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JoystickPlayerExample : MonoBehaviour
{

    AudioSource audio;
    public GameObject dir;
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;
    public Transform _transform;
    public float engine;
    public Vector3 moveDir;
    public int dircheck = 0;
    public float maxX, minX, maxY, minY;
    private GameObject _child;
    private float Horizontal;
    private float Vertical;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
        _transform = transform;      //Transform 캐싱
        engine = 100f;

    }
    public void FixedUpdate()
    {
        Horizontal = variableJoystick.Horizontal;
        Vertical = variableJoystick.Vertical;

        Debug.Log(Horizontal+ " , " + Vertical);


        Freeze();

        _transform.Translate(moveDir * speed * Time.fixedDeltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);


    }
    public void engineup()
    {
        engine += 10;
    }



    private void Freeze()
    {
        switch (dircheck)
        {
            
            case 0:

                Debug.Log("0");
                moveDir = new Vector3(Horizontal, Vertical, 0).normalized;
                dir.active = false;

                break;

            case 1:

                Debug.Log("1");
                dir.active = true;
                if (Horizontal > 0)
                    moveDir = new Vector3(0, Vertical, 0).normalized;
                else
                    moveDir = new Vector3(Horizontal, Vertical, 0).normalized;
                break;

            case 2:
                Debug.Log("2");
                dir.active = true;
                if (Vertical > 0)
                    moveDir = new Vector3(Horizontal, 0, 0).normalized;
                else

                    moveDir = new Vector3(Horizontal, Vertical, 0).normalized;
                break;

            case 3:
                Debug.Log("3");
                dir.active = true;
                if (Vertical < 0)

                    moveDir = new Vector3(Horizontal, 0, 0).normalized;
                else

                    moveDir = new Vector3(Horizontal, Vertical, 0).normalized;
                break;

            case 4:
                Debug.Log("4");
                dir.active = true;
                if (Horizontal < 0)

                    moveDir = new Vector3(0, Vertical, 0).normalized;
                else

                    moveDir = new Vector3(Horizontal, Vertical, 0).normalized;
                break;
        }
    }

    public void checkcrash(float damage) {
        if (engine >0)
        {
            Debug.Log("demage");
            engine -= damage;
        }

    }
  

    public void dirsave(int dir)
    {
        dircheck = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bolt")
        {
            engineup();
            audio.Play();

        }
    }

}