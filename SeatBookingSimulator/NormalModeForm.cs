using SeatBookingSimulator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatBookingSimulator
{
    public partial class NormalModeForm : Form
    {
        SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();
        double inputRow = 0;
        double inputCol = 0;
        string[] splitStrRow;
        string[] splitStrCol;
        string senderText = "";
        bool adjacentSeatMode = false;
        public NormalModeForm()
        {
            InitializeComponent();
        }
        private void textBoxNumOfRow_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.inputRow = double.Parse(textBoxNumOfRow.Text);
            }
            catch
            {
                buttonGenerateSeats.Enabled = false;
                return;
            }//End of try..catch
            buttonGenerateSeats.Enabled = true;
        }//End of textBoxNumOfRow_TextChanged
        private void textBoxSeatPerRow_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.inputCol = double.Parse(textBoxSeatPerRow.Text);
            }
            catch
            {
                buttonGenerateSeats.Enabled = false;
                return;
            }//End of try..catch
            buttonGenerateSeats.Enabled = true;
        }//End of textBoxSeatPerRow_TextChanged

        private void textBoxRowDivider_TextChanged(object sender, EventArgs e)
        {
            this.splitStrRow = textBoxRowDivider.Text.Split(',');
            try
            {
                
            }
            catch
            {
                
            }//End of try..catch
        }//End of textBoxRowDivider_TextChanged

        private void textBoxColDivider_TextChanged(object sender, EventArgs e)
        {
            this.splitStrCol = textBoxColDivider.Text.Split(',');

            try
            {

            }
            catch
            {

            }//End of try..catch
        }//End of textBoxColDivider_TextChanged

        private void Form1_Load(object sender, EventArgs e)
        {
            this.radioButtonAdjacentSeat.CheckedChanged += new System.EventHandler(this.radioButtonAdjacentSeat_CheckedChanged);
        }//End of Form1_Load


        private void buttonGenerateSeats_Click(object sender, EventArgs e)
        {
            int colDivSpace = 0;
            int rowDivSpace = 0;
            Seat s;
            for (int i = 1; i <= inputRow; i++)
            {
                colDivSpace = 0;
                for (int j = 1; j <= inputCol; j++)
                {
                    s = new Seat();
                    s.Row = i; s.Column = j; s.ColDivSpace = colDivSpace; s.RowDivSpace = rowDivSpace;
                    seatList.InsertAtEnd(s);
                    Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
                    labelSeat.Text = s.ComputeSeatLabel();//Set the Text property by using a string
                    labelSeat.Location = new Point((60 * (s.Column - 1)) + 60 + (20 * (s.Column - 1)) + colDivSpace, (60 * (s.Row - 1)) + 60 + (20 * (s.Row - 1)) + rowDivSpace);//Create a Point type object which has x,y coordinate info
                    labelSeat.Size = new Size(60, 60);//Create a Size type object which has the width, height info
                    labelSeat.TextAlign = ContentAlignment.MiddleCenter;//Align the Text to mid - center
                    labelSeat.BorderStyle = BorderStyle.FixedSingle;//Make the border visible
                    labelSeat.BackColor = Color.LightBlue;//Set the background color
                    labelSeat.Font = new Font("Calibri", 10, FontStyle.Bold);
                    labelSeat.ForeColor = Color.Black;
                    labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
                    labelSeat.Click += new EventHandler(labelSeat_Click);
                    // Adding this control to the Panel control, panelSeats
                    this.panelSeats.Controls.Add(labelSeat);
                    if (splitStrCol.Length == 1 && j == Convert.ToInt32(splitStrCol[0]))
                    {
                        colDivSpace = 50;
                    }
                    else if (splitStrCol.Length > 1)
                    {
                        foreach (string colDivNum in splitStrCol)
                        {
                            if (j == Convert.ToInt32(colDivNum))
                            {
                                int indexColDiv = Array.FindIndex(splitStrCol, m => m == String.Format(colDivNum)) + 1;
                                colDivSpace = 50 * indexColDiv;
                            }
                        }
                    }

                };
                if (splitStrRow.Length == 1 && i == Convert.ToInt32(splitStrRow[0]))
                {
                    rowDivSpace = 50;

                }
                else if (splitStrRow.Length > 1)
                {
                    foreach (string rowDivNum in splitStrRow)
                    {
                        if (i == Convert.ToInt32(rowDivNum))
                        {
                            int indexRowDiv = Array.FindIndex(splitStrRow, m => m == String.Format(rowDivNum)) + 1;
                            rowDivSpace = 50 * indexRowDiv;
                        }
                    }
                }
            }
        }
        
        private void labelSeat_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            //MessageBox.Show(String.Format("Row {0} Column {1}",seatInfo.Row,seatInfo.Column));
            Seat seat =  seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat seatLeft = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
            Seat seatRight = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
            Seat seatFront = seatList.SearchByRowAndColumn(seatInfo.Row - 1, seatInfo.Column);
            Seat seatBack = seatList.SearchByRowAndColumn(seatInfo.Row + 1, seatInfo.Column);
            if (adjacentSeatMode == false)
            {
                labelMessage.Text = "r: " + seat.Row.ToString() + "c: " + seat.Column.ToString(); //track for the Seat Row and Seat Col
                if (seat.BookStatus == false)
                {
                    seat.BookStatus = true;
                    if (senderText == "Person A Booking" && seat.BelongToPerson == "")
                    {
                        label.BackColor = Color.CornflowerBlue;
                        seat.BelongToPerson = "A";
                    }
                    else if (senderText == "Person B Booking" && seat.BelongToPerson == "")
                    {
                        label.BackColor = Color.SandyBrown;
                        seat.BelongToPerson = "B";
                    }
                    else if (senderText == "Person C Booking" && seat.BelongToPerson == "")
                    {
                        label.BackColor = Color.LightPink;
                        seat.BelongToPerson = "C";
                    }
                    else if (senderText == "Person D Booking"&& seat.BelongToPerson == "")
                    {
                        label.BackColor = Color.DarkKhaki;
                        seat.BelongToPerson = "D";
                    }
                }
                else
                {
                    seat.BookStatus = false;
                    seat.BelongToPerson = "";
                    label.BackColor = Color.LightBlue;
                }
            }

            else //adjacent mode is true
            {
                labelMessage.Text = "r: " + seat.Row.ToString() + "c: " + seat.Column.ToString(); //track for the Seat Row and Seat Col
                for (int i = 1; i <= inputRow; i++)
                {
                    if (seat.Row == i && ((seat.BelongToPerson == seatLeft.BelongToPerson) || 
                        (seat.BelongToPerson == seatRight.BelongToPerson)))
                    {
                        
                    }
                    else
                    {
                        //label.BackColor = Color.LightBlue;
                    }

                }
            }

        }

        private void buttonPersonA_Click(object sender, EventArgs e)
        {
            senderText = (sender as Button).Text;
        }
        private void buttonPersonB_Click(object sender, EventArgs e)
        {
            senderText = (sender as Button).Text;
        }
        private void buttonPersonC_Click(object sender, EventArgs e)
        {
            senderText = (sender as Button).Text;
        }
        private void buttonPersonD_Click(object sender, EventArgs e)
        {
            senderText = (sender as Button).Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\..\\Data"));
            saveFileDialog.Filter = "Data Files (*.dat)|*.dat";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    BinaryFormatter f = new BinaryFormatter();
                    f.Serialize(stream, seatList);
                    stream.Close();
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

            string filePath;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\..\\Data"));
            openFileDialog.Filter = "Data Files (*.dat)|*.dat";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                BinaryFormatter f = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);

                if (stream.Length != 0)
                {
                    seatList = (SeatDoubleLinkedList)f.Deserialize(stream);
                }
                stream.Close();
            }

            panelSeats.Controls.Clear();

            List<Label> labelList = seatList.GenerateLabels();

            foreach (Label label in labelList)
            {
                {
                    label.Click += new System.EventHandler(labelSeat_Click);
                    panelSeats.Controls.Add(label);
                }
            }
        }//End of buttonLoad_Click

        private void radioButtonAdjacentSeat_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAdjacentSeat.Checked == true)
            {
                adjacentSeatMode = true;
                buttonGenerateSeats.PerformClick();
            }
        }
        private void buttonEndSimulation_Click(object sender, EventArgs e)
        {

        }
    }//End of Form1 class
 }//End of namespace
