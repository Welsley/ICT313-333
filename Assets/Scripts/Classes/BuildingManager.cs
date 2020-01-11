using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BuildingManager
{  
	private List<Building> mBuildings; 

	/// <summary>
	/// Initializes a new instance of the <see cref="BuildingManager"/> class.
	/// </summary>
	public BuildingManager()
	{
		mBuildings = new List<Building> ();
	}

	/// <summary>
	/// Gets the building at index.
	/// </summary>
	/// <returns>The <see cref="Building"/>.</returns>
	/// <param name="index">Index.</param>
	public Building GetBuildingAt(int index)
	{
		return mBuildings [index];
	}

	/// <summary>
	/// Returns the number of buildings.
	/// </summary>
	/// <returns>The number of buildings.</returns>
	public int NumberOfBuildings()
	{
		return mBuildings.Count;
	}

	/// <summary>
	/// Adds the building.
	/// </summary>
	/// <returns><c>true</c>, if building was added, <c>false</c> otherwise.</returns>
	/// <param name="b">The blue component.</param>
	public bool AddBuilding(Building b)
	{
		bool added;
		int startSize = mBuildings.Count;
		Building temp = new Building (b);

		if(!this.ContainsBuilding(b))
			mBuildings.Add(temp);
			
		if(mBuildings.Count > startSize)
			added = true;
		else
			added =false;

		return added;
	}

	/// <summary>
	/// Removes the building.
	/// </summary>
	/// <returns><c>true</c>, if building was removed, <c>false</c> otherwise.</returns>
	/// <param name="b">The blue component.</param>
	public bool RemoveBuilding(Building b)
	{
		bool removed;
		int startSize = mBuildings.Count;
		
		for (int i=0; i<mBuildings.Count; i++) 
		{
			if(mBuildings[i].GetNumber().Equals(b.GetNumber()))
			{
				mBuildings.RemoveAt(i);
				break;
			}
		}

		if(mBuildings.Count < startSize)
			removed = true;
		else
			removed =false;

		return removed;
	}

	/// <summary>
	/// Determines if the building list contains the building.
	/// </summary>
	/// <returns><c>true</c>, if building exists, <c>false</c> otherwise.</returns>
	/// <param name="b">The blue component.</param>
	public bool ContainsBuilding(Building b)
	{
		bool contains = false;
		
		for (int i=0; i<mBuildings.Count; i++) 
		{
			if(mBuildings[i].GetNumber().Equals(b.GetNumber()))
			{
				contains =  true;
				break;
			}
		}
		
		return contains;
	}
}