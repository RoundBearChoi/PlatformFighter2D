using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class BoxCalculator
    {
        public static List<Collider2D> GetCollisionResults(Vector2 centerPoint, OverlapBoxSpecs specs, float DrawLineDuration)
        {
            List<Collider2D> results = new List<Collider2D>();

            float p0_x = centerPoint.x - specs.mBoxBounds.mSize.x / 2f;
            float p0_y = centerPoint.y + specs.mBoxBounds.mSize.y / 2f;

            float p1_x = centerPoint.x - specs.mBoxBounds.mSize.x / 2f;
            float p1_y = centerPoint.y - specs.mBoxBounds.mSize.y / 2f;

            float p2_x = centerPoint.x + specs.mBoxBounds.mSize.x / 2f;
            float p2_y = centerPoint.y - specs.mBoxBounds.mSize.y / 2f;

            float p3_x = centerPoint.x + specs.mBoxBounds.mSize.x / 2f;
            float p3_y = centerPoint.y + specs.mBoxBounds.mSize.y / 2f;

            Vector2 p0 = new Vector2(p0_x, p0_y);
            Vector2 p1 = new Vector2(p1_x, p1_y);
            Vector2 p2 = new Vector2(p2_x, p2_y);
            Vector2 p3 = new Vector2(p3_x, p3_y);

            if (DrawLineDuration > 0f)
            {
                Debug.DrawLine(p0, p1, Color.red, DrawLineDuration);
                Debug.DrawLine(p1, p2, Color.red, DrawLineDuration);
                Debug.DrawLine(p2, p3, Color.red, DrawLineDuration);
                Debug.DrawLine(p3, p0, Color.red, DrawLineDuration);
            }
            else
            {
                Debug.DrawLine(p0, p1, Color.red);
                Debug.DrawLine(p1, p2, Color.red);
                Debug.DrawLine(p2, p3, Color.red);
                Debug.DrawLine(p3, p0, Color.red);
            }


            Physics2D.OverlapBox(centerPoint, specs.mBoxBounds.mSize, specs.mBoxBounds.mAngle, specs.mContactFilter2D, results);

            return results;
        }
    }
}