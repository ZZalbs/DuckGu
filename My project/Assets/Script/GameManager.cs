using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject playerA;
    public GameObject playerB;
    public Rigidbody2D ballRigid;
    public Rigidbody2D playerARigid;
    public Rigidbody2D playerBRigid;


    public Text aScoreText;
    public Text bScoreText;
    public Text resultText;
    public GameObject maincanvas;
    public GameObject resultCanvas;


    Ball ballscript;

    public int Ascore;
    public int Bscore;


    // Start is called before the first frame update
    void Start()
    {
        ballscript = ball.GetComponent<Ball>();
        ballRigid = ball.GetComponent<Rigidbody2D>();
        playerARigid = playerA.GetComponent<Rigidbody2D>();
        playerBRigid = playerB.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        aScoreText.text = Ascore.ToString();
        bScoreText.text = Bscore.ToString();
        if (Ascore != ballscript.aScore)
        {
            Ascore = ballscript.aScore;
            Reset();
        }
        if (Bscore != ballscript.bScore)
        {
            Bscore = ballscript.bScore;
            Reset();
        }
        if(Ascore>=5||Bscore>=5)
        {
            gameEnd();
            
        }
    }

    private void Reset()
    {
        playerA.transform.position = new Vector3(-5, -3, 0);
        playerB.transform.position = new Vector3(5, -3, 0);
        if (ballscript.wherehit == Ball.whereHit.Awin)
            ball.transform.position = new Vector3(1f, 4, 0);
        else
            ball.transform.position = new Vector3(-1f, 4, 0);

        ballRigid.velocity = Vector3.zero;
        playerARigid.velocity = Vector3.zero;
        playerBRigid.velocity = Vector3.zero;
    }

    void gameEnd()
    {
        maincanvas.SetActive(false);
        resultCanvas.SetActive(true);
        if (Ascore == 5)
            resultText.text = "Winner is Player Green!";
        if (Bscore == 5)
            resultText.text = "Winner is Player Orange!";
        Time.timeScale = 0.0f;
    }

    public void restart()
    {
        Time.timeScale = 1.0f;
        maincanvas.SetActive(true);
        resultCanvas.SetActive(false);
        Ascore = 0;
        Bscore = 0;
        
        Reset();
    }

}
