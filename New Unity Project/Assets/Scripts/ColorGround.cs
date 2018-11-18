using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGround : MonoBehaviour {
    public Color cl = new Color(0, 0, 0, 1);
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = cl;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
