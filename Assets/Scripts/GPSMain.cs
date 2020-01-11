using UnityEngine;
using System.Collections;

public class GPSMain : MonoBehaviour {
	private GPSCameraVector _camvec;
	private Geolocation _camloc;
	private float _vecLength;
	private bool _initialized;

	// Use this for initialization
	void Start () {
		_camvec = new GPSCameraVector ();
		_camloc = new Geolocation ();
		//_camloc.initGPS ();
		_vecLength = 1;
		_initialized = false;
		//checkGPS ();
	}
	
	// Update is called once per frame
	void Update () {
		/*while(_initialized == false)
		{
			checkGPS();
		}*/
	}

	// Gives camera's vector
	public Vector3 getCamHeadingVec()
	{
		return _camvec.getCamVec();
	}

	// Gives camera's vector x
	public float getCamHeadingVecX()
	{
		return _camvec.getCamVecX();
	}

	// Gives camera's vector y
	public float getCamHeadingVecY()
	{
		return _camvec.getCamVecY();
	}

	// Gives camera's vector z
	public float getCamHeadingVecZ()
	{
		return _camvec.getCamVecZ();
	}

	// Gives camera's location longitude
	public double getCamLongitude()
	{
		return _camloc.getLongitude();
	}

	// Gives camera's location latitude
	public double getCamLatitude()
	{
		return _camloc.getLatitude();
	}

	public void setCamVecLength(float length)
	{
		_vecLength = length;
	}

	// Tells if camera vector is within an area.
	public bool isVectorInRadius(double longitude, double latitude, double radius)
	{
		double vecPosX = _camloc.getLongitude() + (double)(_camvec.getCamVecX() * _vecLength);
		double vecPosZ = _camloc.getLatitude() + (double)(_camvec.getCamVecZ() * _vecLength);

		double LAB = (double)Mathf.Sqrt((float)(((_camloc.getLongitude () - vecPosX) * (_camloc.getLongitude () - vecPosX)) + ((_camloc.getLatitude () - vecPosZ) * (_camloc.getLatitude () - vecPosZ))));
		double Dx = (_camloc.getLongitude () - vecPosX) / LAB;
		double Dy = (_camloc.getLatitude () - vecPosZ) / LAB;

		double t = Dx * (longitude - _camloc.getLongitude ()) + Dy * (latitude);
		
		double Ex = t * Dx + _camloc.getLongitude();
		double Ey = t * Dy + _camloc.getLatitude();

		double LEC = (double)Mathf.Sqrt ((float)(((Ex - longitude) * (Ex - longitude)) + ((Ey - latitude) * (Ey - latitude))));

		return (LEC < radius);
	}

	/**
	 * @Function: updateGPS().
	 * 
	 * @Summary:
	 * 
	 * Each call checks the status of the geolocation class.
	 * If it has failed, it informs the GUI manager and attempts to re-init.
	 * If it is initializing it informs the GUI manager.
	 * Else, it is successfully initialized.
	 * 
	 * */
	bool checkGPS()
	{
		bool success = false;
		
		if(_camloc.locationFailed()) // if geolocation init failed
		{
			success = false; // flag failure
			_camloc.initGPS(); // attempt to re-initialize
		}
		else if(_camloc.locationInitialising()) // initializing GPS
		{
			success = false; // still initializing
		} 
		else // initialized and has not failed
		{
			success = true; // gps found
			_initialized = true;
		}
		
		return(success);
	}
}
