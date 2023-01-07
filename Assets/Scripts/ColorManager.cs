using TMPro;
using UnityEngine;
public class ColorManager : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private Color[] colors;
    private float lerpTime = 1f;
    private int index;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, colors[index], lerpTime*Time.deltaTime);
        if (GameManager.score % 30 == 0 && GameManager.score != 0)
        {
            index++;
            if (index >= colors.Length)
            {
                index = 0;
            }
        }
        if (GameManager.isBallActive == false && Input.GetMouseButtonDown(0))
        {
            meshRenderer.material.color = colors[0];
        }
    }
}
