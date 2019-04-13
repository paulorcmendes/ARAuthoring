using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksControllerScript : MonoBehaviour
{
    public GameObject linkPrefab;
    private Dictionary<GameObject, Link> links;
    private float lastRemoval;
    private float delayRemoval;
    // Start is called before the first frame update
    void Start()
    {
        delayRemoval = 5f;
        links = new Dictionary<GameObject, Link>();
        lastRemoval = -delayRemoval;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLink(Link link)
    {
        GameObject linkObject = Instantiate(linkPrefab, transform, false);
        LinkCollision linkCollision = linkObject.GetComponent<LinkCollision>();
        linkCollision.Description = link.Description;
        linkCollision.linksController = this;
        linkObject.transform.Translate(new Vector3(0,1.5f*links.Count));
        links.Add(linkObject, link);
    }

    public void RemoveLink(GameObject linkObject)
    {
        float currentTime = Time.time;
        if (currentTime > lastRemoval + delayRemoval)
        {
            lastRemoval = currentTime;
            this.links.Remove(linkObject);
            Destroy(linkObject);
            UpdatePosLinks();
        }
    }


    private void UpdatePosLinks() {
        int i = 0;
        foreach (KeyValuePair<GameObject,Link> pair in links)
        {
            pair.Key.transform.localPosition = new Vector3(0, 1.5f * i);
            i++;
        }
    } 
}
