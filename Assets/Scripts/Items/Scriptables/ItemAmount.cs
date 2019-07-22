using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAmount", menuName = "Player/Inventory/ItemAmount")]
public class ItemAmount : ScriptableObject {
    [SerializeField]
    private Item _item;
    [SerializeField]
    private int _amount;

    public Item Item {
        get {
            return _item;
        }
    }
    public int Amount {
        get {
            return _amount;
        }
    }
}
