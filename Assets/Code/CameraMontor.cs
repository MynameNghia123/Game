using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraMontor : MonoBehaviour
{
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    public Transform lookAt;

    private void Start()
    {
        lookAt = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Reset()
    {
        lookAt = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(deltaX < 0)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (deltaY < 0)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
            //        transform.position += new Vector3(delta.x, delta.y, 0);
        }
        transform.Translate(delta.x * Time.deltaTime, delta.y * Time.deltaTime, 0);

    }
}
