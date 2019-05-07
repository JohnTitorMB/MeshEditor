using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class TreeView : MonoBehaviour
{

    [SerializeField]
    Item itemSelected;

    [SerializeField]
    GameObject itemPrefab;

    [SerializeField]
    GameObject content;

    //List<Item> items;
    
    // Use this for initialization
    void Start ()
    {
        // items = new List<Item>();
        /*
        items.Add(new Item(items.Count));
        items.Sort(delegate (Item x, Item y)
                 {
                     if (x.Index > y.Index)
                         return 0;
                     return 1;
                 });
                 */

        itemSelected = content.GetComponent<Item>();      
        itemSelected.Height = 1080;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(Item parent)
    {       
        GameObject gameObject = Instantiate(itemPrefab, itemSelected.ContentChild);
        RectTransform item = gameObject.GetComponent<RectTransform>();
        RectTransform itemChild = gameObject.transform.parent.GetComponent<RectTransform>();
       // if (itemChild.name == "ItemsChild")
            itemChild.sizeDelta = new Vector2(itemChild.sizeDelta.x, item.sizeDelta.y);

        gameObject.transform.localPosition = -new Vector3(0, 17 * itemSelected.ChildCount, 0);
        itemSelected.AddChild(gameObject.GetComponent<Item>());
        itemSelected = gameObject.GetComponent<Item>();
        itemSelected.Button.GetComponent<Image>().color = new Color(0,0,1,0.3f); 
        itemSelected.Button.onClick.AddListener(delegate { SelecteItem(itemSelected); });
         

    }

    private void SelecteItem(Item item)
    {
        itemSelected = item;
    }
}





