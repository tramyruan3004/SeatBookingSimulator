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
    public partial class NormalMode : Form
    {
        SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();
        public NormalMode()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            /*
          Seat s = new Seat();  s.Row = 1;   s.Column = 1;
            seatList.InsertAtEnd(s);
            s = new Seat(); s.Row = 1; s.Column = 2;
            seatList.InsertAtEnd(s);
            s = new Seat(); s.Row = 1;  s.Column = 3;
            seatList.InsertAtEnd(s);
            labelMessage.Text = "Double Linked List has been built";
            

            Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
            labelSeat.Text = "A1";//Set the Text property by using a string
            labelSeat.Location = new Point(50, 50);//Create a Point type object which has x,y coordinate info
            labelSeat.Size = new Size(60,60);//Create a Size type object which has the width, height info
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;//Align the Text to mid - center
            labelSeat.BorderStyle = BorderStyle.FixedSingle;//Make the border visible
            labelSeat.BackColor = Color.LightBlue;//Set the background color
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = 1, Column = 1 };
            // Adding this control to the Panel control, panelSeats
            this.panelSeats.Controls.Add(labelSeat);
            */
        }//End of Form1_Load


        private void buttonGenerateSeats_Click(object sender, EventArgs e)
        {
            Seat s;
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 11; j++)
                {
                    s = new Seat();
                    s.Row = i; s.Column = j;
                    seatList.InsertAtEnd(s);
                    Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
                    labelSeat.Text = s.ComputeSeatLabel();//Set the Text property by using a string
                    labelSeat.Location = new Point((60 * (s.Column - 1)) + 60 + (20 * (s.Column - 1)), (60 * (s.Row - 1)) + 60 + (20 * (s.Row - 1)));//Create a Point type object which has x,y coordinate info
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
                };
            };
        }
        private void labelSeat_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            //MessageBox.Show(String.Format("Row {0} Column {1}",seatInfo.Row,seatInfo.Column));
            Seat seat =  seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            Seat seatLeft = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
            Seat seatRight = seatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);

            if (seat.BookStatus == false)
            {
                seat.BookStatus = true;
                label.BackColor = Color.LightGreen;
            }
            else
            {
                seat.BookStatus = false;
                label.BackColor = Color.LightBlue;
            }

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

    }//End of Form1 class


    }//End of namespace
