using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class story
{
    public string headline;
    public topic storyTopic;
    public int authorID;
    public float quality;
    public political political;
	[Range(0, 1f)] public float trust;
    public int draft;


}