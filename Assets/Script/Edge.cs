using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : SelectionnableElement
{
    GameObject point1;
    GameObject point2;

    public GameObject Point1
    {
        get
        {
            return point1;
        }

        set
        {
            point1 = value;
        }
    }

    public GameObject Point2
    {
        get
        {
            return point2;
        }

        set
        {
            point2 = value;
        }
    }

    Vector3 lastTransfrom;

    int point1ID;
    int point2ID;

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

    public int Point1ID
    {
        get
        {
            return point1ID;
        }

        set
        {
            point1ID = value;
        }
    }

    public int Point2ID
    {
        get
        {
            return point2ID;
        }

        set
        {
            point2ID = value;
        }
    }

    DataMesh datamesh;
    void Start()
    {
        lastTransfrom = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {        
        if (datamesh && (lastTransfrom - transform.localPosition) != Vector3.zero)
        {
            datamesh.MoveVertice(Point1ID, -(lastTransfrom - transform.localPosition));
            datamesh.MoveVertice(Point2ID, -(lastTransfrom - transform.localPosition));
           // datamesh.ActionsVertices[Point1ID].Invoke(gameObject);
        }
        else
        {
            DataMeshContainer dataMeshContainer = datamesh.DataMeshContainer;
            transform.localPosition = (dataMeshContainer.Vertices[Point2ID] + dataMeshContainer.Vertices[Point1ID]) / 2;
            transform.up = (dataMeshContainer.Vertices[Point2ID] - dataMeshContainer.Vertices[Point1ID]).normalized;
            transform.localScale = new Vector3(0.1f, (dataMeshContainer.Vertices[Point2ID] - dataMeshContainer.Vertices[Point1ID]).magnitude / 2, 0.1f);
        }
    }

    void LateUpdate()
    {
        lastTransfrom = transform.localPosition;
    }

    private void UpdateEdges()
    {
        DataMeshContainer dataMeshContainer = datamesh.DataMeshContainer;
        transform.localPosition = (dataMeshContainer.Vertices[Point2ID] + dataMeshContainer.Vertices[Point1ID]) / 2;
        transform.up = (dataMeshContainer.Vertices[Point2ID] - dataMeshContainer.Vertices[Point1ID]).normalized;
        transform.localScale = new Vector3(0.1f, (dataMeshContainer.Vertices[Point2ID] - dataMeshContainer.Vertices[Point1ID]).magnitude / 2, 0.1f);
    }
}
