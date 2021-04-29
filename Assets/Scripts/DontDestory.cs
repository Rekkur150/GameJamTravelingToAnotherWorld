using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{

    void Start() {

        if (FindObjectsOfType<DontDestory>().Length > 1) {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
