//Create a Binary tree class
 public class Binary_Tree : IBinaryTree //Binary_Tree class inherits from the IBinaryTree interface
{
     public Node Root { get; set; } //The tree root

     //Implements the IBinaryTree interface Add method; transverses the BST inorder, and inserts a new node 
     public bool Add(int value) 
     {
         //initalize the after node variable which transverses the BST to find the right spot for the new node
         //till it is null (no root or falls of the tree)
         //and the before node variable that stores the last node transversed by the after variable 
         Node before = null, after = this.Root; 
         
         // TRANSVERSE TREE TILL A RIGHT INSERTION SPOT IS FOUND OR THE VALUE IS FOUND
         while (after != null) //continue while current root node is not null (has not fallen off the tree)
         {
             before = after; //store after's node in variable before
             if (value < after.Data) //Should new node be in left subtree of current root? 
                 after = after.LeftNode; // make current root's left child the current root
             else if (value > after.Data) //Should new node be in right subtree of current root?
                 after = after.RightNode; // make current root's right child the current root
             else
             {
                 //Same value exists, do nothing
                 return false;
             }
         }
        
         //CREATE A NEW NODE, AND ADD DATA TO IT
         Node newNode = new Node(); //Create a new node object
         newNode.Data = value; //assign value to the new node's data
         
        // INSERT NEW NODE IF TREE IS EMPTY OR INSERTION SPOT FOUND
         if (this.Root == null) //if Tree is empty
             this.Root = newNode; // make new node the root node
         else       // else when tree if not empty
         {
             if (value < before.Data) //if value is less than data in last transversed leafnode 
                 before.LeftNode = newNode; //make new node its left child
             else  //if value is greater than data in last transversed leafnode 
                 before.RightNode = newNode; //make new node its right child
         }

         return true;
     }
     
     
     
     public void TraverseInOrder(Node parent) //Implements the IBinaryTree interface TraverseInorder method: displays the inorder
                                              //transversal of a binary tree
    {
         if (parent != null) //if the CURRENT NODE is not empty/ not fallen off the tree
         {
             int a= parent.Data;
             TraverseInOrder(parent.LeftNode);// Move to left child and call TraverseInorder method
             int b = parent.Data;
             Console.Write(parent.Data + " "); //Display the node's data
             TraverseInOrder(parent.RightNode); // Move to right child and call TraverseInorder method
         }
     }

    public void TraversePreOrder(Node parent)//Implements the IBinaryTree interface TraversePreorder method: displays the preorder
                                             //transversal of a binary tree
    {
        if (parent != null) //if the CURRENT NODE is not empty/ not fallen off the tree
        {
            Console.Write(parent.Data + " "); //Display the node's data
            TraversePreOrder(parent.LeftNode); // Move to left child and call TraverseInorder method
            TraversePreOrder(parent.RightNode); // Move to right child and call TraverseInorder method
        }
    }

        public void TraversePostOrder(Node parent)//Implements the IBinaryTree interface TraversePostorder method: displays the postorder
                                                  //transversal of a binary tree
    {
        if (parent != null)
        {
            TraversePostOrder(parent.LeftNode); // Move to left child and call TraverseInorder method
            TraversePostOrder(parent.RightNode); // Move to right child and call TraverseInorder method
            Console.Write(parent.Data + " "); //Display the node's data
        }
    }
    public int GetTreeHeight()  //Implements the IBinaryTree interface GetTreeHeight  method: returns the height of a BST
    {
         return this.GetTreeHeight(this.Root); // calls the GetTreeHeight Helper
                                               // and returns the height of the root node
     }
    
     //The GetTreeHeight method helper accepts the node from GetTreeHeight method above,
     //gets the height, then returns height to GetTreeHeight method
     private int GetTreeHeight(Node parent)
     {
         if (parent == null) //If the tree is empty (fallen off the tree)
             return 0; //return 0
         else // if the tree is not empty
         {
             // compute the Height of each subtree 
             int lHeight = GetTreeHeight(parent.LeftNode); 
             int rHeight = GetTreeHeight(parent.RightNode);
             
             //use the larger one 
             if (lHeight > rHeight) //if height of left subtree is greater than height of right subtree
                 
                 return (lHeight + 1); //return height of left subtree +1
             else
                 return (rHeight + 1); //return height of right subtree +1
         }
     }


