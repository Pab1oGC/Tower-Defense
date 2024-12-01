using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float speed;
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;
    public Transform minBounds;
    public Transform maxBounds;
    // Start is called before the first frame update
    void Start()
    {
        speed = 12f;
        zoomSpeed = 4f;
        minZoom = 6f;
        maxZoom = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ZoomCamera();
    }
    void Movement()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(movementX, movementY, 0f);

        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.position.x, maxBounds.position.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.position.y, maxBounds.position.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); 
        if (scroll != 0f)
        {
            Camera camera = GetComponent<Camera>();
            camera.orthographicSize -= scroll * zoomSpeed;
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minZoom, maxZoom);
        }
    }
}
