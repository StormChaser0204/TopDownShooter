using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Player/Inventory/Item")]
public class Item : ScriptableObject {
    [SerializeField]
    private string _name;
}
