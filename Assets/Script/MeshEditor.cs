using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeshEditor : MonoBehaviour
{
    [SerializeField]
    GameObject prefeb;

    [SerializeField]
    GameObject prefeb2;

    GameObject Selected;

    [SerializeField]
    ObjectManager ObjectManager;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateMesh(GameObject gameObject, Vector3[] vertices, int[] indices)
    {
       
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        mesh.vertices = vertices;
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);
        

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();
    
       // for (int indice = 0; indice < indices.Length;indice++)
         
           // dataMeshContainer.pointEditor.Add();
        meshFilter.mesh = mesh;

      
    }

    public DataMesh CreateCube()
    {
        GameObject cube = Instantiate(prefeb);
        Vector3[] vertices = {  new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f, 0.5f), new Vector3(-0.5f, -0.5f, 0.5f),
                                new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f, 0.5f), new Vector3(-0.5f, 0.5f, 0.5f)};

        DataMesh dataMesh = cube.GetComponent<DataMesh>();
        DataMeshContainer dataMeshContainer = dataMesh.DataMeshContainer;
        dataMeshContainer.Vertices = vertices.Cast<Vector3>().ToList();
        dataMeshContainer.AddShape(new Shape[] {new Shape(0, 4, 1, 4, 5, 1), 
                                   new Shape(2, 6, 3, 6, 7, 3),
                                   new Shape(3, 7, 0, 7, 4, 0),
                                   new Shape(1, 5, 2, 5, 6, 2),
                                   new Shape(3, 0, 2, 0, 1, 2),
                                   new Shape(4, 7, 5, 7, 6, 5)});

        dataMeshContainer.AddEdge(0, 1);
        dataMeshContainer.AddEdge(1, 2);
        dataMeshContainer.AddEdge(2, 3);
        dataMeshContainer.AddEdge(3, 0);
        dataMeshContainer.AddEdge(4, 5);
        dataMeshContainer.AddEdge(5, 6);
        dataMeshContainer.AddEdge(6, 7);
        dataMeshContainer.AddEdge(7, 4);
        dataMeshContainer.AddEdge(0, 4);
        dataMeshContainer.AddEdge(1, 5);
        dataMeshContainer.AddEdge(2, 6);
        dataMeshContainer.AddEdge(3, 7);

        dataMeshContainer.AddSurface(0, 1,4,5);
        dataMeshContainer.AddSurface(2, 3, 6, 7);
        dataMeshContainer.AddSurface(0, 3, 4, 7);
        dataMeshContainer.AddSurface(1, 2, 5, 6);
        dataMeshContainer.AddSurface(0, 1, 2, 3);
        dataMeshContainer.AddSurface(4, 5, 6, 7);

        Vector3[] finalVertices;
        int[] finalIndices;

        dataMeshContainer.RecalculateVertices(out finalVertices, out finalIndices);
        dataMesh.DataMeshContainer = dataMeshContainer;
        UpdateMesh(cube, finalVertices, finalIndices);
        return dataMesh;
    }

    public void CreatePyramide()
    {
        Vector3[] vertices = { new Vector3(0.0f, 0.5f, 0.0f), new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f, 0.5f), new Vector3(-0.5f, -0.5f, 0.5f)};

        int[] indices = { 1,0,2,
                          4,3,0,
                          2,0,3,
                          1,4,0,
                          1, 2, 3, 3, 4, 1};
        UpdateMesh(Instantiate(prefeb), vertices, indices);
    }

    public void CreatePlane()
    {
        Vector3[] vertices = { new Vector3(-0.5f, 0.0f, -0.5f), new Vector3(0.5f, 0.0f, -0.5f), new Vector3(-0.5f, 0.0f, 0.5f), new Vector3(0.5f, 0.0f, 0.5f) };

        int[] indices = { 0, 2, 1, 1, 2, 3 };

        UpdateMesh(Instantiate(prefeb), vertices, indices);
    }

    public void CreateSphere()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> indices = new List<int>();
        int verticeCount = 0;
     
        float x, y, z, xy;                              // vertex position
        float radius = 0.5f;
        float lengthInv = 1.0f / radius;    // vertex normal
        float s, t;                                     // vertex texCoord

        int sectorCount = 20;
        int stackCount = 20;
        float sectorStep = 2 * Mathf.PI / sectorCount;
        float stackStep = Mathf.PI / stackCount;
        float sectorAngle, stackAngle;

        for (int i = 0; i <= stackCount; ++i)
        {
            stackAngle = Mathf.PI / 2 - i * stackStep;        // starting from pi/2 to -pi/2
            xy = radius * Mathf.Cos(stackAngle);             // r * cos(u)
            z = radius * Mathf.Sin(stackAngle);              // r * sin(u)

            // add (sectorCount+1) vertices per stack
            // the first and last vertices have same position and normal, but different tex coods
            for (int j = 0; j <= sectorCount; ++j)
            {
                sectorAngle = j * sectorStep;

                // vertex position (x, y, z)
                x = xy * Mathf.Cos(sectorAngle);             // r * cos(u) * cos(v)
                y = xy * Mathf.Sin(sectorAngle);             // r * cos(u) * sin(v)


                vertices.Add(new Vector3(x,y,z));
                verticeCount++;

                // vertex tex coord (s, t)
                s = (float)j / sectorCount;
                t = (float)i / stackCount;

                

            }


        }

        // generate index list of sphere triangles
        int k1, k2;
        for (int i = 0; i < stackCount; ++i)
        {
            k1 = i * (sectorCount + 1);     // beginning of current stack
            k2 = k1 + sectorCount + 1;      // beginning of next stack

            for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
            {
                // 2 triangles per sector excluding 1st and last stacks
                if (i != 0)
                {
                    indices.Add(k1);
                    indices.Add(k2);
                    indices.Add(k1 + 1);
                }

                if (i != (stackCount - 1))
                {
                    indices.Add(k1 + 1);
                    indices.Add(k2);
                    indices.Add(k2 + 1);
                }
            }
        }

       
        UpdateMesh(Instantiate(prefeb), vertices.ToArray(), indices.ToArray());

    }

    public void ExtrudeSurface(Surface surface)
    {
        DataMesh dataMesh = surface.Datamesh;
        Vector3 up = surface.GetUp()*2;
        DataMeshContainer dataMeshContainer = dataMesh.DataMeshContainer;
        Vector3 point1 = dataMeshContainer.Vertices[surface.Point1ID];
        Vector3 point2 = dataMeshContainer.Vertices[surface.Point2ID];
        Vector3 point3 = dataMeshContainer.Vertices[surface.Point3ID];
        Vector3 point4 = dataMeshContainer.Vertices[surface.Point4ID];

        Vector3[] newVertices = { point1 + up, point2 + up, point3 + up, point4 + up };
        int index = dataMeshContainer.Vertices.Count;
        dataMeshContainer.AddVertices(newVertices);
        /*
        dataMeshContainer.AddShape(new Shape[] {new Shape(surface.Point1ID, index, surface.Point2ID, index, index+1, surface.Point2ID),
                                   new Shape(surface.Point3ID, index+2, surface.Point4ID, index+2, index+3, surface.Point4ID),
                                   new Shape(surface.Point2ID, index + 1, surface.Point3ID, index + 1, index + 2, surface.Point3ID),
                                   new Shape(surface.Point4ID, surface.Point1ID, surface.Point3ID, surface.Point1ID, surface.Point2ID, surface.Point3ID),
                                   new Shape(index, index + 3, index + 1, index + 3, index + 2, index + 1)});
        */
        //  3, 7, 0, 7, 4, 0
        //    dataMeshContainer.AddShape(new Shape[] {new Shape(surface.Point1ID, index, surface.Point2ID, index, index+1, surface.Point2ID)});
        // dataMeshContainer.AddShape(new Shape[] { new Shape(index+1, surface.Point2ID, index, surface.Point2ID, surface.Point1ID, index) });

        dataMeshContainer.AddShape(new Shape[] {new Shape(surface.Point2ID, index + 1, surface.Point1ID, index + 1, index, surface.Point1ID),
                                                new Shape(surface.Point3ID, index+2, surface.Point4ID, index+2, index+3, surface.Point4ID),
                                                new Shape(surface.Point1ID, index, surface.Point3ID, index, index + 2, surface.Point3ID),
                                                new Shape(index+3, index+1, surface.Point4ID, index+1, surface.Point2ID, surface.Point4ID),
                                                new Shape(index, index+1, index+2, index+1, index+3, index+2)});


        dataMeshContainer.AddEdge(surface.Point1ID, index);
        dataMeshContainer.AddEdge(surface.Point2ID, index+1);
        dataMeshContainer.AddEdge(surface.Point3ID, index + 2);
        dataMeshContainer.AddEdge(surface.Point4ID, index+3);

        dataMeshContainer.AddEdge(index, index+1);
        dataMeshContainer.AddEdge(index + 1, index + 3);
        dataMeshContainer.AddEdge(index + 3, index + 2);
        dataMeshContainer.AddEdge(index + 2, index);

        /*
        dataMeshContainer.AddSurface(surface.Point1ID, surface.Point2ID, index, index + 1);
        dataMeshContainer.AddSurface(surface.Point3ID, surface.Point4ID, index + 2, index + 3);
        dataMeshContainer.AddSurface(surface.Point2ID, surface.Point3ID, index + 1, index + 2);
        dataMeshContainer.AddSurface(surface.Point1ID, surface.Point2ID, surface.Point3ID, surface.Point4ID);
        dataMeshContainer.AddSurface(index, index + 1, index + 2, index + 3);
        */
        Vector3[] finalVertices;
        int[] finalIndices;

        dataMeshContainer.RecalculateVertices(out finalVertices, out finalIndices);
        dataMesh.DataMeshContainer = dataMeshContainer;
        UpdateMesh(dataMesh.gameObject, finalVertices, finalIndices);
    }
}
