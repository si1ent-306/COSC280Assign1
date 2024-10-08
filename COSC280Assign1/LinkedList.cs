//Create a linked list class that implements the ILinked List interface
public class LinkList<T>: ILinkedList<T> //Inherits ILinkedList Interface
{
    public LinkNode<T> first;//The head of the linked list
    
    
    //Implements the InsertFirst method of ILinkedList: it adds a new node to the
    //beginning of the linked list
    public void InsertFirst(T data) 
    {
        //create the new node
        LinkNode<T> newLinkNode = new LinkNode<T>();
        //Put data in the node
        newLinkNode.Data = data;
        //Make first node the new node's next:
        newLinkNode.Next = first;
        //Make the new node the first node
        first = newLinkNode;
    }
    //Q6
    public void InsertLast(T data)
    {
        //Create new node
        LinkNode<T> newLinkNode = new LinkNode<T>();
        //put data in new node
        newLinkNode.Data = data;
        //create new node = to first
        LinkNode<T> i = first;
        //loop through the list till the end
        while (i.Next != null){
            i = i.Next;
        }
        //find the end and make it equal the given data
        i.Next = newLinkNode;
    }
    // DeleteFirst() Implements the DeletesFirst method of ILinkedList
    public LinkNode<T> DeleteFirst() 
    {
        //Assign the first node to a temporary node variable 
        LinkNode<T> Temp = first;
        //Make the next node from the head (first.next) the new head (first)
        first = first.Next;
        return Temp;
    }

    //Q6
    public void DeleteLast()
    {
        //Starting at the first, loop through the list
        LinkNode<T> i = first;
        //check further ahead each loop
        while (i.Next.Next != null)
        {
            i = i.Next;
        }
        //once at the end, make the last node null, deleting it
        i.Next = null;
    }

    // Implements the DisplayList() method of ILinkedList: Displays the data in the linked list
    public void DisplayList() 
    {
        Console.WriteLine("Iterating through linkedlist...");
        //Assign the first node to a current node variable 
        LinkNode<T> current = first;

        while (current != null) // While the tail has not been reached or linked list empty
        {
            T data = current.Data; // store current node's data in data variable
            Console.WriteLine(data); // display current node's data
            current = current.Next; // Move to next node
        }
    }
}