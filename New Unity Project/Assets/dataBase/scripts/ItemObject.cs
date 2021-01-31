using System;
using UnityEngine;
using UnityEngine.UI;

public enum TypeItem
{
    Wood,
    Water,
    Treasure,
    Tool,
    Food,
    Gold
}

public abstract class ItemObject : ScriptableObject
{
    public TypeItem type;
    public Sprite image;
    [TextArea(15, 20)] public string description;
}