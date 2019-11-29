using UnityEngine;

public class player : MonoBehaviour
{
    //private 私人
    //public 公開
    [Header ("速度"),Range(0f,100f)]
    public float speed = 3.5f;
    [Header("跳躍"),Range(100,2000)]
    public int jump = 300;
    [Header("是否在地板上"), Tooltip("判定角色是否在地板上。")]
    public bool isGriund = false;
    [Header("角色名稱")]
    public string Name = "Long";
    [Header("2D 剛體")]
    public Rigidbody2D r2d;
    public Animator ani;

    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundDiamond;


    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        r2d.AddForce(new Vector2(speed*h ,0));
        ani.SetBool("跑步開關", h != 0);

        if (Input.GetKeyDown(KeyCode.A)) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKeyDown(KeyCode.D)) transform.eulerAngles = new Vector3(0, 0, 0);
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGriund == true)
        {
            isGriund = false;
            r2d.AddForce(new Vector2(0, jump));
            ani.SetTrigger("跑步開關");
        }
    }

    private void Dead()
    {

    }
    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "地板")
        {
            isGriund = true;
        }
    }
}
