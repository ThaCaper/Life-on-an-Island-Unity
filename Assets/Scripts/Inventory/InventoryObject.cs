using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
public class InventoryObject : ScriptableObject
{
    public string savePath;
    private MaterialDatabaseObject database;
    public List<InventorySlots> Container = new List<InventorySlots>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (MaterialDatabaseObject) AssetDatabase.LoadAssetAtPath(
            "Assets/Resources/Database.asset", typeof(MaterialDatabaseObject));
//#else
        database = Resources.Load<MaterialDatabaseObject>("Database.asset");
#endif

    }
    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlots(_item, _amount, database.getId[_item]));

    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
        }
    }

    public void OnBeforeSerialize()
    {
        throw new System.NotImplementedException();
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.getItem[Container[i].id];
        }
    }
}
