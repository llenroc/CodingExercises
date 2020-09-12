using System.Collections.Generic;
using Xunit;
using Exercises;

namespace Screens.Tests
{
    public class BlueOriginTests
    {
        [Fact]
        public void GetDiffNodesTest_returnsTrue()
        {
            // Arrange
            TreeNode a = new TreeNode(2);
            TreeNode secondlevel_a = new TreeNode(3);
            TreeNode secondlevel_b = new TreeNode(5);
            secondlevel_a.Children.Add(new TreeNode(0));
            secondlevel_b.Children.Add(new TreeNode(10));
            secondlevel_b.Children.Add(new TreeNode(11));
            secondlevel_b.Children.Add(new TreeNode(12));
            a.Children.Add(secondlevel_a);
            a.Children.Add(secondlevel_b);
            
            TreeNode b = new TreeNode(2);
            TreeNode second = new TreeNode(5);
            second.Children.Add(new TreeNode(9));
            second.Children.Add(new TreeNode(11));
            second.Children.Add(new TreeNode(13));
            b.Children.Add(second);

            // Act
            List<TreeNode> result = BlueOrigin.GetDiffNodes(a, b); // 3, 9, 10, 12, 13

            // Assert
            Assert.NotNull(result);
        }
    }
}