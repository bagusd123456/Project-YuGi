using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                //Select stage    
                if (hit.transform.CompareTag("Grid"))
                {
                    Debug.Log(hit.transform.gameObject.name);
                }
            }
        }

        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Debug.Log(rayHit.transform.name);

        }
        
        
    }
}
