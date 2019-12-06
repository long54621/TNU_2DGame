using UnityEngine;
using UnityEngine.UI;
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
    [Header("鑽石區域")]
    public int diamondCurrent;
    public int diamondTotal;
    public Text textDiamond;


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

    private void Start()
    {   //鑽石總數
        diamondTotal = GameObject.FindGameObjectsWithTag("鑽石").Length;
        //更新介面
        textDiamond.text = "鑽石:0 /" + diamondTotal;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "鑽石")
        {
            aud.PlayOneShot(soundDiamond, 1.5f);    //音源
            Destroy(collision.gameObject);          //刪除(碰撞的物件)
            diamondCurrent++;
            textDiamond.text = "鑽石:" + diamondCurrent + "/" + diamondTotal;
        }
    }


}
