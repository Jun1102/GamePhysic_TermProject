using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hint", menuName = "New Hint")]
public class hint_data : ScriptableObject
{
    [Header("Info")]
    public string hint_name;
    public Sprite icon;
    public Sprite content;
}
