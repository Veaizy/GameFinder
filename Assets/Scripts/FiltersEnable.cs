using UnityEngine;

namespace GameFinder
{
    /// <summary>
    /// Sets this gameobject to be active depending on if <seealso cref="ThisGameIs"/>
    /// includes all flags in <seealso cref="FilterSource"/>.
    /// </summary>
    public class FiltersEnable : MonoBehaviour
    {
        [Tooltip("What types of games the user is looking for.")]
        public GameFilters FilterSource;

        [Tooltip("What type of labels this game is classified as having.")]
        public FilterFlags ThisGameIs;

        private void Reset()
        {
            FilterSource = FindAnyObjectByType<GameFilters>();
        }

        void Start()
        {
            FilterSource.OnFiltersChanged += filtersChanged;
        }

        private void OnDestroy()
        {
            FilterSource.OnFiltersChanged -= filtersChanged;
        }

        private void filtersChanged(FilterFlags newFilter)
        {
            var isMatch = newFilter == 0 || ((int)newFilter & (int)ThisGameIs) == (int)newFilter;
            Debug.Log($"  {newFilter.Bits()} GameFilter \n& {ThisGameIs.Bits()} {this.name} \n= {((int)newFilter & (int)ThisGameIs).Bits()} does{(isMatch ? "" : "n't")} match GameFilter");

            this.gameObject.SetActive(isMatch);
        }
    }
}
