using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameFinder
{
    public class GameFilters : MonoBehaviour
    {
        [Tooltip("What types of games the user is looking for.")]
        public FilterFlags CheckedButtons;

        [Tooltip("Toggle UI used for enabling a filter on a single game classification type.")]
        public GameObject TogglePrefab;

        /// <summary> Broadcast when the set of all filters have changed </summary>
        public event Action<FilterFlags> OnFiltersChanged;

        void Start()
        {
            foreach (var filter in Enum.GetNames(typeof(FilterFlags)))
            {
                var newClone = Instantiate(TogglePrefab);
                newClone.transform.SetParent(this.transform);
                newClone.name = filter.ToString();
                newClone.GetComponentInChildren<Text>().text = filter.ToString();

                var toggle = newClone.GetComponent<Toggle>();
                int filterIndex = newClone.transform.GetSiblingIndex();
                toggle.isOn = (((int)CheckedButtons >> filterIndex) & 1) == 1; // https://stackoverflow.com/questions/21878434/how-am-i-getting-a-single-bit-from-an-int

                addClickListener(newClone);
            }
        }

        /// <summary> Sets up the toggle button to recieve an event that is broadcast when it is clicked </summary>
        private void addClickListener(GameObject newClone)
        {
            // handle click event https://www.reddit.com/r/Unity3D/comments/hhh46x/how_to_addlistener_to_eventtrigger_through_code/ / https://stackoverflow.com/questions/61138585/unity3d-2019-adding-eventtriggers-at-runtime / https://discussions.unity.com/t/getting-gameobject-from-onvaluechanged/771806
            var toggleEvent = newClone.GetComponent<EventTrigger>();
            toggleEvent ??= newClone.AddComponent<EventTrigger>();
            var entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;

#if UNITY_EDITOR
            UnityEditor.Events.UnityEventTools.AddPersistentListener(entry.callback, filterChanged);
#else
            entry.callback.AddListener(filterChanged);
#endif
            toggleEvent.triggers.Add(entry);
        }

        private void filterChanged(BaseEventData ped)
        {
            var filterToggle = ped.selectedObject.GetComponent<Toggle>();
            int filterIndex = filterToggle.transform.GetSiblingIndex();

            // track filter change
            string mod, beforeMod = CheckedButtons.Bits();
            if (filterToggle.isOn) // add filter
            {
                mod = (1 << filterIndex).Bits();
                CheckedButtons |= (FilterFlags)(1 << filterIndex);
            }
            else                   // remove filter
            {
                mod = (~(1 << filterIndex)).Bits();
                CheckedButtons &= (FilterFlags)~(1 << filterIndex);
            }
            Debug.Log("checkbox #" + filterIndex + " anded " + mod + " to " + beforeMod + " creating " + CheckedButtons.Bits());

            // broadcast event that the set of all filters have changed
            if (OnFiltersChanged != null)
            {
                OnFiltersChanged(CheckedButtons);
            }
        }
    }
}
