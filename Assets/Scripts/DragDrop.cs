using System.Collections;
using UnityEngine;
[RequireComponent(typeof(MeshCollider))]

public class DragDrop : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curPosition;
    private Vector3 curScreenPoint;

    [SerializeField] private float speed = 25f;
    private float hor;
    private float ver;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        hor = Input.GetAxis("Mouse X");
        ver = Input.GetAxis("Mouse Y");
    }

    void OnMouseDown()
    {
        Debug.Log("Fruit Picked");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        Debug.Log("Fruit Released");
        rb.velocity = new Vector2(hor * speed, ver * speed);
    }

}
