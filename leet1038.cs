
using System.Diagnostics.CodeAnalysis;


public class Solution1038
{
    private int sum;
    public TreeNode BstToGst(TreeNode root)
    {
        sum = 0;
        Traversal(root);
        return root;
    }
    private void Traversal(TreeNode node)
    {
        if (node == null) return;

        Traversal(node.right);

        sum += node.val;

        node.val = sum;

        Traversal(node.left);


    }
}