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

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        r2d.AddForce(new Vector2(speed*h ,0));
        
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGriund == true)
        {
            isGriund = false;
            r2d.AddForce(new Vector2(0, jump));
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
        isGriund = true;
    }
}
