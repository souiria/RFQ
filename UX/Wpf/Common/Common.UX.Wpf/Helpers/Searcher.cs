using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Extensions;
using Prism.Commands;

namespace Common.UX.Wpf.Helpers
{
    public class Searcher<T> : INotifyPropertyChanged
    {
        private List<SearchResultModel<T>> _searchResults;
        public List<SearchResultModel<T>> SearchResults
        {
            get => _searchResults;
            set => SetProperty(ref _searchResults, value);
        }

        private SearchResultModel<T> _selectedSearch;
        public SearchResultModel<T> SelectedSearch
        {
            get => _selectedSearch;
            set
            {
                SetProperty(ref _selectedSearch, value);
                SelectedSearchChanged();
            }
        }

        private string _searchString;
        public string SearchString
        {
            get => _searchString;
            set
            {
                SetProperty(ref _searchString, value);
                CheckSearchVisibility();
            }
        }

        private bool _searchResultsIsOpen;
        public bool SearchResultsIsOpen
        {
            get => _searchResultsIsOpen;
            set => SetProperty(ref _searchResultsIsOpen, value);
        }

        private bool _searchFocused;
        public bool SearchFocused
        {
            get => _searchFocused;
            set
            {
                SetProperty(ref _searchFocused, value);
                CheckSearchVisibility();
            }
        }

        private bool _isSearching;
        public bool IsSearching
        {
            get => _isSearching;
            set => SetProperty(ref _isSearching, value);
        }

        private bool _isValid = true;
        public bool IsValid
        {
            get => _isValid;
            private set => SetProperty(ref _isValid, value);
        }

        private CancellationTokenSource _cancellationTokenSource;

        public AwaitableDelegateCommand SearchChangedCommand { get; }
        public DelegateCommand ClearCommand { get; }

        private readonly Func<T, bool> _selectionChangedCallBack;
        private readonly Func<IEnumerable<T>> _sourceProvider;

        private Func<T, string> NameResolver { get; }
        private List<SearchParameter<T>> SearchParameters { get; } = new List<SearchParameter<T>>();

        public SearcherClearSetting SearcherClearSetting { get; set; } = SearcherClearSetting.ClearOnSelect;

        public Searcher(Func<IEnumerable<T>> sourceProvider, Func<T, bool> selectionChangedCallBack, Func<T, string> nameResolver)
        {
            SearchChangedCommand = new AwaitableDelegateCommand(SearchAsync);
            ClearCommand = new DelegateCommand(Clear);
            _sourceProvider = sourceProvider;
            _selectionChangedCallBack = selectionChangedCallBack;
            NameResolver = nameResolver;
            IsValid = false;
        }

        public Searcher(Func<IEnumerable<T>> sourceProvider, Action<T> selectionChangedCallBack, Func<T, string> nameResolver) :
            this(sourceProvider, collection =>
            {
                selectionChangedCallBack(collection);
                return true;
            }, nameResolver)
        { }

        public void AddSearchParameter(Func<T, string> valueSelector, string matchedOnName)
        {
            SearchParameters.Add(new SearchParameter<T>(valueSelector, matchedOnName));
        }

        public async Task SearchAsync()
        {
            if (IsSearching)
            {
                _cancellationTokenSource?.Cancel();
            }

            IsSearching = true;
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                SearchResults = await Task.Run(() => Search(_cancellationTokenSource.Token));
            }
            finally
            {
                IsSearching = false;
            }
        }

        private List<SearchResultModel<T>> Search(CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(SearchString)) return null;

            var results = new List<SearchResultModel<T>>();

            var source = _sourceProvider();
            if (source == null) return null;

