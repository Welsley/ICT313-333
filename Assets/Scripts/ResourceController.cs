using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ResourceController : MonoBehaviour 
{
	private BuildingManager bm = new BuildingManager();
	private StaffManager sm = new StaffManager();
	private LectureManager lm = new LectureManager();
	public TextAsset txtfile;

	void Awake()
	{
		LoadAllData (); //load all data when application runs
	}

	public BuildingManager GetBuildingManager()
	{
		return bm;
	}

	public StaffManager GetStaffManager()
	{
		return sm;
	}

	public LectureManager GetLectureManager()
	{
		return lm;
	}

	/// <summary>
	/// Loads all data.
	/// </summary>
	void LoadAllData()
	{
		LoadLectureData (); //load lecture data, MUST happen BEFORE loading building data
		LoadStaffData (); //load staff data
		LoadBuildingData (); //load building data
	}

	/// <summary>
	/// Loads the building data.
	/// </summary>
	void LoadBuildingData()
	{
		Building temp;

		//load science and computing data
		temp = new Building ("245", "Science and Computing");
		//add occupant names
		temp.AddOccupant ("Shri Rai");
		temp.AddOccupant ("Dr Mohd Fairuz Shiratuddin");
		temp.AddOccupant ("Danny Toohey");
		temp.AddOccupant ("Dr Kevin Wong");
		temp.AddOccupant ("Dr Hong Xie");
		temp.AddOccupant ("Dr Nik Thompson");
		temp.AddOccupant ("Dr Pyara Dhillon");
		temp.AddOccupant ("Dr Christian Payne");
		temp.AddOccupant ("Peter Cole");
		temp.AddOccupant ("Dr Nik Thompson");
		//add services
		temp.AddService ("Computing Labs x5");
		temp.AddService ("Meeting Rooms x3");
		temp.AddService ("Research Labs x18");
		temp.AddService ("Male Toilets lvl 2");
		temp.AddService ("Female Toilets lvl 2");
		temp.AddService ("Male Toilets lvl 3");
		temp.AddService ("Female Toilets lvl 3");
		temp.AddService ("Male Emergency Shower 3.048");
		temp.AddService ("Female Emergency Shower 3.046");
		temp.AddService ("First Aid Room 3.052");
		temp.AddService ("RLT");
		//add lectures
		temp.AddLecture (8);
		//add building to building manager
		bm.AddBuilding (temp);

		//load library
		temp = new Building ("350", "Library");
		//add occupant names
		temp.AddOccupant ("Sarah Blacklock");
		temp.AddOccupant ("Dr Stephen Johnson");
		temp.AddOccupant ("Professor Rick Cummings");
		temp.AddOccupant ("Helen Cole");
		temp.AddOccupant ("Dr Angela Jones");
		temp.AddOccupant ("Karyn Barenberg");
		temp.AddOccupant ("Dr Rebecca Bennett");
		temp.AddOccupant ("Pamela Martin-Lynch");
		temp.AddOccupant ("Jodie-Lee McLeod");
		temp.AddOccupant ("Joanne Lisciandro");
		//add services
		temp.AddService ("Computing Labs x5");
		temp.AddService ("Meeting Rooms x2");
		temp.AddService ("Private Study Rooms x20");
		temp.AddService ("Silent Computing Lab lvl 1 South");
		temp.AddService ("Library & Information Services lvl 2 South");
		temp.AddService ("After Hours Entry lvl 2 Learning Link");
		temp.AddService ("DVD Viewing Rooms x3");
		temp.AddService ("Photocopying & Printing Services");
		temp.AddService ("IT Service Desk lvl 3 North");
		temp.AddService ("Reserve Section lvl 3 North");
		//no lectures
		//add building to building manager
		bm.AddBuilding (temp);

		//load ECL
		temp = new Building ("460", "Economics, Commerce and Law");
		//add occupant names
		temp.AddOccupant ("Dr Joseph Indaimo");
		temp.AddOccupant ("Lauren McNaught");
		temp.AddOccupant ("Ken Robson");
		temp.AddOccupant ("Liz Waldeck");
		temp.AddOccupant ("Ajantha Thinkaran");
		temp.AddOccupant ("Dr Arahita Riegler");
		temp.AddOccupant ("Linda Jurevic");
		temp.AddOccupant ("Dr Neil Mcleod");
		temp.AddOccupant ("Sarah Withnall Howe");
		temp.AddOccupant ("Dr Dennis Ndonga");
		//add services
		temp.AddService ("Male/Female Toilets");
		temp.AddService ("Lift Access");
		temp.AddService ("Kitchens");
		temp.AddService ("Meeting/Seminar Rooms");
		temp.AddService ("Computer Labs");
		temp.AddService ("Post Graduate Area");
		temp.AddService ("Lunch Box Cafe");
		temp.AddService ("First Aid Boxes");
		temp.AddService ("Security Call Points");
		temp.AddService ("Catholic Chaplain");
		temp.AddService ("ECL1");
		temp.AddService ("ECL2");
		temp.AddService ("ECL3");
		temp.AddService ("ECL4");
		//add lectures
		temp.AddLecture (1);
		temp.AddLecture (9);
		temp.AddLecture (16);
		temp.AddLecture (17);
		temp.AddLecture (21);
		//add building to building manager
		bm.AddBuilding (temp);

		//add Chancellery



//		//Load building data here
//		string dirInfo = Application.dataPath + "/Resources/Buildings";
//		string[] subdirectories = Directory.GetDirectories (dirInfo);
//
//		foreach (string d in subdirectories) //for each directory
//		{
//			Building temp = new Building();
//			DirectoryInfo dir = new DirectoryInfo(d);
//			string path = dir.Name;
//			txtfile = Resources.Load("Buildings/" + path + "/building_info") as TextAsset;
//			char[] separators = {'\n'};
//			string[] linesFromfile = txtfile.text.Split (separators);
//			string[] tokens;
//
//			//occupants
//			int oIndex = 3; //index of first occupant
//			tokens = linesFromfile[oIndex-1].Split(':'); //split "Number of Occupants: " string
//			int oCount = Int32.Parse (tokens[1].Trim()); //get number of occupants
//			//Debug.Log("OCCUPANTS " + oIndex.ToString() + "   " + tokens[1].Trim() + "   " + oCount.ToString());
//
//			//services
//			int sIndex = oIndex + oCount + 1; //index of first service
//			tokens = linesFromfile[sIndex-1].Split(':'); //split "Number of Services: " string
//			int sCount = Int32.Parse (tokens[1].Trim()); //get the number of services
//			//Debug.Log("SERVICES " + sIndex.ToString() + "   " + tokens[1].Trim() + "   " + sCount.ToString());
//
//			//lectures
//			int lIndex = sIndex + sCount + 1; //index of the first lecture
//			tokens = linesFromfile[lIndex-1].Split(':'); //split "Number of Lectures: " string
//			//Debug.Log(tokens[1]);
//			int lCount = Int32.Parse (tokens[1].Trim()); //get the number of lectures
//
//			//set building number
//			tokens = linesFromfile[0].Split(':'); //split the "Building Number: " string
//			temp.SetNumber(tokens[1].Trim()); //set the building number
//
//			//set building name
//			tokens = linesFromfile[1].Split(':'); //split the "Building Name: " string
//			temp.SetName(tokens[1].Trim()); //set the building name
//
//			//add occupants
//			for(int i=oIndex; i<oIndex + oCount; i++)
//			{
//				temp.AddOccupant(linesFromfile[i]);
//			}
//
//			//add services
//			for(int i=sIndex; i<sIndex + sCount; i++)
//			{
//				temp.AddService(linesFromfile[i]);
//			}
//
//			//add lectures
//			if(lCount > 0)
//			{
//				for(int i=lIndex; i<lIndex + lCount; i++) //for each lecture
//				{
//					string room = linesFromfile[i].Trim ();
//					temp.AddService(room + " (Lecture Room)");
//
//					for(int j=0; j<lm.NumberOfLectures(); j++) //for each lecture in lecture manager
//					{
//						//Debug.Log(lm.GetLectureAt(j).GetRoom());
//						if(lm.GetLectureAt(j).GetRoom().Trim().Equals(room)) //if the lecture room matches current lecture room
//							temp.AddLecture(lm.GetLectureAt(j).GetID());
//					}
//				}
//			}
//
//			bm.AddBuilding(temp);
//		}

//		Debug.Log (">>>No Buildings");
//		Debug.Log(bm.NumberOfBuildings().ToString());
//
//		for(int i=0; i<bm.NumberOfBuildings(); i++)
//		{
//			Debug.Log (">>>Building");
//			Debug.Log(bm.GetBuildingAt(i).GetName());
//			Debug.Log(bm.GetBuildingAt(i).GetNumber());
//
//			Debug.Log (">>>Occupants");
//			for(int j=0; j<bm.GetBuildingAt(i).NumberOfOccupants(); j++)
//				Debug.Log(bm.GetBuildingAt(i).GetOccupantAt(j));
//
//			Debug.Log (">>>Services");
//			for(int j=0; j<bm.GetBuildingAt(i).NumberOfServices(); j++)
//				Debug.Log(bm.GetBuildingAt(i).GetServiceAt(j));
//
//			Debug.Log (">>>Lectures");
//			Debug.Log(bm.GetBuildingAt(i).NumberOfLectures());
//			for(int j=0; j<bm.GetBuildingAt(i).NumberOfLectures(); j++)
//			{
//				int id = bm.GetBuildingAt(i).GetLectureAt(j);
//
//				for(int k=0; k<lm.NumberOfLectures(); k++)
//				{
//					if(lm.GetLectureAt(k).GetID() == id)
//						Debug.Log(lm.GetLectureAt(k).GetUnitCode() + " " + lm.GetLectureAt(k).GetUnitName());
//				}
//			}
//		}
	}

	/// <summary>
	/// Loads the staff data.
	/// </summary>
	void LoadStaffData()
	{
		Staff temp;

		//building 245
		//Shri Rai
		temp = new Staff ();
		temp.SetName ("Shri Rai");
		temp.SetBuildingNo ("245");
		temp.SetOfficeNo("1.019");
		temp.AddPhone ("9360 6090");
		temp.SetEmail ("s.rai@murdoch.edu.au");
		temp.SetPhoto ("none");
		temp.SetPosition ("Senior Lecturer");
		temp.AddOrganisation ("Academy");
		temp.AddOrganisation ("School of Engineering and Information Technology");
		temp.AddOrganisation ("Information Technology");
		//add to staff manager
		sm.AddStaff (temp);

		Debug.Log (temp.GetName ());
		Debug.Log(sm.GetStaffAt(0).GetName());

//		//Load staff data here
//		string dirInfo = Application.dataPath + "/Resources/Staff";
//		string[] subdirectories = Directory.GetDirectories (dirInfo);
//		
//		foreach (string d in subdirectories) //for each directory
//		{
//			Staff temp = new Staff ();
//			DirectoryInfo dir = new DirectoryInfo(d);
//			FileInfo[] files = dir.GetFiles(); //get list of files in the directory
//
//			foreach(FileInfo f in files) //for each file in the directory
//			{
//				if(!f.Name.Contains("meta")) //ignore if file name contains "meta" substring
//				{
//					string path = dir.Name;
//					string file = Path.GetFileNameWithoutExtension(f.Name);
//					TextAsset txtfile = Resources.Load("Staff/" + path + "/" + file) as TextAsset;
//					char[] separators = {'\n'};
//					string[] linesFromfile = txtfile.text.Split (separators);
//					string[] tokens;
//
//					//phones
//					int pIndex = 4; //index of first occupant
//					tokens = linesFromfile[pIndex-1].Split(':'); //split "Number of Phones: " string
//					int pCount = Int32.Parse (tokens[1].Trim()); //get number of phones
//					//Debug.Log(pIndex + " " + pCount);
//
//					//organisations
//					int oIndex = pIndex + pCount + 4; //index of first service
//					tokens = linesFromfile[oIndex-1].Split(':'); //split "Number of Organisations: " string
//					int oCount = Int32.Parse (tokens[1].Trim()); //get the number of organisations
//					//Debug.Log(oIndex + " " + oCount);
//
//					//set staff name
//					tokens = linesFromfile[0].Split(':');
//					temp.SetName(tokens[1].Trim());
//
//					//set building number
//					tokens = linesFromfile[1].Split(':');
//					temp.SetBuildingNo(tokens[1].Trim());
//
//					//set office number
//					tokens = linesFromfile[2].Split(':');
//					temp.SetOfficeNo(tokens[1].Trim());
//
//					//add phones
//					for(int i=pIndex; i<pIndex + pCount; i++)
//					{
//						temp.AddPhone(linesFromfile[i]);
//					}
//
//					//set email
//					tokens = linesFromfile[oIndex - 4].Split(':');
//					temp.SetEmail(tokens[1].Trim());
//
//					//set photo
//					tokens = linesFromfile[oIndex - 3].Split(':');
//					temp.SetPhoto(tokens[1].Trim());
//
//					//set position
//					tokens = linesFromfile[oIndex - 2].Split(':');
//					temp.SetPosition(tokens[1].Trim());
//
//					//add organisations
//					for(int i=oIndex; i<oIndex + oCount; i++)
//					{
//						temp.AddOrganisation(linesFromfile[i]);
//					}
//				}
//
//				sm.AddStaff (temp); //add the staff to the list
//			}
//		}

//		Debug.Log (">>>No Staff");
//		Debug.Log(sm.NumberOfStaff().ToString());
//
//		for(int i=0; i<sm.NumberOfStaff(); i++)
//		{
//			Debug.Log (">>>Staff Member");
//			Debug.Log(sm.GetStaffAt(i).GetName());
//			Debug.Log(sm.GetStaffAt(i).GetBuildingNo());
//			Debug.Log(sm.GetStaffAt(i).GetOfficeNo());
//
//			Debug.Log (">>>Phones");
//			for(int j=0; j<sm.GetStaffAt(i).NumberOfPhones(); j++)
//				Debug.Log(sm.GetStaffAt(i).GetPhoneAt(j));
//
//			Debug.Log(sm.GetStaffAt(i).GetEmail());
//			Debug.Log(sm.GetStaffAt(i).GetPhoto());
//			Debug.Log(sm.GetStaffAt(i).GetPosition());
//
//			Debug.Log (">>>Organisations");
//			for(int j=0; j<sm.GetStaffAt(i).NumberOfOrganisations(); j++)
//				Debug.Log(sm.GetStaffAt(i).GetOrganisationAt(j));
//		}
	}

	/// <summary>
	/// Loads the lecture data.
	/// </summary>
	void LoadLectureData()
	{
		Lecture temp;

		//building 245
		//add ICT167
		temp = new Lecture (8, "ICT167", "Principles of Computer Science", "Tuesday", "13:30", "15:30", "RLT");
		//add lecture to lecture manager
		lm.AddLecture (temp);
		Debug.Log(temp.GetID() + " " + lm.GetLectureAt(0).GetID());

//		//Load lecture data here
//		TextAsset txtfile = Resources.Load("Lectures/lecture_info") as TextAsset;
//		char[] separators = {'\n'};
//		string[] linesFromfile = txtfile.text.Split (separators);
//		string[] tokens;
//
//		foreach (string line in linesFromfile)
//		{
//			Lecture temp = new Lecture ();
//			tokens = line.Split (';');
//
//			temp.SetID(Int32.Parse(tokens[0]));
//			temp.SetUnitCode(tokens[1]);
//			temp.SetUnitName(tokens[2]);
//			temp.SetDay(tokens[3]);
//			temp.SetStart(tokens[4]);
//			temp.SetEnd(tokens[5]);
//			temp.SetRoom(tokens[6]);
//
//			lm.AddLecture(temp); //add lecture to lecture list

			//Debug.Log(temp.GetID() + " " + temp.GetUnitCode() + " " +  temp.GetUnitName() + " " +  temp.GetDay() 
			//          + " " +  temp.GetStart() + " " +  temp.GetEnd() + " " +  temp.GetRoom());
//		}
	}
}