using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShellData", menuName = "DataBase")]
public class ShellInformation : ScriptableObject {
    [SerializeField]
    private List<ShellInfo> _shellsInformation;

    public List<ShellInfo> ShellsInformation {
        get {
            return _shellsInformation;
        }
    }

    public ShellInfo GetShellInfo(ShellInfo.Type shellType) {
        foreach (var shellInfo in _shellsInformation) {
            if(shellInfo.ShellType == shellType) {
                return shellInfo;
            }
        }
        return null;
    }
}
