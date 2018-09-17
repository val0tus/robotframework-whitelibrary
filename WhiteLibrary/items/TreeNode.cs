using TestStack.White.UIItems.TreeItems;
using static CsDynamicLib.Attributes;

namespace CSWhiteLibrary.items
{
    [RobotKeywordClass]
    public class TreeNodeKeywords : LibraryElement
    {
        public TreeNodeKeywords(WhiteLibrary state) : base(state)
        {
        }

        private TreeNode getTreeNode(string locator, string[] nodePath)
        {
            Tree tree = State.Finder.getItemByLocator<Tree>(locator);
            return tree.Nodes.GetItem(nodePath);
        }

        [RobotKeyword]
        public void selectTreeNode(string locator, string[] nodePath)
        {
            TreeNode node = getTreeNode(locator, nodePath);
            node.Select();
        }

        [RobotKeyword]
        public void expandTreeNode(string locator, string[] nodePath)
        {
            TreeNode node = getTreeNode(locator, nodePath);
            node.Expand();
        }

        [RobotKeyword]
        public void doubleClickTreeNode(string locator, string[] nodePath)
        {
            TreeNode node = getTreeNode(locator, nodePath);
            node.DoubleClick();
        }

        [RobotKeyword]
        public void rightClickTreeNode(string locator, string[] nodePath)
        {
            TreeNode node = getTreeNode(locator, nodePath);
            node.RightClick();
        }
    }
}
