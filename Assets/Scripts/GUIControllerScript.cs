using UnityEngine;
using System.Collections;

/**
 * 
 * @Class: GUIControllerScript
 * @Summary: Used to handle GUI for this program
 * 
 * Author: Tim Matisons
 * 
 * */
public class GUIControllerScript : MonoBehaviour {

	public CursorController cursorController;
	private Vector2 scrollPosition = Vector2.zero;
	private Vector2 scrollPosition2 = Vector2.zero;
	private bool showWindow;
	private bool showServicesScrollWindow;
	private bool showOccupantsScrollWindow;
	private bool showLecturesScrollWindow;
	private int fontSize = 16;

	private Rect windowRect;
	private Rect windowRectDupe;
	private string windowLabel;
	private string windowText;
	private int windowIDnum;
	private bool windowServices;
	private bool windowOccupants;
	private bool windowLectures;

	private int screenWidth;
	private int screenHeight;

	private Building currentBuilding;
	private StaffManager staffManager;
	private LectureManager lectureManager;

	private int scrollSize;
	private string scrollText;
	private bool scrollTextLoaded;

	private int buttonNum;

	private Vector2 pos;
	private Vector2 dupePos;
	
	void Start () 
	{
		showWindow = false;
		buttonNum = 0;
		scrollSize = 50000;
		scrollText = "";
		scrollTextLoaded = false;
		showServicesScrollWindow = false;
		showOccupantsScrollWindow = false;
		showLecturesScrollWindow = false;

		screenHeight = Screen.height;
		screenWidth = Screen.width;

	}

	void Update () 
	{
		buttonNum = 0;
		if(windowServices)
		{
			buttonNum++;
		}
		if(windowOccupants)
		{
			buttonNum++;
		}
		if(windowLectures)
		{
			buttonNum++;
		}

		pos = cursorController.GetCursorPosition ();
		dupePos = pos;
		dupePos.x += screenWidth / 2;

		if (Time.frameCount % 30 == 0)
		{
			System.GC.Collect();
		}
	}

	void OnGUI()
	{
		GUI.depth = 2;

		GUI.skin.label.fontSize = fontSize;


		//ScrollView Services
		if(showServicesScrollWindow)
		{
			ScrollWindowFunction(0);
		}
		//End Scrollview Services

		///ScrollView Occupants
		else if(showOccupantsScrollWindow)
		{
			ScrollWindowFunction(1);
		}
		//End Scrollview Occupants

		//ScrollView Lectures
		else if(showLecturesScrollWindow)
		{
			ScrollWindowFunction(2);
		}
		//End Scrollview Lectures


		//Windows
		windowRectDupe = new Rect (windowRect);
		windowRectDupe.x += screenWidth / 2;

		if(showWindow)
		{
			windowRect = GUI.Window (windowIDnum, windowRect, WindowFunction, windowLabel);
			windowRectDupe = GUI.Window (windowIDnum + 1, windowRectDupe, WindowFunction, windowLabel);
		}
		//End Windows
	}

	public bool isWindowOpen()
	{
		return showWindow;
	}


