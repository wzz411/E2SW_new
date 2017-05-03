using UnityEngine;

enum ObjectType { NewNode }

public abstract class SaveableObject : MonoBehaviour
{
    protected string save;

    [SerializeField]
    private ObjectType objectType;

    private void Start()
    {
        SaveGameManager.Instance.SaveableObjects.Add(this);


    }

    public virtual void Save(int id)
    {
        PlayerPrefs.SetString(id.ToString(), objectType + "_" + transform.position.ToString());

        

    }

    public virtual void Load(string[] values)
    {
        transform.localPosition = SaveGameManager.Instance.StringToVector(values[1]);

    }

    public void DestroySaveable()
    {
        SaveGameManager.Instance.SaveableObjects.Remove(this);
        Destroy(gameObject);
    }

}
