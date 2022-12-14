using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAMove : PlayerMove
{
    public override void Move()
    {
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        else if (Input.GetKey(KeyCode.D)) moveX = 1f;
        else moveX = 0f;
        gameObject.transform.Translate(new Vector2(moveX,0)*Time.deltaTime*speed);
        if (Input.GetKeyDown(KeyCode.W)&&!onAir) Jump();
        if (Input.GetKeyDown(KeyCode.Space) && power == 100) Power();
    }
    public override void Jump()
    {
        rigid.AddForce(new Vector2(0, jumpscale ),ForceMode2D.Impulse);
        Invoke("JumpCheck", 0.05f);
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" && onPower)
        {
            Ball b = collision.gameObject.GetComponent<Ball>();
            if (moveX == 0) b.Powerhit(1);
            else b.Powerhit((int)moveX);
            //TimeStop();
            //Invoke("TimeReset", 0.05f);
            PowerReset();
        }

    }
    public override void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AFloor") { onAir = false; Debug.Log("hit"); }
    }
    public override void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AFloor") { onAir = true; Debug.Log("out"); }
    }
}
