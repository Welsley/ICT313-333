using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Staff
{  
	string mName;
	string mBuildingNo;
	string mOfficeNo;
	List<string> mPhones;
	string mEmail;
	string mPhoto;
	string mPosition;
	List<string> mOrganisations;

	/// <summary>
	/// Initializes a new instance of the <see cref="Staff"/> class.
	/// </summary>
	public Staff()
	{
		mName = null;
		mBuildingNo = null;
		mOfficeNo = null;
		mEmail = null;
		mPhoto = null;
		mPosition = null;

		mPhones = new List<string> ();
		mOrganisations = new List<string> ();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Staff"/> class.
	/// </summary>
	/// <param name="s">S.</param>
	public Staff(Staff s)
	{
		mName = s.GetName ();
		mBuildingNo = s.GetBuildingNo ();
		mOfficeNo = s.GetOfficeNo ();
		mEmail = s.GetEmail ();
		mPhoto = s.GetPhoto ();
		mPosition = s.GetPosition ();

		mPhones = new List<string> ();
		mOrganisations = new List<string> ();

		for(int i=0; i<s.NumberOfPhones(); i++)
		{
			this.AddPhone(s.GetPhoneAt(i));
		}

		for(int i=0; i<s.NumberOfOrganisations(); i++)
		{
			this.AddOrganisation(s.GetOrganisationAt(i));
		}
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
	/// Sets the building no.
	/// </summary>
	/// <returns><c>true</c>, if building no was set, <c>false</c> otherwise.</returns>
	/// <param name="num">Number.</param>
	public bool SetBuildingNo(string num)
	{
		bool isValid;

		if (num != null) 
		{
			mBuildingNo = num;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the office no.
	/// </summary>
	/// <returns><c>true</c>, if office no was set, <c>false</c> otherwise.</returns>
	/// <param name="num">Number.</param>
	public bool SetOfficeNo(string num)
	{
		bool isValid;

		if (num != null) 
		{
			mOfficeNo = num;
			isValid = true;
		} 
		else
			isValid = false;
		
		return isValid;
	}

	/// <summary>
	/// Sets the email.
	/// </summary>
	/// <returns><c>true</c>, if email was set, <c>false</c> otherwise.</returns>
	/// <param name="email">Email.</param>
	public bool SetEmail(string email)
	{
		bool isValid;

		if (email != null) 
		{
			mEmail = email;
			isValid = true;
		} 
		else
			isValid = false;

		return isValid;
	}

	/// <summary>
	/// Sets the photo.
	/// </summary>
	/// <returns><c>true</c>, if photo was set, <c>false</c> otherwise.</returns>
	/// <param name="file">File.</param>
	public bool SetPhoto(string file)
	{
		bool isValid;

		if (file != null) 
		{
			mPhoto = file;
			isValid = true;
		} 
		else
			isValid = false;
		
		return isValid;
	}

	/// <summary>
	/// Sets the position.
	/// </summary>
	/// <returns><c>true</c>, if position was set, <c>false</c> otherwise.</returns>
	/// <param name="position">Position.</param>
	public bool SetPosition(string position)
	{
		bool isValid;

		if (position != null) 
		{
			mPosition = position;
			isValid = true;
		} 
		else
			isValid = false;
		
		return isValid;
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
	/// Gets the building no.
	/// </summary>
	/// <returns>The building no.</returns>
	public string GetBuildingNo()
	{
		return mBuildingNo;
	}

	/// <summary>
	/// Gets the office no.
	/// </summary>
	/// <returns>The office no.</returns>
	public string GetOfficeNo()
	{
		return mOfficeNo;
	}

	/// <summary>
	/// Gets the email.
	/// </summary>
	/// <returns>The email.</returns>
	public string GetEmail()
	{
		return  mEmail;
	}

	/// <summary>
	/// Gets the photo filename.
	/// </summary>
	/// <returns>The photo filename.</returns>
	public string GetPhoto()
	{
		return mPhoto;
	}

	/// <summary>
	/// Gets the position.
	/// </summary>
	/// <returns>The position.</returns>
	public string GetPosition()
	{
		return mPosition;
	}

	/// <summary>
	/// Gets the phone at index.
	/// </summary>
	/// <returns>The <see cref="System.String"/>.</returns>
	/// <param name="index">Index.</param>
	public string GetPhoneAt(int index)
	{
		return mPhones [index];
	}

	/// <summary>
	/// Gets the organisation at index.
	/// </summary>
	/// <returns>The <see cref="System.String"/>.</returns>
	/// <param name="index">Index.</param>
	public string GetOrganisationAt(int index)
	{
		return mOrganisations [index];
	}

	/// <summary>
	/// Gets the number of phones.
	/// </summary>
	/// <returns>The number of phones.</returns>
	public int NumberOfPhones()
	{
		return mPhones.Count;
	}

	/// <summary>
	/// Gets the number of organisations.
	/// </summary>
	/// <returns>The number of organisations.</returns>
	public int NumberOfOrganisations()
	{
		return mOrganisations.Count;
	}

	/// <summary>
	/// Adds the phone.
	/// </summary>
	/// <returns><c>true</c>, if phone was added, <c>false</c> otherwise.</returns>
	/// <param name="phone">Phone.</param>
	public bool AddPhone(string phone)
	{
		bool added;
		int startSize = mPhones.Count;
		
		if ((phone != null) && (!this.ContainsPhone(phone))) //if phone not null AND phone doesnt already exist
		{
			mPhones.Add(phone);
			
			if(mPhones.Count > startSize)
				added = true;
			else
				added =false;
		} 
		else
			added = false;
		
		return added;
	}

	/// <summary>
	/// Removes the phone.
	/// </summary>
	/// <returns><c>true</c>, if phone was removed, <c>false</c> otherwise.</returns>
	/// <param name="phone">Phone.</param>
	public bool RemovePhone(string phone)
	{
		bool removed;
		int startSize = mPhones.Count;
		
		if (phone != null) 
		{
			mPhones.Remove(phone);
			
			if(mPhones.Count < startSize)
				removed = true;
			else
				removed =false;
		} 
		else
			removed = false;
		
		return removed;
	}

	/// <summary>
	/// Determines if the phone list contains the phone.
	/// </summary>
	/// <returns><c>true</c>, if phone was contained, <c>false</c> otherwise.</returns>
	/// <param name="phone">Phone.</param>
	public bool ContainsPhone(string phone)
	{
		bool contains;
		
		if (phone != null) 
		{
			contains = mPhones.Contains(phone);
		} 
		else
			contains = false;
		
		return contains;
	}

	/// <summary>
	/// Adds the organisation.
	/// </summary>
	/// <returns><c>true</c>, if organisation was added, <c>false</c> otherwise.</returns>
	/// <param name="organisation">Organisation.</param>
	public bool AddOrganisation(string organisation)
	{
		bool added;
		int startSize = mOrganisations.Count;
		
		if ((organisation != null) && (!this.ContainsOrganisation(organisation))) //if organisation not null AND organisation doesnt already exist
		{
			mOrganisations.Add(organisation);
			
			if(mOrganisations.Count > startSize)
				added = true;
			else
				added =false;
		} 
		else
			added = false;
		
		return added;
	}

	/// <summary>
	/// Removes the organisation.
	/// </summary>
	/// <returns><c>true</c>, if organisation was removed, <c>false</c> otherwise.</returns>
	/// <param name="organisation">Organisation.</param>
	public bool RemoveOrganisation(string organisation)
	{
		bool removed;
		int startSize = mOrganisations.Count;
		
		if (organisation != null) 
		{
			mOrganisations.Remove(organisation);
			
			if(mOrganisations.Count < startSize)
				removed = true;
			else
				removed =false;
		} 
		else
			removed = false;
		
		return removed;
	}

	/// <summary>
	/// Determines if the organisation list contains the organisation.
	/// </summary>
	/// <returns><c>true</c>, if organisation exists, <c>false</c> otherwise.</returns>
	/// <param name="organisation">Organisation.</param>
	public bool ContainsOrganisation(string organisation)
	{
		bool contains;
		
		if (organisation != null) 
		{
			contains = mOrganisations.Contains(organisation);
		} 
		else
			contains = false;
		
		return contains;
	}
}