            foreach (var item in source)
            {
                cancellationToken.ThrowIfCancellationRequested();

                foreach (var searchParameter in SearchParameters)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (string.IsNullOrEmpty(searchParameter.GetValue(item)) ||
                        !searchParameter.GetValue(item).Contains(SearchString,
                            StringComparison.CurrentCultureIgnoreCase)) continue;

                    var searchResult = new SearchResultModel<T>(item, NameResolver(item),
                        searchParameter.GetValue(item), searchParameter.MatchedOn, 0);

                    results.Add(searchResult);
                    break;
                }

            }

            return results.OrderBy(x => x.Match.Length).ToList();
        }

        private static IEnumerable<INode> ModifySource(IEnumerable<INode> source, int depth)
        {
            var modifiedSource = source;
            for (var i = 0; i < depth; i++)
            {
                modifiedSource = modifiedSource.SelectMany(node => node.Nodes);
            }

            return modifiedSource;
        }

        #region -- NotifyPropertyChanged --

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        #endregion

        private void SelectedSearchChanged()
        {
            if (SelectedSearch == null) return;

            IsValid = _selectionChangedCallBack(SelectedSearch.Value);
            if (SearcherClearSetting == SearcherClearSetting.ClearOnSelect)
                Clear();
            else
                SetProperty(ref _searchString, NameResolver(SelectedSearch.Value), nameof(SearchString));
        }

        /// <summary>
        /// Sets the selected value of the search and call the selection callback.
        /// </summary>
        /// <param name="item">The item to select.</param>
        public void SetSelected(T item)
        {
            IsValid = _selectionChangedCallBack(item);
            if (SearcherClearSetting == SearcherClearSetting.ClearOnSelect)
                Clear();
            else
                SetProperty(ref _searchString, NameResolver(item), nameof(SearchString));
        }

        private void CheckSearchVisibility()
        {
            if (!string.IsNullOrEmpty(SearchString) && SearchFocused)
            {
                SearchResultsIsOpen = true;
                //SearchResults = await SearchAsync();
            }
            else
                SearchResultsIsOpen = false;
        }

        public void Clear()
        {
            SearchString = string.Empty;

            if (SearcherClearSetting == SearcherClearSetting.RemoveSelectionOnClear)
                IsValid = _selectionChangedCallBack(default);
        }
    }

    public class HierarchySearcher : INotifyPropertyChanged
    {
        private List<SearchResultModel<INode>> _searchResults;
        public List<SearchResultModel<INode>> SearchResults
        {
            get => _searchResults;
            set => SetProperty(ref _searchResults, value);
        }

        private SearchResultModel<INode> _selectedSearch;
        public SearchResultModel<INode> SelectedSearch
        {
            get => _selectedSearch;
            set
            {
                SetProperty(ref _selectedSearch, value);
                SelectedSearchChanged();
            }
        }

        private string _searchString;
        public string SearchString
        {
            get => _searchString;
            set
            {
                SetProperty(ref _searchString, value);
                CheckSearchVisibility();
            }
        }

        private bool _searchResultsIsOpen;
        public bool SearchResultsIsOpen
        {
            get => _searchResultsIsOpen;
            set => SetProperty(ref _searchResultsIsOpen, value);
        }

        private bool _searchFocused;
        public bool SearchFocused
        {
            get => _searchFocused;
            set
            {
                SetProperty(ref _searchFocused, value);
                CheckSearchVisibility();
            }
        }

        private bool _isSearching;
        public bool IsSearching
        {
            get => _isSearching;
            set => SetProperty(ref _isSearching, value);
        }

        private bool _isValid = true;
        public bool IsValid
        {
            get => _isValid;
            private set => SetProperty(ref _isValid, value);
        }

        private CancellationTokenSource _cancellationTokenSource;

        public AwaitableDelegateCommand SearchChangedCommand { get; }
        public DelegateCommand ClearCommand { get; }

        private readonly Func<INode, bool> _selectionChangedCallBack;
        private readonly Func<IEnumerable<INode>> _sourceProvider;

        private Dictionary<int, Func<INode, string>> NameResolvers { get; } = new Dictionary<int, Func<INode, string>>();
        private Dictionary<int, List<SearchParameter<INode>>> SearchParameters { get; } = new Dictionary<int, List<SearchParameter<INode>>>();

        public SearcherClearSetting SearcherClearSetting { get; set; } = SearcherClearSetting.ClearOnSelect;

        public HierarchySearcher(Func<IEnumerable<INode>> sourceProvider, Func<INode, bool> selectionChangedCallBack)
        {
            SearchChangedCommand = new AwaitableDelegateCommand(SearchAsync);
            ClearCommand = new DelegateCommand(Clear);
            _sourceProvider = sourceProvider;
            _selectionChangedCallBack = selectionChangedCallBack;
        }

        public HierarchySearcher(Func<IEnumerable<INode>> sourceProvider, Action<INode> selectionChangedCallBack) :
            this(sourceProvider, collection =>
            {
                selectionChangedCallBack(collection);
                return true;
            })
        { }

        public void AddSearchParameter(int depth, Func<INode, string> valueSelector, string matchedOnName)
        {
            if (!SearchParameters.ContainsKey(depth))
                SearchParameters[depth] = new List<SearchParameter<INode>>();

            SearchParameters[depth].Add(new SearchParameter<INode>(valueSelector, matchedOnName));
        }

        public void AddNameResolver(int depth, Func<INode, string> nameResolver) => NameResolvers.Add(depth, nameResolver);

        public async Task SearchAsync()
        {
            if (IsSearching)
            {
                _cancellationTokenSource?.Cancel();
            }

            IsSearching = true;
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                SearchResults = await Task.Run(() => Search(_cancellationTokenSource.Token));
            }
            finally
            {
                IsSearching = false;
            }
        }

        private List<SearchResultModel<INode>> Search(CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(SearchString)) return null;

            var results = new List<SearchResultModel<INode>>();

            foreach (var depth in SearchParameters.Keys)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var modifiedSource = ModifySource(_sourceProvider(), depth);
                //TODO: Crashes when searches while list is Empty(Using tab to navigate to Searchbar)
                if (modifiedSource != null)
                {
                    foreach (var node in modifiedSource)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        foreach (var searchParameter in SearchParameters[depth])
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            if (string.IsNullOrEmpty(searchParameter.GetValue(node)) ||
                                !searchParameter.GetValue(node).Contains(SearchString,
                                    StringComparison.CurrentCultureIgnoreCase)) continue;

                            var searchResult = new SearchResultModel<INode>(node, NameResolvers[depth](node),
                                searchParameter.GetValue(node), searchParameter.MatchedOn, depth);

                            // -- Get path --
                            if (depth > 0)
                            {
                                var path = new string[depth];
                                var newNode = node;
                                for (var i = depth - 1; i >= 0; i--)
                                {
                                    newNode = newNode.ParentNode;
                                    path[i] = (NameResolvers[i](newNode));
                                }

                                searchResult.Path = path.ToArray();
                            }

                            results.Add(searchResult);
                            break;
                        }
                    }
                }
            }

            return results.OrderBy(x => x.Match.Length).ToList();
        }

        private static IEnumerable<INode> ModifySource(IEnumerable<INode> source, int depth)
        {
            var modifiedSource = source;
            for (var i = 0; i < depth; i++)
            {
                modifiedSource = modifiedSource.SelectMany(node => node.Nodes);
            }

            return modifiedSource;
        }

        #region -- NotifyPropertyChanged --

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        #endregion

        private void SelectedSearchChanged()
        {
            if (SelectedSearch == null) return;

            IsValid = _selectionChangedCallBack(SelectedSearch.Value);
            if (SearcherClearSetting == SearcherClearSetting.ClearOnSelect)
                Clear();
            else
                SetProperty(ref _searchString, NameResolvers[SelectedSearch.Depth](SelectedSearch.Value), nameof(SearchString));
        }

        /// <summary>
        /// Sets the selected value of the search and call the selection callback.
        /// </summary>
        /// <param name="depth">The depth of which the node reside in the hierarchy source. This is used for resolving the name.</param>
        /// <param name="node">The node to select.</param>
        public void SetSelected(int depth, INode node)
        {
            IsValid = _selectionChangedCallBack(node);
            if (SearcherClearSetting == SearcherClearSetting.ClearOnSelect)
                Clear();
            else
                SetProperty(ref _searchString, NameResolvers[depth](node), nameof(SearchString));
        }

        private void CheckSearchVisibility()
        {
            if (!string.IsNullOrEmpty(SearchString) && SearchFocused)
            {
                SearchResultsIsOpen = true;
            }
            else
                SearchResultsIsOpen = false;
        }

        public void Clear()
        {
            SearchString = string.Empty;

            if (SearcherClearSetting == SearcherClearSetting.RemoveSelectionOnClear)
                IsValid = _selectionChangedCallBack(null);
        }
    }

    public class SearchParameter<T>
    {
        public Func<T, string> GetValue { get; }
        public string MatchedOn { get; }

        internal SearchParameter(Func<T, string> valueSelector, string matchedOnName)
        {
            GetValue = valueSelector;
            MatchedOn = matchedOnName;
        }
    }

    public class SearchResultModel<T>
    {
        public T Value { get; }
        public string Name { get; }
        public string Match { get; }
        public string MatchType { get; }
        public string[] Path { get; set; }
        public int Depth { get; }

        public SearchResultModel(T value, string name, string match, string matchType, int depth = 0)
        {
            Value = value;
            Name = name;
            Match = match;
            MatchType = matchType;
            Depth = depth;
        }
    }

    public enum SearcherClearSetting
    {
        None,
        ClearOnSelect,
        RemoveSelectionOnClear
    }
}
