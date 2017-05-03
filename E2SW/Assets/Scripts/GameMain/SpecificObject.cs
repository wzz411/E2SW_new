using UnityEngine;

public class SpecificObject : SaveableObject
{
   


    private void Update()
    {


    }

    public override void Save(int id)
    {
        base.Save(id);
    }

    public override void Load(string[] values)
    {
        base.Load(values);
    }
}