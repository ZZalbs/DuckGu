using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    protected int power =0;
    protected int jumpscale = 10;
    protected int speed = 7;
    
    protected float moveX = 0;
    protected float moveY = 0;

    protected Rigidbody2D rigid;
    protected bool onAir=true;
    protected bool onJump = false;
    [SerializeField] protected bool onPower = false;

    public Slider powerSlider;

    public GameObject powerBar;
    public GameObject powerObj;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(PowerUp());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(onJump && !onAir) {
            rigid.velocity = Vector3.zero;
            onJump = false;
        }
        powerSlider.value = (float)power / 100;
    }

    protected void JumpCheck()
    {
        onJump = true;
    }

    public virtual void Move() { }
    public virtual void Jump() { }
    public void Power()
    {
        jumpscale *= 2;
        onPower = true;
        powerObj.SetActive(true);
    }

    protected void PowerReset()
    {
        power = 0;
        onPower = false;
        jumpscale /= 2;
        powerObj.SetActive(false);
    }

    IEnumerator PowerUp()
    {
        while (true)
        {       
            if(power<100) power += 1;
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Power : " + power);
        }
    }

    protected void TimeStop()
    {
        Time.timeScale = 0.1f;
    }
    protected void TimeReset()
    {
        Time.timeScale = 1.0f;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision){    }
    public virtual void OnCollisionStay2D(Collision2D collision) { }
    public virtual void OnCollisionExit2D(Collision2D collision) { }
}
