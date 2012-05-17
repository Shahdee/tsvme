using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vme
{
    public enum Imagebpp { Eightbpp, Sixteenbpp };

    /* Бинарное дерево */
    public class TreeNode
    {
        public int value;
        public TreeNode left, right;
        public string code;


        public TreeNode()
        {
            value = 0;
            left = null;
            right = null;
            code = "";
        }
    }

    public class TBinarySTree
    {
        public TreeNode root;

        public TBinarySTree()
        {
            root = null;
        }
    }

}
