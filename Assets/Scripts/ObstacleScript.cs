using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    public float xDelt = 5f;
    public float yDelt = 5f;
    public float RotationDeltaX = 40f;
    public float RotationDeltaY = 40f;
    public float RotationDeltaZ = 90f;
    public float SizeDelta = 0.5f;
    public float zCoordinateDestory = -20f;

    private ObstacleController con;

    // Start is called before the first frame update
    void Start()
    {
        con = gameObject.GetComponentInParent<ObstacleController>();
        //Generate the Randomness
        float x = Random.Range(-1*xDelt, yDelt);
        float y = Random.Range(-1*xDelt, yDelt);
        float xRot = Random.Range(-1 * RotationDeltaX, RotationDeltaX);
        float yRot = Random.Range(-1 * RotationDeltaY, RotationDeltaY);
        float zRot = Random.Range(-1 * RotationDeltaZ, RotationDeltaZ);
        float size = Random.Range(-1 * SizeDelta, SizeDelta);

        //Add some randomness
        transform.position += new Vector3(x,0,y);
        transform.rotation = Quaternion.Euler(xRot,yRot,zRot);
        transform.localScale += new Vector3(transform.localScale.x + size, 0 ,transform.localScale.z + size);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0,0,-1 * con.getCurrentSpeed() * Time.deltaTime);

        if (transform.position.z < zCoordinateDestory) {
            Destroy(gameObject);
        }
    }

    public void setPosition(float z) {
        transform.position = new Vector3(transform.position.x,transform.position.y,z);
    }
}
