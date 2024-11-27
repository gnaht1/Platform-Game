using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FoodManager : MonoBehaviour
{
    public int foodCount;
    public TextMeshProUGUI foodText; // For TextMesh Pro

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = ": "+ foodCount.ToString();
    }
}
