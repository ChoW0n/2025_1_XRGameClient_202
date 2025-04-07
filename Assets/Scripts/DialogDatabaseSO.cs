using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogDatebase", menuName = "Dialog System/Database")]
public class DialogDatabaseSO : ScriptableObject
{
    public List<DialogSO> dialogs = new List<DialogSO>();

    private Dictionary<int, DialogSO> dialogsById;              //캐싱을 위한 딕셔너리 사용 

    public void Initialize()
    {
        dialogsById = new Dictionary<int, DialogSO>();

        foreach (var dialog in dialogs)
        {
            if (dialog != null)
            {
                dialogsById[dialog.id] = dialog;
            }
        }
    }
    public DialogSO GetDialogById(int id)
    {
        if (dialogsById == null)
            Initialize();

        if(dialogsById.TryGetValue(id, out DialogSO dialog))
            return dialog;

        return null;    
    }
}
