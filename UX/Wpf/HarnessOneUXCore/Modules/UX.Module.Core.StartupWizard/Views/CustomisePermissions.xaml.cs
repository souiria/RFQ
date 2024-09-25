using Infragistics.Controls.Menus;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Common.Core.Contracts.Interfaces.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.Views
{
    /// <summary>
    /// Interaction logic for CustomisePermissions.xaml
    /// </summary>
    public partial class CustomisePermissions : UserControl
    {
        private bool updatingUI = false;

        public CustomisePermissions()
        {
            InitializeComponent();
        }

        private void MenuDataTree_NodeCheckedChanged(object sender, NodeEventArgs e)
        {
            if (!updatingUI)
            {
                if (e.Node.IsChecked.HasValue)
                {
                    if (e.Node.IsChecked.Value)
                    {
                        if (e.Node.Data is FieldHierarchyModel)
                        {
                            var parentNode = e.Node.Manager.ParentNode;

                            //UpdateUI(() =>
                            //{
                            (parentNode.Data as IHierarchyModel).IsSelected = true;
                            //});

                        }
                        else
                        {
                            UpdateUI(() =>
                            {
                                ValdiateParentNodes(e.Node);
                                CheckAllChildNodes(e.Node);
                            });
                        }
                    }
                    else
                    {
                        (e.Node.Data as IHierarchyModel).IsSelected = true;
                    }
                }
                else
                {
                    UpdateUI(() =>
                    {
                        (e.Node.Data as IHierarchyModel).IsSelected = false;
                        UncheckAllChildNodes(e.Node);
                        if (!(e.Node.Data is FieldHierarchyModel))
                            ValdiateParentNodes(e.Node);
                    });
                }
            }
        }

        private void UpdateUI(Action action)
        {
            try
            {
                updatingUI = true;
                action();
                updatingUI = false;
            }
            catch (Exception e)
            {
                updatingUI = false;
            }
        }

        private XamDataTreeNode FindNode(XamDataTree tree, XamDataTreeNode node)
        {
            var nodeFound = false;
            foreach (var moduleNode in tree.Nodes)
            {
                if (moduleNode.Data == node.Data)
                    return moduleNode;
                else
                {
                    foreach (var viewNode in moduleNode.Nodes)
                    {
                        if (viewNode.Data == node.Data)
                            return viewNode;
                    }
                }
            }
            return null;
        }

        private void CheckAllChildNodes(XamDataTreeNode node)
        {
            if (node?.Nodes != null && (!(node.Data is ViewHierarchyModel) || Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                foreach (var childNode in node.Nodes)
                {
                    (childNode.Data as IHierarchyModel).IsSelected = true;
                    CheckAllChildNodes(childNode);
                }
            }
        }

        private bool? UncheckAllChildNodes(XamDataTreeNode node)
        {
            if ((node.Data as IHierarchyModel).IsActive)
            {
                if (node != null && node.HasChildren)
                {
                    var childNodes = node.Nodes;
                    bool?[] states = new bool?[childNodes.Count];
                    for (int i = 0; i < childNodes.Count; i++)
                        states[i] = UncheckAllChildNodes(childNodes[i]);

                    if (states.All(x => x.HasValue && x.Value))
                    {
                        (node.Data as IHierarchyModel).IsSelected = true;
                        return true;
                    }
                    if (states.All(x => x.HasValue && !x.Value))
                    {
                        (node.Data as IHierarchyModel).IsSelected = false;
                        return false;
                    }

                     (node.Data as IHierarchyModel).IsSelected = null;
                    return null;
                }
                else
                {
                    (node.Data as IHierarchyModel).IsSelected = false;
                    return false;
                }
            }
            else
            {
                return (node.Data as IHierarchyModel).IsSelected;
            }
        }

        private void UncheckAllEnabledChildNodes(XamDataTreeNode node)
        {
            if (node?.Nodes != null)
            {
                foreach (var childNode in node.Nodes)
                {
                    if ((childNode.Data as IHierarchyModel).IsActive)
                    {
                        (childNode.Data as IHierarchyModel).IsSelected = false;
                        UncheckAllEnabledChildNodes(childNode);
                    }
                }
            }
        }

        private void ValdiateParentNodes(XamDataTreeNode node)
        {
            var currentNode = node;
            while (currentNode.Manager.ParentNode != null)
            {
                currentNode = currentNode.Manager.ParentNode;
                if (currentNode.HasChildren)
                {
                    if (currentNode.Nodes.All(x => x.IsChecked.HasValue && x.IsChecked.Value))
                        (currentNode.Data as IHierarchyModel).IsSelected = true;
                    else if (currentNode.Nodes.All(x => x.IsChecked.HasValue && !x.IsChecked.Value))
                        (currentNode.Data as IHierarchyModel).IsSelected = false;
                    else
                        (currentNode.Data as IHierarchyModel).IsSelected = null;
                }
            }
        }
    }
}
