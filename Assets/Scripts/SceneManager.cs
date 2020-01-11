using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
	private Geolocation _camLoc;
	private double _directionx;
	private double _directiony;
	private double _locationx;
	private double _locationy;
	private double _trueNorth;
	private double _vecLength;
	private GUIControllerScript gcs;
	private string _location;
	private Rect _GUIWindow;
	private AndroidJavaClass gpsActivityJavaClass;
	private ResourceController rc;
	private BuildingManager buildingManager;
	private StaffManager staffManager;
	private LectureManager lectureManager;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		AndroidJNI.AttachCurrentThread();
		//gpsActivityJavaClass = new AndroidJavaClass ("com.TeamWARIS.WARISProject.CustomGPS");
		Debug.Log ("sdkfsdkjfahksd");
		_camLoc = gameObject.AddComponent<Geolocation>();
		_camLoc.initGPS();
		_directionx = 0;
		_directiony = 1;
		setCamVecLength(0.00015);
		checkGPS();
		gcs = GetComponent<GUIControllerScript>();
		_location = "";
		_GUIWindow = new Rect(Screen.width / 4 + 10, (Screen.height / 2) + 10, Screen.width / 4 - 20, (Screen.height / 2) - 35);

		rc = (ResourceController)GameObject.Find ("Resource Controller").GetComponent<ResourceController> ();
		buildingManager = rc.GetBuildingManager ();

		gpsActivityJavaClass = new AndroidJavaClass ("com.TeamWARIS.WARISProject.CustomGPS");
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
		if(! checkGPS())
		{
			gcs.SetupWindow(_GUIWindow, "Connection lost!", "Reaquiring locational information now...", 0, false, false, false, null, null, null);
			//gcs.SetupWindow(_GUIWindow, number, name, 0, true, true, true, );
		}
		else
		{
			if(findLookAt())
			{
				switch(_location)
				{
					case "Science and Computing":
					{
						//if(!gcs.isWindowOpen())
						//{
							gcs.SetupWindow(_GUIWindow, buildingManager.GetBuildingAt (0).GetNumber (), buildingManager.GetBuildingAt (0).GetName (), 0, true, true, true, buildingManager.GetBuildingAt(0), staffManager, lectureManager);
						//}
						break;
					}
					case "Library":
					{
						//if(!gcs.isWindowOpen())
						//{
							gcs.SetupWindow(_GUIWindow, buildingManager.GetBuildingAt (1).GetNumber (), buildingManager.GetBuildingAt (1).GetName (), 0, true, true, true, buildingManager.GetBuildingAt(1), staffManager, lectureManager);
						//}
						break;
					}
					case "ECL":
					{
						//if(!gcs.isWindowOpen())
						//{
							gcs.SetupWindow(_GUIWindow, buildingManager.GetBuildingAt (2).GetNumber (), buildingManager.GetBuildingAt (2).GetName (), 0, true, true, true, buildingManager.GetBuildingAt(2), staffManager, lectureManager);
						//}
						break;
					}
					case "Chancellery":
					{
						//if(!gcs.isWindowOpen())
						//{
							gcs.SetupWindow(_GUIWindow, buildingManager.GetBuildingAt (3).GetNumber (), buildingManager.GetBuildingAt (3).GetName (), 0, true, true, true, buildingManager.GetBuildingAt(3), staffManager, lectureManager);
						//}
						break;
					}
					default:
					{
						break;
					}
				}
			}

		}
	}

	/// <summary>
	/// Gets the location of the device.
	/// </summary>
	private void getLocation()
	{
		_locationx = gpsActivityJavaClass.CallStatic<double>("getLongitude");
		_locationy = gpsActivityJavaClass.CallStatic<double>("getLatitude");
		/*_locationx = _camLoc.getLongitude();
		_locationy = _camLoc.getLatitude();*/
	}

	/// <summary>
	/// Gets the degrees away from North.
	/// </summary>
	private void getTrueHeading()
	{
		_trueNorth = (double)_camLoc.getTrueNorth();
	}

	/// <summary>
	/// Sets the length of the device's vector.
	/// </summary>
	/// <param name="length">Length.</param>
	private void setCamVecLength(double length)
	{
		_vecLength = length;
	}

	/// <summary>
	/// Finds the device's direction it is facing.
	/// </summary>
	private void findVecDirection()
	{
		this.getTrueHeading();
		double trueNorthRad = _trueNorth * (double)Mathf.Deg2Rad;
		_directionx = 0d * (double)Mathf.Cos((float)trueNorthRad) + 1d * (double)Mathf.Sin((float)trueNorthRad);
		_directiony = -0d * (double)Mathf.Sin((float)trueNorthRad) + 1d * (double)Mathf.Cos((float)trueNorthRad);
	}

	/// <summary>
	/// Tells if the vector is in the radius of the location given.
	/// </summary>
	/// <returns><c>true</c>, if vector in radius was ised, <c>false</c> otherwise.</returns>
	/// <param name="longitude">Longitude.</param>
	/// <param name="latitude">Latitude.</param>
	/// <param name="radius">Radius.</param>
	private bool isVectorInRadius(double longitude, double latitude, double radius)
	{
		this.getLocation();
		this.findVecDirection();
		/*
		// The following algorithm was found from an online source.
		double vecPosX = _locationx + _directionx * _vecLength;
		double vecPosY = _locationy + _directiony * _vecLength;
		
		double LAB = (double)(Mathf.Sqrt(Mathf.Pow((float)(vecPosX - _locationx), 2f) + (Mathf.Pow((float)(vecPosY - _locationy), 2f))));
		double Dx = (vecPosX - _locationx) / LAB;
		double Dy = (vecPosY - _locationy) / LAB;
		
		double t = Dx * (longitude - _locationx) + Dy * (latitude - _locationy);
		
		double Ex = t * Dx + _locationx;
		double Ey = t * Dy + _locationy;
		
		double LEC = (double)Mathf.Sqrt(Mathf.Pow((float)(Ex - longitude), 2f) + Mathf.Pow((float)(Ey - latitude), 2f));
		
		return (LEC < radius);
		*/
		// ----------

		double vecPosX = _directionx * _vecLength + _locationx;
		double vecPosY = _directiony * _vecLength + _locationy;
		
		double vecPosXDist = (double)Mathf.Abs((float)(vecPosX - longitude));
		double vecPosYDist = (double)Mathf.Abs((float)(vecPosY - latitude));
		
		double vecPosDist = Mathf.Sqrt(Mathf.Pow((float)vecPosXDist, 2f) + Mathf.Pow((float)vecPosYDist, 2f));

		return (vecPosDist < radius);
		
		//return ((Mathf.Sqrt((Mathf.Pow((Mathf.Abs((float)((_directionx * (float)_vecLength + _locationx) - longitude))), 2) + Mathf.Pow((Mathf.Abs((float)((_directiony * (float)_vecLength + _locationy) - latitude))), 2)))) < radius);

		// ----------
		/*
		double posx = (double)Mathf.Abs((float)(longitude - _locationx));
		double posy = (double)Mathf.Abs((float)(latitude - _locationy));
		
		double vecPosDist = Mathf.Sqrt((Mathf.Pow((float)posx, 2f) + Mathf.Pow((float)posy, 2f)));
		
		return (vecPosDist < radius);
		*/
	}

	private bool findLookAt()
	{
		if(isVectorInRadius(115.834377d, -32.067591d, 0.0002625d))
		{
			_location = "ECL";
			return true;
		}
		else if(isVectorInRadius(115.837015d, -32.066654d, 0.00026125d))
		{
			_location = "Science and Computing";
			return true;
		}
		else if(isVectorInRadius(115.835067d, -32.067263d, 0.000475d))
		{
			_location = "Library";
			return true;
		}
		else if(isVectorInRadius(115.835731d, -32.065950d, 0.000188d) || isVectorInRadius(115.836020d, -32.065954d, 0.000113d))
		{
			_location = "Chancellery";
			return true;
		}
		else
		{
			_location = "Unknown Location";
			return false;
		}
		return false;
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
	private bool checkGPS()
	{
		// GetComponent<GUIControllerScript>().SetupWindow (new Rect ((Screen.width / 2)-220, 20, 200, 250), "INITIALIZING...", "INITIALIZING...", 0, true, true, true);
		//bool success = false;
		
		if(_camLoc.locationFailed()) // if geolocation init failed
		{
			// GetComponent<GUIControllerScript>().SetupWindow (new Rect ((Screen.width / 2)-220, 20, 200, 250), "1111111111", "1111111111", 0, true, true, true);
			_camLoc.initGPS(); // attempt to re-initialize
			return false; // flag failure
		}
		else if(_camLoc.locationInitialising()) // initializing GPS
		{
			// GetComponent<GUIControllerScript>().SetupWindow (new Rect ((Screen.width / 2)-220, 20, 200, 250), "2222222222", "2222222222", 0, true, true, true);
			return false; // still initializing
		} 
		else // initialized and has not failed
		{
			// GetComponent<GUIControllerScript>().SetupWindow (new Rect ((Screen.width / 2)-220, 20, 200, 250), "3333333333", "3333333333", 0, true, true, true);
			return true; // gps found
		}
	}


}