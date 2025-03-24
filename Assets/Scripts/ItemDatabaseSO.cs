using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemDatabase", menuName = "Inventory/Database")]
public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();         //itemSO�� ����Ʈ�� �����Ѵ�.

    //ĳ���� ���� ����
    private Dictionary<int, ItemSO> itemsByld;               //ID�� �������� ã�� ���� ĳ��
    private Dictionary<string, ItemSO> itemsByName;          //�̸����� ������ ã��
    
    public void Initalize()             //�ʱ� ���� �Լ�
    {
        itemsByld = new Dictionary<int, ItemSO>();           //���� ���� �߱� ������ Dictionary �Ҵ�
        itemsByName = new Dictionary<string, ItemSO>();

        foreach (var item in items)                         //items ����Ʈ�� ���� �Ǿ� �ִ� ���� ������ Dictionary�� �Է��Ѵ�
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

    //�̸����� ������ ã��
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

    //Ÿ������ ������ ���͸�
    public List<ItemSO> GetItemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
