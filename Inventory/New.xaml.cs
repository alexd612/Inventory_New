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
using System.Reflection;
using static System.Reflection.BindingFlags;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Inventory
{
    /// <summary>
    /// Interaction logic for New.xaml
    /// </summary>
    /// 




    public class NewIventoryItem
    {
        public string Serial_Number { get; set; }
        public string Equipment_Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Deployed_To { get; set; }
        public string Machine_Name { get; set; }
        public string Conway_Tag { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
  
    }


    public partial class New : Window
    {



        public NewIventoryItem Myitem { get; set; }


        public string create_user_;
        public DateTime create_date_;


        private Mainwindow m_form = null;



        public New(Mainwindow f)
        {
            InitializeComponent();

            Username_Date user = new Username_Date();
            create_user_ = user.Username;
            create_date_ = Convert.ToDateTime(user.Create_Date);
            m_form = f;

            Myitem = new NewIventoryItem();

            DataContext = Myitem;

            //populate cbxdeployed

            try
            {

                cbx_deployed_to.Items.Clear();
                var context = new EquipmentEntities();

                var query = (from a in context.Equipments select a.Deployed_To).Distinct().OrderBy(x => x);
                cbx_deployed_to.ItemsSource = query.ToList();

            }
            catch (System.InvalidOperationException)
            {
                return;


            }
            //populate cbx status
        
            //populate cbx_eq_type
            try
            {

                cbx_equip_type.Items.Clear();
                var context = new EquipmentEntities();

                var query = (from a in context.Equipments select a.Eq_Type).Distinct().OrderBy(x => x);
                cbx_equip_type.ItemsSource = query.ToList();

            }
            catch (System.InvalidOperationException)
            {
                return;


            }
        }


        //cbx, txt, btn envents************************************************************************************************



        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {

            if (Myitem.Serial_Number == null || Myitem.Make == null || Myitem.Model == null || Myitem.Equipment_Type == null)
            {
                MessageBox.Show("Serial Number, Make, and Model are mandatory. Cannot add new equipment", "Warning"); return;
            }


            var context = new EquipmentEntities();
            //send to equipment table
            var equipment = new Equipment
            {
                Serial_Number = Myitem.Serial_Number,
                Eq_Type = Myitem.Equipment_Type,
                Deployed_To = Myitem.Deployed_To,
                Make = Myitem.Make,
                Model = Myitem.Model,
                Machine_Name = Myitem.Machine_Name,
                Conway_Tag = Myitem.Conway_Tag,
                Status = Myitem.Status,
                Notes = Myitem.Notes,
                Field = "N",
                Create_User = create_user_,
                Create_Date = create_date_

            };

            context.Equipments.Add(equipment);
            context.SaveChanges();





            MessageBox.Show("New equipment added to inventory!", "Equipment Added");

            MessageBoxResult result = MessageBox.Show("Will this equipment be used at other locations?", "Field Equipment", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //clear all controls in grid

                    //open field forma nd get field data
                    Field field_form = new Field();
                    field_form.serial_number = Myitem.Serial_Number;
                    field_form.Show();


                    break;

                case MessageBoxResult.No:
                    MessageBoxResult result1 = MessageBox.Show("Would You like to add another?", "Add Equipment?", MessageBoxButton.YesNo);
                    switch (result1)
                    {

                        case MessageBoxResult.Yes:
                            //clear form

                            foreach (UIElement x in this.grid_modify.Children)
                            {
                                if (x is System.Windows.Controls.TextBox)
                                {
                                    ((System.Windows.Controls.TextBox)x).Text = "";

                                }
                            }
                            foreach (UIElement y in this.grid_modify.Children)
                            {
                                if (y is System.Windows.Controls.ComboBox)
                                {
                                    ((System.Windows.Controls.ComboBox)y).SelectedIndex = 0;

                                }

                            }
                            cbx_status.SelectedIndex = -1;
                            cbx_equip_type.SelectedIndex = -1;
                            break;




                        case MessageBoxResult.No:
                  
                            this.Close();
                            break;


                    }
                    break;
                case MessageBoxResult.Cancel:

                    break;
            }








        }

        private void Window_Closed(object sender, EventArgs e)
         {


            //   m_form.dg_inventory.Items.Add(Myitem);



            m_form.refresh_field();

        }






    }

}