	/// <summary>
	/// Function for a GUI window.
	/// </summary>
	/// <param name="windowID">ID for the window.</param>
	void WindowFunction(int windowID)
	{
		GUI.Label (new Rect(20, 20, 100, 50), windowText);

		Vector2 pos = cursorController.GetCursorPosition ();

		if(windowServices)
		{
			int h = 50*buttonNum;
			if(h > 150)
				h = 150;
			var testRect = new Rect (35, windowRect.height - h, 130, 40);
			GUI.Button(testRect, "Service Details");
			testRect = new Rect (testRect.x + windowRect.x, testRect.y + windowRect.y, testRect.width, testRect.height); 
			if(testRect.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
			{
				showServicesScrollWindow = true;
				showOccupantsScrollWindow = false;
				showLecturesScrollWindow = false;
			}
		}

		if(windowOccupants)
		{
			int h = 50*buttonNum;
			if(h > 100)
				h = 100;
			var testRect = new Rect (35, windowRect.height - h, 130, 40);
			GUI.Button(testRect, "Occupant Details");
			testRect = new Rect (testRect.x + windowRect.x, testRect.y + windowRect.y, testRect.width, testRect.height); 
			if(testRect.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
			{
				showOccupantsScrollWindow = true;
				showServicesScrollWindow = false;
				showLecturesScrollWindow = false;
			}
		}

		if(windowLectures)
		{
			int h = 50*buttonNum;
			if(h > 50)
				h = 50;
			var testRect = new Rect (35, windowRect.height - h, 130, 40);
			GUI.Button(testRect, "Lectures Details");
			testRect = new Rect (testRect.x + windowRect.x, testRect.y + windowRect.y, testRect.width, testRect.height); 
			if(testRect.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
			{
				showLecturesScrollWindow = true;
				showServicesScrollWindow = false;
				showOccupantsScrollWindow = false;
			}
		}

		var testRect2 = new Rect (windowRect.width - 50, 0, 50, 50);
		GUI.Button (testRect2, "X");
		testRect2 = new Rect (testRect2.x + windowRect.x, testRect2.y + windowRect.y, testRect2.width, testRect2.height);
		if(testRect2.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
		{
			showWindow = false;
			showServicesScrollWindow = false;
			showOccupantsScrollWindow = false;
			showLecturesScrollWindow = false;
		}
	}


	/// <summary>
	/// Sets up the window.
	/// Sets private GUIControllerScript variables to those passed in
	/// </summary>
	/// <param name="window">Rect containing window size and position.</param>
	/// <param name="label">Label of the window.</param>
	/// <param name="text">Text to be written in the window.</param>
	/// <param name="windowID">Window ID number.</param>
	/// <param name="services">If set to <c>true</c> window has a "Services Details" button.</param>
	/// <param name="occupants">If set to <c>true</c> window has an "Occupants Details" button.</param>
	/// <param name="lectures">If set to <c>true</c> window has a "Lecture Details" button.</param>
	/// <param name="buildingDetails">Building data structure with info for the scroll texts.</param>
	public void SetupWindow(Rect window, string label, string text, int windowID, bool services, bool occupants, bool lectures, Building buildingDetails, StaffManager staffDetails, LectureManager lectureDetails)
	{
		windowRect = window;
		// windowRect = new Rect(window);
		windowLabel = label;
		windowText = text;
		windowIDnum = windowID;
		windowServices = services;
		windowOccupants = occupants;
		windowLectures = lectures;
		currentBuilding = buildingDetails;
		staffManager = staffDetails;
		lectureManager = lectureDetails;
		showWindow = true;

	}


	/// <summary>
	/// Function for a scroll window
	/// </summary>
	/// <param name="type">Type of data being displayed in the scroll window. 0 for services, 1 for occupants, 2 for lectures</param>
	private void ScrollWindowFunction(int type)
	{
		if(!scrollTextLoaded)
		{
			scrollText = "\n\n\n";
			switch(type)
			{
				case 0:
				{
					for(int i = 0; i < currentBuilding.NumberOfServices(); i++)//********************************************************************************************************
					{
						scrollText += currentBuilding.GetServiceAt(i);
						scrollText += "\n";
					}
					break;
				}
				case 1:
				{
					/*for(int i = 0; i < currentBuilding.NumberOfOccupants(); i++)
					{
						string name = currentBuilding.GetOccupantAt(i);
						for(int j = 0; j < staffManager.NumberOfStaff(); j++)
						{
							if(name.Equals(staffManager.GetStaffAt(j).GetName()))
							{
								scrollText += staffManager.GetStaffAt(j).GetName();
								scrollText += "\n";
								scrollText += staffManager.GetStaffAt (j).GetPosition();
								scrollText += "\n";
								scrollText += staffManager.GetStaffAt(j).GetOfficeNo().ToString();
								scrollText += "\n";
								scrollText += staffManager.GetStaffAt(j).GetEmail();
								scrollText += "\n";
								for(int k = 0; k < staffManager.GetStaffAt(j).NumberOfPhones(); k++)
								{
									scrollText += staffManager.GetStaffAt(j).GetPhoneAt(k);
									if(!(k < staffManager.GetStaffAt(j).NumberOfPhones() - 1))
									{
										scrollText += ", ";
									}
									else
									{
										scrollText += "\n";
									}									
								}
								for(int k = 0; k < staffManager.GetStaffAt(j).NumberOfOrganisations(); k++)
								{
									scrollText += staffManager.GetStaffAt (j).GetOrganisationAt(k);
									if(!(k < staffManager.GetStaffAt(j).NumberOfOrganisations() - 1))
									{
										scrollText += ", ";
									}	
								}
								scrollText += "\n\n\n";
							}
						   
						}

						
					}*/
					scrollText += "testtttttt"; 
					break;
				}
				case 2:
				{
					for(int i = 0; i < currentBuilding.NumberOfLectures(); i++) //for each lecture in building
					{
						int id = currentBuilding.GetLectureAt(i);
						for(int j = 0; j < lectureManager.NumberOfLectures(); j++)
						{
							if(id == lectureManager.GetLectureAt(j).GetID())
							{
							scrollText += lectureManager.GetLectureAt(j).GetUnitCode();
							scrollText += "\n";
							scrollText += lectureManager.GetLectureAt(j).GetUnitName();
							scrollText += "\n";
							scrollText += lectureManager.GetLectureAt(j).GetDay();
							scrollText += " ";
							scrollText += lectureManager.GetLectureAt(j).GetStart();
							scrollText += " - ";
							scrollText += lectureManager.GetLectureAt(j).GetEnd();
							scrollText += "\n";
							scrollText += lectureManager.GetLectureAt(j).GetRoom();
							}
						}
						scrollText += "\n\n\n";
					}
					break;
				}
				default:
				{
					Debug.Log("ScrollWindowFunction in GUIControllerScipt: Wrong type used!");
					break;
				}
			}
			scrollTextLoaded = true;
		}

		var testWinRect = new Rect (20, 300, 300, 300);
		scrollPosition = GUI.BeginScrollView (testWinRect, scrollPosition, new Rect (0, 0, 190, scrollSize));
		if(testWinRect.Contains (pos)) //if cursor over window
		{
			if(Input.GetAxis ("Scroll Y") != 0)
			{
				if(Input.GetAxis ("Scroll Y") > 0 && scrollPosition.y < scrollSize)
					GUI.ScrollTo(new Rect(0, scrollPosition.y + 5.0f, 300, 300));
				else if(Input.GetAxis ("Scroll Y") < 0 && scrollPosition.y > 0)
					GUI.ScrollTo(new Rect(0, scrollPosition.y - 10.0f, 300, 300));
			}
		}
		
		var testRect2 = new Rect (testWinRect.width - 50, 0, 50, 50);
		GUI.Button (testRect2, "X");
		testRect2 = new Rect (testRect2.x + testWinRect.x, testRect2.y + testWinRect.y, testRect2.width, testRect2.height);
		if(testRect2.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked, only need one button test
		{
			showServicesScrollWindow = false;
			showOccupantsScrollWindow = false;
			showLecturesScrollWindow = false;
			scrollTextLoaded = false;
			scrollText = "";
		}
		
		scrollText = GUI.TextArea (new Rect (0, 0, 300, scrollSize), scrollText);
		GUI.EndScrollView ();
		
		
		var testWinRectDupe = new Rect (testWinRect);
		testWinRectDupe.x += screenWidth/2;
		scrollPosition2 = GUI.BeginScrollView (testWinRectDupe, scrollPosition2, new Rect (0, 0, 190, scrollSize));
		if(testWinRectDupe.Contains (dupePos)) //if cursor over window
		{
			if(Input.GetAxis ("Scroll Y") != 0)
			{
				if(Input.GetAxis ("Scroll Y") > 0 && scrollPosition2.y < scrollSize)
					GUI.ScrollTo(new Rect(0, scrollPosition2.y + 5.0f, 300, 300));
				else if(Input.GetAxis ("Scroll Y") < 0 && scrollPosition2.y > 0)
					GUI.ScrollTo(new Rect(0, scrollPosition2.y - 10.0f, 300, 300));
			}
		}
		
		testRect2 = new Rect (250, 0, 50, 50);
		GUI.Button (testRect2, "X");
		testRect2 = new Rect (testRect2.x + scrollPosition.x, testRect2.y + scrollPosition.y, testRect2.width, testRect2.height);
		if(testRect2.Contains(pos) && cursorController.CursorClicked()) //if cursor over button and clicked
		{
			showServicesScrollWindow = false;
			showOccupantsScrollWindow = false;
			showLecturesScrollWindow = false;
		}

		scrollText = GUI.TextArea (new Rect (0, 0, 300, scrollSize), scrollText);
		GUI.EndScrollView ();
	}
}
