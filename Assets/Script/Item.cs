using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    void Awake()
    {
        Transform transformChild = transform.Find("ItemsChild");
        if (transformChild == null)
            ContentChild = transform.GetComponent<RectTransform>();
        else
            ContentChild = transformChild.GetComponent<RectTransform>();

        if (transform.Find("Button"))
        {
            button = transform.Find("Button").GetComponent<Button>();
        }
    }

    RectTransform contentChild;
    int index;
    List<Item> chlid = new List<Item>();
    Item parent;
    bool isClosed = false;
    int height = 0;
    int itemCountOpen = 0;
    Button button;

    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }

    public bool IsClosed
    {
        get
        {
            return isClosed;
        }

        set
        {
            isClosed = value;
        }
    }

    public int ChildCount
    {
        get
        {
            return chlid.Count;
        }
    }

    public RectTransform ContentChild
    {
        get
        {
            return contentChild;
        }

        set
        {
            contentChild = value;
        }
    }

    public int Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
        }
    }

    public Item Parent
    {
        get
        {
            return parent;
        }

        set
        {
            parent = value;
        }
    }

    public int ItemCountOpen
    {
        get
        {
            return itemCountOpen;
        }

        set
        {
            itemCountOpen = value;            
        }
    }

    public Button Button
    {
        get
        {
            return button;
        }

        set
        {
            button = value;
        }
    }

    public void AddChild(Item item)
    {
        chlid.Add(item);
        item.Parent = this;
       // if (contentChild.name == "ItemsChild")
       // {
            ItemCountOpen++;            
            UpdateItemchildSize();
       // }
    }

    private void UpdateItemchildSize()
    {
        contentChild.sizeDelta = new Vector2(contentChild.sizeDelta.x, itemCountOpen * 17);
        if(parent)
        {
            parent.ItemCountOpen++;
            parent.UpdateItemchildSize();
        }
    }
 
}

