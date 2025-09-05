using System;
using System.Diagnostics.Tracing;

public class Solution226 {
    
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;

        TreeNode tmp = root.left;
        root.left = root.right;
        root.right = tmp;

        InvertTree(root.left);
        InvertTree(root.right);
        return root;
    }
}