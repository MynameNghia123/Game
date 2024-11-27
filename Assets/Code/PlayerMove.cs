using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Vector3 movePosition;
    private void FixedUpdate()
    {
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
            transform.localScale = Vector3.one;
        else if (movePosition.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.Translate(movePosition * Time.deltaTime);
    }
}
