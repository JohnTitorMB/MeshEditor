using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    static ObjectManager instance = null;
    static public ObjectManager Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<ObjectManager>();

            return instance;
        }
    }

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    GameObject curentAction;

    [SerializeField]
    GameObject[] actionList;

    [SerializeField]
    GameObject maskAction;

    [SerializeField]
    GameObject root;

    [SerializeField]
    MeshEditor MeshEditor;

    [SerializeField]
    GameObject textHiearchy;

    [SerializeField]
    TreeView hiearchy;

    [SerializeField]
    public GameObject prefabVertices;

    [SerializeField]
    public GameObject prefabEdge;

    [SerializeField]
    public GameObject prefabSurface;

    [SerializeField]
    public GameObject prefabSpline;

    [SerializeField]
    public Material selectedMaterial;

    [SerializeField]
    public Material UnSelectedMaterial;


    private GameObject selectedObject;
    private GameObject selectionnableElement;
    private int currentAction = 0;

    public GameObject SelectedObject
    {
        get
        {
            return selectedObject;
        }

        set
        {
            selectedObject = value;

        }
    }

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    LayerMask layerMask;

    // Use this for initialization
    void Start()
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(root);
        if (root)
        {
            
        }
    }
    // Update is called once per frame
    void Update ()
    {
		if(!Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0) && selectedObject)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (selectionnableElement)
            {
                MeshRenderer meshRenderer = selectionnableElement.GetComponent<MeshRenderer>();
                meshRenderer.material = UnSelectedMaterial;
            }

            if (Physics.Raycast(ray, out raycastHit,100,layerMask))
            {                
                selectionnableElement = raycastHit.transform.gameObject;
                MeshRenderer meshRenderer = selectionnableElement.GetComponent<MeshRenderer>();
                meshRenderer.material = selectedMaterial;
            }
             
        }

        if(Input.GetKeyDown(KeyCode.V) && selectionnableElement != null && selectionnableElement.GetComponent<Surface>())
        {
            MeshEditor.ExtrudeSurface(selectionnableElement.GetComponent<Surface>());
            DisplayElement();
        }
    }

    public void AddGameObject(GameObject parent,GameObject gameObject)
    {
       

    }

    public void AddCube(GameObject parent)
    {

        DataMesh cube = MeshEditor.CreateCube();
        selectedObject = cube.gameObject;
          
        cube.transform.parent = selectedObject.transform;
        
        cube.Text = Instantiate(textHiearchy, hiearchy.transform).GetComponent<Text>();
        hiearchy.AddItem(null);
        DisplayElement();
    }

    public void OpenAction()
    {
        RectTransform rectTransform = maskAction.GetComponent<RectTransform>();
        FullTween fullTween = maskAction.GetComponent<FullTween>();
        if (fullTween.State == FullTween.Estate.Progress)
            return;
        if (rectTransform.sizeDelta.y == 0)
            fullTween.SetEndValue(new Vector2(50,200));
        else
            fullTween.SetEndValue(new Vector2(50, 0));

        maskAction.GetComponent<FullTween>().StartFullTween(EStartValue.CurrentValue);
    }

    public void SetAction(int action)
    {
        currentAction = action;

        FullTween fullTween = maskAction.GetComponent<FullTween>();
        fullTween.SetEndValue(new Vector2(50, 0));
        maskAction.GetComponent<FullTween>().StartFullTween(EStartValue.CurrentValue);
        curentAction.GetComponent<Image>().sprite = actionList[action].GetComponent<Image>().sprite;
        curentAction.GetComponent<Image>().color = actionList[action].GetComponent<Image>().color;
        DisplayElement();
    }

    public void DisplayElement()
    {
        foreach (Transform child in selectedObject.transform)
        {
            Destroy(child.gameObject);
        }

        selectedObject.GetComponent<MeshRenderer>().enabled = true;
        if (currentAction == 0)
            AddVertices();
        else if (currentAction == 1)
            AddEdge();
        else if (currentAction == 2)
            AddSurface();
        else if (currentAction == 3)
            AddBezierSpline();
    }

    public void AddVertices()
    {
        DataMesh dataMesh = selectedObject.GetComponent<DataMesh>();
        DataMeshContainer dataMeshContainer = dataMesh.DataMeshContainer;
        for (int i = 0; i < dataMeshContainer.Vertices.Count; i++)
        {
            GameObject gameObject = Instantiate(prefabVertices, selectedObject.transform);
            gameObject.GetComponent<Vertices>().Id = i;
            gameObject.GetComponent<Vertices>().Datamesh = dataMesh;
            gameObject.transform.localPosition = dataMeshContainer.Vertices[i];
        }
    }

    public void AddEdge()
    {
        if (selectedObject == null)
            return;

        DataMesh dataMesh = selectedObject.GetComponent<DataMesh>();
        DataMeshContainer dataMeshContainer = dataMesh.DataMeshContainer;
        dataMesh.ActionsVertices = new System.Action<GameObject>[dataMeshContainer.Vertices.Count];

        for (int i = 0; i < dataMeshContainer.Edges.Count; i++)
        {
            GameObject gameObject = Instantiate(prefabEdge, selectedObject.transform);
            gameObject.GetComponent<Edge>().Point1ID = dataMeshContainer.Edges[i].indice;
            gameObject.GetComponent<Edge>().Point2ID = dataMeshContainer.Edges[i].indice2;
            gameObject.GetComponent<Edge>().Datamesh = dataMesh;
            gameObject.transform.localPosition = (dataMeshContainer.Vertices[gameObject.GetComponent<Edge>().Point2ID] + dataMeshContainer.Vertices[gameObject.GetComponent<Edge>().Point1ID]) / 2;
            gameObject.transform.up = (dataMeshContainer.Vertices[gameObject.GetComponent<Edge>().Point2ID] - dataMeshContainer.Vertices[gameObject.GetComponent<Edge>().Point1ID]).normalized;
            gameObject.transform.localScale = new Vector3(0.1f, (dataMeshContainer.Vertices[gameObject.GetComponent<Edge>().Point2ID] - dataMeshContainer.Vertices[gameObject.GetComponent<Edge>().Point1ID]).magnitude / 2, 0.1f);
            dataMesh.ActionsVertices[dataMeshContainer.Edges[i].indice] += (arg) => { UpdateEedge(gameObject,arg); };
        }
    }

    public void AddSurface()
    {
        selectedObject.GetComponent<MeshRenderer>().enabled = false;
        DataMesh dataMesh = selectedObject.GetComponent<DataMesh>();
        DataMeshContainer dataMeshContainer = dataMesh.DataMeshContainer;
        for (int i = 0; i < dataMeshContainer.Shapes.Count; i++)
        {
            Vector3 point1, point2, point3, point4;
            GameObject gameObject = Instantiate(prefabSurface, selectedObject.transform);
            gameObject.GetComponent<Surface>().Point1ID = dataMeshContainer.Shapes[i].indices[0];
            gameObject.GetComponent<Surface>().Point2ID = dataMeshContainer.Shapes[i].indices[1];
            gameObject.GetComponent<Surface>().Point3ID = dataMeshContainer.Shapes[i].indices[2];
            gameObject.GetComponent<Surface>().Point4ID = dataMeshContainer.Shapes[i].indices[4];
            gameObject.GetComponent<Surface>().Datamesh = dataMesh;

            point1 = dataMeshContainer.Vertices[dataMeshContainer.Shapes[i].indices[0]];
            point2 = dataMeshContainer.Vertices[dataMeshContainer.Shapes[i].indices[1]];
            point3 = dataMeshContainer.Vertices[dataMeshContainer.Shapes[i].indices[2]];
            point4 = dataMeshContainer.Vertices[dataMeshContainer.Shapes[i].indices[4]];
            Vector3 center = (point1 + point2 + point3 + point4) / 4;

            gameObject.transform.localPosition = center;
            gameObject.GetComponent<Surface>().Init();
        }
    }

    public void UpdateEedge(GameObject element,GameObject arg)
    {
        Debug.Log("oui");
        if (arg == element)
            return;
        /*
        DataMesh dataMesh = selectedObject.GetComponent<DataMesh>();
        DataMeshContainer dataMeshContainer = dataMesh.DataMeshContainer;


        element.transform.localPosition = (dataMeshContainer.Vertices[element.GetComponent<Edge>().Point2ID] + dataMeshContainer.Vertices[element.GetComponent<Edge>().Point1ID]) / 2;
        element.transform.up = (dataMeshContainer.Vertices[element.GetComponent<Edge>().Point2ID] - 
                                   dataMeshContainer.Vertices[element.GetComponent<Edge>().Point1ID]).normalized;
        element.transform.localScale = new Vector3(0.1f, (dataMeshContainer.Vertices[element.GetComponent<Edge>().Point2ID] - dataMeshContainer.Vertices[element.GetComponent<Edge>().Point1ID]).magnitude / 2, 0.1f);
        */
    }

    void AddBezierSpline()
    {
        DataMesh dataMesh = selectedObject.GetComponent<DataMesh>();
        DataMeshContainer dataMeshContainer = dataMesh.DataMeshContainer;

        GameObject gameObject = Instantiate(prefabSpline, selectedObject.transform);
        gameObject.GetComponent<SplineBezierCurve>().Datamesh = dataMesh;
        gameObject.transform.localPosition = Vector3.zero;
    }

}
