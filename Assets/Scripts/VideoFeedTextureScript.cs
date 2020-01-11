using UnityEngine;
using System.Collections;

public class VideoFeedTextureScript : MonoBehaviour {
	private WebCamTexture webCamTexture;
	// Use this for initialization
	void Start () {
		// Set Orientation of the device.
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		// Set it so the device will never go into sleep mode
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		// set up for making a new WebCamTexture object.
		string deviceName = WebCamTexture.devices[0].name;
		webCamTexture = new WebCamTexture(deviceName, (int)((float)Screen.width/3), (int)((float)Screen.height/3), 60);
		webCamTexture.anisoLevel = 0;
		webCamTexture.filterMode = FilterMode.Point;
		webCamTexture.wrapMode = TextureWrapMode.Clamp;
		// Set the texture of the guiTexture that this script is attached to to webCamTexture.
		this.guiTexture.texture = webCamTexture;
		// Start the device camera.
		webCamTexture.Play();
		// Set up for guiTexture.
		guiTexture.pixelInset = new Rect(0, 0, Screen.width/2, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if(!webCamTexture.isPlaying)
		{
			webCamTexture.Play();
		}
	}
}
