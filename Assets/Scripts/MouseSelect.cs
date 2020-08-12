using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> selected = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (!hitInfo.transform.gameObject.CompareTag("Ground"))
                {
                    selected = hitInfo.transform.gameObject;
                }
                else
                {
                    selected = null;
                }
            }
        }
    }
}
