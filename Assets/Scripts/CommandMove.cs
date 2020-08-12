using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandMove : MonoBehaviour
{
    MouseSelect mouseSelection;
    public float moveSpeed = 20f;
    public GameObject movementMarker;
    GameObject instantiatedMarker = null;
    List<GameObject> movementLocations;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        mouseSelection = FindObjectOfType<Camera>().GetComponent<MouseSelect>();
        movementLocations = new List<GameObject>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && mouseSelection.selected == gameObject)
            {
                instantiatedMarker = Instantiate(movementMarker, hitInfo.point + new Vector3(0, .5f, 0), movementMarker.transform.rotation);
                movementLocations.Add(instantiatedMarker);
            }
        }

        if(instantiatedMarker != null)
        {
            if(Vector3.Distance(transform.position, movementLocations[0].transform.position) >= .5f)
            {
                //transform.position = Vector3.MoveTowards(transform.position, movementLocations[0].transform.position, moveSpeed * Time.deltaTime);
                agent.SetDestination(movementLocations[0].transform.position);
            }
            else
            {
                if(instantiatedMarker != null)
                {
                    GameObject temp = movementLocations[0];
                    movementLocations.Remove(temp);
                    Destroy(temp);
                }
            }
            
        }
    }
}
