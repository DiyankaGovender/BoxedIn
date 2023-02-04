using UnityEngine;

public class GrappleRope : MonoBehaviour
{
   
    public GrapplingGun grapplingGun;
    public LineRenderer lineRenderer;

 
    public int lineAccuracy= 20;
    [Range(0, 20)]  public float straightenLineSpeed = 11.5f;

    public AnimationCurve lineAnimationCurve;
    [Range(0.01f, 4)] public float lineWaveSize = 1.65f;
    float linewaveSize;

  
    public AnimationCurve lineLaunchSpeedCurve;
    [Range(1, 50)] public float lineLaunchSpeed= 10.5f;

    float lineMoveTime = 0;

    public bool isHooking = false;

    bool canDrawLine =true;
    bool straightLine = true;

    public GameObject line; 

    public void start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.positionCount = lineAccuracy;
        linewaveSize = lineWaveSize;


        lineRenderer = line.GetComponent<LineRenderer>();
        MeshCollider meshCollider = line.AddComponent<MeshCollider>();


        Mesh mesh = new Mesh();
        lineRenderer.BakeMesh(mesh, true);
        meshCollider.sharedMesh = mesh;

    }

    private void OnEnable()
    {
        lineMoveTime = 0;
        lineRenderer.enabled = true;
        lineRenderer.positionCount = lineAccuracy;
        linewaveSize = lineWaveSize;
        straightLine = false;
        LinePointToFirePoint();
    }

    private void OnDisable()
    {
        lineRenderer.enabled = false;
        isHooking = false;
    }

    void LinePointToFirePoint()
    {
        for (int i = 0; i < lineAccuracy; i++)
        {
            lineRenderer.SetPosition(i, grapplingGun.whipFirePoint.position);
        }
    }

    void Update()
    {
        lineMoveTime += Time.deltaTime;

        if (canDrawLine)
        {
            DrawLine();
        }
    }

    void DrawLine()
    {
        if (straightLine==false)
        {
            if (lineRenderer.GetPosition(lineAccuracy - 1).x != grapplingGun.hookPoint.x)
            {
                DrawLineWaves();
            }
            else
            {
                straightLine = true;
            }
        }
        else
        {
            if (isHooking == false)
            {
                grapplingGun.Hook();
                isHooking = true;
            }
            if (linewaveSize > 0)
            {
                linewaveSize -= Time.deltaTime * straightenLineSpeed;
                DrawLineWaves();
            }
            else
            {
                linewaveSize = 0;
                DrawLineNoWaves();
            }
        }
    }

    void DrawLineWaves()
    {
        //CODE ADAPTED FROM CODE BY 1 MINUTE UNITY FROM https://www.youtube.com/watch?v=dnNCVcVS6uw AT 5:13 
        for (int i = 0; i < lineAccuracy; i++)
        {
            float delta = (float)i / ((float)lineAccuracy - 1f);
            Vector2 offset = Vector2.Perpendicular(grapplingGun.hookDistance).normalized * lineAnimationCurve.Evaluate(delta) * linewaveSize;
            Vector2 targetPosition = Vector2.Lerp(grapplingGun.whipFirePoint.position, grapplingGun.hookPoint, delta) + offset;
            Vector2 currentPosition = Vector2.Lerp(grapplingGun.whipFirePoint.position, targetPosition, 
                lineLaunchSpeedCurve.Evaluate(lineMoveTime) * lineLaunchSpeed);

            lineRenderer.SetPosition(i, currentPosition);
        }
    }

    void DrawLineNoWaves()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, grapplingGun.hookPoint);
        lineRenderer.SetPosition(1, grapplingGun.whipFirePoint.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("ENEMY");
        }

    }

}

