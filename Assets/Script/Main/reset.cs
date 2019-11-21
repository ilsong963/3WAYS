using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Debug.Log("click");
            count++;                                        //마우스 입력받으면 count 증가

        }
        if (count == 10)
        {
                Debug.Log("reset");
                PlayerPrefs.DeleteAll();
        }
    }
}