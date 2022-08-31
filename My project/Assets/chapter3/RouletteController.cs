using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour
{
    float speed = 0;
    public long lscore = 0;
    float v3 = 0;
    public bool bssw = true;
    bool bsw = false;
    GameObject car;
    GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        game = GameObject.Find("GameObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (bssw)
        {

            if (Input.GetMouseButton(0))
            {
                speed = 10;
                bsw = true;
            }

            speed *= 0.99f;
            gameObject.transform.Rotate(0, 0, speed);

            if (speed < 0.001f && bsw)
            {
                v3 = gameObject.transform.eulerAngles.z;
                bsw = false;

                if (v3 >= -30 && v3 <= 30)
                {
                    lscore = 1;
                    Debug.Log("운수나쁨");
                }
                else if (v3 >= 30 && v3 <= 90)
                {
                    lscore = 2;
                    Debug.Log("운수대통");
                }
                else if (v3 >= 90 && v3 <= 150)
                {
                    lscore = 1;
                    Debug.Log("운수매우나쁨");
                }
                else if (v3 >= 150 && v3 <= 210)
                {
                    lscore = 3;
                    Debug.Log("운수보통");
                }
                else if (v3 >= 210 && v3 <= 270)
                {
                    lscore = 2;
                    Debug.Log("운수조심");
                }
                else if (v3 >= 270 && v3 <= 330)
                {
                    lscore = 4;
                    Debug.Log("운수좋음");
                }

            }
        }

    }

    public void SetBssw(bool bssw)
    {
        this.bssw = bssw;
    }

    public void SetSocre(long lscore)
    {
        this.lscore = lscore;
    }
}
