using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
	public TextMeshProUGUI lifeText;

	public void setLife(int life)
	{
		lifeText.text = "Lives: " + life;
	}
}