using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    GameObject roulette;
    GameObject go;
    public float speed = 0;
    public bool bssw = false;
    Vector2 startPos;
    Vector2 endpos;
    long lscore;

    // Start is called before the first frame update
    void Start()
    {
        roulette = GameObject.Find("roulette");
        go = GameObject.Find("GameObject");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (bssw)
        {
            lscore = roulette.gameObject.GetComponent<RouletteController>().lscore;
            Debug.Log(lscore.ToString());

            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                endpos = Input.mousePosition;
                float swipeLiength = endpos.x - startPos.x;

                speed = swipeLiength / 500.0f;
               // GetComponent<AudioSource>().Play();

                
                lscore--;
                roulette.gameObject.GetComponent<RouletteController>().SetSocre(lscore);
            }

            if(lscore == 0)
            {
                go.gameObject.GetComponent<GameObjectController>().bssw = true;
            }
            else
            {
                go.gameObject.GetComponent<GameObjectController>().bssw = false;
            }

            transform.Translate(speed, 0, 0);

            speed *= 0.98f;
        }

    }

    public void SetBssw(bool bssw)
    {
        this.bssw = bssw;
    }
}
