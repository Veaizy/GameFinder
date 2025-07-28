using System;
using UnityEngine;
using UnityEngine.UI;

public class GameFilters : MonoBehaviour
{
    [Flags]
    public enum FilterFlags
    {
        isSingleplayer,
        isMultiplayer,
        isTopdown,
        isFirstperson,
        isThirdperson,
        isSandbox,
        isLinear,
        isShooter,
        isSurvival,
        isPuzzle,
    }

    public FilterFlags CheckedButtons;
    public GameObject togglePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var filter in Enum.GetNames(typeof(FilterFlags)))
        {
            var newClone = Instantiate(togglePrefab);
            newClone.transform.parent = this.transform;
            newClone.name = filter.ToString();
            newClone.GetComponentInChildren<Text>().text = filter.ToString();
            newClone.GetComponent<Toggle>().isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
