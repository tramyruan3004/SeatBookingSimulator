using SeatBookingSimulator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace SeatBookingSimulator
{
    public partial class SafeDistancingAndSmartModeForm : Form
    {
        SeatDoubleLinkedList seatListSDSM = new SeatDoubleLinkedList();
        double inputRow = 0;
        double inputCol = 0;
        string senderText = "";
        int numSeatsSelected = 0;
        string radioButtonChecked = "";
        int colDiv;
        int rowDiv;
        List<Label> labelListSDSM = new List<Label>();
        public SafeDistancingAndSmartModeForm()
        {
            InitializeComponent();
        }
        private void SafeDistancingAndSmartModeForm_Load(object sender, EventArgs e)
        {
            this.radioButtonDisable.Click += new System.EventHandler(this.radButtonType_Click);
            this.radioButtonEnable.Click += new System.EventHandler(this.radButtonType_Click);
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
                    f.Serialize(stream, seatListSDSM);
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
                    seatListSDSM = (SeatDoubleLinkedList)f.Deserialize(stream);
                    
                }
                stream.Close();
                panelSeats.Controls.Clear();

                List<Label> labelList = seatListSDSM.GenerateLabels();

                foreach (Label label in labelList)
                {
                    {
                        label.Click += new System.EventHandler(labelSeat_Click);
                        panelSeats.Controls.Add(label);
                    }
                }
                resetState();
            }
        }//End of buttonLoad_Click
        private void resetState()
        {
            buttonGenerateSeats.Enabled = false;
            buttonPersonA.Enabled = true;
            buttonPersonB.Enabled = true;
            buttonPersonC.Enabled = true;
            buttonPersonD.Enabled = true;

            if (seatListSDSM.ExistSeatBelongToPerson("A"))
            {
                buttonPersonA.Enabled = false;
            }
            if (seatListSDSM.ExistSeatBelongToPerson("B"))
            {
                buttonPersonB.Enabled = false;
            }
            if (seatListSDSM.ExistSeatBelongToPerson("C"))
            {
                buttonPersonC.Enabled = false;
            }
            if (seatListSDSM.ExistSeatBelongToPerson("D"))
            {
                buttonPersonD.Enabled = false;
            }
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
        private void calculateDividers()
        {
            colDiv = (int) (double.Parse(textBoxSeatPerRow.Text) /2);
            rowDiv = (int)(double.Parse(textBoxNumOfRow.Text) / 2);
        }
        private void buttonGenerateSeats_Click(object sender, EventArgs e)
        {
            panelSeats.Controls.Clear();
            calculateDividers();
            Seat s;
            int colDivSpace = 0;
            int rowDivSpace = 0;
            for (int i = 1; i <= inputRow; i++)
            {
                colDivSpace = 0;
                for (int j = 1; j <= inputCol; j++)
                {
                    s = new Seat();
                    s.Row = i; s.Column = j; s.ColDivSpace = colDivSpace; s.RowDivSpace = rowDivSpace; s.SmartMode = true;
                    seatListSDSM.InsertAtEnd(s);
                    Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
                    labelSeat.Text = s.ComputeSeatLabel();//Set the Text property by using a string
                    labelSeat.Location = new Point((60 * (s.Column - 1)) + 60 + (20 * (s.Column - 1)) 
                        + colDivSpace, (60 * (s.Row - 1)) + 60 + (20 * (s.Row - 1)) + rowDivSpace);//Create a Point type object which has x,y coordinate info
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
                    if (colDiv == 0) {colDivSpace = 0;}
                    else if (j == colDiv) {colDivSpace = 50;}
                    labelListSDSM.Add(labelSeat);
                }
                if (rowDiv == 0) {rowDivSpace = 0;}
                else if ( i == rowDiv){rowDivSpace = 50;}
            }
            labelMessage.Text = seatListSDSM.GetLength().ToString();
            buttonGenerateSeats.Enabled = false;
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
            Seat seat = seatListSDSM.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat seatLeft = seatListSDSM.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
            Seat seatRight = seatListSDSM.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
            Seat seatFront = seatListSDSM.SearchByRowAndColumn(seatInfo.Row - 1, seatInfo.Column);
            Seat seatBack = seatListSDSM.SearchByRowAndColumn(seatInfo.Row + 1, seatInfo.Column);
            void changeColorSeatAccToInd(Seat pSeat)
            {
                if (pSeat.BelongToPerson == "" &&
                    labelListSDSM[seatListSDSM.ReturnIndNumInLabelList(pSeat)].BackColor != Color.IndianRed)
                {
                    labelListSDSM[seatListSDSM.ReturnIndNumInLabelList(pSeat)].BackColor = Color.LightYellow;
                }
            }
            void changeBackColorSeatAccToInd(Seat pSeat)
            {
                if (pSeat.BelongToPerson == "" && 
                    labelListSDSM[seatListSDSM.ReturnIndNumInLabelList(pSeat)].BackColor != Color.IndianRed)
                {
                    labelListSDSM[seatListSDSM.ReturnIndNumInLabelList(pSeat)].BackColor = Color.LightBlue;
                }
            }
            void shortCutAssignSurrSeat(String person) //local function
            {
                if (checkSeatMostLeft(seat))
                {
                    if (seatBack == null) { seatFront.CanBookedBy = person; changeColorSeatAccToInd(seatFront); }
                    else if (seatFront == null) { seatBack.CanBookedBy = person; changeColorSeatAccToInd(seatBack); }
                    else { seatFront.CanBookedBy = person; seatBack.CanBookedBy = person;
                        changeColorSeatAccToInd(seatFront); changeColorSeatAccToInd(seatBack);}
                    seatRight.CanBookedBy = person;
                    changeColorSeatAccToInd(seatRight);
                }
                else if (checkSeatMostRight(seat))
                {
                    if (seatBack == null) { seatFront.CanBookedBy = person; changeColorSeatAccToInd(seatFront); }
                    else if (seatFront == null) { seatBack.CanBookedBy = person; changeColorSeatAccToInd(seatBack); }
                    else{seatFront.CanBookedBy = person; seatBack.CanBookedBy = person;
                        changeColorSeatAccToInd(seatFront); changeColorSeatAccToInd(seatBack);}
                    seatLeft.CanBookedBy = person;
                    changeColorSeatAccToInd(seatLeft);
                }
                else
                {
                    if (seatBack == null) { seatFront.CanBookedBy = person; changeColorSeatAccToInd(seatFront); }
                    else if (seatFront == null) { seatBack.CanBookedBy = person; changeColorSeatAccToInd(seatBack); }
                    else {seatFront.CanBookedBy = person; seatBack.CanBookedBy = person;
                        changeColorSeatAccToInd(seatFront); changeColorSeatAccToInd(seatBack);}
                    seatLeft.CanBookedBy = person; changeColorSeatAccToInd(seatLeft);
                    seatRight.CanBookedBy = person; changeColorSeatAccToInd(seatRight);
                }
                seat.BelongToPerson = person;
            }
            void shortCutUnassignSurrSeat(String person)
            {
                if (checkSeatMostLeft(seat))
                {
                    if (seatBack == null) { seatFront.CanBookedBy = ""; changeBackColorSeatAccToInd(seatFront); }
                    else if (seatFront == null) { seatBack.CanBookedBy = ""; changeBackColorSeatAccToInd(seatBack); }
                    else {seatFront.CanBookedBy = ""; seatBack.CanBookedBy = "";
                        changeBackColorSeatAccToInd(seatFront); changeBackColorSeatAccToInd(seatBack);}
                    seatRight.CanBookedBy = ""; changeBackColorSeatAccToInd(seatRight);
                    seat.BookStatus = false;
                    seat.BelongToPerson = "";
                    label.BackColor = Color.LightBlue;
                }
                else if (checkSeatMostRight(seat))
                {
                    if (seatBack == null) { seatFront.CanBookedBy = ""; changeBackColorSeatAccToInd(seatFront); }
                    else if (seatFront == null) { seatBack.CanBookedBy = ""; changeBackColorSeatAccToInd(seatBack); }
                    else {seatFront.CanBookedBy = ""; seatBack.CanBookedBy = "";
                        changeBackColorSeatAccToInd(seatFront); changeBackColorSeatAccToInd(seatBack);}
                    seatLeft.CanBookedBy = ""; changeBackColorSeatAccToInd(seatLeft);
                    seat.BookStatus = false;
                    seat.BelongToPerson = "";
                    label.BackColor = Color.LightBlue;
                }
                else
                {
                    if (seatRight.CanBookedBy == person && seatLeft.BelongToPerson == person)
                    {
                        if (seatBack == null) { seatFront.CanBookedBy = ""; changeBackColorSeatAccToInd(seatFront); }
                        else if (seatFront == null) { seatBack.CanBookedBy = ""; changeBackColorSeatAccToInd(seatBack); }
                        else {seatFront.CanBookedBy = ""; seatBack.CanBookedBy = "";
                            changeBackColorSeatAccToInd(seatFront); changeBackColorSeatAccToInd(seatBack);}
                        seatRight.CanBookedBy = ""; changeBackColorSeatAccToInd(seatRight);
                        seat.CanBookedBy = person;
                        seat.BookStatus = false;
                        seat.BelongToPerson = "";
                        label.BackColor = Color.LightYellow;
                    }
                    else if (seatLeft.CanBookedBy == person && seatRight.BelongToPerson == person)
                    {
                        if (seatBack == null) { seatFront.CanBookedBy = ""; changeBackColorSeatAccToInd(seatFront); }
                        else if (seatFront == null) { seatBack.CanBookedBy = ""; changeBackColorSeatAccToInd(seatBack); }
                        else {seatFront.CanBookedBy = ""; seatBack.CanBookedBy = "";
                            changeBackColorSeatAccToInd(seatFront); changeBackColorSeatAccToInd(seatBack);}
                        seatLeft.CanBookedBy = ""; changeBackColorSeatAccToInd(seatLeft);
                        seat.CanBookedBy = person; 
                        seat.BookStatus = false;
                        seat.BelongToPerson = "";
                        label.BackColor = Color.LightYellow;
                    }
                }
                numSeatsSelected--;
            }//End of method shortCutUnassignSurrSeat
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
                if (seat.BookStatus == false && seat.CanBook == true) //seat wasnt selected 
                {
                    if (senderText == "Person A Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.CornflowerBlue;
                        shortCutAssignSurrSeat("A"); //function runs if else statements
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person B Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        label.BackColor = Color.SandyBrown;
                        seat.BookStatus = true;
                        shortCutAssignSurrSeat("B"); //function runs if else statements
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person C Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        label.BackColor = Color.LightPink;
                        seat.BookStatus = true;
                        shortCutAssignSurrSeat("C"); //function runs if else statements
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person D Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.DarkKhaki;
                        shortCutAssignSurrSeat("D"); //function runs if else statements
                        numSeatsSelected++;
                    }
                }
            }
            else if (numSeatsSelected == 1 && seat.BookStatus == true && seat.CanBook == true) //seat was selected and want to unclick
            {
                if (senderText == "Person A Booking" && seat.BelongToPerson == "A")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat(""); //function runs if else statements
                    numSeatsSelected--;
                }
                else if (senderText == "Person B Booking" && seat.BelongToPerson == "B")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat(""); //function runs if else statements
                    numSeatsSelected--;
                }
                else if (senderText == "Person C Booking" && seat.BelongToPerson == "C")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat(""); //function runs if else statements
                    numSeatsSelected--;
                }
                else if (senderText == "Person D Booking" && seat.BelongToPerson == "D")
                {
                    seat.BookStatus = false;
                    label.BackColor = Color.LightBlue;
                    shortCutAssignSurrSeat(""); //function runs if else statements
                    numSeatsSelected--;
                }
            }
            else //numSeatsSelected > 1
            {
                if (seat.BookStatus == false && seat.CanBook == true) //for other seats to select unselected seats
                {
                    if (senderText == "Person A Booking" && seat.BelongToPerson == "" && seat.CanBookedBy == "A")
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.CornflowerBlue;
                        shortCutAssignSurrSeat("A"); //function runs if else statements
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person B Booking" && seat.BelongToPerson == "" && (seat.CanBookedBy == "B"))
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.SandyBrown;
                        shortCutAssignSurrSeat("B"); //function runs if else statements
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person C Booking" && seat.BelongToPerson == "" && (seat.CanBookedBy == "C"))
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.LightPink;
                        shortCutAssignSurrSeat("C"); //function runs if else statements
                        numSeatsSelected++;
                    }
                    else if (senderText == "Person D Booking" && seat.BelongToPerson == "" && (seat.CanBookedBy == "D"))
                    {
                        seat.BookStatus = true;
                        label.BackColor = Color.DarkKhaki;
                        shortCutAssignSurrSeat("D"); //function runs if else statements
                        numSeatsSelected++;
                    }
                }
                else if (seat.BookStatus == true && seat.CanBook == true) //(seat.BookStatus == true) unclicking selected seats
                {
                    if (senderText == "Person A Booking" && seat.BelongToPerson == "A" &&
                        (seatRight.BelongToPerson != "A" || seatLeft.BelongToPerson != "A") && 
                        (seatFront.BelongToPerson != "A" || seatBack.BelongToPerson != "A"))
                    {
                        shortCutUnassignSurrSeat("A");
                    }
                    else if (senderText == "Person B Booking" && seat.BelongToPerson == "B" &&
                        (seatRight.BelongToPerson != "B" || seatLeft.BelongToPerson != "B") &&
                        (seatFront.BelongToPerson != "B" || seatBack.BelongToPerson != "B"))
                    {
                        shortCutUnassignSurrSeat("B");
                    }
                    else if (senderText == "Person C Booking" && seat.BelongToPerson == "C" &&
                        (seatRight.BelongToPerson != "C" || seatLeft.BelongToPerson != "C") &&
                        (seatFront.BelongToPerson != "C" || seatBack.BelongToPerson != "C"))
                    {
                        shortCutUnassignSurrSeat("C");
                    }
                    else if (senderText == "Person D Booking" && seat.BelongToPerson == "D" &&
                        (seatRight.BelongToPerson != "D" || seatLeft.BelongToPerson != "D") &&
                        (seatFront.BelongToPerson != "D" || seatBack.BelongToPerson != "D"))
                    {
                        shortCutUnassignSurrSeat("D");
                    }
                }
            }
        }
        private void turnSeatToRed()
        {
            Node p = seatListSDSM.Start;
            while (p.Next != null)
            {
                if (p.Seat.CanBookedBy != "" && p.Seat.BelongToPerson == "")
                {
                    p.Seat.CanBook = false;
                }
                p = p.Next;
            }
        }
        private void buttonPersonA_Click(object sender, EventArgs e)
        {
            manualEditor.Enabled = false;
            turnSeatToRed();
            foreach (Label l in labelListSDSM)
            {
                if (l.BackColor == Color.LightYellow)
                {
                    l.BackColor = Color.IndianRed;
                }
            }
            if (senderText == "") { senderText = "Person A Booking"; /*by default all enabled*/}
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
            turnSeatToRed();
            foreach (Label l in labelListSDSM)
            {
                if (l.BackColor == Color.LightYellow)
                {
                    l.BackColor = Color.IndianRed;
                }
            }
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
            turnSeatToRed();
            foreach (Label l in labelListSDSM)
            {
                if (l.BackColor == Color.LightYellow)
                {
                    l.BackColor = Color.IndianRed;
                }
            }
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
            turnSeatToRed();
            foreach (Label l in labelListSDSM)
            {
                if (l.BackColor == Color.LightYellow)
                {
                    l.BackColor = Color.IndianRed;
                }
            }
            if (senderText == "") { senderText = "Person D Booking"; }
            else if (senderText == "manualMode") { senderText = "Person D Booking"; }
            else if (senderText == "Person A Booking") { buttonPersonA.Enabled = false; }
            else if (senderText == "Person C Booking") { buttonPersonC.Enabled = false; }
            else if (senderText == "Person B Booking") { buttonPersonB.Enabled = false; }
            senderText = (sender as Button).Text;
            numSeatsSelected = 0;
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
            seatListSDSM.SetCanBook(false);
            foreach (Label labelS in labelListSDSM)
            {
                labelS.BackColor = Color.IndianRed;
            }
            manualEditor.Enabled = true;
            buttonPersonA.Enabled = true;
            buttonPersonB.Enabled = true;
            buttonPersonC.Enabled = true;
            buttonPersonD.Enabled = true;
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

        private void buttonEnableAll_Click(object sender, EventArgs e)
        {
            seatListSDSM.SetCanBook(true);
            foreach (Label labelS in labelListSDSM)
            {
                labelS.BackColor = Color.LightBlue;
            }
            manualEditor.Enabled = true;
        }
        private void buttonDisableAll_Click(object sender, EventArgs e)
        {
            seatListSDSM.SetCanBook(false);
            foreach (Label labelS in labelListSDSM)
            {
                labelS.BackColor = Color.IndianRed;
            }
            manualEditor.Enabled = true;
        }
    }
}
