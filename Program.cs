using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using LinkedListVisualizer;

namespace LinkedList
{
    public partial class LinkedList : Form
    {
        public LinkedList()
        {
            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 11001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            InitializeComponent();

            button1.Click += new EventHandler(Button1__Click);
            button2.Click += new EventHandler(Button2__Click);
            button3.Click += new EventHandler(Button3__Click);
            button4.Click += new EventHandler(Button4__Click);
            button5.Click += new EventHandler(Button5__Click);
            button6.Click += new EventHandler(Button6__Click);
        }

        /* Linked List Examples        

       1. Create a Linked List of strings
           LinkedList<string> sentence = new LinkedList<string>();

       2. Create a Linked List from an array of strings
           string[] words =
               { "the", "red", "car", "speeds", "away" };
           LinkedList<string> sentence = new LinkedList<string>(words);

       3. Add new strings to the end of the Linked List
           sentence.AddLast("word");

       4. Add the word 'today' to the beginning of the linked list.
           sentence.AddFirst("today");

       5. Move the first node to be the last node.
           LinkedListNode<string> firstNode = sentence.First;
           sentence.RemoveFirst();
           sentence.AddLast(firstNode);

       6. Change the last node to 'yesterday'
           sentence.RemoveLast();
           sentence.AddLast("yesterday");

       7. Move the last node to be the first node.
           LinkedListNode<string> lastNode = sentence.Last;
           sentence.RemoveLast();
           sentence.AddFirst(lastNode);

       8. Find the last occurence of 'the'.
           LinkedListNode<string> target = sentence.FindLast("the");
           if (target == null)
           {
               // "the" is not found
           }
           else
           {
               // Add 'bright' and 'red' after 'the' (the LinkedListNode named target).
               sentence.AddAfter(target, "bright");
               sentence.AddAfter(target, "red");
           }

       9. Find the 'car' node
           LinkedListNode<string> target = sentence.Find("car");

       10. Add 'sporty' and 'red' before 'car':
           sentence.AddBefore(target, "sporty");
           sentence.AddBefore(target, "red");

       11. Keep a reference to the 'car' node
       and to the previous node in the list
           carNode = sentence.Find("car");
           LinkedListNode<string> current = carNode.Previous;

       12. The AddBefore method throws an InvalidOperationException
       if you try to add a node that already belongs to a list.
           try
           {
               // try to add carNode before current
               sentence.AddBefore(current, carNode);
           }
           catch (InvalidOperationException ex)
           {
               Console.WriteLine("Exception message: {0}", ex.Message);
           }


       13. Remove the node referred to by carNode, and then add it
       before the node referred to by current.
           sentence.Remove(carNode);
           sentence.AddBefore(current, carNode);


       14. Add the 'current' node after the node referred to by mark2
           sentence.AddAfter(mark2, current);

       15. The Remove method finds and removes the
       first node that that has the specified value.
           sentence.Remove("red");

       16. Create an array with the same number of
       elements as the linked list.
           string[] sArray = new string[sentence.Count];
           sentence.CopyTo(sArray, 0);

       17. Walk through a Linked List in forward order
           LinkedListNode<object> linkedListNode = linkedList.First;

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Next;
           }

       18. Walk through a Linked List in reverse order
           LinkedListNode<object> linkedListNode = linkedList.Last;

           while( linkedListNode != null )
           {
               linkedListNode = linkedListNode.Previous;
           }

       19. Change the Value of a node
           linkedListNode.Value = "new value";

       20. Release all the nodes.
           sentence.Clear();

       */



        private void Button1__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the digits 1 through 10
            LinkedList<object> linkedList = new LinkedList<object>();

