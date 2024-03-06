using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _6_Test
{
    public partial class Form1 : Form
    {
        private DateTime connectionStartTime; // Bağlantı başlangıç zamanı
        List<PointPairList> graphDataLists = new List<PointPairList>();
        List<TestData> receivedDataList = new List<TestData>();
        GraphPane myPane = new GraphPane();
        LineItem myCurve;
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000; // 1 saniyede bir güncelleme yap
        }

        private void zedGraphControl3_Load(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = comboBoxPort.SelectedItem.ToString();
                    serialPort1.Open();
                    connectionStartTime = DateTime.Now; // Bağlantı başlangıç zamanını kaydet
                    timer1.Start();
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - connectionStartTime; // Geçen süreyi hesapla
            label1Zaman.Text = elapsedTime.ToString(@"hh\:mm\:ss"); // Label'a yazdır
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    timer1.Stop();
                    buttonConnect.Enabled = true;
                    buttonDisconnect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı kesme hatası: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            foreach (String port in ports)
            {
                comboBoxPort.Items.Add(port);
            }
            if (!serialPort1.IsOpen)
            {
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                
            }
            GraphPane graphPane1 = zedGraphControl1.GraphPane;
            graphPane1.Title.Text = "Isı Grafik Testi 1";
            graphPane1.XAxis.Scale.Min = 0; // Minimum değer
            graphPane1.YAxis.Scale.Min = 0; // Minimum değer
            graphPane1.XAxis.Title.Text = "Zaman(sn)";
            graphPane1.XAxis.Scale.MajorStep = 5;
            graphPane1.YAxis.Title.Text = "Değer(Güç & Watt)";
            graphPane1.YAxis.Scale.MajorStep = 5;
            GraphPane graphPane2 = zedGraphControl2.GraphPane;
            graphPane2.Title.Text = "Isı Grafik Testi 2";
            graphPane2.XAxis.Scale.Min = 0;
            graphPane2.YAxis.Scale.Min = 0;
            graphPane2.XAxis.Scale.MajorStep = 5;
            graphPane2.YAxis.Scale.MajorStep = 5;
            graphPane2.XAxis.Title.Text = "Zaman(sn)";
            graphPane2.YAxis.Title.Text = "Değer(Güç & Watt)";
            GraphPane graphPane3 = zedGraphControl3.GraphPane;
            graphPane3.Title.Text = "Isı Grafik Testi 3";
            graphPane3.XAxis.Scale.Min = 0;
            graphPane3.YAxis.Scale.Min = 0;
            graphPane3.XAxis.Scale.MajorStep = 5;
            graphPane3.YAxis.Scale.MajorStep = 5;
            graphPane3.XAxis.Title.Text = "Zaman(sn)";
            graphPane3.YAxis.Title.Text = "Değer(Güç & Watt)";
            GraphPane graphPane4 = zedGraphControl4.GraphPane;
            graphPane4.Title.Text = "Isı Grafik Testi 4";
            graphPane4.XAxis.Scale.Min = 0;
            graphPane4.YAxis.Scale.Min = 0;
            graphPane4.XAxis.Scale.MajorStep = 5;
            graphPane4.YAxis.Scale.MajorStep = 5;
            graphPane4.XAxis.Title.Text = "Zaman(sn)";
            graphPane4.YAxis.Title.Text = "Değer(Güç & Watt)";
            GraphPane graphPane5 = zedGraphControl5.GraphPane;
            graphPane5.Title.Text = "Isı Grafik Testi 5";
            graphPane5.XAxis.Scale.Min = 0;
            graphPane5.YAxis.Scale.Min = 0;
            graphPane5.XAxis.Scale.MajorStep = 5;
            graphPane5.YAxis.Scale.MajorStep = 5;
            graphPane5.XAxis.Title.Text = "Zaman(sn)";
            graphPane5.YAxis.Title.Text = "Değer(Güç & Watt)";
            GraphPane graphPane6 = zedGraphControl6.GraphPane; ;
            graphPane6.Title.Text = "Isı Grafik Testi 6";
            graphPane6.XAxis.Scale.Min = 0;
            graphPane6.YAxis.Scale.Min = 0;
            graphPane6.XAxis.Scale.MajorStep = 5;
            graphPane6.YAxis.Scale.MajorStep = 5;
            graphPane6.XAxis.Title.Text = "Zaman(sn)";
            graphPane6.YAxis.Title.Text = "Değer(Güç & Watt)";

            LineItem curve1 = graphPane1.AddCurve("NTC 1", null , null , Color.Blue, SymbolType.None);
            LineItem curve2 = graphPane1.AddCurve("NTC 2", null , null, Color.Red, SymbolType.None);
            LineItem curve3 = graphPane1.AddCurve("NTC 3", null, null , Color.Green, SymbolType.None);
            LineItem curve4 = graphPane1.AddCurve("NTC 4", null , null, Color.Yellow, SymbolType.None);
            LineItem curve5 = graphPane1.AddCurve("NTC 5", null, null, Color.GreenYellow, SymbolType.None);
            LineItem curve6 = graphPane1.AddCurve("NTC 6", null, null, Color.DarkBlue, SymbolType.None);
            LineItem curve7 = graphPane1.AddCurve("GÜÇ ", null, null, Color.Black, SymbolType.None);
            LineItem curve8 = graphPane1.AddCurve("VOLTAJ ", null, null, Color.Brown, SymbolType.None);

            LineItem curve9 = graphPane2.AddCurve("NTC 1", null, null, Color.Blue, SymbolType.None);
            LineItem curve10 = graphPane2.AddCurve("NTC 2", null, null, Color.Red, SymbolType.None);
            LineItem curve11 = graphPane2.AddCurve("NTC 3", null, null, Color.Green, SymbolType.None);
            LineItem curve12 = graphPane2.AddCurve("NTC 4", null, null, Color.Yellow, SymbolType.None);
            LineItem curve13 = graphPane2.AddCurve("NTC 5", null, null, Color.GreenYellow, SymbolType.None);
            LineItem curve14 = graphPane2.AddCurve("NTC 6", null, null, Color.DarkBlue, SymbolType.None);
            LineItem curve15 = graphPane2.AddCurve("GÜÇ", null, null, Color.Black, SymbolType.None);
            LineItem curve16 = graphPane2.AddCurve("VOLTAJ", null, null, Color.Brown, SymbolType.None);

            LineItem curve17 = graphPane3.AddCurve("NTC 1", null, null, Color.Blue, SymbolType.None);
            LineItem curve18 = graphPane3.AddCurve("NTC 2", null, null, Color.Red, SymbolType.None);
            LineItem curve19 = graphPane3.AddCurve("NTC 3", null, null, Color.Green, SymbolType.None);
            LineItem curve20 = graphPane3.AddCurve("NTC 4", null, null, Color.Yellow, SymbolType.None);
            LineItem curve21 = graphPane3.AddCurve("NTC 5", null, null, Color.GreenYellow, SymbolType.None);
            LineItem curve22 = graphPane3.AddCurve("NTC 6", null, null, Color.DarkBlue, SymbolType.None);
            LineItem curve23 = graphPane3.AddCurve("GÜÇ", null, null, Color.Black, SymbolType.None);
            LineItem curve24 = graphPane3.AddCurve("VOLTAJ", null, null, Color.Brown, SymbolType.None);

            LineItem curve25 = graphPane4.AddCurve("NTC 1", null, null, Color.Blue, SymbolType.None);
            LineItem curve26 = graphPane4.AddCurve("NTC 2", null, null, Color.Red, SymbolType.None);
            LineItem curve27 = graphPane4.AddCurve("NTC 3", null, null, Color.Green, SymbolType.None);
            LineItem curve28 = graphPane4.AddCurve("NTC 4", null, null, Color.Yellow, SymbolType.None);
            LineItem curve29 = graphPane4.AddCurve("NTC 5", null, null, Color.GreenYellow, SymbolType.None);
            LineItem curve30 = graphPane4.AddCurve("NTC 6", null, null, Color.DarkBlue, SymbolType.None);
            LineItem curve31 = graphPane4.AddCurve("GÜÇ", null, null, Color.Black, SymbolType.None);
            LineItem curve32 = graphPane4.AddCurve("VOLTAJ", null, null, Color.Brown, SymbolType.None);

            LineItem curve33 = graphPane5.AddCurve("NTC 1", null, null, Color.Blue, SymbolType.None);
            LineItem curve34 = graphPane5.AddCurve("NTC 2", null, null, Color.Red, SymbolType.None);
            LineItem curve35 = graphPane5.AddCurve("NTC 3", null, null, Color.Green, SymbolType.None);
            LineItem curve36 = graphPane5.AddCurve("NTC 4", null, null, Color.Yellow, SymbolType.None);
            LineItem curve37 = graphPane5.AddCurve("NTC 5", null, null, Color.GreenYellow, SymbolType.None);
            LineItem curve38 = graphPane5.AddCurve("NTC 6", null, null, Color.DarkBlue, SymbolType.None);
            LineItem curve39 = graphPane5.AddCurve("GÜÇ", null, null, Color.Black, SymbolType.None);
            LineItem curve40 = graphPane5.AddCurve("VOLTAJ", null, null, Color.Brown, SymbolType.None);

            LineItem curve41 = graphPane6.AddCurve("NTC 1", null, null, Color.Blue, SymbolType.None);
            LineItem curve42 = graphPane6.AddCurve("NTC 2", null, null, Color.Red, SymbolType.None);
            LineItem curve43 = graphPane6.AddCurve("NTC 3", null, null, Color.Green, SymbolType.None);
            LineItem curve44 = graphPane6.AddCurve("NTC 4", null, null, Color.Yellow, SymbolType.None);
            LineItem curve45 = graphPane6.AddCurve("NTC 5", null, null, Color.GreenYellow, SymbolType.None);
            LineItem curve46 = graphPane6.AddCurve("NTC 6", null, null, Color.DarkBlue, SymbolType.None);
            LineItem curve47 = graphPane6.AddCurve("GÜÇ", null, null, Color.Black, SymbolType.None);
            LineItem curve48 = graphPane6.AddCurve("VOLTAJ", null, null, Color.Brown, SymbolType.None);

            zedGraphControl1.Invalidate();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            zedGraphControl2.Invalidate();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();
            zedGraphControl3.Invalidate();
            zedGraphControl3.AxisChange();
            zedGraphControl3.Refresh();
            zedGraphControl4.Invalidate();
            zedGraphControl4.AxisChange();
            zedGraphControl4.Refresh();
            zedGraphControl5.Invalidate();
            zedGraphControl5.AxisChange();
            zedGraphControl5.Refresh();
            zedGraphControl6.Invalidate();
            zedGraphControl6.AxisChange();
            zedGraphControl6.Refresh();

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string receivedData = serialPort1.ReadLine(); // Seri porttan gelen veriyi oku
                                                              // Gelen veriyi ayrıştır ve TestData nesnesine ekle
                TestData newData = ParseData(receivedData);
                receivedDataList.Add(newData);
                // Veriyi grafiklere ve textbox'lara aktar
                UpdateGraphsAndTextBoxes(newData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri alma hatası: " + ex.Message);
            }
        }

        private void UpdateGraphsAndTextBoxes(TestData newData)
        {
            // Grafikleri güncelleme işlemi
            // Örneğin, grafik1 için yeni veriyi eklemek
            if (newData != null)
            {
                double x = DateTime.Now.ToOADate();
                // Her bir test için
                for (int i = 0; i < 6; i++)
                {
                    double[] yValues = new double[8]; // Her bir test için bir dizi oluştur

                    // TestData nesnesindeki verilere ulaşmak için reflection kullanarak dinamik olarak özelliklere erişiyoruz.
                    for (int j = 0; j < 8; j++)
                    {
                        string propertyName = "Value" + (i * 8 + j + 1); // Özellik adını oluştur
                        double y = (double)newData.GetType().GetProperty(propertyName).GetValue(newData); // Özelliğin değerini al

                        switch (i)
                        {
                            case 0:
                                AddDataToGraph(zedGraphControl1, x, yValues);
                                break;
                            case 1:
                                AddDataToGraph(zedGraphControl2, x, yValues);
                                break;
                            case 2:
                                AddDataToGraph(zedGraphControl3, x, yValues);
                                break;
                            case 3:
                                AddDataToGraph(zedGraphControl4, x, yValues);
                                break;
                            case 4:
                                AddDataToGraph(zedGraphControl5, x, yValues);
                                break;
                            case 5:
                                AddDataToGraph(zedGraphControl6, x, yValues);
                                break;

                        }

                        // Değerleri diziye ekleme işlemi
                        yValues[j] = y;
                        AddToTextBox(i + 1, j + 1, newData); // TextBox'lara da ekleme işlemi
                    }

                    // Ekleme işlemi
                    AddDataToGraph(zedGraphControl1, x, yValues);
                }
            }
        }

        private void AddToTextBox(int v, int v1, TestData newData)
        {
            if (newData != null)
            textBox1Data1.AppendText(newData.Value1.ToString() + Environment.NewLine); //                 **** 1. Test *****
            textBox1Data2.AppendText(newData.Value2.ToString() + Environment.NewLine);
            textBox1Data3.AppendText(newData.Value3.ToString() + Environment.NewLine);
            textBox1Data4.AppendText(newData.Value4.ToString() + Environment.NewLine);
            textBox1Data5.AppendText(newData.Value5.ToString() + Environment.NewLine);
            textBox1Data6.AppendText(newData.Value6.ToString() + Environment.NewLine);
            textBox1Data7.AppendText(newData.Value7.ToString() + Environment.NewLine);
            textBox1Data8.AppendText(newData.Value8.ToString() + Environment.NewLine);

            textBox2Data1.AppendText(newData.Value9.ToString() + Environment.NewLine); //                 **** 2. Test  ****
            textBox2Data2.AppendText(newData.Value10.ToString() + Environment.NewLine);
            textBox2Data3.AppendText(newData.Value11.ToString() + Environment.NewLine);
            textBox2Data4.AppendText(newData.Value12.ToString() + Environment.NewLine);
            textBox2Data5.AppendText(newData.Value13.ToString() + Environment.NewLine);
            textBox2Data6.AppendText(newData.Value14.ToString() + Environment.NewLine);
            textBox2Data7.AppendText(newData.Value15.ToString() + Environment.NewLine);
            textBox2Data8.AppendText(newData.Value16.ToString() + Environment.NewLine);

            textBox3Data1.AppendText(newData.Value17.ToString() + Environment.NewLine);//                 ***** 3. Test *****
            textBox3Data2.AppendText(newData.Value18.ToString() + Environment.NewLine);
            textBox3Data3.AppendText(newData.Value19.ToString() + Environment.NewLine);
            textBox3Data4.AppendText(newData.Value20.ToString() + Environment.NewLine);
            textBox3Data5.AppendText(newData.Value21.ToString() + Environment.NewLine);
            textBox3Data6.AppendText(newData.Value22.ToString() + Environment.NewLine);
            textBox3Data7.AppendText(newData.Value23.ToString() + Environment.NewLine);
            textBox3Data8.AppendText(newData.Value24.ToString() + Environment.NewLine);

            textBox4Data1.AppendText(newData.Value25.ToString() + Environment.NewLine); //               ***** 4. Test *****
            textBox4Data2.AppendText(newData.Value26.ToString() + Environment.NewLine);
            textBox4Data3.AppendText(newData.Value27.ToString() + Environment.NewLine);
            textBox4Data4.AppendText(newData.Value28.ToString() + Environment.NewLine);
            textBox4Data5.AppendText(newData.Value29.ToString() + Environment.NewLine);
            textBox4Data6.AppendText(newData.Value30.ToString() + Environment.NewLine);
            textBox4Data7.AppendText(newData.Value31.ToString() + Environment.NewLine);
            textBox4Data8.AppendText(newData.Value32.ToString() + Environment.NewLine);

            textBox5Data1.AppendText(newData.Value33.ToString() + Environment.NewLine); //               ***** 5. Test *****
            textBox5Data2.AppendText(newData.Value34.ToString() + Environment.NewLine);
            textBox5Data3.AppendText(newData.Value35.ToString() + Environment.NewLine);
            textBox5Data4.AppendText(newData.Value36.ToString() + Environment.NewLine);
            textBox5Data5.AppendText(newData.Value37.ToString() + Environment.NewLine);
            textBox5Data6.AppendText(newData.Value38.ToString() + Environment.NewLine);
            textBox5Data7.AppendText(newData.Value39.ToString() + Environment.NewLine);
            textBox5Data8.AppendText(newData.Value40.ToString() + Environment.NewLine);

            textBox6Data1.AppendText(newData.Value41.ToString() + Environment.NewLine);//                 ***** 6. Test *****
            textBox6Data2.AppendText(newData.Value42.ToString() + Environment.NewLine);
            textBox6Data3.AppendText(newData.Value43.ToString() + Environment.NewLine);
            textBox6Data4.AppendText(newData.Value44.ToString() + Environment.NewLine);
            textBox6Data5.AppendText(newData.Value45.ToString() + Environment.NewLine);
            textBox6Data6.AppendText(newData.Value46.ToString() + Environment.NewLine);
            textBox6Data7.AppendText(newData.Value47.ToString() + Environment.NewLine);
            textBox6Data8.AppendText(newData.Value48.ToString() + Environment.NewLine);
        }

        private void AddDataToGraph(ZedGraphControl zedGraphControl, double x, double[] yValues)
        {
            GraphPane graphPane1 = zedGraphControl.GraphPane;
            // Her bir eğriyi (curve) güncelle
            for (int i = 0; i < yValues.Length; i++)
            {
                if (graphPane1.CurveList.Count <= i) return; // Eğer eğri yoksa çık
                LineItem curve = graphPane1.CurveList[i] as LineItem;
                if (curve == null) continue; // Eğri yoksa bir sonrakine geç
                IPointListEdit list = curve.Points as IPointListEdit;
                if (list == null) continue; // Listesi yoksa bir sonrakine geç
                list.Add(x, yValues[i]); // Noktayı ekle
            }
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }
        private void AddDataToAllGraphs(double x, double[] yValues)
        {
            AddDataToGraph(zedGraphControl1, x, yValues);
            AddDataToGraph(zedGraphControl2, x, yValues);
            AddDataToGraph(zedGraphControl3, x, yValues);
            AddDataToGraph(zedGraphControl4, x, yValues);
            AddDataToGraph(zedGraphControl5, x, yValues);
            AddDataToGraph(zedGraphControl6, x, yValues);
        }

        private TestData ParseData(string receivedData)
        {
            TestData newData = new TestData();
            // Örnek olarak, gelen verinin virgülle ayrılmış parçaları olduğunu varsayalım
            string[] dataParts = receivedData.Split(',');

            if (dataParts.Length >= 48)
            {
                try
                {
                    // Her bir veri parçasını uygun şekilde TestData nesnesine ekle
                    newData.Value1 = Convert.ToDouble(dataParts[0]);
                    newData.Value2 = Convert.ToDouble(dataParts[1]);
                    newData.Value3 = Convert.ToDouble(dataParts[2]);
                    newData.Value4 = Convert.ToDouble(dataParts[3]);
                    newData.Value5 = Convert.ToDouble(dataParts[4]);
                    newData.Value6 = Convert.ToDouble(dataParts[5]);
                    newData.Value7 = Convert.ToDouble(dataParts[6]);
                    newData.Value8 = Convert.ToDouble(dataParts[7]);
                    newData.Value9 = Convert.ToDouble(dataParts[8]);
                    newData.Value10 = Convert.ToDouble(dataParts[9]);
                    newData.Value11 = Convert.ToDouble(dataParts[10]);
                    newData.Value12 = Convert.ToDouble(dataParts[11]);
                    newData.Value13 = Convert.ToDouble(dataParts[12]);
                    newData.Value14 = Convert.ToDouble(dataParts[13]);
                    newData.Value15 = Convert.ToDouble(dataParts[14]);
                    newData.Value16 = Convert.ToDouble(dataParts[15]);
                    newData.Value17 = Convert.ToDouble(dataParts[16]);
                    newData.Value18 = Convert.ToDouble(dataParts[17]);
                    newData.Value19 = Convert.ToDouble(dataParts[18]);
                    newData.Value20 = Convert.ToDouble(dataParts[19]);
                    newData.Value21 = Convert.ToDouble(dataParts[20]);
                    newData.Value22 = Convert.ToDouble(dataParts[21]);
                    newData.Value23 = Convert.ToDouble(dataParts[22]);
                    newData.Value24 = Convert.ToDouble(dataParts[23]);
                    newData.Value25 = Convert.ToDouble(dataParts[24]);
                    newData.Value26 = Convert.ToDouble(dataParts[25]);
                    newData.Value27 = Convert.ToDouble(dataParts[26]);
                    newData.Value28 = Convert.ToDouble(dataParts[27]);
                    newData.Value29 = Convert.ToDouble(dataParts[28]);
                    newData.Value30 = Convert.ToDouble(dataParts[29]);
                    newData.Value31 = Convert.ToDouble(dataParts[30]);
                    newData.Value32 = Convert.ToDouble(dataParts[31]);
                    newData.Value33 = Convert.ToDouble(dataParts[32]);
                    newData.Value34 = Convert.ToDouble(dataParts[33]);
                    newData.Value35 = Convert.ToDouble(dataParts[34]);
                    newData.Value36 = Convert.ToDouble(dataParts[35]);
                    newData.Value37 = Convert.ToDouble(dataParts[36]);
                    newData.Value38 = Convert.ToDouble(dataParts[37]);
                    newData.Value39 = Convert.ToDouble(dataParts[38]);
                    newData.Value40 = Convert.ToDouble(dataParts[39]);
                    newData.Value41 = Convert.ToDouble(dataParts[40]);
                    newData.Value42 = Convert.ToDouble(dataParts[41]);
                    newData.Value43 = Convert.ToDouble(dataParts[42]);
                    newData.Value44 = Convert.ToDouble(dataParts[43]);
                    newData.Value45 = Convert.ToDouble(dataParts[44]);
                    newData.Value46 = Convert.ToDouble(dataParts[45]);
                    newData.Value47 = Convert.ToDouble(dataParts[46]);
                    newData.Value48 = Convert.ToDouble(dataParts[47]);
                }
                catch (Exception ex)
                {
                    // Veri dönüştürme hatası olursa burada işleyin
                    MessageBox.Show("Veri ayrıştırma hatası: " + ex.Message);
                }
            }
            return newData;
        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2Data1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
