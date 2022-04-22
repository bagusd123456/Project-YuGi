using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    public Vector3 CurrentMousePosition;
    public Vector3 defaultPosition;

    public RaycastHit2D hit;
    //public CardData cardDataSO;

    
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        #region OnMouseButton3D
        /*if (Input.GetMouseButtonDown(0))
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
        }*/
        #endregion

        #region OnMouseButton2D
        /*RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Debug.Log(rayHit.transform.name);

        }*/
        #endregion

    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerdata = (PointerEventData)data;

        Vector2 position;
        Vector3 position3D;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform, pointerdata.position,
            canvas.worldCamera, out position);
        /*RectTransformUtility.ScreenPointToWorldPointInRectangle((RectTransform)canvas.transform, pointerdata.position,
            canvas.worldCamera, out position3D);*/

        //gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = false;
        transform.position = canvas.transform.TransformPoint(position);
    }

    public void DropHandler(BaseEventData data)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

		if (rayHit.transform)
		{
            GridData gridData = rayHit.transform.gameObject.GetComponent<GridData>();
            CardData cardData = gameObject.GetComponent<Card>().cardDataSO;

            if (rayHit && rayHit.transform.gameObject.CompareTag("Grid") && gridData != null && cardData != null)
            {
                if (((int)gridData._gridType) == ((int)cardData._cardType) && rayHit.collider.GetType() == typeof(BoxCollider2D))
                {
                    //gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = true;
                    //transform.SetParent(rayHit.transform);
                    transform.position = rayHit.transform.position;
                    Debug.Log("On Hit: " + rayHit.transform.name);
                }
                else if (rayHit.collider.GetType() != typeof(BoxCollider2D))
                {
                    transform.position = defaultPosition;
                    Debug.Log("Cancel");
                }
                else
                {
                    transform.position = defaultPosition;
                    Debug.Log("Cancel");
                }
            }
            else {
                transform.position = defaultPosition;
                Debug.Log("Cancel");
            }
		}
		else {
            transform.position = defaultPosition;
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (rayHit)
        {
            //Debug.Log(rayHit.transform.name);
        }

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
    }
}
