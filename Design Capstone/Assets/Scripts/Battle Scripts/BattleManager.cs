using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using InControl;

public class BattleManager : MonoBehaviour {
    public float offset = 0.3f;
    public float spawnTimer = 3.0f;
    public int hitStreak = 0;

    public GameObject canvas;
    public GameObject arrowPrefab;
    public GameObject touchCursorPrefab;

    public GameObject monster;
    public GameObject healthBar;
    public GameObject swipeBox;
    public GameObject streakText;
    public GameObject critText;
    
    public Dictionary<string, Vector2> swipeTypes;
    public Queue<GameObject> swipeArrows;

    TouchControl input;
    Vector2 touchStart;
    Vector2 touchEnd;

    // Use this for initialization
    void Start() {
        touchStart = Vector2.zero;
        touchEnd = Vector2.zero;
        swipeTypes = new Dictionary<string, Vector2>();
        swipeArrows = new Queue<GameObject>();
        InvokeRepeating("SpawnArrow", spawnTimer, spawnTimer);

        //Initialize Dictionary
        swipeTypes.Add("Up", Vector2.up);
        swipeTypes.Add("Down", Vector2.down);
        swipeTypes.Add("Left", Vector2.left);
        swipeTypes.Add("Right", Vector2.right);
    }

    // Update is called once per frame
    void Update() {
        //Record Swipes
        if(RecordSwipe() && CheckSwipe(touchStart, touchEnd, offset)) {
            GameObject arrow = swipeArrows.Peek();

            //Calcualte distance between arrow and swipebox
            float dist = Vector3.Distance(arrow.transform.position, swipeBox.transform.position);
           
            if(dist <= 200.0) {
                Destroy(swipeArrows.Dequeue());

                //Hit monsters health
                //Check for crit
                if(hitStreak > 0 && hitStreak % 10 == 0) {
                    monster.GetComponent<Monster>().DealDamage(5);
                    critText.GetComponent<Animator>().SetTrigger("Crit");
                    
                } else {
                    monster.GetComponent<Monster>().DealDamage(1);
                }
                

                healthBar.GetComponent<BarFill>().fill = monster.GetComponent<Monster>().GetHealthPercent();

                hitStreak++;
            } else {
                hitStreak = 0;
            }
        }

        //Despawn Arrows
        if(swipeArrows.Count > 0 && swipeArrows.Peek().transform.position.y < -6.0f) {
            Destroy(swipeArrows.Dequeue());
            hitStreak = 0;
        }


        /*if(hitStreak >= 5) {
            streakText.GetComponent<CanvasRenderer>().SetAlpha(1);
        } else {
            streakText.GetComponent<CanvasRenderer>().SetAlpha(0);
        }*/

        streakText.GetComponent<Text>().text = hitStreak + "x";
    }

    /// <summary>
    /// Returns a bool representing whether a swipe was detected or not
    /// True if swipe was detected, false otherwise
    /// </summary>
    public bool RecordSwipe() {
        if(TouchManager.TouchCount > 0) {
            InControl.Touch touch = TouchManager.GetTouch(0);

            //Record starting position of touch
            if(touch.phase == TouchPhase.Began) {
                touchStart = touch.position;

            } else if(touch.phase == TouchPhase.Ended) {
                touchEnd = touch.position;

                //Play box animation
                swipeBox.GetComponent<Animator>().SetTrigger("PulseBox");

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Returns a vector representing the normalized swipe direction, returns a zero vector if no touch
    /// </summary>
    /// <param name="start">The swipe starting position</param>
    /// /// <param name="end">The swipe ending position</param>
    public bool CheckSwipe(Vector2 start, Vector2 end, float offset) {
        Vector2 swipeDir = new Vector2(end.x - start.x, end.y - start.y).normalized;
        foreach(var key in swipeTypes.Keys) {
            Vector2 swipeTypeDir = swipeTypes[key];
            Vector2 accuracy = new Vector2(swipeDir.x - swipeTypeDir.x, swipeDir.y - swipeTypeDir.y);
            float mag = accuracy.magnitude;

            if(mag <= offset) {
                Debug.Log("Swipe Type: " + key + ", " + swipeTypeDir);
                Debug.Log(swipeArrows.Peek().GetComponent<SwipeArrow>().swipeType); 
                if(swipeArrows.Count > 0 && swipeArrows.Peek().GetComponent<SwipeArrow>().swipeType.Equals(key)) {
                    return true;
                }
            }
        }

        return false;
    }

    public void SpawnArrow() {
        //Randomly choose arrow direction
        List<string> keys = new List<string>(swipeTypes.Keys);
        string dir = keys[Random.Range(0, keys.Count)];

        //Make arrow with specified parameters
        var newArrow = Instantiate(arrowPrefab, canvas.transform);
        newArrow.transform.SetParent(canvas.transform);
        newArrow.GetComponent<SwipeArrow>().swipeType = dir;

        switch(dir) {
            case "Up":
                break;
            case "Down":
                newArrow.transform.Rotate(0, 0, 180);
                break;
            case "Left":
                newArrow.transform.Rotate(0, 0, 90);
                break;
            case "Right":
                newArrow.transform.Rotate(0, 0, 270);
                break;
        }

        swipeArrows.Enqueue(newArrow);
    }
}
