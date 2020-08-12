using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorder = 30f;
    public float scrollSpeed = 20f;

    public Vector3 panLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        float vertical = Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;

        if (Input.mousePosition.y >= Screen.height - panBorder)
        {
            vertical += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBorder)
        {
            vertical -= panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x >= Screen.width - panBorder)
        {
            horizontal += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= panBorder)
        {
            horizontal -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * 100f * Time.deltaTime;

        pos.z += vertical;
        pos.x += horizontal;
        pos.y -= scroll;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y - 15, panLimit.y - 15);
        pos.y = Mathf.Clamp(pos.y, 15, panLimit.z + 15);

        transform.position = pos;
    }
}
