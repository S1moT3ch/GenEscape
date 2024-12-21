using UnityEngine;

public class LineBetweenPoints : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    private LineRenderer lineRenderer;

    public float amplitude = 0.5f;
    public float speed = 1f;

    private Vector3 initialStartPos;
    private Vector3 initialEndPos;

    void Start()
    {
        startPoint = gameObject.GetComponent<Transform>();

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.positionCount = 2;

        // Salva le posizioni iniziali
        initialStartPos = startPoint.position;
        initialEndPos = endPoint.position;
    }

    void Update()
    {
        if (startPoint != null && endPoint != null)
        {
            // Movimento verticale
            float offset = Mathf.Sin(Time.time * speed) * amplitude;

            Vector3 startPos = initialStartPos + new Vector3(0, offset, 0);
            Vector3 endPos = initialEndPos + new Vector3(0, offset, 0);

            // Imposta le posizioni della linea
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
        }
    }
}