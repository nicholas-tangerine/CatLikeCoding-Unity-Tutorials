using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10,1000)]
    int resolution = 10;

    Transform[] points;

    // Initializes the boxes along the x axis at y = z = 0

    void Awake() {
        float step = 2f / resolution;
        
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        
        points = new Transform[resolution];

        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i] = Instantiate(pointPrefab);

            position.x = (i + 0.5f) * step - 1f;

            point.localPosition = position;
            point.localScale = scale;

            point.SetParent(transform, false);
        }
    }

    void Update() {
        float time = Time.time;

        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));

            point.localPosition = position;
        }


    }
}
