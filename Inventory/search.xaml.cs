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
using System.Windows.Shapes;

namespace Inventory
{




    /// <summary>
    /// Interaction logic for search.xaml
    /// </summary>
    public partial class search : Window
    {

        public string serial_number;

        public search()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_serial_number.Text.ToString() == "") { return; }
                InventoryItem search = new InventoryItem();
                var search_serialnum = txt_serial_number.Text;

                //search for serial number

                var context = new EquipmentEntities();
                var query = (from a in context.Equipments
                             where a.Serial_Number.Equals(search_serialnum)
                             select new InventoryItem
                             {
                                 Serial_Number = a.Serial_Number,
                                 Make = a.Make,
                                 Model = a.Model,
                                 Deployed_To = a.Deployed_To,
                                 Machine_Name = a.Machine_Name,
                                 Equipment_Type = a.Eq_Type,
                                 Conway_Tag = a.Conway_Tag,
                                 Status = a.Status,
                                 Notes = a.Notes,
                                 Field_Equipment = a.Field,
                                 Create_User = a.Create_User,
                                 Create_Date = a.Create_Date ?? DateTime.MinValue
                             }).ToList();

                if (query.Count == 0)
                {
                    MessageBox.Show("Could not find serial number, searching for similar serial numbers.", "Search Failed");

                    var first = search_serialnum.Substring(0, 3);
                    var last = search_serialnum.Substring(search_serialnum.Length - 3);

                    query = (from a in context.Equipments
                             where a.Serial_Number.Contains(first) || a.Serial_Number.Contains(last)
                             select new InventoryItem
                             {
                                 Serial_Number = a.Serial_Number,
                                 Make = a.Make,
                                 Model = a.Model,
                                 Deployed_To = a.Deployed_To,
                                 Machine_Name = a.Machine_Name,
                                 Equipment_Type = a.Eq_Type,
                                 Conway_Tag = a.Conway_Tag,
                                 Status = a.Status,
                                 Notes = a.Notes,
                                 Field_Equipment = a.Field,
                                 Create_User = a.Create_User,
                                 Create_Date = a.Create_Date ?? DateTime.MinValue
                             }).ToList();


                    lv_results.ItemsSource = query;

                }
                else
                {
                    MessageBox.Show("Serial Number found.", "Serial Number Found");

                    lv_results.ItemsSource = query;


                }
            }

            catch (System.ArgumentOutOfRangeException) { MessageBox.Show("There is no text in the serial number field.","Warning"); return; }

        }
        private void lv_results_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you wish to modify equipment?", "Modify Equipment", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //clear all controls in grid

                    var old_data = lv_results.SelectedItem as InventoryItem;
                    serial_number = old_data.Serial_Number;
                
                    Modify sw = new Modify(null, this);
                    sw.DataContext = lv_results.SelectedItem;
                    sw.Show();

                    break;


                case MessageBoxResult.No:
                    this.Close();
                    break;
                case MessageBoxResult.Cancel:

                    break;
            }
        }

  
        //qurries

        public void refresh_field()
        {
            var context = new EquipmentEntities();
            var query = (from a in context.Equipments
                         where a.Serial_Number.Equals(serial_number)
                         select new InventoryItem
                         {
                             Serial_Number = a.Serial_Number,
                             Make = a.Make,
                             Model = a.Model,
                             Deployed_To = a.Deployed_To,
                             Machine_Name = a.Machine_Name,
                             Equipment_Type = a.Eq_Type,
                             Conway_Tag = a.Conway_Tag,
                             Status = a.Status,
                             Notes = a.Notes,
                             Field_Equipment = a.Field,
                             Create_User = a.Create_User,
                             Create_Date = a.Create_Date ?? DateTime.MinValue
                         }).ToList();


            lv_results.ItemsSource = query;
        


        }


    }
}