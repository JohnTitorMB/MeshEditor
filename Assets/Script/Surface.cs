using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : SelectionnableElement
{
    Vector3 lastTransfrom;

    int point1ID;
    int point2ID;
    int point3ID;
    int point4ID;
    MeshFilter meshfilter;

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

    public int Point3ID
    {
        get
        {
            return point3ID;
        }

        set
        {
            point3ID = value;
        }
    }

    public int Point4ID
    {
        get
        {
            return point4ID;
        }

        set
        {
            point4ID = value;
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
        DataMeshContainer dataMeshContainer = datamesh.DataMeshContainer;

        if (datamesh && (lastTransfrom - transform.localPosition) != Vector3.zero)
        {
            datamesh.MoveVertice(Point1ID, -(lastTransfrom - transform.localPosition));
            datamesh.MoveVertice(Point2ID, -(lastTransfrom - transform.localPosition));
            datamesh.MoveVertice(Point3ID, -(lastTransfrom - transform.localPosition));
            datamesh.MoveVertice(Point4ID, -(lastTransfrom - transform.localPosition));
        }
        else
        {
            Vector3 point1 = dataMeshContainer.Vertices[Point1ID];
            Vector3 point2 = dataMeshContainer.Vertices[Point2ID];
            Vector3 point3 = dataMeshContainer.Vertices[Point3ID];
            Vector3 point4 = dataMeshContainer.Vertices[Point4ID];

            Vector3 center = (point1 + point2 + point3 + point4) / 4;
            gameObject.transform.localPosition = center;
            Init();
        }


    }

    void LateUpdate()
    {
        lastTransfrom = transform.localPosition;
    }

    public void Init()
    {
        meshfilter = GetComponent<MeshFilter>();
        Mesh mesh = meshfilter.mesh;
        List<Vector3> vertices = new List<Vector3>();
        DataMeshContainer dataMeshContainer = datamesh.DataMeshContainer;        
        vertices.Add(dataMeshContainer.Vertices[Point1ID] - transform.localPosition);
        vertices.Add(dataMeshContainer.Vertices[Point2ID] - transform.localPosition);
        vertices.Add(dataMeshContainer.Vertices[Point3ID] - transform.localPosition);
        vertices.Add(dataMeshContainer.Vertices[Point4ID] - transform.localPosition);

        mesh.SetVertices(vertices);
        int[] indices = { 0, 1, 2, 1, 3, 2 };
        mesh.SetIndices(indices,MeshTopology.Triangles,0);

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();

        meshfilter.mesh = mesh;

        GetComponent<MeshCollider>().sharedMesh = meshfilter.mesh;

    }



    public Vector3 GetCenter()
    {
        return transform.localPosition;
    }

    public Vector3 GetUp()
    {
        DataMeshContainer dataMeshContainer = datamesh.DataMeshContainer;
        Vector3 point12 = dataMeshContainer.Vertices[Point1ID];
        Vector3 point22 = dataMeshContainer.Vertices[Point2ID];
        Vector3 up = Vector3.Cross(point12 - gameObject.transform.localPosition, point22 - gameObject.transform.localPosition);
        return up;
    }
}
