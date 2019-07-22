using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExtractionComponent : BaseComponent {
    [SerializeField]
    private int _extractTime;
    [SerializeField]
    private int _extractCount;
    [SerializeField]
    private int _extractRadius;

    private Coroutine _workCoroutine;
    private List<DepositComponent> _deposits;
    private List<ItemCount> _extractedItems;

    protected override void Init() {
        _deposits = new List<DepositComponent>();
        _extractedItems = new List<ItemCount>();
    }

    private void Start() {
        BeforeStartWork();
    }

    public void BeforeStartWork() {
        var scanner = gameObject.AddComponent<SphereCollider>();
        scanner.isTrigger = true;
        scanner.radius = _extractRadius;
        var depositsColliders = Physics.OverlapSphere(scanner.transform.position, scanner.radius);

        foreach (var collider in depositsColliders) {
            var depositComponent = collider.GetComponentInParent<DepositComponent>();
            if (depositComponent == null) continue;
            AddDeposit(depositComponent);
        }
        StartWork();
    }

    private void AddDeposit(DepositComponent depositComponent) {
        _deposits.Add(depositComponent);
        foreach (var item in _extractedItems) {
            if (item.Item == depositComponent.Item) return;
        }
        _extractedItems.Add(new ItemCount(depositComponent.Item));
    }

    private void StartWork() {
        _workCoroutine = StartCoroutine(Working());
    }

    private void StopWorking() {
        StopCoroutine(_workCoroutine);
    }

    private IEnumerator Working() {
        var waiting = new WaitForSeconds(_extractTime);

        while (true) {
            foreach (var deposit in _deposits) {
                deposit.TakeItem(_extractCount);
                AddItemAmount(deposit.Item);
            }
            yield return waiting;
        }
    }

    private void AddItemAmount(Item item) {
        foreach (var extractedItem in _extractedItems) {
            if (extractedItem.Item == item) {
                extractedItem.Count += _extractCount;
                break;
            }
        }
    }

   
}
