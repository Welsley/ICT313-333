using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LectureManager
{  
	private List<Lecture> mLectures; 

	public LectureManager()
	{
		mLectures = new List<Lecture> ();
	}

	public Lecture GetLectureAt(int index)
	{
		return mLectures [index];
	}

	public int NumberOfLectures()
	{
		return mLectures.Count;
	}

	/// <summary>
	/// Adds the lecture.
	/// </summary>
	/// <returns><c>true</c>, if lecture was added, <c>false</c> otherwise.</returns>
	/// <param name="l">L.</param>
	public bool AddLecture(Lecture l)
	{
		bool added;
		int startSize = mLectures.Count;
		Lecture temp = new Lecture (l);
		
		if(!this.ContainsLecture(l))
			mLectures.Add(temp);
		
		if(mLectures.Count > startSize)
			added = true;
		else
			added =false;
		
		return added;
	}
	
	/// <summary>
	/// Removes the lecture.
	/// </summary>
	/// <returns><c>true</c>, if lecture was removed, <c>false</c> otherwise.</returns>
	/// <param name="l">L.</param>
	public bool RemoveLecture(Lecture l)
	{
		bool removed;
		int startSize = mLectures.Count;
		
		for (int i=0; i<mLectures.Count; i++) 
		{
			if(mLectures[i].GetID() == l.GetID())
			{
				mLectures.RemoveAt(i);
				break;
			}
		}
		
		if(mLectures.Count < startSize)
			removed = true;
		else
			removed =false;
		
		return removed;
	}
	
	/// <summary>
	/// Determines if the lecture list contains the lecture.
	/// </summary>
	/// <returns><c>true</c>, if lecture exists, <c>false</c> otherwise.</returns>
	/// <param name="l">L.</param>
	public bool ContainsLecture(Lecture l)
	{
		bool contains = false;
		
		for (int i=0; i<mLectures.Count; i++) 
		{
			if(mLectures[i].GetID() == l.GetID())
			{
				contains =  true;
				break;
			}
		}
		
		return contains;
	}
}
