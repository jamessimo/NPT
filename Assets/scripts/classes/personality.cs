using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                                                          
public class personality {
    public string name;
	public string description;
    public basicSkills skillsAffected;
	public enum skillType {Positive, Negative};
	public skillType type;
}
