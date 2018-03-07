using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFT153_Algorithms
{
    public class Node
    {
        public int data;//contains the acutal data of the node. can be as simple as an int or a whole new object.
        public Node next; //contains location of the next item in the list.
    }

    //creates the start of the list, the header.
    public class List
    {
        //defines the head / the first node in the list.
        public Node head;
    }

    class Program
    {

        static void clear_set(List set)
        {
            //by setting the head to null, the rest of the list is effectively removed.
            set.head = null;
        }

        static bool is_element_of(int x, List set)
        {
            //initialise a bool to store the outcome.
            bool inSet = false;
            Node current = set.head;
            //traverse the list and compare each element to the users' input.
            while (current != null)
            {
                //if it finds a match, set the bool to true.
                if (current.data == x)
                {
                    inSet = true;
                }
                current = current.next;
            }
            //return the bool result.
            return inSet;
        }

        //returns the length of the parsed list.
        static int size(List set)
        {
            //creates a variable to store the length.
            int length = 0;

            //set the current to the head.
            Node current = set.head;
            //traverse the list, incrementing the length variable with each node traversed.
            while (current != null)
            {
                length++;
                current = current.next;
            }
            //return the length.
            return length;
        }

        //prints the lists elements.
        static void print(List set)
        {
            Node current = set.head;
            //print brace for better presentation in console.
            Console.Write("{ ");
            //traverse through the list, printing each nodes' data to console.
            while (current != null)
            {

                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine("}");
        }

        //adds the data to the parsed list.
        static void add(List set, int data)
        {
            //checks to see if the element is already in the list.
            if (is_element_of(data, set))
            {
                //alerts the user that they cannot input repeat values.
                Console.WriteLine("Please enter an int that is not already present");

            }
            else
            {

                //checks if the head of the list is empty i.e. if the list has even been created yet.
                if (set.head == null)
                {
                    //if not, set the head of the list to a new node, and initialise its data & next.
                    set.head = new Node();

                    set.head.data = data;
                    set.head.next = null;
                }
                else
                {
                    //if the list has been created, create a new node, set its data & next and append it to the end  of the existing nodes.
                    Node toAdd = new Node();
                    toAdd.data = data;

                    Node currentNew = set.head;
                    //traverse to the end of the list.
                    while (currentNew.next != null)
                    {
                        currentNew = currentNew.next;
                    }

                    currentNew.next = toAdd;

                }
            }
        }
        
        //removes the users input from the parsed list.
        static void remove(List set, int x)
        {
            //sets the current node to the start of the list.
            Node current = set.head;
            //start looping through the list, on ahead of the current.
            while (current.next != null)
            {
                //search for the users input.
                if (current.data == x)
                {
                    //if they match, it means the users input matches the head of the list. set the head to the next element, thus deleting the head.
                    set.head = current.next;
                }
                //if it doesnt match the head, compare the next nodes, using 3 pointers so that we are checking the one in the middle and can connect the two either side.
                else if (current.next.data == x)
                {
                    //if the final element is the one that matches, set the penultimate '.next' to null.
                    if (current.next.next == null)
                    {
                        current.next = null;
                    }
                    else
                    {
                        //connect the one before and after the matching element.
                        current.next = current.next.next;
                        break;
                    }

                }
                //if its not already been set to null by the above operations, progress to the next element.
                if (current.next != null)
                {
                    current = current.next;
                }

            }

        }

        //will check to see if the list is empty. If the first element is null, then the list is empty.
        static bool isEmpty(List set)
        {
            //if the head of the list is null, then no list exists.
            return (set.head == null);
        }

        //will copy the list into a new list, and return it.
        static List copy(List set, List setCopy)
        {
            //sets current to the head of the parsed list.
            Node current = set.head;
            //loops through the list 
            while (current != null)
            {
                //if the head of the new list is null, create one.
                if (setCopy.head == null)
                {
                    //create a new node for the head.
                    setCopy.head = new Node();
                    //set its data to that of the current node.
                    setCopy.head.data = current.data;
                    setCopy.head.next = null;
                }
                else //if the head does exist, just create a new node.
                {
                    Node toAdd = new Node();
                    //sets the new node to the data of the current node.
                    toAdd.data = current.data;

                    Node currentCopy = setCopy.head;
                    //loop to the end of the existing copyList.
                    while (currentCopy.next != null)
                    {
                        currentCopy = currentCopy.next;
                    }
                    //append the new node to the end.
                    currentCopy.next = toAdd;
                    
                }
                //move onto the next element and repeat the copying process.
                current = current.next;
            }
            //returns the newly copied list.
            return setCopy;
        }
        //will check to see if the contents of 'subset' are in the main user set.
        static bool is_subset(List set, List subset)
        {
            //initialises a set of variables used in the method.
            bool isSubset = false;
            int numberOfMatches = 0;
            int subsetLength = size(subset);
            //sets up the relevant pointers in each set.
            Node subCurrent = subset.head;
            Node current = set.head;

            //loops through each set
            while (subCurrent != null)
            {
                while(current != null)
                {
                    //compares the data of each element in each set.
                    if (subCurrent.data == current.data)
                    {
                        //if the data matches, increment the following variable.
                        numberOfMatches++;
                        break;
                    }
                    current = current.next;
                }
                subCurrent = subCurrent.next;
            }
            //if the numberOfMatches is equal to the total length of the subset, all elements in the subset must be in the main set, thus its a subset.
            if (numberOfMatches == subsetLength)
            {
                //set the following bool to true.
                isSubset = true;
            }
            return isSubset;
        }

        static List union(List set1, List set2)
        {
            List unionSet = new List();
            bool temp = false;
            
            unionSet = copy(set1, unionSet);
      
            Node set2Current = set2.head;
            Node unionCurrent = unionSet.head;

            while (unionCurrent != null)
            {
               while (set2Current != null)
                {

                    if (unionCurrent == set2Current)
                    {
                        temp = true;
                    }

                    

                    set2Current = set2Current.next;
                }

                if (temp == false)
                {
                    Node toAdd = new Node();

                    toAdd.data = set2Current.data;

                    Node current = unionSet.head;
                    while (current.next != null)
                    {
                        current = current.next;
                    }

                    current.next = toAdd;
                }
                unionCurrent = unionCurrent.next;
            }
            return unionSet;
        }

        static List intersection (List set1, List set2)
        {
            //sets up the relevant pointers.
            Node current1 = set1.head;
            Node current2 = set2.head;

            //craetes a new list to store the intersection.
            List intersectionSet = new List();

            //loops through each set.
            while (current1 != null)
            {
                while (current2 != null)
                {
                    //if the data matches, add that data to the intersectionSet created above.
                    if (current1.data == current2.data)
                    {
                        if (intersectionSet.head == null)
                        {
                            intersectionSet.head = new Node();

                            intersectionSet.head.data = current1.data;
                            intersectionSet.head.next = null;
                        }
                        else
                        {
                            Node toAdd = new Node();
                            toAdd.data = current1.data;

                            Node current = intersectionSet.head;
                            while (current.next != null)
                            {
                                current = current.next;
                            }

                            current.next = toAdd;
                        }

                        current2 = current2.next;
                        break;
                    }

                    current2 = current2.next;

                }
                current1 = current1.next;
            }
            //return the final set.
            return intersectionSet;
        }

       //this method contains 'difference()' has been commented out because it was not functional at time of hand-in.
       //static List difference (List set1, List set2)
       // {
       //     List differenceSet = new List();

       //     Node current1 = set1.head;
       //     Node current2 = set2.head;

       //     while (current1 != null)
       //     {
       //         while (current2 != null)
       //         {
       //             if (current1.data == current2.data)
       //             {
       //                 break;
       //             }
       //             else
       //             {
       //                 if (differenceSet.head == null)
       //                 {
       //                     differenceSet.head = new Node();

       //                     differenceSet.head.data = current1.data;
       //                     differenceSet.head.next = null;
       //                 }
       //                 else
       //                 {
       //                     Node toAdd = new Node();
       //                     toAdd.data = current1.data;

       //                     Node current = differenceSet.head;
       //                     while (current.next != null)
       //                     {
       //                         current = current.next;
       //                     }

       //                     current.next = toAdd;
       //                 }
       //             }

       //             current2 = current2.next;
       //         }


       //         current1 = current1.next;
       //     }

       //     return differenceSet;
       // }
        static void Main(string[] args)
        {
            
            //declares the relevant lists for testing.
            List set = new List();
            List setCopy = new List();
            List subset = new List();
            List intersectionSet = new List();
            List differenceSet = new List();


            //creates a small subset for later testing.
            add(subset, 1);
            add(subset, 2);
            add(subset, 3);

            //Add a set of ints (entered by the user) to the set by appending them onto the last one.
            int input = 0;
            Console.WriteLine("Please enter individual ints to create a set of ints. '-1' to end set creation.");
            while (input >= 0)
            {
                input = Convert.ToInt32(Console.ReadLine());
                if(input >=0)
                    add(set, input);
            }
            Console.WriteLine("-------------------------------------\n");

            //checks if the head of the set is empty/null and returns it in a bool.
            bool empty = isEmpty(set);
            Console.WriteLine("isEmpty: " + empty);
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();


            //gets the current size/length of the set.
            int setSize = size(set);
            Console.WriteLine("This set is " + setSize + " nodes in length");
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();

            //Checks if the users' input is present in the set.
            Console.WriteLine("Please enter an int to see if it is present in this set");
            int isPresent = Convert.ToInt32(Console.ReadLine());
            bool inSet = is_element_of(isPresent, set);
            Console.WriteLine("isPresent:" + inSet);
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();

            //prints the complete set.
            Console.WriteLine("Set: ");
            print(set);
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();

            //will search the set for the users input and remove it.
            Console.WriteLine("Please enter an int to remove");
            int toRemove = Convert.ToInt32(Console.ReadLine());
            remove(set, toRemove);
            Console.WriteLine("-------------------------------------\n");
            //prints the updated set with the users' input removed.
            Console.WriteLine("Updated set:");
            print(set);
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();

            //copies the set to a new set & prints it.
            setCopy = copy(set, setCopy);
            Console.WriteLine("Copied set: ");
            print(setCopy);
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();

            //returns if all the elements in the subset are present in the main set.
            bool isSubset = is_subset(set, subset);

            Console.WriteLine("Main set: ");
            print(set);

            Console.WriteLine("Subset: ");
            print(subset);

            Console.WriteLine("isSubset: " + isSubset);
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();

            //returns the intersection of the sets.
            intersectionSet = intersection(set, subset);
            Console.WriteLine("Main set: ");
            print(set);

            Console.WriteLine("Secondary set: ");
            print(subset);

            Console.WriteLine("Intersection set: ");       
            print(intersectionSet);
            Console.WriteLine("-------------------------------------\n");

            Console.WriteLine("Press enter to progress...");
            Console.ReadLine();

            Console.WriteLine("Press enter to clear the list.");
            clear_set(set);
            Console.WriteLine("Set cleared.");
            Console.WriteLine("set: ");
            print(set);
            //union set doesn't work correctly.

            //difference set doesn't work correctly.

            //symmetric_difference wasn't attempted. 

            Console.WriteLine("Press any key to close application");
            Console.ReadLine();

          
        }
    }

    //class that defines what a single item in the list can be.




}
