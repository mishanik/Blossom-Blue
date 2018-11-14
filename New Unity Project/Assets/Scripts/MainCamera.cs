using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    public float SharpnessZoom = 20f; //Скорость зума
    public float CameraPosition;
    public int CameraZoomMax = -28;
    public int CameraZoomMin = -5;
    public float CameraSpeed = 0.2f;
    //public MouseState MS;
	void Start () {
        //MS = gameObject.GetComponent<MouseState>();
        transform.position = new Vector3(0, 0, -15);
	}
	
	void Update () {
        CameraHeightPosition();
        CameraWidthPosition();
       
	}

    void CameraHeightPosition()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.z < CameraZoomMin) {
            //CameraPosition += 2 * SharpnessZoom * Time.deltaTime;
            CameraSpeed += 0.007f;
            transform.position += new Vector3(0, 0, 2 * SharpnessZoom * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.z > CameraZoomMax)
        {
            //CameraPosition -= 2 * SharpnessZoom * Time.deltaTime;
            CameraSpeed -= 0.0015f;
            transform.position -= new Vector3(0, 0, 2 * SharpnessZoom * Time.deltaTime);
        }
    }
    void CameraWidthPosition()
    {
        if (20 > Input.mousePosition.x)
        {
            transform.position -= new Vector3(CameraSpeed, 0, 0);
        }
        if ((Screen.width - 10) < Input.mousePosition.x)
        {
            transform.position += new Vector3(CameraSpeed, 0, 0);
        }
        
        if (20 > Input.mousePosition.y)
        {
            transform.position -= new Vector3(0, CameraSpeed, 0);
        }
        if ((Screen.height - 10) < Input.mousePosition.y)
        {
            transform.position += new Vector3(0, CameraSpeed, 0);
        }
    }
}
