using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Vector3 movePosition;
    [SerializeField] private bool isMove = true;
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        if(isMove)
             this.Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 
        // GetAxis trả về giá trị thực  có bộ lọc => có nghĩa là mọi thứ sẽ có quán tính khi đang di chuyển mà đột ngột
        // ngừng lại thì nó sẽ dung lại từ từ, ngược lại với GetAxisRaw là sẽ ngừng lại luôn
        // getAxis => trả về giá trị thực 1 or -1 nhưng khi ấn thì số sẽ chạy từ 0  dần lên 1 và ngược lại
        // getAxisRaw => thì trả về giá trị thực 1 or -1 khi ấn thì nó trả về 1 và ko ấn thì nó trả về 0
        movePosition = new Vector3(x * speed, y * speed, 0);

        if (movePosition.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movePosition.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0 ,new Vector2(0, movePosition.y), Mathf.Abs(movePosition.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        //hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movePosition.y), Mathf.Abs(movePosition.y) * Time.deltaTime, LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(0, movePosition.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movePosition.x, 0), Mathf.Abs(movePosition.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
       // hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movePosition.x, 0), Mathf.Abs(movePosition.x) * Time.deltaTime, LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate( movePosition.x * Time.deltaTime, 0, 0);
        }
    }
}
