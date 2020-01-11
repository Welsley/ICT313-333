using UnityEngine;
using System.Collections;

public class GPSCameraVector : MonoBehaviour {
	private Vector3 _heading;
	// Use this for initialization
	void Start () {
		Input.location.Start ();
		Input.compass.enabled = true;
		_heading.x = 0;
		_heading.y = 0;
		_heading.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		_heading = Input.compass.rawVector;
		//print ("HAI!");
	}
	
	public Vector3 getCamVec()
	{
		return _heading;
	}
	
	public float getCamVecX()
	{
		return _heading.x;
	}
	
	public float getCamVecY()
	{
		return _heading.y;
	}
	
	public float getCamVecZ()
	{
		return _heading.z;
	}
}