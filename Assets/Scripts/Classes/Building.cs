using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Building
{  
	private string mNumber; 
	private string mName;
	private List<string> mOccupants;
	private List<string> mServices;
	private List<int> mLectures;

	/// <summary>
	/// Initializes a new instance of the <see cref="Building"/> class.
	/// </summary>
	public Building()
	{
		mNumber = null;
		mName = null;
		mOccupants = new List<string> ();
		mServices = new List<string> ();
		mLectures = new List<int> ();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Building"/> class.
	/// </summary>
	/// <param name="num">Number.</param>
	/// <param name="name">Name.</param>
	public Building(string num, string name)
	{
		mNumber = num;
		mName = name;
		mOccupants = new List<string> ();
		mServices = new List<string> ();
		mLectures = new List<int> ();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Building"/> class.
	/// </summary>
	/// <param name="b">The blue component.</param>
	public Building(Building b)
	{
		mNumber = b.GetNumber (); 
		mName = b.GetName ();
		mOccupants = new List<string> ();
		mServices = new List<string> ();
		mLectures = new List<int> ();

		for(int i=0; i<b.NumberOfOccupants(); i++)
		{
			this.AddOccupant(b.GetOccupantAt(i));
		}

		for(int i=0; i<b.NumberOfServices(); i++)
		{
			this.AddService(b.GetServiceAt(i));
		}

		for(int i=0; i<b.NumberOfLectures(); i++)
		{
			this.AddLecture(b.GetLectureAt(i));
		}
	}

	/// <summary>
	/// Sets the number.
	/// </summary>
	/// <returns><c>true</c>, if number was set, <c>false</c> otherwise.</returns>
	/// <param name="num">Number.</param>
	public bool SetNumber(string num)
	{
		bool isValid;

		if (num != null) 
		{
			mNumber = num;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the name.
	/// </summary>
	/// <returns><c>true</c>, if name was set, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	public bool SetName(string name)
	{
		bool isValid;
		
		if (name != null) 
		{
			mName = name;
			isValid = true;
		} 
		else
			isValid = false;
		
		return isValid;
	}

	/// <summary>
	/// Gets the number.
	/// </summary>
	/// <returns>The number.</returns>
	public string GetNumber()
	{
		return mNumber;
	}

	/// <summary>
	/// Gets the name.
	/// </summary>
	/// <returns>The name.</returns>
	public string GetName()
	{
		return mName;
	}

	/// <summary>
	/// Gets the occupant at index.
	/// </summary>
	/// <returns>The <see cref="System.String"/>.</returns>
	/// <param name="index">Index.</param>
	public string GetOccupantAt(int index)
	{
		return mOccupants [index];
	}

	/// <summary>
	/// Gets the service at index.
	/// </summary>
	/// <returns>The <see cref="System.String"/>.</returns>
	/// <param name="index">Index.</param>
	public string GetServiceAt(int index)
	{
		return mServices [index];
	}

	/// <summary>
	/// Gets the lecture at index.
	/// </summary>
	/// <returns>The <see cref="System.Int32"/>.</returns>
	/// <param name="index">Index.</param>
	public int GetLectureAt(int index)
	{
		return mLectures [index];
	}

	/// <summary>
	/// Gets the number of occupants.
	/// </summary>
	/// <returns>The number of occupants.</returns>
	public int NumberOfOccupants()
	{
		return mOccupants.Count;
	}

	/// <summary>
	/// Gets the number of services.
	/// </summary>
	/// <returns>The number of services.</returns>
	public int NumberOfServices()
	{
		return mServices.Count;
	}

	/// <summary>
	/// Gets the number of lectures.
	/// </summary>
	/// <returns>The number of lectures.</returns>
	public int NumberOfLectures()
	{
		return mLectures.Count;
	}

	/// <summary>
	/// Adds the occupant.
	/// </summary>
	/// <returns><c>true</c>, if occupant was added, <c>false</c> otherwise.</returns>
	/// <param name="occupant">Occupant.</param>
	public bool AddOccupant(string occupant)
	{
		bool added;
		int startSize = mOccupants.Count;
		
		if ((occupant != null) && (!this.ContainsOccupant(occupant))) //if occupant not null AND occupant doesnt already exist
		{
			mOccupants.Add(occupant);

			if(mOccupants.Count > startSize)
				added = true;
			else
				added =false;
		} 
		else
			added = false;
		
		return added;
	}

	/// <summary>
	/// Removes the occupant.
	/// </summary>
	/// <returns><c>true</c>, if occupant was removed, <c>false</c> otherwise.</returns>
	/// <param name="occupant">Occupant.</param>
	public bool RemoveOccupant(string occupant)
	{
		bool removed;
		int startSize = mOccupants.Count;
		
		if (occupant != null) 
		{
			mOccupants.Remove(occupant);
			
			if(mOccupants.Count < startSize)
				removed = true;
			else
				removed =false;
		} 
		else
			removed = false;
		
		return removed;
	}

	/// <summary>
	/// Determines if the occupant list contains the occupant.
	/// </summary>
	/// <returns><c>true</c>, if occupant exists, <c>false</c> otherwise.</returns>
	/// <param name="occupant">Occupant.</param>
	public bool ContainsOccupant(string occupant)
	{
		bool contains;
		
		if (occupant != null) 
		{
			contains  = mOccupants.Contains(occupant);
		} 
		else
			contains = false;
		
		return contains;
	}

	/// <summary>
	/// Adds the service.
	/// </summary>
	/// <returns><c>true</c>, if service was added, <c>false</c> otherwise.</returns>
	/// <param name="service">Service.</param>
	public bool AddService(string service)
	{
		bool added;
		int startSize = mServices.Count;
		
		if ((service != null) && (!this.ContainsService(service))) //if service is not null AND service doesnt already exist
		{
			mServices.Add(service);
			
			if(mServices.Count > startSize)
				added = true;
			else
				added =false;
		} 
		else
			added = false;
		
		return added;
	}

	/// <summary>
	/// Removes the service.
	/// </summary>
	/// <returns><c>true</c>, if service was removed, <c>false</c> otherwise.</returns>
	/// <param name="service">Service.</param>
	public bool RemoveService(string service)
	{
		bool removed;
		int startSize = mServices.Count;
		
		if (service != null) 
		{
			mServices.Remove(service);
			
			if(mServices.Count < startSize)
				removed = true;
			else
				removed =false;
		} 
		else
			removed = false;
		
		return removed;
	}

	/// <summary>
	/// Determine if service list contains the service.
	/// </summary>
	/// <returns><c>true</c>, if service exists, <c>false</c> otherwise.</returns>
	/// <param name="service">Service.</param>
	public bool ContainsService(string service)
	{
		bool contains;
		
		if (service != null) 
		{
			contains = mServices.Contains(service);
		} 
		else
			contains = false;
		
		return contains;
	}

	/// <summary>
	/// Adds the lecture.
	/// </summary>
	/// <returns><c>true</c>, if lecture was added, <c>false</c> otherwise.</returns>
	/// <param name="lectureID">Lecture I.</param>
	public bool AddLecture(int lectureID)
	{
		bool added;
		int startSize = mLectures.Count;
		
		if ((lectureID > 0) && (!this.ContainsLecture(lectureID))) //if lectureID is greater than 0 AND lecture does not exist
		{
			mLectures.Add(lectureID);
			
			if(mLectures.Count > startSize)
				added = true;
			else
				added =false;
		} 
		else
			added = false;
		
		return added;
	}

	/// <summary>
	/// Removes the lecture.
	/// </summary>
	/// <returns><c>true</c>, if lecture was removed, <c>false</c> otherwise.</returns>
	/// <param name="lectureID">Lecture I.</param>
	public bool RemoveLecture(int lectureID)
	{
		bool removed;
		int startSize = mLectures.Count;
		
		if (lectureID > 0) 
		{
			mLectures.Remove(lectureID);
			
			if(mLectures.Count < startSize)
				removed = true;
			else
				removed =false;
		} 
		else
			removed = false;
		
		return removed;
	}

	/// <summary>
	/// Determines if the lecture list contains the lecture.
	/// </summary>
	/// <returns><c>true</c>, if lecture exists, <c>false</c> otherwise.</returns>
	/// <param name="lectureID">Lecture I.</param>
	public bool ContainsLecture(int lectureID)
	{
		bool contains;
		
		if (lectureID > 0) 
		{
			contains = mLectures.Contains(lectureID);
		} 
		else
			contains = false;
		
		return contains;
	}
}