using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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

namespace LoanApproveScript1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoanBtn_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<RecommendView> LoanDetailsList = LoanRepository.GetRecommendList(14, true);
            List<string> AlreadyApproveData = GetLoanIDAlready();

            int Count = 0;
            foreach(RecommendView r in LoanDetailsList)
            {
                if(AlreadyApproveData.Contains(r.CustomerID)==false)
                {
                    LoanRepository.ApproveLoan(r);

                    //return;
                    Count++;
                    if (Count == 100)
                    {
                        Console.Beep(3000, 1000);
                        MessageBox.Show("Hello");
                        return;
                    }


                }
            }
            Console.Beep(3000, 1000);
            MessageBox.Show("Finished");

        }

       




        public static List<string> GetLoanIDAlready()
        {
            List<string> CustomerIds = new List<string>();
            using(SqlConnection sqlconn=new SqlConnection(LoanApproveScript1.Properties.Settings.Default.DBConnection))
            {
                sqlconn.Open();
                if(ConnectionState.Open==sqlconn.State)
                {
                    SqlCommand sqlcomm = new SqlCommand();
                    sqlcomm.Connection = sqlconn;
                    sqlcomm.CommandText = "select CustomerID from LoanDetails";
                    SqlDataReader reader = sqlcomm.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            string id = reader.GetString(0);
                            CustomerIds.Add(id);
                        }
                    }
                }
            }

            return CustomerIds;
        }
    }
}
