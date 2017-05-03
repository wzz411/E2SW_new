using UnityEngine;
using System.Collections.Generic;

public class SaveGameManager : MonoBehaviour
{
    private static SaveGameManager instance;
    public List<SaveableObject> SaveableObjects { get; private set; } //put all obejcts that need to be saved into this list

    public static SaveGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SaveGameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        SaveableObjects = new List<SaveableObject>();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("ObjectCount", SaveableObjects.Count);

        for (int i = 0; i < SaveableObjects.Count; i++)
        {
            SaveableObjects[i].Save(i);
        }
    }

    public void Load()
    {
        foreach(SaveableObject obj in SaveableObjects)
        {
            if(obj != null)
            {
                Destroy(obj.gameObject);
            }
        }
        SaveableObjects.Clear();
        int objectCount = PlayerPrefs.GetInt("ObjectCount");
        for (int i = 0; i < objectCount; i++)
        {
            string[] value = PlayerPrefs.GetString(i.ToString()).Split('_');
            GameObject tmp = null; 
            switch (value[0])
            {
                case "NewNode":
                    tmp = Instantiate(Resources.Load("Prefabs/NewNode") as GameObject);
                    break;
            }
            if (tmp != null)
            {
                tmp.GetComponent<SaveableObject>().Load(value);
            }

        }

        


    }



    public Vector3 StringToVector(string value)
    {
        value = value.Trim(new char[] { '(', ')' });
        value = value.Replace(" ", "");
        string[] pos = value.Split(',');


        return new Vector3(float.Parse(pos[0]),float.Parse(pos[1]),float.Parse(pos[2]));
    }

    public Quaternion StringToQuaternion(string value)
    {
        return Quaternion.identity;
    }


}