    //Implements the IBinaryTree interface Find  Method: checks if a node containing a given value exists, and displays accordingly
    public void Find(int value)
     {
         if (this.Find(value, this.Root) == null) //Is the value of the recursive call to Find method
                                                  //equal to null (i.e. nothing found)  
             Console.WriteLine("Nothing found!");
         else if (this.Find(value, this.Root).Data == value) //Is the return node data of the recursive Find method
                                                             //equal to the given value
             Console.WriteLine("Item was found!");
     }
    //Find helper - Checks the tree until it finds the given value or
    //falls off the tree (current node returns null)
    private Node Find(int value, Node parent)
    {
        if (parent == null || value == parent.Data) return parent;// checks if node is null (still on the tree) or data found
     
        else if (value < parent.Data) // checks if given value is less than current node's data
            return Find(value, parent.LeftNode); // call the find method with the current node's left node (move left)
         
        else return Find(value, parent.RightNode); // call the find method with the current node's right node (move right)
    }


    //Implements the IBinaryTree interface Remove  method; accepts the value of the node to be deleted, and calls the remove helper function
    // starting at the root
    public void Remove(int value)
     {
         this.Root = Remove(this.Root, value);
     }

    //Remove method helper accepts a node and key, then deletes the key and returns the new root*/
     private Node Remove(Node parent, int key)
     {
        if (parent == null) //if node is empty
            return parent; // return node

        if (key < parent.Data) //if value is less than node's data
            parent.LeftNode = Remove(parent.LeftNode, key);//Move to the left, and recursively call the Remove method again
                                                           //then assign return value as left child of last node visited
        else if (key > parent.Data)
        {
            parent.RightNode = Remove(parent.RightNode, key); //Move to the right, and recursively call the Remove method again
                                                              //then assign return value as right child of last node visited
        }
         
        else // if value is same as node's value, then this is the node to be deleted 
        {
            // For node with only one child or no child  
            if (parent.LeftNode == null)//If its left node is empty
                return parent.RightNode; //return node's right child
            else if (parent.RightNode == null) //If its right node is empty
                return parent.LeftNode;  //return node's left child

            // node with two children: Get the inorder successor (smallest in the right subtree)  
            parent.Data = MinValue(parent.RightNode); //Make sucessor value the value of last node visited

            // Recursively Delete the inorder successor node
           parent.RightNode = Remove(parent.RightNode, parent.Data);
        }
         return parent;
     }

     public void RemovePred(int value)
     {
         this.Root = RemovePred(this.Root, value);
     }

     //Just like remove RemovePred uses a helper method
     public Node RemovePred(Node parent, int key)
     {
         if (parent == null) return parent; 

         if (key < parent.Data) //if value is less than node's data
             parent.LeftNode = Remove(parent.LeftNode, key);//Move to the left, and recursively call the Remove method again
         //then assign return value as left child of last node visited
         else if (key > parent.Data)
         {
             parent.RightNode = Remove(parent.RightNode, key); //Move to the right, and recursively call the Remove method again
             //then assign return value as right child of last node visited
         }
         
         else // if value is same as node's value, then this is the node to be deleted 
         {
             // For node with only one child or no child  
             if (parent.LeftNode == null)//If its left node is empty
                 return parent.RightNode; //return node's right child
             else if (parent.RightNode == null) //If its right node is empty
                 return parent.LeftNode;  //return node's left child

             // node with two children: Get the predecessor  (largest in the left subtree)  
             parent.Data = MaxValue(parent.LeftNode); //Make predecessor  value the value of last node visited

             // Recursively Delete 
             parent.LeftNode = Remove(parent.LeftNode, parent.Data);
         }
         return parent;
     }
    
     public int MinValue(Node node) //Implements the IBinaryTree interface MinValue  method: gets the smallest value in a node's subtree
    {
         int min = node.Data;

         while (node.LeftNode != null) //while the left child is not null (haven't fallen off the tree)
         {
             min = node.LeftNode.Data; //Store the data of the left child in the min variable
             node = node.LeftNode; //Move to the next left child
         }

         return min; //Return the minimum value
     }

     public int MaxValue(Node node)
     {
         int max = node.Data;
         while (node.RightNode != null)
         {
             max = node.RightNode.Data;
             node = node.RightNode;
         }
         return max;
     }

     public LinkedList<int> ReturnLinkedList()
     {
         //This list will be the one returned
         LinkedList<int> list = new LinkedList<int>();
         //use a recursive helper method that is given the root element, and the list to fill
         RecursiveReturnLinkedList(Root, list);
         //Return the new list
         return list;
     }

     private void RecursiveReturnLinkedList(Node root, LinkedList<int> list)
     {
         //Break Condition is when the end of a subtree is reached
         if (root == null)
         {
             return;
         }

         //If we want it to be in desending order, we start with teh highest, or the right tree
         //So go to the end of the tree then add
         RecursiveReturnLinkedList(root.RightNode, list);
         //The root node would be between the to trees obviously
         //This line adds the number from the root at the time at the end making it decend
         list.AddLast(root.Data);
         //Then finish to to the left tree
         RecursiveReturnLinkedList(root.LeftNode, list);
         
     }

}