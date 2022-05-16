using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SeatBookingSimulator.Classes
{
    [Serializable]
    internal class Seat
    {
        //This property is used to describe whether the seat "has been selected"
        private bool _bookStatus = false;
        //This property is used to describe that the seat is not bookable at all
        private bool _canBook = false;
        // The _row field is 2 if the object is modelling a seat at row "B".
        private int _row;
        // _column field is 3 if the object is modelling a seat at column 3.
        private int _column;
        public int Row // property
        {
            get { return _row; } // get method
            set
            {
                _row = value;
            } // set method
        }
        public int Column // property
        {
            get { return _column; } // get method
            set { _column = value; } // set method
        }
        public bool CanBook // property
        {
            get { return _canBook; } // get method
            set
            {
                _canBook = value;
            } // set method
        }
        public bool BookStatus // property
        {
            get { return _bookStatus; } // get method
            set
            {
                _bookStatus = value;
            } // set method
        }
        //ComputeSeatLabel is a method defined inside the Seat class
        //ComputeSeatLabel is "not" a property.
        public string ComputeSeatLabel()
        {
            return ((char)(_row + 64)).ToString() + _column.ToString();
        }//End of ComputeSeatLabel

        public Label CreateLabel()
        {
            
           
            Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
            labelSeat.Text = this.ComputeSeatLabel();//Set the Text property by using a string
            labelSeat.Location = new Point((60 * (this.Column - 1)) + 60 + (20 * (this.Column - 1)), (60 * (this.Row - 1)) + 60 + (20 * (this.Row - 1)));//Create a Point type object which has x,y coordinate info
            labelSeat.Size = new Size(60, 60);//Create a Size type object which has the width, height info
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;//Align the Text to mid - center
            labelSeat.BorderStyle = BorderStyle.FixedSingle;//Make the border visible
            labelSeat.BackColor = Color.LightBlue;//Set the background color
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = this.Row, Column = this.Column };
            labelSeat.BackColor = Color.LightBlue;
            if (this.BookStatus == true)
            {
                labelSeat.BackColor = Color.LightGreen;
            }
            return labelSeat;
        }//End of CreateLabel

    }//end of Seat class
}//end of Namespace
