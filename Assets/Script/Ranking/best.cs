using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class best : MonoBehaviour
{

    int highscore;
    string topplayer;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("one_int");
        topplayer = PlayerPrefs.GetString("one_str");

        this.GetComponent<Text>().text = topplayer + "\n\n" + highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
