using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public GameObject ObstacleSpawner;
    public GameObject Obstacle;
    public float ObstacleSpawnerRate = 10f;
    public float ObstacleSpeed = 10f;
    public float generateDistance = 200f;
    public float generateSpacing = 20f;
    public bool generating = true;

    private float timer = 0f;

    private Vector3 boundExtents;

    // Start is called before the first frame update
    void Start()
    {
        //Get the bounds of the box
        Bounds boundBound = ObstacleSpawner.GetComponent<MeshFilter>().sharedMesh.bounds;
        boundExtents = Vector3.Scale(boundBound.extents, ObstacleSpawner.transform.localScale);
        generateTerrain();
    }

    // Update is called once per frame
    void Update()
    {

        if (generating) {
            timer += Time.deltaTime;

            if (timer > ObstacleSpawnerRate) { //Spawn Obstacle
                timer = 0f;

                createOpstacle();
            }
        } else {
            ObstacleSpeed = 0f;
        }
    }

    public float getCurrentSpeed() {
        return ObstacleSpeed;
    }

    void generateTerrain() {

        for (int i = 0; i < (generateDistance/(ObstacleSpawnerRate*ObstacleSpeed)); i++) {
            createOpstacleWithPosition(ObstacleSpawner.transform.position.z - ((ObstacleSpawnerRate*ObstacleSpeed)*i));
        }


    }

    private void createOpstacle() {
        createOpstacleWithPosition(ObstacleSpawner.transform.position.z);
    }

    private void createOpstacleWithPosition(float z) {
        if (transform.childCount < 100) {
            GameObject newObstacle = Instantiate(Obstacle, ObstacleSpawner.transform);
            newObstacle.SetActive(true);
            newObstacle.GetComponent<ObstacleScript>().setPosition(z);
        }
    }

}
