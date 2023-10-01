using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestLipstick : MonoBehaviour, IPointerClickHandler,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Point p1;
    public Point p2;
    public float RotateDegree;
    float zAxis;
    Vector3 prevPos;
    [SerializeField]bool isOverlapped;

    public void OnBeginDrag(PointerEventData eventData)
    {
        prevPos = gameObject.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenToWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(screenToWorldPos.x, screenToWorldPos.y, 0);
        Debug.Log("Overlap state: " + isOverlapped);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isOverlapped)
        {
            gameObject.transform.position = prevPos;
        }
        isOverlapped = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        Vector3 prevRotation = gameObject.transform.localEulerAngles;
        zAxis += RotateDegree;
        gameObject.transform.localEulerAngles = new Vector3(0, 0, zAxis);
        //Debug.Log("Overlap state: " + isOverlapped);
        //if (isOverlapped)
        //{
        //    Debug.Log("Overlapped while rotating");
        //    gameObject.transform.localEulerAngles = prevRotation;
        //    zAxis -= RotateDegree;
        //    return;
        //}
        //isOverlapped= false;
        if (zAxis != 360) return;
        zAxis = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        isOverlapped = false;
        zAxis = gameObject.transform.rotation.eulerAngles.z;
        prevPos = gameObject.transform.position;
        //Debug.Log(gameObject.name+ ":");
        //Debug.Log("p1 pos: " + p1.GetPos());
        //if (p2 != null)
        //{
        //    Debug.Log("p2 pos: " + p2.GetPos());
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Overlapped");
        if (collision.gameObject.tag == "Item")
        {
           isOverlapped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            isOverlapped = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
