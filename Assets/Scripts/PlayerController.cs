using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject boundPlan;
    public GameController GameController;

    public float speed = 1f;
    public float epsilon = 0.1f;

    private Vector3 boundMin;
    private Vector3 boundSize;
    private Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {

        MainCamera = Camera.main;

        //Cursor.lockState = CursorLockMode.Confined;

        //Get the bounds of the bounds object, so the mouse can figure out where on the
        Bounds boundBound = boundPlan.GetComponent<MeshFilter>().sharedMesh.bounds;
        boundMin = Vector3.Scale(boundBound.min, boundPlan.transform.localScale);
        boundSize = Vector3.Scale(boundBound.size, boundPlan.transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {

        float mouseXRatio = Input.mousePosition.x/Screen.width;
        float mouseYRatio = Input.mousePosition.y/Screen.height;

        if (mouseXRatio > 1) {
            mouseXRatio = 1;
        } else if (mouseXRatio < 0) {
            mouseXRatio = 0;
        }

        if (mouseYRatio > 1) {
            mouseYRatio = 1;
        } else if (mouseYRatio < 0) {
            mouseYRatio = 0;
        }

        Vector3 targetPosition = new Vector3(boundMin.x + boundSize.x * (mouseXRatio), boundMin.z + boundSize.z * (mouseYRatio), boundPlan.transform.position.z);
        Vector3 translateVector = targetPosition-transform.position;

        Vector3 pointingPosition = targetPosition + new Vector3(0,0,20);

        transform.LookAt(pointingPosition);
        MainCamera.transform.LookAt(pointingPosition + new Vector3(0,0,500));

        if (translateVector.magnitude > epsilon) {
            transform.Translate(translateVector * speed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Obstacle") {
            GameController.onCrashed();
        }
    }
}
