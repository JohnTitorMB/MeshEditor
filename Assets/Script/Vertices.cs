using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertices : SelectionnableElement
{
    int id = 0;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public DataMesh Datamesh
    {
        get
        {
            return datamesh;
        }

        set
        {
            datamesh = value;
        }
    }

    DataMesh datamesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (datamesh && transform.hasChanged)
            datamesh.UpdateVertices(id, transform.localPosition);
    }
}
