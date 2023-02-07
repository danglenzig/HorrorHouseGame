using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceVCamScript : MonoBehaviour
{
    public string cameraTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject activeCam = GameObject.FindGameObjectWithTag(cameraTag);
        transform.LookAt(activeCam.transform.position,Vector3.up);
    }
}
