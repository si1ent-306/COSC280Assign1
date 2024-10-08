// See https://aka.ms/new-console-template for more information

//QUESTION 6 OUTPUT
LinkList<int> l = new LinkList<int>();
// l.InsertFirst(1); //Insert into Linkedlist
// l.InsertFirst(2);//Insert into Linkedlist
// l.InsertFirst(3);//Insert into Linkedlist
// l.InsertFirst(4);//Insert into Linkedlist
// l.DeleteFirst(); //Delete from Linkedlist
// l.InsertLast(6);
// l.InsertLast(7);
// l.InsertLast(8);
// l.DeleteLast();
// l.DisplayList();

//QuESTION 7 OUTPUT
Binary_Tree b = new Binary_Tree();
b.Add(15); //Add a node
b.Add(12); //Add a node
b.Add(21); //Add a node
b.Add(11); //Add a node
b.Add(22); //Add a node
b.Add(20); //Add a node
b.TraverseInOrder(b.Root); //Iterate through the Binary Tree inorder transversal
Console.WriteLine("\n"+b.GetTreeHeight()); //Display height of Binary Tree
Console.WriteLine(b.MinValue(b.Root)); //Find the minimum value in the tree, starting at the root node
b.Find(15); //Search for node 15