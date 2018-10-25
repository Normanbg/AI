using UnityEngine;
using System.Collections;

public class AIPerceptionManager : MonoBehaviour {

	public GameObject Alert;
    public AIMemory memory;

    private void Start()
    {
       memory = GetComponent<AIMemory>();
    }

    // Update is called once per frame
    void PerceptionEvent (PerceptionEvent ev) {

		if(ev.type == global::PerceptionEvent.types.NEW)
		{
            memory.AddEntry(ev.go);
			Debug.Log("Saw something NEW");
			Alert.SetActive(true);
		}
		else
		{
            memory.PastMemChange(ev.go);
			Debug.Log("LOST something");
			Alert.SetActive(false);
		}
	}
}
