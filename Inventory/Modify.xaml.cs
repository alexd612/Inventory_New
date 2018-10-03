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

namespace Inventory
{
    /// <summary>
    /// Interaction logic for Modify.xaml
    /// </summary>
    /// 



    public class Inventory_History
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
        public string Create_User { get; set; }
        public DateTime Create_Date { get; set; }

        public Inventory_History() { }



    }

    public partial class Modify : Window
    {
        public string create_user;
        public DateTime create_date;
        public FieldInventory field_item { get; set; }
        Inventory_History item_history = new Inventory_History();

        private Mainwindow m_form = null;
        private search s_form = null;

        public Modify(Mainwindow f, search s)
        {

            try
            {
                InitializeComponent();

                if(f != null) { m_form = f; }
                if(s != null) { s_form = s; }
               
                Username_Date user = new Username_Date();
                create_user = user.Username;
                create_date = Convert.ToDateTime(user.Create_Date);




            }

            catch (System.NullReferenceException)
            {



                return;
            }



        }

     




        //txt, btn, cbx events**************************************************************************************************************
        private void cbx_status_DropDownOpened(object sender, EventArgs e)
        {
            //try
           // {
            //    var selected_status = cbx_status.SelectedItem.ToString();
            //    cbx_status.Items.Clear();
            //    var context = new EquipmentEntities();

            //    var query = (from a in context.Equipments select a.Status).Distinct().OrderBy(x => x);
            //    cbx_status.ItemsSource = query.ToList();

            //    cbx_status.SelectedItem = selected_status;
            //}
            //catch (System.InvalidOperationException) { return; }
            //catch (System.NullReferenceException) { return; }

        }

        private void cbx_Deployed_To_DropDownOpened(object sender, EventArgs e)
        {

            try
            {
                cbx_Deployed_To.Items.Clear();
                var context = new EquipmentEntities();
                var query = (from a in context.Equipments select a.Deployed_To).Distinct().OrderBy(x => x);
                cbx_Deployed_To.ItemsSource = query.ToList();


            }

            catch (System.InvalidOperationException)
            {
                return;


            }



        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            //check to see if radio button is selected



            //get equipment id
            var context = new EquipmentEntities();
            var query = (from a in context.Equipments
                         where a.Serial_Number == txt_serial_number.Text
                         select a.Equipment_ID).Single();
            var equip_id = query;
            int eid = Convert.ToInt32(equip_id);


            //push to equipment history

            var history = new Equipment_History
            {
                Equipment_ID = eid,
                Serial_Number = item_history.Serial_Number,
                EQ_Type = item_history.Equipment_Type,
                Deployed_To = item_history.Deployed_To,
                Status = item_history.Status,
                Make = item_history.Make,
                Model = item_history.Model,
                Machine_Name = item_history.Machine_Name,
                Conway_Tag = item_history.Conway_Tag,
                Notes = item_history.Notes,
                Create_User = item_history.Create_User,
                Create_Date = item_history.Create_Date
            };
            context.Equipment_History.Add(history);
            context.SaveChanges();

            //update equipment table with new information
            var query1 = (from a in context.Equipments
                          where a.Equipment_ID.Equals(equip_id)
                          select a).First();
            //   update fields


            if (this.DataContext.GetType().GetProperty("Deployed_To").GetValue(this.DataContext, null) == null) { query1.Deployed_To = null;}
            else {query1.Deployed_To = this.DataContext.GetType().GetProperty("Deployed_To").GetValue(this.DataContext, null).ToString();}

            query1.Status = this.DataContext.GetType().GetProperty("Status").GetValue(this.DataContext, null).ToString();

            if (this.DataContext.GetType().GetProperty("Machine_Name").GetValue(this.DataContext, null) == null) { query1.Machine_Name = null; }
            else { query1.Machine_Name = this.DataContext.GetType().GetProperty("Machine_Name").GetValue(this.DataContext, null).ToString(); }

            if (this.DataContext.GetType().GetProperty("Conway_Tag").GetValue(this.DataContext, null) == null) { query1.Conway_Tag = null; }
            else { query1.Conway_Tag = this.DataContext.GetType().GetProperty("Conway_Tag").GetValue(this.DataContext, null).ToString(); }


            if (this.DataContext.GetType().GetProperty("Notes").GetValue(this.DataContext, null) == null) { query1.Notes = null; }
            else { query1.Notes = this.DataContext.GetType().GetProperty("Notes").GetValue(this.DataContext, null).ToString(); }


            query1.Create_User = create_user;
            query1.Create_Date = create_date;
            context.SaveChanges();

            MessageBox.Show("Equipment has been modified!", "Completed");

            MessageBoxResult result = MessageBox.Show("Will this equipment be used at other locations?", "Field Equipment", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //clear all controls in grid

                    //open field forma nd get field data
                    Field field_form = new Field();
                    field_form.eid = eid;
                    field_form.serial_number = this.DataContext.GetType().GetProperty("Serial_Number").GetValue(this.DataContext, null).ToString();
                    field_form.Show();


                    break;

                case MessageBoxResult.No:
                    this.Close();
                    break;
                case MessageBoxResult.Cancel:

                    break;
            }







        }


        //window events
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //refresh   

            if (m_form != null) { m_form.refresh_field(); m_form.summary(); }
            if (s_form != null) { s_form.refresh_field();  }
        
         




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            txt_serial_number.IsEnabled = false;
            cbx_equip_type.IsEnabled = false;
            txt_serial_number.IsEnabled = false;
            txt_make.IsEnabled = false;
            txt_model.IsEnabled = false;

            if (this.DataContext.GetType().GetProperty("Status").GetValue(this.DataContext, null) == null)
            {
                cbx_status.SelectedIndex = 0;
            }

            else
            {
                cbx_status.Items.Insert(0, this.DataContext.GetType().GetProperty("Status").GetValue(this.DataContext, null).ToString());
                cbx_status.SelectedIndex = 0;
            }
            //get equipment information to store and send to history table in modify form

            item_history.Serial_Number = this.DataContext.GetType().GetProperty("Serial_Number").GetValue(this.DataContext, null).ToString();
            item_history.Equipment_Type = this.DataContext.GetType().GetProperty("Equipment_Type").GetValue(this.DataContext, null).ToString();
            item_history.Make = this.DataContext.GetType().GetProperty("Make").GetValue(this.DataContext, null).ToString();
            item_history.Model = this.DataContext.GetType().GetProperty("Model").GetValue(this.DataContext, null).ToString();


            if ((this.DataContext.GetType().GetProperty("Machine_Name").GetValue(this.DataContext, null) == null)){ item_history.Machine_Name = null; }
            else { item_history.Machine_Name = this.DataContext.GetType().GetProperty("Machine_Name").GetValue(this.DataContext, null).ToString(); }

            if (this.DataContext.GetType().GetProperty("Conway_Tag").GetValue(this.DataContext, null) == null){ item_history.Conway_Tag = null; }
            else { item_history.Conway_Tag = this.DataContext.GetType().GetProperty("Conway_Tag").GetValue(this.DataContext, null).ToString(); }


            if (this.DataContext.GetType().GetProperty("Deployed_To").GetValue(this.DataContext, null) == null) { item_history.Deployed_To = null; }
            else { item_history.Deployed_To = this.DataContext.GetType().GetProperty("Deployed_To").GetValue(this.DataContext, null).ToString(); }

            if (this.DataContext.GetType().GetProperty("Status").GetValue(this.DataContext, null) == null) { item_history.Status = null; }
            else { item_history.Status = this.DataContext.GetType().GetProperty("Status").GetValue(this.DataContext, null).ToString(); }

            if (this.DataContext.GetType().GetProperty("Notes").GetValue(this.DataContext, null) == null) { item_history.Notes = null; }
            else { item_history.Notes = this.DataContext.GetType().GetProperty("Notes").GetValue(this.DataContext, null).ToString(); }

            item_history.Create_User = this.DataContext.GetType().GetProperty("Create_User").GetValue(this.DataContext, null).ToString();
            item_history.Create_Date = Convert.ToDateTime(this.DataContext.GetType().GetProperty("Create_Date").GetValue(this.DataContext, null).ToString());



            }


     


        }




    }

