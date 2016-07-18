using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using CD_LogicForConfigInfo;


namespace OneStep
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DataBaseInfo> dataInfo = new List<DataBaseInfo>();
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void LoadResource(object sender, RoutedEventArgs e)
        {
            CreateAllColumns();

            SolidColorBrush blue = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            SolidColorBrush yellow = new SolidColorBrush(Color.FromRgb(255, 255, 0));

            //Step1:连接数据库,预留
            bool connect = false;

            LogicForConfigInfo logic = new LogicForConfigInfo();
            if (connect)//Step2:从数据库读取商品和经销商列表,并写入本地,预留
            {

            }
            else//Step3:当连接不上数据库时触发从本地读取商品和经销商列表
            {
                if( !logic.LoadConfigInfo() )
                {
                    //待增加日志系统
                }
            }
            
            for (int i = 0; i < 50; ++i)
            {
                string com = string.Format("COM{0}", i+1);
                DataBaseInfo data = new DataBaseInfo();
                //this.dataInfo.Add(new DataBaseInfo()
                //{
                //    ComID = com,
                //    FillColor = yellow,
                //    StartBind = false,
                //    StopBind = true ,
                //    Dealer = new DataTable(),
                //    Product = logic.configLst.Values.ToList<string>()
                //});
                data.ComID = com;
                data.FillColor = yellow;
                data.StartBind = false;
                data.StopBind = true;

                DataTable table = new DataTable();
                table.Columns.Add("经销商列表", typeof(string));
                foreach(var dir in logic.configLst)
                {
                    table.Rows.Add(dir.Key);
                }
                data.Dealer = table;

                this.dataInfo.Add(data);
            }

            this.dataGrid.ItemsSource = null;
            this.dataGrid.ItemsSource = dataInfo;
        }


        private bool ConnectDataBase()
        {

            return true;
        }


        

        private void CreateAllColumns()
        {
            CreateColumnEllipse();
            CreateColumnComID();
            CreateColumnStatus();
            CreateColumnProduct();
            CreateColumnDealer();
        }

        private void CreateColumnEllipse()
        {
            DataGridTemplateColumn column = new DataGridTemplateColumn();
            DataTemplate temp = new DataTemplate();

            //生成Ellipse
            FrameworkElementFactory ellipse = new FrameworkElementFactory(typeof(Ellipse));
            ellipse.SetValue(Ellipse.WidthProperty, 10.0);
            ellipse.SetValue(Ellipse.HeightProperty, 10.0);
            Binding binding = new Binding("FillColor");
            ellipse.SetBinding(Ellipse.FillProperty, binding);

            temp.VisualTree = ellipse;
            column.CellTemplate = temp;

            this.dataGrid.Columns.Add(column);
        }


        private void CreateColumnComID()
        {
            DataGridTextColumn column = new DataGridTextColumn()
            {
                Header = "物理串口",
                Binding = new Binding("ComID")
            };

            this.dataGrid.Columns.Add(column);
        }


        private void CreateColumnStatus()
        {
            DataGridTemplateColumn column = new DataGridTemplateColumn()
            {
                Header = "监控状态",
            };
            DataTemplate temp = new DataTemplate();

            //生成StackPanel
            FrameworkElementFactory panel = new FrameworkElementFactory(typeof(StackPanel));
            panel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            //生成RadioButton
            FrameworkElementFactory radio = new FrameworkElementFactory(typeof(RadioButton));
            radio.SetValue(RadioButton.ContentProperty, "启动监控");
            Binding binding = new Binding("StartBind");
            radio.SetBinding(RadioButton.IsCheckedProperty, binding);
            panel.AppendChild(radio);

            //生成RadioButton
            radio = new FrameworkElementFactory(typeof(RadioButton));
            radio.SetValue(RadioButton.ContentProperty, "停止监控");
            binding = new Binding("StopBind");
            radio.SetBinding(RadioButton.IsCheckedProperty, binding);
            panel.AppendChild(radio);

            temp.VisualTree = panel;
            column.CellTemplate = temp;

            this.dataGrid.Columns.Add(column);
        }

        private void CreateColumnProduct()
        {
            DataGridComboBoxColumn column = new DataGridComboBoxColumn()
            {
                Header = "商品列表",
                SelectedItemBinding = new Binding("ProductID")
            };

            this.dataGrid.Columns.Add(column);
        }


        private void CreateColumnDealer()
        {
            DataGridComboBoxColumn column = new DataGridComboBoxColumn()
            {
                Header = "经销商列表",
                SelectedItemBinding = new Binding("DealerID")
            };

            this.dataGrid.Columns.Add(column);
        }

        
    }
}
