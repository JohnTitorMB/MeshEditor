using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public enum EShape
{
    VERTEX,
    LINE,
    TRIANGLE,
    QUAD
};

public struct DataMeshContainer
{
    List<Shape> shapes;
    List<EdgeData> edges;
    List<SurfaceData> surfaces;
    Dictionary<int, List<int>> indexWithVertivex;
    public List<Vector3> Vertices
    {
        get;
        set;
    }

    public Dictionary<int, List<int>> IndexWithVertivex
    {
        get
        {
            return indexWithVertivex;
        }

        set
        {
            indexWithVertivex = value;
        }
    }

    public List<EdgeData> Edges
    {
        get
        {
            return edges;
        }

        set
        {
            edges = value;
        }
    }

    public List<Shape> Shapes
    {
        get
        {
            return shapes;
        }

        set
        {
            shapes = value;
        }
    }

    public List<SurfaceData> Surfaces
    {
        get
        {
            return surfaces;
        }

        set
        {
            surfaces = value;
        }
    }

    public void AddVertices(Vector3[] _Vertices)
    {
        if (Vertices == null)
            Vertices = new List<Vector3>();

        foreach (Vector3 vertex in _Vertices)
            Vertices.Add(vertex);
    }

    public void AddShape(Shape[] _shape)
    {
        if (Shapes == null)
            Shapes = new List<Shape>();

        foreach (Shape shape in _shape)
            Shapes.Add(shape);
    }

    public void AddEdge(int indice, int indice2)
    {
        if (Edges == null)
            Edges = new List<EdgeData>();

        Edges.Add(new EdgeData(indice, indice2));
    }

    public void AddSurface(int indice, int indice2, int indice3, int indice4)
    {
        if (surfaces == null)
            surfaces = new List<SurfaceData>();

        surfaces.Add(new SurfaceData(indice, indice2,indice3,indice4));
    }

    public void RecalculateVertices(out Vector3[] _vertices, out int[] _indices)
    {
        List<Vector3> verticeList = new List<Vector3>();
        List<int> indiceList = new List<int>();

        int index = 0;
        IndexWithVertivex = new Dictionary<int, List<int>>();
        foreach (Shape shape in Shapes)
        {   
            verticeList.Add(Vertices[shape.indices[0]]);
            verticeList.Add(Vertices[shape.indices[1]]);
            verticeList.Add(Vertices[shape.indices[2]]);
            verticeList.Add(Vertices[shape.indices[4]]);

            indiceList.Add(index);
            indiceList.Add(index + 1);
            indiceList.Add(index + 2);
            indiceList.Add(index + 1);
            indiceList.Add(index + 3);
            indiceList.Add(index + 2);

            List<int> indices = new List<int>();
            if (!IndexWithVertivex.TryGetValue(shape.indices[0], out indices))
            {
                indices = new List<int>();
                IndexWithVertivex.Add(shape.indices[0], new List<int>());
            }
            indices.Add(index);
            IndexWithVertivex[shape.indices[0]] = indices;


            if (!IndexWithVertivex.TryGetValue(shape.indices[1], out indices))
            {
                indices = new List<int>();
                IndexWithVertivex.Add(shape.indices[1], new List<int>());
            }
            indices.Add(index+1);
            IndexWithVertivex[shape.indices[1]] = indices;


            if (!IndexWithVertivex.TryGetValue(shape.indices[2], out indices))
            {
                indices = new List<int>();
                IndexWithVertivex.Add(shape.indices[2], new List<int>());
            }

            indices.Add(index+2);
            IndexWithVertivex[shape.indices[2]] = indices;

            indices = new List<int>();

            if (!IndexWithVertivex.TryGetValue(shape.indices[4], out indices))
            {
                indices = new List<int>();
                IndexWithVertivex.Add(shape.indices[4], new List<int>());
            }
            indices.Add(index+3);
            IndexWithVertivex[shape.indices[4]] = indices;

            index = index + 4;

        }
        _vertices = verticeList.ToArray();
        _indices = indiceList.ToArray();
    }

};

public class Shape
{
    public Shape(params int[] _indices)
    {
        indices = _indices.Cast<int>().ToList();
    }
    //  EShape eShape = EShape.VERTEX;
    public List<int> indices;
}

public class EdgeData
{
    public EdgeData(int _indice, int _indice2)
    {
        indice = _indice;
        indice2 = _indice2;

    }

    public int indice;
    public int indice2;   
}

public class SurfaceData
{
    public SurfaceData(int _indice, int _indice2, int _indice3, int _indice4)
    {
        indice = _indice;
        indice2 = _indice2;
        indice3 = _indice3;
        indice4 = _indice4;

    }

    public int indice;
    public int indice2;
    public int indice3;
    public int indice4;
}

public class DataMesh : MonoBehaviour
{
    Text text;
    public DataMeshContainer DataMeshContainer
    {
        get;
        set;
    }

    public Text Text
    {
        get
        {
            return text;
        }

        set
        {
            text = value;
        }
    }
    Delegate verticesEvent;

    public Action<GameObject>[] ActionsVertices
    {
        get
        {
            return actionsVertices;
        }

        set
        {
            actionsVertices = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    Action<GameObject>[]  actionsVertices;


    public void UpdateVertices(int id,Vector3 position)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        DataMeshContainer.Vertices[id] = position;

        List<int> indices = new List<int>();
        if (DataMeshContainer.IndexWithVertivex.TryGetValue(id, out indices))
        {
            Vector3[] vertice = mesh.vertices;
            foreach (int index in indices)
                vertice[index] = position;

            mesh.vertices = vertice;
        }

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;
    }

    public void MoveVertice(int id, Vector3 translation)
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        DataMeshContainer.Vertices[id] += translation;


        List<int> indices = new List<int>();
        if (DataMeshContainer.IndexWithVertivex.TryGetValue(id, out indices))
        {
            Vector3[] vertice = mesh.vertices;
            foreach (int index in indices)
                vertice[index] += translation;
                
            mesh.vertices = vertice;
        }

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;
    }
}