            // 2. Your code here
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i + 1);
            }

            // 3. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button2__Click(object sender, EventArgs e)
        {
            // 1. using Button1__Click() create a LinkedList which contains the digits 1 through 10
            LinkedList<object> linkedList = new LinkedList<object>();

            // 2. Your code here
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i + 1);
            }

            // 3. using example #18, copy the linkedList to reverseLinkedList in reverse order
            // so that reverseLinkedList goes from 10 to 1
            LinkedList<object> reverseLinkedList = new LinkedList<object>();
            LinkedListNode<object> linkedListNode;

            // 4. Your code here
            // assign the reference node to the last
            linkedListNode = linkedList.Last;
            // while there are still nodes
            while (linkedListNode != null)
            {
                // remove the node being referenced
                linkedList.RemoveLast();
                // add the reference node to the other list
                reverseLinkedList.AddLast(linkedListNode);
                // find the last node in linkedList
                linkedListNode = linkedList.Last;
            }

            // 5. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(reverseLinkedList);
        }

        private void Button3__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the words
            // "the", "fox", "jumped", "over", "the", "dog"
            LinkedList<object> linkedList = null;
            LinkedListNode<object> linkedListNode;
            string[] sentence = null;

            // 2. Your code here
            // create a linked list
            linkedList = new LinkedList<object>();
            // assign a string array with the correct values
            sentence = new string[] { "the", "fox", "jumped", "over", "the", "dog" };
            // add them to the linked list
            foreach (string s in sentence)
            {
                linkedList.AddLast(s);
            }

            // 3. add "quick" and "brown" before "fox"

            // 4. Your code here
            // manually assign modifications to the linked list
            linkedListNode = linkedList.FindLast("fox");
            linkedList.AddBefore(linkedListNode, "quick");
            linkedList.AddBefore(linkedListNode, "brown");

            // 5. using example #8, add "lazy" after the last "the"

            // 6. Your code here
            // manually assign modifications to the linked list
            linkedListNode = linkedList.FindLast("the");
            linkedList.AddAfter(linkedListNode, "lazy");

            // 7. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button4__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the words
            // Because I'm sad Clap along if you feel like a room without a roof
            // Because I'm sad Clap along if you feel like sadness is the truth sad
            LinkedList<object> linkedList = null;
            LinkedListNode<object> linkedListNode;
            string[] sentence = null;

            // 2. Your code here
            // create a linked list
            linkedList = new LinkedList<object>();
            // assign a string array with the correct values
            string words = "Because I'm sad Clap along if you feel like a room without a roof Because I'm sad Clap along if you feel like sadness is the truth sad";
            sentence = words.Split(' ');
            // add them to the linked list
            foreach (string s in sentence)
            {
                linkedList.AddLast(s);
            }

            // 3. replace "sad" with "happy"
            // and "sadness with "happiness"
            // note that because Value is an object 
            // you will have to cast Value as a string as follows:
            //     if( (string)linkedListNode.Value == "sad"

            // 4. Your code here
            //find an initial sad
            linkedListNode = linkedList.FindLast("sad");
            // if we found a sad loop through all the sad
            while (linkedListNode != null)
            {
                // add a happy right after the sad
                linkedList.AddAfter(linkedListNode, "happy");
                // remove the sad
                linkedList.Remove(linkedListNode);
                // find the next sad
                linkedListNode = linkedList.FindLast("sad");
            }
            // find an initial sadness
            linkedListNode = linkedList.FindLast("sadness");
            // if we found a sadness loop through all the sadness
            while (linkedListNode != null)
            {
                // add a happiness right after the sadness
                linkedList.AddAfter(linkedListNode, "happiness");
                // remove the sadness
                linkedList.Remove(linkedListNode);
                // find the next sadness
                linkedListNode = linkedList.FindLast("sadness");
            }


            // 5. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button5__Click(object sender, EventArgs e)
        {
            // 1. create a LinkedList which contains the following words
            // The Spain in rain falls plain on the mainly
            LinkedList<object> linkedList = null;
            LinkedListNode<object> linkedListNode1;
            LinkedListNode<object> linkedListNode2;
            string[] sentence = null;

            // 2. Your code here
            // create a linked list
            linkedList = new LinkedList<object>();
            // asssign the linked list to the correct values
            string words = "The Spain in rain falls plain on the mainly";
            sentence = words.Split(' ');
            // add them to the linked list
            foreach (string s in sentence)
            {
                linkedList.AddLast(s);
            }

            // 3. manipulate the list using Find(), Remove(), AddBefore() and/or AddAfter() to result in
            // "The rain in Spain falls mainly on the plain"
            // your Add methods must use 2 LinkedListNode arguments like examples #13 and #14 
            // you may not use string arguments in your Add method calls <----=

            // 4. Your code here
            // manually assign the modifications to the linked list
            //0 = the, 1 = spain, 2 = in, 3 = rain, 4 = falls, 5 = plain, 6 = on, 7 = the, 8 = mainly
            linkedListNode1 = linkedList.FindLast("Spain");
            linkedListNode2 = linkedList.FindLast("rain");
            linkedList.Remove(linkedListNode2);
            linkedList.AddBefore(linkedListNode1, linkedListNode2);
            //0 = the, 1 = rain 2 = spain, 3 = in, 4 = falls, 5 = plain, 6 = on, 7 = the, 8 = mainly
            linkedListNode1 = linkedList.FindLast("rain");
            linkedListNode2 = linkedList.FindLast("in");
            linkedList.Remove(linkedListNode2);
            linkedList.AddAfter(linkedListNode1, linkedListNode2);
            //0 = the, 1 = rain 2 = in, 3 = spain 4 = falls, 5 = plain, 6 = on, 7 = the, 8 = mainly
            linkedListNode1 = linkedList.FindLast("falls");
            linkedListNode2 = linkedList.FindLast("mainly");
            linkedList.Remove(linkedListNode2);
            linkedList.AddAfter(linkedListNode1, linkedListNode2);
            //0 = the, 1 = rain 2 = in, 3 = spain 4 = falls, 5 = mainly, 6 = plain, 7 = on, 8 = the
            linkedListNode1 = linkedList.FindLast("mainly");
            linkedListNode2 = linkedList.FindLast("on");
            linkedList.Remove(linkedListNode2);
            linkedList.AddAfter(linkedListNode1, linkedListNode2);
            //0 = the, 1 = rain 2 = in, 3 = spain 4 = falls, 5 = mainly, 6 = on, 7 = plain, 8 = the
            linkedListNode1 = linkedList.FindLast("on");
            linkedListNode2 = linkedList.FindLast("the");
            linkedList.Remove(linkedListNode2);
            linkedList.AddAfter(linkedListNode1, linkedListNode2);
            //0 = the, 1 = rain 2 = in, 3 = spain 4 = falls, 5 = mainly, 6 = on, 7 = the, 8 = plain

            // 5. then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(linkedList);
        }

        private void Button6__Click(object sender, EventArgs e)
        {
            LinkedListNode<object> linkedListNode1;
            LinkedListNode<object> linkedListNode2;

            string[] letters = { "D", "O", "R", "M", "I", "T", "O", "R", "Y" };
            LinkedList<object> anagram = new LinkedList<object>(letters);

            // rearrange the Nodes to spell "DIRTYROOM"
            // your Add methods must use 2 LinkedListNode arguments like examples #13 and #14 
            // you may not use string arguments in your Add method calls

            // Your code here
            // manually assign the modifications to the linked list
            //D, O, R, M, I, T, O, R, Y
            linkedListNode1 = anagram.FindLast("D");
            linkedListNode2 = anagram.FindLast("I");
            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);
            //D, I, O, R, M, T, O, R, Y
            linkedListNode1 = linkedListNode2;
            linkedListNode2 = anagram.FindLast("R");
            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);
            //D, I, R, O, R, M, T, O, Y
            linkedListNode1 = linkedListNode2;
            linkedListNode2 = anagram.FindLast("T");
            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);
            //D, I, R, T, O, R, M, O, Y
            linkedListNode1 = linkedListNode2;
            linkedListNode2 = anagram.FindLast("Y");
            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);
            //D, I, R, T, Y, O, R, M, O
            linkedListNode1 = linkedListNode2;
            linkedListNode2 = anagram.FindLast("R");
            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);
            //D, I, R, T, Y, R, O, M, O
            linkedListNode1 = linkedListNode2;
            linkedListNode2 = anagram.FindLast("O");
            anagram.Remove(linkedListNode2);
            anagram.AddAfter(linkedListNode1, linkedListNode2);
            //D, I, R, T, Y, R, O, O, M

            // then call the visualizer
            VisualizeLinkedList visualizeLinkedList = new VisualizeLinkedList(anagram);
        }
    }
}