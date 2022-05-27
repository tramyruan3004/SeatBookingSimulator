using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SeatBookingSimulator.Classes
{
    [Serializable]
    internal class SeatDoubleLinkedList
    {
        private int length = 0;
        //"Always make sure" that this "start" refers to the first node of the list.
        public Node Start { get; set; }
        public SeatDoubleLinkedList()
        {
            this.Start = null;
        }//End of constructor
        public int GetLength()
        {
            if (this.Start != null)
            {
                length++;
            }
            Node p = this.Start;
            while (p.Next != null)
            {
                p = p.Next;
                length++;
            }// End of while
            return length;
        }
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
        
        public int ReturnIndNumInLabelList(Seat pSeat)
        {
            int ind = 0;
            Node p = this.Start;
            while (p != null)
            {
                if ((p.Seat.Column == pSeat.Column) && (p.Seat.Row == pSeat.Row))
                {
                    //If the node referenced by p satisfies the
                    //search criteria, exit the loop
                    //The p will reference the node which satisfies
                    //the search criteria before exiting the while loop.
                    break;//Exit the while loop
                }
                p = p.Next;//Continue to the next node
                ind++;
            }//While loop
            if (p == null)
            {
                return -1;
            }
            else
            {
                return ind;
            }//End of if..else block
        }
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
                Label labelSeat = p.Seat.CreateLabel();
                labels.Add(labelSeat);
                return labels;
            }//End of if..else block
        }//End of GenerateLabels
        public void SetCanBook(bool status)
        {
            Node p = this.Start;
            while (p.Next != null)
            {
                p.Seat.CanBook = status;
                if (status == false)
                {
                    p.Seat.BookStatus = false;
                    p.Seat.BelongToPerson = "";
                    p.Seat.CanBookedBy = "";
                }
                p = p.Next;
            }
        }
        public bool ExistSeatBelongToPerson(string referPerson)
        {
            Node p = this.Start;
            while (p.Next != null)
            {
                if (p.Seat.BelongToPerson == referPerson)
                {
                    return true;
                };
                p = p.Next;
            }
            return false;
        }

        
}//End of class
}//End of namespace
