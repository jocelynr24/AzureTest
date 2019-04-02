using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour
{
    public GameObject reference;
    public GameObject position;
    
    void Update()
    {
        Vector3 posRef = GameObject.Find("ReferenceCube").transform.position;
        Vector3 posPos = GameObject.Find("PositionCube").transform.position;

        Vector3 posRel = posPos - posRef;

        GameObject.Find("x").GetComponent<Text>().text = posRel.x.ToString();
        GameObject.Find("y").GetComponent<Text>().text = posRel.y.ToString();
        GameObject.Find("z").GetComponent<Text>().text = posRel.z.ToString();
    }
}
