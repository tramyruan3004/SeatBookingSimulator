using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SeatBookingSimulator.Classes
{
    [Serializable]
    internal class SeatDoubleLinkedList
    {
        //"Always make sure" that this "start" refers to the first node of the list.
        public Node Start { get; set; }
        public SeatDoubleLinkedList()
        {
            this.Start = null;
        }//End of constructor
        public void InsertAtEnd(Seat pSeatData)
        {
            Node newNode = new Node(pSeatData);
            if (this.Start == null)
            {
                this.Start = newNode;
                return;
            }
            Node p = this.Start;
            // Traverse through the list until the p refers to
            // the last node.
            while (p.Next != null)
            {
                p = p.Next;
            }// End of while
            p.Next = newNode;
            newNode.Prev = p;
        }//End of InsertAtEnd
        public Seat SearchByRowAndColumn(int pRow, int pColumn)
        {
            Node p = this.Start;
            while (p != null)
            {
                if ((p.Seat.Column == pColumn) && (p.Seat.Row == pRow))
                {
                    //If the node referenced by p satisfies the
                    //search criteria, exit the loop
                    //The p will reference the node which satisfies
                    //the search criteria before exiting the while loop.
                    break;//Exit the while loop
                }
                p = p.Next; //Continue to the next node
            }//While loop
            if (p == null)
            {
                return null;
            }
            else
            {
                return p.Seat;
            }//End of if..else block
        }//End of SearchByRowAndColumn

        public List<Label> GenerateLabels()
        {
            List<Label> labels = new List<Label>();
            Node p = this.Start;
            while (p != null)
            {
                Label labelSeat = p.Seat.CreateLabel();
                labels.Add(labelSeat);

                p = p.Next; //Continue to the next node
            }//While loop
            if (p == null)
            {
                return labels;
            }
            else
            {
                return labels;
            }//End of if..else block
        }//End of GenerateLabels
        
}//End of class
}//End of namespace
