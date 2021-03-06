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
        bool validString = true;
        int numSeatsSelected = 0;
        string radioButtonChecked = "";
        List<Label> labelList = new List<Label>();
        public NormalModeForm()
        {
            InitializeComponent();
        }
        private void NormalModeForm_Load(object sender, EventArgs e)
        {
            this.radioButtonDisable.Click += new System.EventHandler(this.radButtonType_Click);
            this.radioButtonEnable.Click += new System.EventHandler(this.radButtonType_Click);
        }
        private void textBoxNumOfRow_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(textBoxNumOfRow.Text) == 0)
                {
                    buttonGenerateSeats.Enabled = false;
                    return;
                }
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
                if (double.Parse(textBoxSeatPerRow.Text) == 0)
                {
                    buttonGenerateSeats.Enabled = false;
                    return;
                }
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
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ','};
            var chars = Enumerable.Range(0, char.MaxValue + 1)
                .Select(i => (char)i)
                .ToArray();

            var unallowedChars = chars.Except(allowedChars).ToArray();

            if (textBoxRowDivider.Text.IndexOfAny(unallowedChars) != -1)
            {
                validString = false;
            }
            else
            {
                validString = true;
            }
            if (validString == false)
            {
                buttonGenerateSeats.Enabled = false;
                return;
            }
            else
            {
                buttonGenerateSeats.Enabled = true;
            }
            this.splitStrRow = textBoxRowDivider.Text.Split(',');

        }//End of textBoxRowDivider_TextChanged
        private void textBoxColDivider_TextChanged(object sender, EventArgs e)
        {
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
            var chars = Enumerable.Range(0, char.MaxValue + 1)
                .Select(i => (char)i)
                .ToArray();

            var unallowedChars = chars.Except(allowedChars).ToArray();

            if (textBoxColDivider.Text.IndexOfAny(unallowedChars) != -1)
            {
                validString = false;
            }
            else
            {
                validString = true;
            }
            if (validString == false)
            {
                buttonGenerateSeats.Enabled = false;
                return;
            }
            else
            {
                buttonGenerateSeats.Enabled = true;
            }
            this.splitStrCol = textBoxColDivider.Text.Split(',');
        }//End of textBoxColDivider_TextChanged

        private void buttonGenerateSeats_Click(object sender, EventArgs e)
        {
            panelSeats.Controls.Clear();
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
                    if (s.CanBook == true)
                    {
                        labelSeat.BackColor = Color.LightBlue;//Set the background color
                        s.BookStatus = false;
                    }
                    else
                    {
                        labelSeat.BackColor = Color.IndianRed;//Set the background color
                    }
                    labelSeat.Font = new Font("Calibri", 10, FontStyle.Bold);
                    labelSeat.ForeColor = Color.Black;
                    labelSeat.Tag = new SeatInfo() { Row = s.Row, Column = s.Column };
                    labelSeat.Click += new EventHandler(labelSeat_Click);
                    // Adding this control to the Panel control, panelSeats
                    this.panelSeats.Controls.Add(labelSeat);
                    if (splitStrCol == null  || (splitStrCol.Length == 1 && Convert.ToInt32(splitStrCol[0]) == 0))
                    {
                        colDivSpace = 0;
                    }
                    else if (splitStrCol.Length == 1 && j == Convert.ToInt32(splitStrCol[0]))
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
                    labelList.Add(labelSeat);
                };
                if (splitStrRow == null || (splitStrRow.Length == 1 && Convert.ToInt32(splitStrRow[0]) == 0))
                {
                    rowDivSpace = 0;
                }
                else if (splitStrRow.Length == 1 && i == Convert.ToInt32(splitStrRow[0]))
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
            labelMessage.Text = seatList.GetLength().ToString();
            buttonGenerateSeats.Enabled = false;
        }

        private void buttonManualMode_Click(object sender, EventArgs e)
        {
            senderText = "manualMode";
            if (buttonDisableAll.Enabled == false)
            {
                radioButtonDisable.Enabled = true; radioButtonEnable.Enabled = true;
                buttonDisableAll.Enabled = true; buttonEnableAll.Enabled = true;
            }
            else
            {
                radioButtonDisable.Enabled = false; radioButtonEnable.Enabled = false;
                buttonDisableAll.Enabled = false; buttonEnableAll.Enabled = false;
            }
        }

        private bool checkSeatMostLeft(Seat s)
        {
            if (s.Column == 1)
            {
                return true;
            }
            return false;
        }
        private bool checkSeatMostRight(Seat s)
        {
            if (s.Column == inputCol)
            {
                return true;
            }
            return false;
        }
        private void labelSeat_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            //MessageBox.Show(String.Format("Row {0} Column {1}",seatInfo.Row,seatInfo.Column));
            Seat seat = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat seatLeft = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
            Seat seatRight = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);

            void shortCutAssignSurrSeat(String person) //local function
            {
                seat.BelongToPerson = person;
                if (checkSeatMostLeft(seat))
                {
                    seatRight.CanBookedBy = person;
                }
                else if (checkSeatMostRight(seat))
                {
                    seatLeft.CanBookedBy = person;
                }
                else
                {
                    seatLeft.CanBookedBy = person; 
                    seatRight.CanBookedBy = person;
                }
            }
            void shortCutUnassignSurrSeat(String person)
            {
                if (checkSeatMostLeft(seat))
                {
                    seatRight.CanBookedBy = "";
                    seat.BookStatus = false;
                    seat.BelongToPerson = "";
                    label.BackColor = Color.LightBlue;
                }
                else if (checkSeatMostRight(seat))
                {
                    seatLeft.CanBookedBy = "";
                    seat.BookStatus = false;
                    seat.BelongToPerson = "";
                    label.BackColor = Color.LightBlue;
                }
                else
                {
                    if (seatRight.CanBookedBy == person && seatLeft.BelongToPerson == person)
                    {
                        seatRight.CanBookedBy = "";
                        seat.CanBookedBy = person;
                        seat.BookStatus = false;
                        seat.BelongToPerson = "";
                        label.BackColor = Color.LightBlue;
                    }
                    else if (seatLeft.CanBookedBy == person && seatRight.BelongToPerson == person)
                    {
                        seatLeft.CanBookedBy = "";
                        seat.CanBookedBy = person;
                        seat.BookStatus = false;
                        seat.BelongToPerson = "";
                        label.BackColor = Color.LightBlue;
                    }
                }
                numSeatsSelected--;
            }

            if (senderText == "manualMode") //for enable or disable seats manually
            {
                if (radioButtonChecked == "e")
                {
                    seat.CanBook = true;
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                }
                else if (radioButtonChecked == "d")
                {
                    seat.CanBook = false;
                    label.BackColor = Color.IndianRed;
                }
            }//End of manualMode setting
            if (numSeatsSelected == 0) //for the first value
            {
                if (seat.BookStatus == false && seat.CanBook == true) //selecting an unselected seat 
                {
                    if (senderText == "Person A Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.CornflowerBlue;
                        shortCutAssignSurrSeat("A");
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person B Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.SandyBrown;
                        shortCutAssignSurrSeat("B");
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person C Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.LightPink;
                        shortCutAssignSurrSeat("C");
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person D Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.DarkKhaki;
                        shortCutAssignSurrSeat("D");
                        numSeatsSelected++;
                    }
                }//End of selecting the first seat
            }
            else if (numSeatsSelected == 1 && seat.BookStatus == true && seat.CanBook == true)//unselecting the first selected seat
            {
                if (senderText == "Person A Booking" && seat.BelongToPerson == "A")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat("");
                    numSeatsSelected--;
                }
                else if (senderText == "Person B Booking" && seat.BelongToPerson == "B")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat("");
                    numSeatsSelected--;
                }
                else if (senderText == "Person C Booking" && seat.BelongToPerson == "C")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat("");
                    numSeatsSelected--;
                }
                else if (senderText == "Person D Booking" && seat.BelongToPerson == "D")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat("");
                    numSeatsSelected--;
                }
            }
            else //(numSeatsSelected > 1) selecting the next seats
            {
                if (seat.BookStatus == false && seat.CanBook == true)
                {
                    if (senderText == "Person A Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "A")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.CornflowerBlue;
                        shortCutAssignSurrSeat("A");
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person B Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "B")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.SandyBrown;
                        shortCutAssignSurrSeat("B");
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person C Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "C")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.LightPink;
                        shortCutAssignSurrSeat("C");
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person D Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "D")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.DarkKhaki;
                        shortCutAssignSurrSeat("D");
                        numSeatsSelected++;
                    }

                }
                else if (seat.BookStatus == true && seat.CanBook == true) //unclick //seat.BookStatus == true
                {
                    if (senderText == "Person A Booking" && seat.BelongToPerson == "A" && 
                        (seatRight.BelongToPerson != "A" || seatLeft.BelongToPerson != "A"))
                    {
                        shortCutUnassignSurrSeat("A");
                    }
                    else if (senderText == "Person B Booking" && seat.BelongToPerson == "B" &&
                        (seatRight.BelongToPerson != "B" || seatLeft.BelongToPerson != "B"))
                    {
                        shortCutUnassignSurrSeat("B");
                    }
                    else if (senderText == "Person C Booking" && seat.BelongToPerson == "C" &&
                        (seatRight.BelongToPerson != "C" || seatLeft.BelongToPerson != "C"))
                    {
                        shortCutUnassignSurrSeat("C");
                    }
                    else if (senderText == "Person D Booking" && seat.BelongToPerson == "D" &&
                        (seatRight.BelongToPerson != "D" || seatLeft.BelongToPerson != "D"))
                    {
                        shortCutUnassignSurrSeat("D");
                    }
                }
            }
        }

        private void buttonPersonA_Click(object sender, EventArgs e)
        {
            manualEditor.Enabled = false;
            if (senderText == ""){ senderText = "Person A Booking"; /*by default all enabled*/}
            else if (senderText == "manualMode") { senderText = "Person A Booking"; }
            else if (senderText == "Person B Booking") { buttonPersonB.Enabled = false; }
            else if (senderText == "Person C Booking") { buttonPersonC.Enabled = false; }
            else if (senderText == "Person D Booking") { buttonPersonD.Enabled = false; }
            senderText = (sender as Button).Text;
            numSeatsSelected = 0;
        }
        private void buttonPersonB_Click(object sender, EventArgs e)
        {
            manualEditor.Enabled = false;
            if (senderText == "") { senderText = "Person B Booking"; }
            else if (senderText == "manualMode") { senderText = "Person B Booking"; }
            else if (senderText == "Person A Booking") { buttonPersonA.Enabled = false; }
            else if (senderText == "Person C Booking") { buttonPersonC.Enabled = false; }
            else if (senderText == "Person D Booking") { buttonPersonD.Enabled = false; }
            senderText = (sender as Button).Text;
            numSeatsSelected = 0;
        }
        private void buttonPersonC_Click(object sender, EventArgs e)
        {
            manualEditor.Enabled = false;
            if (senderText == "") { senderText = "Person C Booking"; }
            else if (senderText == "manualMode") { senderText = "Person C Booking"; }
            else if (senderText == "Person A Booking") { buttonPersonA.Enabled = false; }
            else if (senderText == "Person B Booking") { buttonPersonB.Enabled = false; }
            else if (senderText == "Person D Booking") { buttonPersonD.Enabled = false; }
            senderText = (sender as Button).Text;
            numSeatsSelected = 0;
        }
        private void buttonPersonD_Click(object sender, EventArgs e)
        {
            manualEditor.Enabled = false;
            if (senderText == "") { senderText = "Person D Booking"; }
            else if (senderText == "manualMode") { senderText = "Person D Booking"; }
            else if (senderText == "Person A Booking") { buttonPersonA.Enabled = false; }
            else if (senderText == "Person C Booking") { buttonPersonC.Enabled = false; }
            else if (senderText == "Person B Booking") { buttonPersonB.Enabled = false; }
            senderText = (sender as Button).Text;
            numSeatsSelected = 0;
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
        }//End of buttonLoad_Click
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
                    panelSeats.Controls.Clear();

                    List<Label> labelListSD = seatList.GenerateLabels();

                    foreach (Label label in labelListSD)
                    {
                        {
                            label.Click += new System.EventHandler(labelSeat_Click);
                            panelSeats.Controls.Add(label);
                        }
                    }
                    resetState();
                }
                stream.Close();
            }
        }//End of buttonLoad_Click
        private void resetState()
        {
            buttonGenerateSeats.Enabled = false;
            buttonPersonA.Enabled = true;
            buttonPersonB.Enabled = true;
            buttonPersonC.Enabled = true;
            buttonPersonD.Enabled = true;

            if (seatList.ExistSeatBelongToPerson("A"))
            {
                buttonPersonA.Enabled = false;
            }
            if (seatList.ExistSeatBelongToPerson("B"))
            {
                buttonPersonB.Enabled = false;
            }
            if (seatList.ExistSeatBelongToPerson("C"))
            {
                buttonPersonC.Enabled = false;
            }
            if (seatList.ExistSeatBelongToPerson("D"))
            {
                buttonPersonD.Enabled = false;
            }
        }

        private void buttonEndSimulation_Click(object sender, EventArgs e)
        {
            manualEditor.Enabled = false;
            buttonPersonA.Enabled = false;
            buttonPersonB.Enabled = false;
            buttonPersonC.Enabled = false;
            buttonPersonD.Enabled = false;
        }
        private void buttonResetSimulation_Click(object sender, EventArgs e)
        {
            seatList.SetCanBook(false);
            foreach (Label labelS in labelList)
            {
                labelS.BackColor = Color.IndianRed;
            }
            manualEditor.Enabled = true;
            buttonPersonA.Enabled = true;
            buttonPersonB.Enabled = true;
            buttonPersonC.Enabled = true; 
            buttonPersonD.Enabled = true; 
        }

        private void radButtonType_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Radio button is clicked. The radio button text is " + ((RadioButton)sender).Text);
            RadioButton radioButtonSelectedType = (RadioButton)sender;
            if (radioButtonSelectedType.Text == "Enable")
            {
                radioButtonChecked = "e";
            }
            else if (radioButtonSelectedType.Text == "Disable")
            {
                radioButtonChecked = "d";
            }
        }

        private void buttonEnableAll_Click(object sender, EventArgs e)
        {
            seatList.SetCanBook(true);
            foreach (Label labelS in labelList)
            {
                labelS.BackColor = Color.LightBlue;
            }
            manualEditor.Enabled = true;
        }
        private void buttonDisableAll_Click(object sender, EventArgs e)
        {
            seatList.SetCanBook(false);
            foreach (Label labelS in labelList)
            {
                labelS.BackColor = Color.IndianRed;
            }
            manualEditor.Enabled = true;
        }
    }//End of Form1 class
 }//End of namespace
