using UnityEngine;

[System.Serializable]
public class ItemCount {
    [SerializeField]
    private Item _item;
    [SerializeField]
    private int _count;

    public ItemCount(Item item) {
        _item = item;
        _count = 0;
    }

    public Item Item {
        get {
            return _item;
        }
        set {
            _item = value;
        }
    }

    public int Count {
        get {
            return _count;
        }
        set {
            _count = value;
        }
    }
}
