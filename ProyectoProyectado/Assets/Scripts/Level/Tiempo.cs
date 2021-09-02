using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
	public bool Fin = false;
    public Text timerText;
    int m = 0, s = 0;
    private void Start()
    {
		writeTimer(m, s); 
		Invoke("updateTimer", 1f);
	}
	void Update()
	{
		if (Fin)
		CancelInvoke();
	}
	private void updateTimer()
	{
		s++;
		if (s > 59)
		{
			s = 0;
			m++;
		}
		writeTimer(m, s);
		Invoke("updateTimer", 1f);
	}
	private void writeTimer(int m, int s)
	{
		if (m < 10)
		{
			if (s < 10)
			{
				timerText.text = "0" + m.ToString() + ":0" + s.ToString();
			}
			else
			{
				timerText.text = "0" + m.ToString() + ":" + s.ToString();
			}
		}
		else if (m < 61)
		{
			if (s < 10)
			{
				timerText.text = m.ToString() + ":0" + s.ToString();
			}
			else
			{
				timerText.text = m.ToString() + ":" + s.ToString();
			}
		}
		else
			timerText.text = "+1h";
	}
}
