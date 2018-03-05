using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Item : MonoBehaviour {
	[XmlAttribute("name")]
	public string name;
	[XmlElement("life")]
	public float lifeGain;
	[XmlElement("damage")]
	public float damage;
	[XmlAttribute("description")]
	public string description;
	[XmlAttribute("Item_ID")]
	public int item_ID;
	[XmlAttribute("type")]
	public string type;

}
