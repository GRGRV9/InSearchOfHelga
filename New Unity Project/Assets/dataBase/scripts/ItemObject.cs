using UnityEngine;
using UnityEngine.UI;

public abstract class ItemObject : ScriptableObject
{
    public Sprite image;
    [TextArea(15, 20)] public string description;
}