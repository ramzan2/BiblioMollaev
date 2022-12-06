using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiblioMollaev.ClassFolder
{
    class CBClass
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=10.128.14.64\SQLEXPRESS;
                                     Initial Catalog=user149;
                                 User ID=user149;Password=wsruser149");
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        public void LoadFIO(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * From dbo.Author " +
                    "Order by IDAuthor ASC", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    comboBox.Items.Add(sqlDataReader[1].ToString() + " " +
                        sqlDataReader[2].ToString() + " " +
                        sqlDataReader[3].ToString());
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadCBCity(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select IDCity, " +
                    "NameCity " +
                    "From dbo.[City] Order by IDCity ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[City]");
                comboBox.ItemsSource = dataSet
                    .Tables["[City]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[City]"].Columns["NameCity"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[City]"].Columns["IDCity"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void LoadCBPublisher(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select IDPublisher, " +
                    "NamePublisher " +
                    "From dbo.[Publisher] Order by IDPublisher ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Publisher]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Publisher]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[Publisher]"].Columns["NamePublisher"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[Publisher]"].Columns["IDPublisher"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }
}
