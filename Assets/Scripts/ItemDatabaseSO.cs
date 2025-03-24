using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemDatabase", menuName = "Inventory/Database")]
public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();         //itemSO를 리스트로 관리한다.

    //캐싱을 위한 사전
    private Dictionary<int, ItemSO> itemsByld;               //ID로 아이템을 찾기 위한 캐싱
    private Dictionary<string, ItemSO> itemsByName;          //이름으로 아이템 찾기
    
    public void Initalize()             //초기 설정 함수
    {
        itemsByld = new Dictionary<int, ItemSO>();           //위에 선언만 했기 때문에 Dictionary 할당
        itemsByName = new Dictionary<string, ItemSO>();

        foreach (var item in items)                         //items 리스트에 선언 되어 있는 것을 가지고 Dictionary에 입력한다
        {
            itemsByld[item.id] = item;
            itemsByName[item.itemName] = item;
        }
    }

    public ItemSO GetItemByld(int id)
    {
        if (itemsByld == null)
        {
            Initalize();
        }
        if (itemsByld.TryGetValue(id, out ItemSO item))
        {
            return item;
        }

        return null;
    }

    //이름으로 아이템 찾기
    public ItemSO GetItemByName(string name)
    {
        if (itemsByName == null)
        {
            Initalize();
        }
        if (!itemsByName.TryGetValue(name, out ItemSO item))
        {
            return item;
        }

        return null;
    }

    //타입으로 아이템 필터링
    public List<ItemSO> GetItemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
