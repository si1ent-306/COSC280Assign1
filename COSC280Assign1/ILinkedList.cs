public interface ILinkedList<T> //Linked 
{
    /// <summary>
    /// Adds a new node to the beginning of the linked list
    /// </summary>
    /// <param name="data">The contents of the node to be added to the linked list</param>
    /// <returns>void</returns>
    void InsertFirst(T data);
    
    //Q6
    /// <summary>
    /// Inserts and node at the end of a linked list
    /// </summary>
    /// <param name="index">The contents of the node to be added to the linked list</param>
    /// <returns>void</returns>
    void InsertLast(T index);

    /// <summary>
    /// Deletes the node at the beginning of the linked list
    /// </summary>
    /// <returns>The deleted node</returns> 
    LinkNode<T> DeleteFirst();
    
    //Q6
    /// <summary>
    /// Deletes the node at the end of the linked list
    /// </summary>
    /// <returns>void</returns> 
    void DeleteLast();

    /// <summary>
    /// Iterates through the linked list from the head
    /// </summary>
    /// <returns>void</returns> 
    void DisplayList();
}