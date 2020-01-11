using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StaffManager
{ 
	private List<Staff> mStaff; 

	/// <summary>
	/// Initializes a new instance of the <see cref="StaffManager"/> class.
	/// </summary>
	public StaffManager()
	{
		mStaff = new List<Staff> ();
	}
	
	/// <summary>
	/// Gets the staff at index.
	/// </summary>
	/// <returns>The <see cref="Staff"/>.</returns>
	/// <param name="index">Index.</param>
	public Staff GetStaffAt(int index)
	{
		return mStaff [index];
	}
	
	/// <summary>
	/// Gets the number of staff.
	/// </summary>
	/// <returns>The number of staff.</returns>
	public int NumberOfStaff()
	{
		return mStaff.Count;
	}
	
	/// <summary>
	/// Adds the staff.
	/// </summary>
	/// <returns><c>true</c>, if staff was added, <c>false</c> otherwise.</returns>
	/// <param name="s">S.</param>
	public bool AddStaff(Staff s)
	{
		bool added;
		int startSize = mStaff.Count;
		Staff temp = new Staff (s);
		
		if(!this.ContainsStaff(s))
			mStaff.Add(temp);
		
		if(mStaff.Count > startSize)
			added = true;
		else
			added =false;
		
		return added;
	}
	
	/// <summary>
	/// Removes the staff.
	/// </summary>
	/// <returns><c>true</c>, if staff was removed, <c>false</c> otherwise.</returns>
	/// <param name="s">S.</param>
	public bool RemoveStaff(Staff s)
	{
		bool removed;
		int startSize = mStaff.Count;
		
		for (int i=0; i<mStaff.Count; i++) 
		{
			if(mStaff[i].GetName().Equals(s.GetName()) && ( mStaff[i].GetOfficeNo().Equals(s.GetOfficeNo()))
			   && ( mStaff[i].GetBuildingNo().Equals(s.GetBuildingNo())))
			{
				mStaff.RemoveAt(i);
				break;
			}
		}
		
		if(mStaff.Count < startSize)
			removed = true;
		else
			removed =false;
		
		return removed;
	}
	
	/// <summary>
	/// Determins if the staff list contains the staff.
	/// </summary>
	/// <returns><c>true</c>, if staff exists, <c>false</c> otherwise.</returns>
	/// <param name="s">S.</param>
	public bool ContainsStaff(Staff s)
	{
		bool contains = false;

		if(mStaff.Count > 0)
		{
			for (int i=0; i<mStaff.Count; i++) 
			{
				if(mStaff[i].GetName().Equals(s.GetName()) && ( mStaff[i].GetOfficeNo().Equals(s.GetOfficeNo()))
				   && ( mStaff[i].GetBuildingNo().Equals(s.GetBuildingNo())))
				{
					contains =  true;
					break;
				}			
			}
		}
		
		return contains;
	}
}
