using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum whereHit {Awin,Bwin};
    public whereHit wherehit = whereHit.Awin;
    public int aScore, bScore;
    

    void hit()
    {
        if (wherehit == whereHit.Awin)  aScore++;
        else bScore++;
    }

    public void Powerhit(int moveX)
    {
        Rigidbody2D r = gameObject.GetComponent<Rigidbody2D>();
        r.velocity = Vector3.zero;
        switch(moveX)
        {
            case 1:
                r.AddForce(new Vector2(10,-2), ForceMode2D.Impulse);
                break;
            case -1:
                r.AddForce(new Vector2(-10, -2), ForceMode2D.Impulse);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AFloor") { 
            wherehit = whereHit.Bwin; 
            hit(); 
        }
        if (collision.gameObject.tag == "BFloor") { 
            wherehit = whereHit.Awin; 
            hit(); 
        }
    }


}
