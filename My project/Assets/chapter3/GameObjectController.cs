using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameObjectController : MonoBehaviour
{

    GameObject car;
    GameObject roulette;
    GameObject flag;
    GameObject score;
    Text myScore;
    long lscore = 0;
    public bool bssw = false;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        roulette = GameObject.Find("roulette");
        flag = GameObject.Find("flag");
        score = GameObject.Find("score");
        myScore = GameObject.Find("score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        lscore = roulette.gameObject.GetComponent<RouletteController>().lscore;

        if (lscore == 0 && !car.gameObject.GetComponent<CarController>().bssw && bssw)
        {
            myScore.text = "패배! ";
        }
        else
        {
            myScore.text = "남은 횟수 " + lscore.ToString();
        }

        if (lscore > 0 )
        {
            car.gameObject.GetComponent<CarController>().SetBssw(true);
            roulette.gameObject.GetComponent<RouletteController>().SetBssw(false);
        }
        else
        {
            car.gameObject.GetComponent<CarController>().SetBssw(false);
            car.gameObject.GetComponent<CarController>().speed = 0;
            roulette.gameObject.GetComponent<RouletteController>().SetBssw(true);
        }


        float lenght = flag.transform.position.x - car.transform.position.x;
        Debug.Log("남은거리 : " + lenght.ToString("F2"));

        if(lenght > 0 && lenght < 1.50f )
        {
            myScore.text = "승리! ";
            lscore = 0;
            bssw = false;
        }



    }
}
