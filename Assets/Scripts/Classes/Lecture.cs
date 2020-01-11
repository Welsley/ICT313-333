using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Lecture
{  
	private int mID;
	private string mUnitCode;
	private string mUnitName;
	private string mDay;
	private string mStart;
	private string mEnd;
	private string mRoom;

	/// <summary>
	/// Initializes a new instance of the <see cref="Lecture"/> class.
	/// </summary>
	public Lecture()
	{
		mID = 0;
		mUnitCode = null;
		mUnitName = null;
		mDay = null;
		mStart = null;
		mEnd = null;
		mRoom = null;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Lecture"/> class.
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <param name="code">Code.</param>
	/// <param name="name">Name.</param>
	/// <param name="day">Day.</param>
	/// <param name="start">Start.</param>
	/// <param name="end">End.</param>
	/// <param name="room">Room.</param>
	public Lecture(int id, string code, string name, string day, string start, string end, string room)
	{
		mID = id;
		mUnitCode = code;
		mUnitName = name;
		mDay = day;
		mStart = start;
		mEnd = end;
		mRoom = room;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Lecture"/> class.
	/// </summary>
	/// <param name="l">L.</param>
	public Lecture(Lecture l)
	{
		mID = l.GetID();
		mUnitCode = l.GetUnitCode();
		mUnitName = l.GetUnitName();
		mDay = l.GetDay();
		mStart = l.GetStart();
		mEnd = l.GetEnd();
		mRoom = l.GetRoom();
	}

	/// <summary>
	/// Sets the ID.
	/// </summary>
	/// <returns><c>true</c>, if ID was set, <c>false</c> otherwise.</returns>
	/// <param name="id">Identifier.</param>
	public bool SetID(int id)
	{
		bool isValid;

		if (id > 0) 
		{
			mID = id;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the unit code.
	/// </summary>
	/// <returns><c>true</c>, if unit code was set, <c>false</c> otherwise.</returns>
	/// <param name="code">Code.</param>
	public bool SetUnitCode(string code)
	{
		bool isValid;

		if (code != null) 
		{
			mUnitCode = code;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the name of the unit.
	/// </summary>
	/// <returns><c>true</c>, if unit name was set, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	public bool SetUnitName(string name)
	{
		bool isValid;

		if (name != null) 
		{
			mUnitName = name;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the day.
	/// </summary>
	/// <returns><c>true</c>, if day was set, <c>false</c> otherwise.</returns>
	/// <param name="day">Day.</param>
	public bool SetDay(string day)
	{
		bool isValid;

		if (day != null) 
		{
			mDay = day;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the start.
	/// </summary>
	/// <returns><c>true</c>, if start was set, <c>false</c> otherwise.</returns>
	/// <param name="start">Start.</param>
	public bool SetStart(string start)
	{
		bool isValid;

		if (start != null) 
		{
			mStart = start;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the end.
	/// </summary>
	/// <returns><c>true</c>, if end was set, <c>false</c> otherwise.</returns>
	/// <param name="end">End.</param>
	public bool SetEnd(string end)
	{
		bool isValid;

		if (end != null) 
		{
			mEnd = end;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the room.
	/// </summary>
	/// <returns><c>true</c>, if room was set, <c>false</c> otherwise.</returns>
	/// <param name="room">Room.</param>
	public bool SetRoom(string room)
	{
		bool isValid;

		if (room != null) 
		{
			mRoom = room;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Gets the ID.
	/// </summary>
	/// <returns>The ID.</returns>
	public int GetID()
	{
		return mID;
	}

	/// <summary>
	/// Gets the unit code.
	/// </summary>
	/// <returns>The unit code.</returns>
	public string GetUnitCode()
	{
		return mUnitCode;
	}

	/// <summary>
	/// Gets the name of the unit.
	/// </summary>
	/// <returns>The unit name.</returns>
	public string GetUnitName()
	{
		return mUnitName;
	}

	/// <summary>
	/// Gets the day.
	/// </summary>
	/// <returns>The day.</returns>
	public string GetDay()
	{
		return mDay;
	}

	/// <summary>
	/// Gets the start.
	/// </summary>
	/// <returns>The start.</returns>
	public string GetStart()
	{
		return mStart;
	}

	/// <summary>
	/// Gets the end.
	/// </summary>
	/// <returns>The end.</returns>
	public string GetEnd()
	{
		return mEnd;
	}

	/// <summary>
	/// Gets the room.
	/// </summary>
	/// <returns>The room.</returns>
	public string GetRoom()
	{
		return mRoom;
	}
}
