using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositComponent: BaseComponent {
    [SerializeField]
    private Item _item;
    [SerializeField]
    private int _count;

    public Item Item {
        get {
            return _item;
        }
    }

    public void TakeItem(int count) {
        _count -= count;
    }

    protected override void Init() {
    }
}
