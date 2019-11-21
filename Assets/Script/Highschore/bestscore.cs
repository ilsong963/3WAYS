using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bestscore : MonoBehaviour
{

    int highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("one_int");

        this.GetComponent<Text>().text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
