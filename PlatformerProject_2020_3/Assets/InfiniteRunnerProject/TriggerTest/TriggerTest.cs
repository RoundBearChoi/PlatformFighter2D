using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.TriggerTest
{
    public class TriggerTest : MonoBehaviour
    {
        [SerializeField]
        Vector2 size = new Vector2();

        void FixedUpdate()
        {
            ContactFilter2D filter = new ContactFilter2D();
            List<Collider2D> results = new List<Collider2D>();
            int count = Physics2D.OverlapBox(Vector2.zero, size, 0f, filter, results);

            Vector2[] points = new Vector2[4];
            points[0] = new Vector2(size.x * -0.5f, size.y * 0.5f);
            points[1] = new Vector2(size.x * -0.5f, size.y * -0.5f);
            points[2] = new Vector2(size.x * 0.5f, size.y * -0.5f);
            points[3] = new Vector2(size.x * 0.5f, size.y * 0.5f);

            Debug.DrawLine(points[0], points[1], Color.red, 0.1f);
            Debug.DrawLine(points[1], points[2], Color.red, 0.1f);
            Debug.DrawLine(points[2], points[3], Color.red, 0.1f);
            Debug.DrawLine(points[3], points[0], Color.red, 0.1f);

            foreach(Collider2D c in results)
            {
                Debugger.Log("touching " + c.gameObject.name);
            }
        }
    }
}