// See https://aka.ms/new-console-template for more information

//QUESTION 6 OUTPUT
Console.WriteLine("QUESTION 6 OUTPUT");
LinkList<int> l = new LinkList<int>();
l.InsertFirst(1); //Insert into Linkedlist
l.InsertFirst(2);//Insert into Linkedlist
l.InsertFirst(3);//Insert into Linkedlist
l.InsertFirst(4);//Insert into Linkedlist
l.DeleteFirst(); //Delete from Linkedlist
l.InsertLast(6);
l.InsertLast(7);
l.InsertLast(8);
l.DeleteLast();
l.DisplayList();

//QUESTION 7 OUTPUT
Console.WriteLine("QUESTION 7 OUTPUT");
Binary_Tree b = new Binary_Tree();
b.Add(8); 
b.Add(3); 
b.Add(1); 
b.Add(6); 
b.Add(4); 
b.Add(7); 
b.Add(10); 
b.Add(14); 
b.Add(13); 
LinkedList<int> list = b.ReturnLinkedList();
foreach (int num in list)
{
    Console.Write(num + " ");
}