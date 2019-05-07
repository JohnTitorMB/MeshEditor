using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineBezierCurve : MonoBehaviour
{
    [SerializeField]
    float controleScale = 1.0f;

    CurveType curveType = CurveType.BezierCurve;

    [SerializeField]
    GameObject Cpoint;

    [SerializeField]
    List<GameObject> points;

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
    Vector3[] vertices;
    void Start()
    {
        points = new List<GameObject>();
        points.Add(Instantiate(Cpoint, transform.position + new Vector3(-10, 0, 0), Quaternion.identity));
        points.Add(Instantiate(Cpoint, transform.position + new Vector3(-10, 5, 0), Quaternion.identity));
        points.Add(Instantiate(Cpoint, transform.position + new Vector3(10, 5, 0), Quaternion.identity));
        points.Add(Instantiate(Cpoint, transform.position + new Vector3(10, 0, 0), Quaternion.identity));
        DataMeshContainer dataMeshContainer = datamesh.DataMeshContainer;
        vertices = dataMeshContainer.Vertices.ToArray();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vert = vertices[i];
            Vector3 pos = datamesh.gameObject.transform.position + vert;
            if (pos.x > points[0].transform.position.x && pos.x < points[points.Count - 1].transform.position.x)
            {
                float t = (pos.x - points[0].transform.position.x) / (points[points.Count - 1].transform.position.x - points[0].transform.position.x);

                Vector3 finalPos = GetInterpolate(t) - datamesh.transform.position;

                datamesh.UpdateVertices(i, vert + new Vector3(0, finalPos.y, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            int index = points.Count - 1;
            points.Add(Instantiate(Cpoint, points[index].transform.position + new Vector3(0, 1, 0), Quaternion.identity));
            points.Add(Instantiate(Cpoint, points[index].transform.position + new Vector3(2, 1, 0), Quaternion.identity));
            points.Add(Instantiate(Cpoint, points[index].transform.position + new Vector3(2, 0, 0), Quaternion.identity));
        }
        
        if (curveType == CurveType.HermitiennesCurve)
            DisplayCurve(points[0].transform.position, points[3].transform.position, points[1].transform.position, points[2].transform.position);
        else
            DisplayCurve(points[0].transform.position, points[1].transform.position, points[2].transform.position, points[3].transform.position);

        Debug.DrawLine(points[0].transform.position, points[1].transform.position, new Color(1, 0, 0, 1));
        Debug.DrawLine(points[2].transform.position, points[3].transform.position, new Color(1, 0, 0, 1));

        for (int i = 4; i < points.Count; i = i + 3)
        {
            if (curveType == CurveType.HermitiennesCurve)
                DisplayCurve(points[i - 1].transform.position, points[i + 2].transform.position, points[i].transform.position, points[i + 1].transform.position);
            else
                DisplayCurve(points[i - 1].transform.position, points[i].transform.position, points[i + 1].transform.position, points[i + 2].transform.position);

            Debug.DrawLine(points[i - 1].transform.position, points[i].transform.position, new Color(1, 0, 0, 1));
            Debug.DrawLine(points[i + 1].transform.position, points[i + 2].transform.position, new Color(1, 0, 0, 1));
        }
        

    }

    Vector3 GetInterpolate(float t)
    {
        MyMatrix1x4 T = new MyMatrix1x4(Mathf.Pow(t, 3), Mathf.Pow(t, 2), t, 1);
        MyMatrix4x4 M = GetCurveTypeMatrix();
        MyMatrix3x4 G = new MyMatrix3x4(points[0].transform.position, points[1].transform.position, points[2].transform.position, points[3].transform.position);
        Vector3 TMG = (T * M * G).ToVector3();
        return TMG;
    }

    void DisplayCurve(Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4)
    {
        for (float t = 0.0f; t < 1; t += 0.001f)
        {
            MyMatrix1x4 T = new MyMatrix1x4(Mathf.Pow(t, 3), Mathf.Pow(t, 2), t, 1);
            MyMatrix1x4 T2 = new MyMatrix1x4(Mathf.Pow(t + 0.001f, 3), Mathf.Pow(t + 0.001f, 2), t + 0.001f, 1);
            MyMatrix4x4 M = GetCurveTypeMatrix();
            MyMatrix3x4 G = new MyMatrix3x4(point1, point2, point3, point4);
            /*
            if (curveType == CurveType.HermitiennesCurve)
                G = new MyMatrix3x4(point1.transform.position, point4.transform.position, point2.transform.position, point3.transform.position);
            */
            Vector3 TMG = (T * M * G).ToVector3();
            Vector3 TMG2 = (T2 * M * G).ToVector3();
            Debug.DrawLine(TMG, TMG2, new Color(0, 0, 0, 1), 0);
        }
    }

    MyMatrix4x4 GetCurveTypeMatrix()
    {
        switch (curveType)
        {
            case CurveType.HermitiennesCurve:
                return new MyMatrix4x4(2, -2, 1, 1,
                                       -3, 3, -2, -1,
                                       0, 0, 1, 0,
                                       1, 0, 0, 0);

            case CurveType.BezierCurve:
                return new MyMatrix4x4(-1, 3, -3, 1,
                                       3, -6, 3, 0,
                                       -3, 3, 0, 0,
                                       1, 0, 0, 0);

            case CurveType.BSplineCurve:
                return 1.0f / 6.0f * new MyMatrix4x4(-1, 3, -3, 1,
                                        3, -6, 3, 0,
                                       -3, 0, 3, 0,
                                        1, 4, 1, 0);

            case CurveType.CatmullRom:
                return 0.5f * new MyMatrix4x4(-1, 3, -3, 1,
                                                    2, -5, 4, -1,
                                                   -1, 0, 1, 0,
                                                    0, 2, 0, 0);
        }

        return null;
    }
}
