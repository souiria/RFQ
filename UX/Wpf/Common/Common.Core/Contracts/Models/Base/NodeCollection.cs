using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Base
{
    [DataContract]
    public class NodeCollection : INotifyPropertyChanged, INode
    {
        private Guid? _branchId;

        [DataMember]
        public Guid? BranchId
        {
            get => _branchId;
            set => SetProperty(ref _branchId, value);
        }

        private object _value;

        [DataMember]
        public object Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        private INode _parentNode;

        [DataMember]
        public INode ParentNode
        {
            get => _parentNode;
            set => SetProperty(ref _parentNode, value);
        }

        private ObservableCollection<NodeCollection> _nodes;

        [DataMember]
        public ObservableCollection<NodeCollection> Nodes
        {
            get => _nodes;
            set => SetProperty(ref _nodes, value);
        }

        /// <inheritdoc />
        public NodeCollection()
        {
            Nodes = new ObservableCollection<NodeCollection>();
        }

        /// <inheritdoc />
        public NodeCollection(object value) : this()
        {
            Value = value;
        }

        /// <inheritdoc />
        public NodeCollection(object value, Guid combinedId) : this(value)
        {
            BranchId = combinedId;
        }

        public void AddChild(object value, Guid? branchId = null)
        {
            Nodes.Add(new NodeCollection(value)
            {
                ParentNode = this,
                BranchId = branchId
            });
        }

        public void AddChild(NodeCollection node)
        {
            node.ParentNode = this;
            Nodes.Add(node);
        }

        IList<INode> INode.Nodes => Nodes.Cast<INode>().ToList();
        public int Count => Nodes.Count;
        public NodeCollection this[int index] => Nodes[index];

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public interface INode
    {
        Guid? BranchId { get; set; }
        object Value { get; set; }
        INode ParentNode { get; set; }
        IList<INode> Nodes { get; }
    }
}
